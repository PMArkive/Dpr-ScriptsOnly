using Audio;
using Dpr.Box;
using Dpr.EvScript;
using Dpr.SecretBase;
using Dpr.Title;
using Dpr.UI;
using GameData;
using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using XLSXContent;

public class FieldConnector : SceneConnector
{
    private AssetRequestOperation playerRequestOperation;
    private AssetRequestOperation bgRequestOperatioin;
    private StaticQueue<string> bgQueue = new StaticQueue<string>(2);

    public AreaID loadedAreaID { get; set; } = AreaID.UNKNOWN;

    private bool isFieldUnload;
    private Coroutine fieldUnloadCoroutine;
    private SecretBaseController secretBaseController;
    public static bool drawCollisions;
    private static Mesh _boxMesh;
    private static Material _boxMat;
    public static bool IsSetupOperationRunning;
    private int _unload_limit_count;
    private const int _UNLOAD_LIMIT = 20;

    public override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);

        if (!drawCollisions)
            return;

        if (_bgCacheObjects == null)
            return;

        var boxes = _bgCacheObjects.GetComponentsInChildren<BoxCollider>().Where(x => x.gameObject.layer == Layer.ObstacleLayer);
        if (boxes == null)
            return;

        if (Camera.main == null)
            return;

        if (_boxMesh == null)
        {
            _boxMat = new Material(Shader.Find("Unlit/Color"));
            _boxMat.color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
            _boxMesh = new Mesh();
            _boxMesh.vertices = new Vector3[8]
            {
                new Vector3(-1.0f, -1.0f, -1.0f), new Vector3(1.0f, -1.0f, -1.0f),
                new Vector3(1.0f, -1.0f, 1.0f),   new Vector3(-1.0f, -1.0f, 1.0f),
                new Vector3(-1.0f, 1.0f, -1.0f),  new Vector3(1.0f, 1.0f, -1.0f),
                new Vector3(1.0f, 1.0f, 1.0f),    new Vector3(-1.0f, 1.0f, 1.0f),
            };
            _boxMesh.SetIndices(new int[24] { 0, 1, 1, 2, 2, 3, 3, 0, 4, 5, 5, 6, 6, 7, 7, 4, 0, 4, 1, 5, 2, 6, 3, 7 }, MeshTopology.Lines, 0);
            _boxMesh.UploadMeshData(true);
        }

        foreach (var box in boxes)
        {
            var matrix = box.transform.localToWorldMatrix;
            var center = box.center;
            var size = box.size * 0.5f;

            var resultMatrix = new Matrix4x4
            {
                m00 = matrix.m00 * size.x,
                m10 = matrix.m10 * size.x,
                m20 = matrix.m20 * size.x,
                m30 = matrix.m30 * size.x,
                m01 = matrix.m01 * size.y,
                m11 = matrix.m11 * size.y,
                m21 = matrix.m21 * size.y,
                m31 = matrix.m31 * size.y,
                m02 = matrix.m02 * size.z,
                m12 = matrix.m12 * size.z,
                m22 = matrix.m22 * size.z,
                m32 = matrix.m32 * size.z,
                m03 = matrix.m03 + matrix.m02 * center.z + matrix.m01 * center.y + matrix.m00 * center.x,
                m13 = matrix.m13 + matrix.m12 * center.z + matrix.m11 * center.y + matrix.m10 * center.x,
                m23 = matrix.m23 + matrix.m22 * center.z + matrix.m21 * center.y + matrix.m20 * center.x,
                m33 = matrix.m33,
            };

            Graphics.DrawMesh(_boxMesh, resultMatrix, _boxMat, Layer.Nothing);
        }
    }

    public override IEnumerator PrepareOperation()
    {
        if (PlayerWork.IsZenmetuFlag)
            ZenmetuProc();

        if (PlayerWork.transitionLocation.HasValue)
            PlayerWork.transitionZoneID = (ZoneID)PlayerWork.transitionLocation.Value.zoneID;

        AudioManager.Instance.PostEvent(AK.EVENTS.STOP_BUSENV);
        FieldManager.Instance.UniqueBGMEvent(PlayerWork.transitionZoneID, PlayerWork.zoneID);

        if (PlayerWork.transitionZoneID != ZoneID.UNKNOWN)
        {
            UIContestPhoto.ReleasePhotoResources();

            var mapInfo = GameManager.mapInfo[(int)PlayerWork.transitionZoneID];

            if (EntityManager.activeFieldPlayer != null && EntityManager.activeFieldPlayer.FashionTableID != PlayerWork.playerFashion)
            {
                Destroy(EntityManager.activeFieldPlayer.gameObject);
                EntityManager.activeFieldPlayer = null;
            }

            if (EntityManager.activeFieldPlayer == null)
            {
                for (int i=0; i<DataManager.CharacterDressData.Data.Length; i++)
                {
                    var dressData = DataManager.CharacterDressData.Data[i];
                    if (dressData.Index == PlayerWork.playerFashion)
                        playerRequestOperation = AssetManager.AppendAssetBundleRequest("persons/field/" + dressData.FieldGraphic, true, null, null);
                }

                if (playerRequestOperation == null)
                    playerRequestOperation = AssetManager.AppendAssetBundleRequest("persons/field/fc0001_00", true, null, null);
            }

            if (!PlayerWork.FieldCacheFlag)
                bgRequestOperatioin = AssetManager.AppendAssetBundleRequest(mapInfo.AssetBundleName, true, null, null);
        }

        AssetManager.DispatchRequests(null);
        yield return null;
    }

    public override bool SwitchingOperation(SceneID target)
    {
        if (sceneID != target)
        {
            if (fieldUnloadCoroutine == null)
                fieldUnloadCoroutine = Sequencer.Start(UnloadField());

            if (isFieldUnload)
                fieldUnloadCoroutine = null;

            return isFieldUnload;
        }

        if (PlayerWork.Warp == PlayerWork.WarpType.None)
        {
            var mapInfo = GameManager.mapInfo[(int)PlayerWork.transitionZoneID];
            if (loadedAreaID == mapInfo.AreaID && !mapInfo.Reload)
            {
                if (PlayerWork.transitionLocation.HasValue)
                {
                    var transLocation = PlayerWork.transitionLocation.Value;
                    EntityManager.activeFieldPlayer.SetPositionDirect(new Vector3(-transLocation.posX, transLocation.posY, transLocation.posZ));
                    EntityManager.activeFieldPlayer.SetDir((DIR)transLocation.dir);
                    GameManager.fieldCamera.ForceUpdateCamera();
                }
                else
                {
                    if (PlayerWork.locatorIndex == -1)
                    {
                        EntityManager.activeFieldPlayer.gridPositionDirect = PlayerWork.grid;
                        EntityManager.activeFieldPlayer.Height = PlayerWork.height;
                        EntityManager.activeFieldPlayer.SetYawAngleDirect(PlayerWork.rotation);
                    }
                    else
                    {
                        EntityManager.activeFieldPlayer.locatorDirect = mapInfo.Locators[PlayerWork.locatorIndex];
                        PlayerWork.locatorIndex = -1;
                    }
                }

                PlayerWork.transitionZoneID = ZoneID.UNKNOWN;
                EvDataManager.Instanse?.CallFieldWarpExitLabel();
                return false;
            }
        }

        isFieldUnload = true;
        return true;
    }

    public override IEnumerator SetupOperation()
    {
        if (!FieldManager.SealPrevFalg)
        {
            while (FieldManager.Instance.IsMenuOpen)
                yield return null;
        }

        PlayerWork.isPlayerInputActive = false;
        var sw = new SimpleStopwatch("FieldConnector.SetupOperation()");

        if (!PlayerWork.FieldCacheFlag)
            yield return base.SetupOperation();

        var currentTime = sw.elapsedMilliseconds;
        var lastTime = currentTime;

        do
        {
            if (playerRequestOperation != null)
            {
                if (!playerRequestOperation.keepWaiting)
                {
                    for (int i=0; i<playerRequestOperation.assetBundleRequest.cache.loadedAssets.Length; i++)
                    {
                        var go = playerRequestOperation.assetBundleRequest.cache.loadedAssets[i] as GameObject;
                        if (go != null)
                        {
                            Instantiate(go, GameManager.fieldObjectHolder).GetComponent<BaseEntity>().Register();
                            AssetManager.UnloadAssetBundle(playerRequestOperation.assetBundleRequest.uri);
                            playerRequestOperation = null;
                            EntityManager.activeFieldPlayer.FashionTableID = PlayerWork.playerFashion;
                            EntityManager.activeFieldPlayer.SetAnimationEvents(DataManager.CharacterGraphics.Data[PlayerWork.playerSex ? 0 : 4].animTbl);
                            break;
                        }
                    }
                }
            }

            if (bgRequestOperatioin != null)
            {
                if (!bgRequestOperatioin.keepWaiting)
                {
                    currentTime = sw.elapsedMilliseconds;
                    lastTime = currentTime;

                    var newGo = Instantiate(bgRequestOperatioin.assetBundleRequest.cache.loadedAssets[0], _bgCacheObjects);

                    currentTime = sw.elapsedMilliseconds;
                    lastTime = currentTime;

                    var effects = (newGo as GameObject).GetComponentsInChildren<FieldEffect>(true);

                    for (int i=0; i<effects.Length; i++)
                        FieldEffect.AppendRequest(effects[i]);

                    yield return FieldEffect.DispathRequests();

                    currentTime = sw.elapsedMilliseconds;
                    lastTime = currentTime;

                    if (bgQueue.count == 2)
                        AssetManager.UnloadAssetBundle(bgQueue.Dequeue());

                    bgQueue.Enqueue(bgRequestOperatioin.assetBundleRequest.uri);
                    bgRequestOperatioin = null;
                    yield return null;
                }
            }

            yield return null;
        }
        while (playerRequestOperation != null || bgRequestOperatioin != null);

        if (PlayerWork.transitionZoneID < ZoneID.C01)
            PlayerWork.transitionZoneID = ZoneID.C01;

        var zoneData = GameManager.mapInfo[(int)PlayerWork.transitionZoneID];
        renderSettings = zoneData.RenderSettings;

        if (PlayerWork.Warp != PlayerWork.WarpType.None)
        {
            FieldObjWork.Clear();
            if (EntityManager.activeFieldPlayer.IsSwim())
                EntityManager.activeFieldPlayer.ChangeSwim(false);
        }

        yield return FieldManager.Instance.SceneInit();

        currentTime = sw.elapsedMilliseconds;
        lastTime = currentTime;

        var colorVariation = EntityManager.activeFieldPlayer.GetComponent<ColorVariation>();
        if (colorVariation != null)
            colorVariation.ColorIndex = PlayerWork.colorID;

        EntityManager.activeFieldPlayer.WorkApplyVisibility();

        if (PlayerWork.locatorIndex == -1)
        {
            if (!ZoneWork.IsUnionRoom(PlayerWork.zoneID) ||
                (PlayerWork.transitionZoneID != ZoneID.UNKNOWN && !ZoneWork.IsUnionRoom(PlayerWork.transitionZoneID)))
            {
                EntityManager.activeFieldPlayer.gridPositionDirect = PlayerWork.grid;
                EntityManager.activeFieldPlayer.Height = PlayerWork.height;
                EntityManager.activeFieldPlayer.SetYawAngleDirect(PlayerWork.rotation);
            }
        }
        else
        {
            EntityManager.activeFieldPlayer.locatorDirect = zoneData.Locators[PlayerWork.locatorIndex];
            PlayerWork.locatorIndex = -1;
        }

        if (PlayerWork.transitionLocation.HasValue)
        {
            var location = PlayerWork.transitionLocation.Value;
            EntityManager.activeFieldPlayer.SetPositionDirect(new Vector3(-location.posX, location.posY, location.posZ));
            EntityManager.activeFieldPlayer.SetDir((DIR)location.dir);
        }

        if (PlayerWork.IsZenmetuFlag)
        {
            EntityManager.activeFieldPlayer.ChangeForm(0, null);
            PlayerWork.playerParty.RecoverAll();
            BoxPokemonWork.RecoverAll();
        }

        while (!FieldManager.Instance.IsSceneLoadEnd())
            yield return null;

        while (!EvDataManager.Instanse.RefCountZeroUnload())
            yield return null;

        currentTime = sw.elapsedMilliseconds;
        lastTime = currentTime;

        while (GameManager.CPU_BOOST_OFF())
            yield return null;

        yield return FieldManager.Instance.SceneInitAfter();

        currentTime = sw.elapsedMilliseconds;
        lastTime = currentTime;

        EntityManager.BuildFieldEntities();
        GameManager.fieldObjectHolder.gameObject.SetActive(true);
        AdjustPlayerPositionUnderGround(zoneData);
        PlayerGroundPlacement(zoneData);

        bool unload = false;
        if (PlayerWork.zoneID != ZoneID.UNKNOWN)
        {
            var mapType = GameManager.mapInfo[(int)PlayerWork.zoneID].MapType;
            unload = mapType < MapType.MAPTYPE_ROOM || mapType == MapType.MAPTYPE_UNDERGROUND;
        }
        
        if (ZoneWork.IsSecretBase(PlayerWork.transitionZoneID))
        {
            switch (PlayerWork.transitionZoneID)
            {
                case ZoneID.UGAASECRETBASE01:
                case ZoneID.UGABSECRETBASE01:
                case ZoneID.UGBASECRETBASE01:
                case ZoneID.UGCASECRETBASE01:
                case ZoneID.UGDASECRETBASE01:
                case ZoneID.UGEASECRETBASE01:
                case ZoneID.UGFASECRETBASE01:
                default:
                    SecretBaseSaveDataWork.RoomGrade = 0;
                    break;

                case ZoneID.UGAASECRETBASE02:
                case ZoneID.UGABSECRETBASE02:
                case ZoneID.UGBASECRETBASE02:
                case ZoneID.UGCASECRETBASE02:
                case ZoneID.UGDASECRETBASE02:
                case ZoneID.UGEASECRETBASE02:
                case ZoneID.UGFASECRETBASE02:
                    SecretBaseSaveDataWork.RoomGrade = 1;
                    break;

                case ZoneID.UGAASECRETBASE03:
                case ZoneID.UGABSECRETBASE03:
                case ZoneID.UGBASECRETBASE03:
                case ZoneID.UGCASECRETBASE03:
                case ZoneID.UGDASECRETBASE03:
                case ZoneID.UGEASECRETBASE03:
                case ZoneID.UGFASECRETBASE03:
                    SecretBaseSaveDataWork.RoomGrade = 2;
                    break;
            }

            lastTime = sw.elapsedMilliseconds;

            AssetManager.AppendAssetBundleRequest("sb/sbcontroller", true, null, null);

            yield return AssetManager.DispatchRequests((eventType, name, asset) =>
            {
                if (eventType == RequestEventType.Cached)
                {
                    AssetManager.UnloadAssetBundle(name);
                    return;
                }

                if (eventType != RequestEventType.Activated)
                    return;

                var go = asset as GameObject;
                if (go == null)
                    return;

                currentTime = sw.elapsedMilliseconds;
                lastTime = sw.elapsedMilliseconds;

                var newGo = Instantiate(asset) as GameObject;

                currentTime = sw.elapsedMilliseconds;

                secretBaseController = newGo.GetComponent<SecretBaseController>();
            });

            yield return secretBaseController.ActivateOperation(this);

            Sequencer.update += secretBaseController.OnUpdate;
        }
        else
        {
            ReleaseSecretBase();
        }

        FlagWork.SetFlag(EvWork.FLAG_INDEX.FLAG_STOP_ZONE_PROGRAM, false);
        ZoneID from = PlayerWork.zoneID;
        ZoneID to = PlayerWork.transitionZoneID;
        PlayerWork.zoneID = PlayerWork.transitionZoneID;
        loadedAreaID = zoneData.AreaID;

        if (GameManager.fieldCamera != null)
        {
            if (PlayerWork.zoneID != ZoneID.UNKNOWN)
                GameManager.fieldCamera.SetPanCameraFlag(zoneData.RoomPanCamera);

            float clipPlane;
            switch (PlayerWork.zoneID)
            {
                case ZoneID.D05R0114:
                case ZoneID.D05R0115:
                case ZoneID.D05R0116:
                case ZoneID.D10R0801:
                case ZoneID.D05R0117:
                case ZoneID.D10R0901:
                case ZoneID.D10R0902:
                    clipPlane = 300.0f;
                    break;

                default:
                    clipPlane = 75.0f;
                    break;
            }

            if (GameManager.fieldCamera.GetCamera() != null)
                GameManager.fieldCamera.GetCamera().farClipPlane = clipPlane;
        }

        FieldManager.Instance.ZoneChangeSetZenmetu(PlayerWork.zoneID);

        if (from != ZoneID.UNKNOWN && to != ZoneID.UNKNOWN && !PlayerWork.IsZenmetuFlag)
        {
            if (GameManager.mapInfo[(int)from].MapType != GameManager.mapInfo[(int)to].MapType)
                FieldManager.Instance.SetAutoSaveState(FieldManager.AutoSaveState.Zone_Change);
        }

        if (PlayerWork.evolveRequets == null || PlayerWork.evolveRequets.Count == 0)
            yield return FieldManager.Instance.ZoneChangeAutoSave();

        FieldManager.Instance.SceneStart();

        while (!FieldManager.Instance.IsSceneLoadEnd())
            yield return null;

        if (!PlayerWork.IsNeedUnloadOnFieldConnector)
        {
            if (unload)
            {
                lastTime = sw.elapsedMilliseconds;
                GC.Collect();
                yield return UnityEngine.Resources.UnloadUnusedAssets();

                currentTime = sw.elapsedMilliseconds;
                _unload_limit_count = 0;
            }
            else
            {
                _unload_limit_count++;

                if (_unload_limit_count > _UNLOAD_LIMIT)
                {
                    lastTime = sw.elapsedMilliseconds;
                    GC.Collect();
                    yield return UnityEngine.Resources.UnloadUnusedAssets();

                    currentTime = sw.elapsedMilliseconds;
                    _unload_limit_count = 0;
                }
                else
                {
                    lastTime = sw.elapsedMilliseconds;
                    GC.Collect();
                    currentTime = sw.elapsedMilliseconds;
                }
            }
        }
        else
        {
            PlayerWork.IsNeedUnloadOnFieldConnector = false;
            GC.Collect();
            yield return UnityEngine.Resources.UnloadUnusedAssets();

            currentTime = sw.elapsedMilliseconds;
            _unload_limit_count = 0;
        }

        if (reflectionCamera == null || !zoneData.ReflectionCamera)
            reflectionCamera.gameObject.SetActive(false);
        else
            reflectionCamera.gameObject.SetActive(true);

        PlayerWork.SetWarp(PlayerWork.WarpType.None);
        IsSetupOperationRunning = false;
        PlayerWork.IsZenmetuFlag = false;
        AssetPreloader.UnloadPreloadAssetBundle();

        sw?.Dispose();
    }

    private void AdjustPlayerPositionUnderGround(MapInfo.SheetZoneData zoneData)
    {
        DIR CheckWallDir(ZoneID zoneId, Vector2Int centerGrid)
        {
            if (!CanEntryAttribute(zoneId, new Vector2Int(centerGrid.x - 1, centerGrid.y)))
                return DIR.DIR_LEFT;

            if (!CanEntryAttribute(zoneId, new Vector2Int(centerGrid.x + 1, centerGrid.y)))
                return DIR.DIR_RIGHT;

            if (!CanEntryAttribute(zoneId, new Vector2Int(centerGrid.x, centerGrid.y - 1)))
                return DIR.DIR_UP;

            if (!CanEntryAttribute(zoneId, new Vector2Int(centerGrid.x, centerGrid.y + 1)))
                return DIR.DIR_DOWN;

            return DIR.DIR_NOT;
        }

        bool CanEntryAttribute(ZoneID zoneId, Vector2Int grid)
        {
            GameManager.GetAttribute(zoneId, grid, out int code, out int stop);
            if (stop != 128)
            {
                var table = GameManager.GetAttributeTable(code);
                if (table != null)
                    return table.Entry;
            }

            return false;
        }

        if (EntityManager.activeFieldPlayer == null)
            return;

        if (zoneData.MapType != MapType.MAPTYPE_UNDERGROUND)
            return;

        if (ZoneWork.IsUnderGroundRoad(zoneData.ZoneID))
            return;

        var pos = EntityManager.activeFieldPlayer.gridPosition;

        switch (CheckWallDir(zoneData.ZoneID, pos))
        {
            case DIR.DIR_UP:
                pos.y++;
                break;

            case DIR.DIR_DOWN:
                pos.y--;
                break;

            case DIR.DIR_LEFT:
                pos.x++;
                break;

            case DIR.DIR_RIGHT:
                pos.x--;
                break;

            case DIR.DIR_NOT:
                return;
        }

        switch (CheckWallDir(zoneData.ZoneID, pos))
        {
            case DIR.DIR_UP:
                pos.y++;
                break;

            case DIR.DIR_DOWN:
                pos.y--;
                break;

            case DIR.DIR_LEFT:
                pos.x++;
                break;

            case DIR.DIR_RIGHT:
                pos.x--;
                break;

            case DIR.DIR_NOT:
                EntityManager.activeFieldPlayer.gridPositionDirect = pos;
                return;
        }

        switch (CheckWallDir(zoneData.ZoneID, pos))
        {
            case DIR.DIR_UP:
                pos.y++;
                break;

            case DIR.DIR_DOWN:
                pos.y--;
                break;

            case DIR.DIR_LEFT:
                pos.x++;
                break;

            case DIR.DIR_RIGHT:
                pos.x--;
                break;

            case DIR.DIR_NOT:
                EntityManager.activeFieldPlayer.gridPositionDirect = pos;
                return;
        }
    }

    private void PlayerGroundPlacement(MapInfo.SheetZoneData zoneData)
    {
        var pos = EntityManager.activeFieldPlayer.transform.position;
        RaycastHit hit;
        float newY = 0.0f;

        if (zoneData.MapType != MapType.MAPTYPE_UNDERGROUND)
        {
            if (Physics.Raycast(pos + new Vector3(0.0f, 1.5f, 0.0f), new Vector3(0.0f, -1.0f, 0.0f), out hit, 4.0f))
            {
                newY = hit.point.y;
            }
            else
            {
                for (int i=0; i<50; i+=2)
                {
                    var origin = new Vector3(pos.x, i, pos.z) + new Vector3(0.0f, 2.0f, 0.0f);
                    if (Physics.Raycast(origin, new Vector3(0.0f, -1.0f, 0.0f), out hit, 4.0f))
                    {
                        newY = hit.point.y;
                        break;
                    }
                }
            }
        }

        if (EntityManager.activeFieldPlayer.IsSwim())
        {
            EntityManager.activeFieldPlayer.isLanding = false;
            if (zoneData.MapType != MapType.MAPTYPE_UNDERGROUND)
                newY += 0.5f;
        }

        EntityManager.activeFieldPlayer.SetPositionDirect(new Vector3(pos.x, newY, pos.z));
        GameManager.fieldCamera.Target = EntityManager.activeFieldPlayer.transform;
        GameManager.fieldCamera.ForceUpdateCamera();
    }

    private IEnumerator UnloadField()
    {
        if (FieldManager.Instance != null)
        {
            isFieldUnload = false;
            yield return FieldManager.Instance.OnSceneChange();
            ReleaseSecretBase();
        }

        isFieldUnload = true;
    }

    private void ReleaseSecretBase()
    {
        if (secretBaseController == null)
            return;

        Sequencer.update -= secretBaseController.OnUpdate;
        mainCamera.gameObject.SetActive(true);
        Destroy(secretBaseController.gameObject);
        secretBaseController = null;
    }

    private void ZenmetuProc()
    {
        PlayerWork.FieldCacheFlag = false;
        FlagWork.SetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_PAIR, false);
        FieldManager.fwMng.PartnerNPC_ObjectName = "";
        FieldManager.fwMng.NPCToPartner();

        var zenmetu = DataManager.ZenmetuZone.data.FirstOrDefault(__ => __.zoneID == PlayerWork.transitionZoneID);
        if (zenmetu == null)
            return;

        var mapInfo = GameManager.mapInfo[(int)zenmetu.townMapZoneID];
        var locator = mapInfo.Locators[zenmetu.locators];

        var player = PlayerWork.PlayerSaveData;
        player.TownMapLocation.zoneID = (int)zenmetu.townMapZoneID;
        player.TownMapLocation.posX = locator.x >= 0.0f ? (int)-locator.x : locator.x;
        player.TownMapLocation.posY = locator.w;
        player.TownMapLocation.posZ = locator.x >= 0.0f ? (int)locator.y : locator.y;
        player.TownMapLocation.dir = 0;
        PlayerWork.PlayerSaveData = player;
    }
}