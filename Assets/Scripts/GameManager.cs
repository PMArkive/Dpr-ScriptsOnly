using System;
using Dpr.Message;
using Pml;
using ScriptableObjectFormat;
using SmartPoint.AssetAssistant;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using XLSXContent;
using System.Linq;
using Dpr;
using Dpr.EvScript;
using Dpr.UI;
using System.Collections;
using GameData;
using Effect;
using SmartPoint.Components;
using Audio;
using poketool.poke_memo;
using SmartPoint.AssetAssistant.UnityExtensions;
using Dpr.Battle.Logic;
using Dpr.NX;

[ExecuteAlways]
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public const long ticksPerDay = 864000000000;
    public const long ticksPerSecond = 10000000;

    [SerializeField]
    private Transform _fieldObjectHolder;
    [SerializeField]
    private Transform _battleObjectHolder;
    [SerializeField]
    private GameObject _licenseTextObject;
    [SerializeField]
    private GameObject _errorTextObject;
    [SerializeField]
    private TextMeshProUGUI _officeTextUGUI;
    [SerializeField]
    private TextMeshProUGUI _userTextUGUI;
    [SerializeField]
    private string _securityFileName;
    [SerializeField]
    private string _primarySecurityKey;
    [SerializeField]
    private string _secondarySecurityKey;
    [SerializeField]
    private PokemonData _debugPokemonData;
    private GameSettings gameSettings;
    public static SceneConnector connector = null;

    public static Transform fieldObjectHolder { get => Instance._fieldObjectHolder; }
    public static Transform battleObjectHolder { get => Instance._battleObjectHolder; }
    public static bool isReady { get; set; }
    public static MapInfo mapInfo { get => Instance.gameSettings.mapInfo; }
    public static ArenaInfo arenaInfo { get => Instance.gameSettings.arenaInfo; }
    public static CalenderEncTable calenderEncTable { get => Instance.gameSettings.calenderEncTable; }
    public static FieldEncountTable fieldEncountTable { get => PlayerWork.cassetVersion == CassetVersion.DPR_B ? Instance.gameSettings.fieldEncountTable_d : Instance.gameSettings.fieldEncountTable_p; }
    public static WaterSettings waterSettings { get => Instance.gameSettings.waterSettings; }
    public static bool afterStarting { get; set; } = false;
    public static bool playEnding { get; set; } = false;

    private static DateTime _nowTime;

    public static DateTime nowTime { get => _nowTime; set => _nowTime = value; }
    public static long tickOffset { get; set; } = 0;
    public static long timeScale { get; set; } = 1;
    public static bool pause { get; set; } = false;

    public static float elapsedTimeOfDay
    {
        get
        {
            long ticks = nowTime.Ticks;
            long scaledTicks = (tickOffset + timeScale * (ticks % ticksPerDay)) % ticksPerDay;
            return ((float)scaledTicks / ticksPerDay) * 24.0f;
        }
    }
    public static PeriodOfDay currentPeriodOfDay
    {
        get
        {
            float elapsedTime = elapsedTimeOfDay;

            if (elapsedTime < 2.0f)
                return PeriodOfDay.Night;
            else if (elapsedTime < 4.0f)
                return PeriodOfDay.Midnight;
            else if (elapsedTime < 10.0f)
                return PeriodOfDay.Morning;
            else if (elapsedTime < 17.0f)
                return PeriodOfDay.Daytime;
            else if (elapsedTime < 20.0f)
                return PeriodOfDay.Evening;
            else
                return PeriodOfDay.Night;
        }
    }
    public static ValueTuple<PeriodOfDay, float, float> currentPeriodOfDayEx
    {
        get
        {
            // TODO: Simplify this a bit
            float elapsedTime = elapsedTimeOfDay;
            float fVar2, fVar3;
            PeriodOfDay period;

            if (elapsedTime < 2.0f)
            {
                fVar3 = 4.0f;
                fVar2 = (elapsedTime + fVar3) / 6.0f;
                fVar3 = Mathf.Max((fVar2 * 360.0f - 350.0f) * 0.1f, 0.0f);
                period = PeriodOfDay.Night;
            }
            else if (elapsedTime < 4.0f)
            {
                fVar2 = (elapsedTime - 2.0f) * 0.5f;
                fVar3 = Mathf.Max((fVar2 * 120.0f - 110.0f) * 0.1f, 0.0f);
                period = PeriodOfDay.Midnight;
            }
            else if (elapsedTime < 10.0f)
            {
                fVar2 = (elapsedTime - 4.0f) / 6.0f;
                fVar3 = Mathf.Max((fVar2 * 360.0f - 350.0f) * 0.1f, 0.0f);
                period = PeriodOfDay.Morning;
            }
            else if (elapsedTime < 17.0f)
            {
                fVar2 = (elapsedTime - 10.0f) / 7.0f;
                fVar3 = Mathf.Max((fVar2 * 420.0f - 410.0f) * 0.1f, 0.0f);
                period = PeriodOfDay.Daytime;
            }
            else if (elapsedTime < 20.0f)
            {
                fVar2 = (elapsedTime - 17.0f) / 3.0f;
                fVar3 = Mathf.Max((fVar2 * 180.0f - 170.0f) * 0.1f, 0.0f);
                period = PeriodOfDay.Evening;
            }
            else
            {
                fVar3 = -20.0f;
                fVar2 = (elapsedTime + fVar3) / 6.0f;
                fVar3 = Mathf.Max((fVar2 * 360.0f - 350.0f) * 0.1f, 0.0f);
                period = PeriodOfDay.Night;
            }

            return (period, fVar2, fVar3);
        }
    }
    public static PokemonData debugPokemonData { get => Instance._debugPokemonData; }

    private AreaID _cacheAreaID = AreaID.UNKNOWN;
    private SceneID _targetSceneID = SceneID.Unknown;
    private Coroutine _loadingOperation;
    private bool _switchingNow;

    public static FieldCamera fieldCamera;
    public static bool isControllable = true;
    public static bool useSubAttribute = false;

    public static FieldEncountTable.Sheettable GetFieldEncountData(ZoneID zoneid)
    {
        if (Instance.gameSettings != null)
        {
            return fieldEncountTable.table.FirstOrDefault(__ => __.zoneID == zoneid);
        }

        return null;
    }

    public static FieldEncountTable.Sheethoneytree[] GetHoneyTreeEncountLotteryTable()
    {
        if (Instance.gameSettings != null)
        {
            return fieldEncountTable.honeytree;
        }

        return null;
    }

    public static FieldEncountTable.Sheetmistu[] GetHoneyTreeEncountTable()
    {
        if (Instance.gameSettings != null)
        {
            return fieldEncountTable.mistu;
        }

        return null;
    }

    public static MonsNo GetSafariMonsNo(int index)
    {
        if (Instance.gameSettings != null)
        {
            return fieldEncountTable.safari[index].MonsNo;
        }

        return MonsNo.NULL;
    }

    public static MonsNo GetUrayamaMonsNo(int index)
    {
        if (Instance.gameSettings != null)
        {
            return fieldEncountTable.urayama[index].monsNo;
        }

        return MonsNo.NULL;
    }

    [AssetAssistantInitializeMethod]
    private static void Initialize()
    {
        // TODO: Switch/nn stuff
        UserAccount.Open();
        SaveDataLinkage.CheckSaveData();
        PlayerWork.Load(false, false);

        // Update the Town Map guide from the 1.0.0 "Try adventuring all over the Sinnoh region!" to the guide that points you to the Snowpoint boat.
        if (PlayerWork.GetInt(EvWork.WORK_INDEX.TOWNMAP_GUIDE_SEQUENCE) == 12650)
            PlayerWork.SetInt(EvWork.WORK_INDEX.TOWNMAP_GUIDE_SEQUENCE, 12700);

        SceneBrowser.delayCall += () => Sequencer.Start(OnetimeInitializeOperation());

        Camera.onPreCull -= OnCameraPreCull;
        Camera.onPreCull += OnCameraPreCull;
    }

    private static void OnCameraPreCull(Camera camera)
    {
        bool IsNan(Quaternion q)
        {
            return !float.IsNaN(q.x) && !float.IsNaN(q.y) && !float.IsNaN(q.z) && !float.IsNaN(q.w);
        }

        var rotation = camera?.transform?.rotation;
        if (rotation.HasValue)
        {
            if (IsNan(rotation.Value))
            {
                // Empty
            }
        }
    }
    
    private static IEnumerator OnetimeInitializeOperation()
    {
        UIManager.Instance.NowLoadingOpen(waitTime: 0.0f, isBackground: true);
#if SWITCH
        UnityEngine.Switch.Performance.SetConfiguration(Performance.PerformanceMode.Normal, Performance.PerformanceConfiguration.Cpu1020MhzGpu384MhzEmc1331Mhz);
#endif

        AssetManager.AppendAssetBundleRequest("scriptableobjects/gamesettings", true, null, null);
        yield return AssetManager.DispatchRequests((eventType, name, asset) => { 
            switch (eventType)
            {
                case RequestEventType.Activated:
                    if (asset != null)
                        Instance.gameSettings = asset as GameSettings;
                    break;
                case RequestEventType.Cached:
                    AssetManager.UnloadAssetBundle(name);
                    break;
            }
        });

        nowTime = DateTime.Now;
        PlayerWork.SetTransitionZone(PlayerWork.zoneID, PlayerWork.locatorIndex);
        yield return DataManager.StartUpLoad();

        while (!DataManager.IsLoaded())
            yield return null;

        if (PlayerWork.msgLangID < MessageEnumData.MsgLangId.JPN || PlayerWork.msgLangID > MessageEnumData.MsgLangId.TCH)
            PlayerWork.msgLangID = UIManager.GetMessageLangIdFromIetfCode(UIManager.GetCurrentIetfCode());

        // Result of this line is ignored.
        PlayerWork.GetLoadResult();
        bool isOpening = PlayerWork.uniqueID == 0;
        UIManager.Instance.RegisterOnDestroy();
        UIManager.Instance.LoadDatabase();
        EffectManager.Instance.LoadDatabase();

        while (!UIManager.Instance.isLoadedDatabase || !EffectManager.Instance.isLoadedDatabase)
            yield return null;

        EffectManager.Instance.LoadResidents();
        UIManager.Instance.LoadResidents();

        MessageManager.Instance.Initialize(PlayerWork.msgLangID);
        MessageManager.Instance.SetJPNKanjiFlag(PlayerWork.isKanji);

        while (!MessageManager.Instance.IsInitialize)
            yield return null;

        SwitchNativeUtils.SetExpectedVolumeBalance(0.5f, 1.0f);
        SoftwareKeyboard.Initialize();
        SixAxisSensorManager.Initialize();

        UIManager.Instance.LoadWindows(isOpening);

        if (!isOpening)
            yield return UIManager.Instance.OpInitializeAfterLangDecide(null);

        UgItemWork.Create();
        isReady = true;
        Sequencer.update += Instance.OnUpdate;
        DebugMenu.tryOpenDelegate += () => !Fader.isBusy;

        PlayerWork.isPlayerInputActive = true;
        Sequencer.SubscribeUpdate(-9999, CheckDebugPause);
        ConfigWork.InvokeChangedValues(ref PlayerWork.config);

        Instance._loadingOperation = Sequencer.Start(Instance.SceneSwitchingOperation());
        yield return null;
    }

    public static void ReloadLanguege(MessageEnumData.MsgLangId unloadLangId, UnityAction<bool> onLoaded)
    {
        MessageManager.Instance.SetJPNKanjiFlag(PlayerWork.isKanji);
        if (PlayerWork.msgLangID == unloadLangId)
        {
            onLoaded.Invoke(false);
        }

        MessageManager.Instance.ReloadAllMsbtFile(PlayerWork.msgLangID, () => onLoaded.Invoke(true));
    }

    public static void AfterInitialize(AfterInitType type, MessageEnumData.MsgLangId unloadLangId, UnityAction<AfterLoadState> onLoaded)
    {
        UIManager.Instance.Reload(unloadLangId, () =>
        {
            if (SoftwareKeyboard.isInitialized)
                SoftwareKeyboard.Terminate();

            SoftwareKeyboard.Initialize();
            onLoaded.Invoke(AfterLoadState.Ui);

            UIManager.Instance.InitializeAfterLangDecide(() => onLoaded.Invoke(AfterLoadState.Ui2));
        });
    }

    private static void CheckDebugPause(float deltaTime)
    {
        // Empty
    }

    private void OnUpdate(float deltaTime)
    {
        if (connector != null)
        {
            // Check save version
#if PEARL
            if (PlayerWork.cassetVersion != CassetVersion.DPR_S)
            {
                RestartUtility.RestartProgram();
                return;
            }
#else
            if (PlayerWork.cassetVersion != CassetVersion.DPR_B)
            {
                RestartUtility.RestartProgram();
                return;
            }
#endif
        }

        if (_switchingNow || SceneBrowser.isRequested)
            return;

        if (SceneBrowser.currentScene != null && connector != null)
        {
            _nowTime = DateTime.Now;

            if (PlayerWork.isBattling)
            {
                if (BattleProc.isEnd)
                {
                    PlayerWork.SetTransitionZone(PlayerWork.zoneID, -1);
                    PlayerWork.isBattling = false;
                    PlayerWork.isEncount = false;
                    ItemWork.ResetItemListMemory(UIBag.BootType.Battle);
                }
            }
            else
            {
                switch(connector.sceneID)
                {
                    case SceneID.Field:
                        if (PlayerWork.isEncount)
                        {
                            BattleProc.SetParam(PlayerWork.battleSetupParam);

                            if (!ZoneWork.IsUnionRoom(PlayerWork.zoneID))
                            {
                                if (EntityManager.activeFieldPlayer != null)
                                    PlayerWork.SetPlayerPosData(EntityManager.activeFieldPlayer);
                            }

                            PlayerWork.isBattling = true;
                        }
                        else if (PlayerWork.isSealPreview && connector.sceneID != SceneID.SealPreview)
                        {
                            if (!ZoneWork.IsUnionRoom(PlayerWork.zoneID))
                            {
                                if (EntityManager.activeFieldPlayer != null)
                                    PlayerWork.SetPlayerPosData(EntityManager.activeFieldPlayer);
                            }
                        }
                        break;

                    case SceneID.DigFossil:
                        Fader.valid = true;
                        Fader.FadeIn();
                        break;
                }
            }

            _switchingNow = true;
        }
        else
        {
            if (string.IsNullOrEmpty(StartupSettings.startupScenePath))
                _switchingNow = true;
        }
    }

    private IEnumerator SceneSwitchingOperation()
    {
        while (true)
        {
            // 0 & 1
            while (!_switchingNow)
                yield return null;

            UpdateTargetScene();

            if (_targetSceneID == SceneID.Field && PlayerWork.transitionZoneID == ZoneID.UNKNOWN)
            {
                _switchingNow = false;
                yield return null;
                continue;
            }

            if (connector != null && !connector.SwitchingOperation(_targetSceneID))
            {
                _switchingNow = false;
                yield return null;
                continue;
            }

            if (connector != null && connector.sceneID == _targetSceneID)
            {
                Fader.FadeOut();
                if (connector.sceneID == SceneID.Field && UIManager.Instance)
                    UIManager.Instance.NowLoadingOpen();
            }
            else
            {
                string scenePath;
                switch (_targetSceneID)
                {
                    case SceneID.Field:
                        scenePath = "SharedAssets/Games/Scenes/" + "Field";
                        break;
                    case SceneID.Battle:
                        scenePath = "SharedAssets/Games/Scenes/" + "Battle";
                        break;
                    case SceneID.Title:
                        scenePath = "SharedAssets/Games/Scenes/" + "Title";
                        break;
                    case SceneID.Opening:
                        scenePath = "SharedAssets/Games/Scenes/" + "Opening/Opening";
                        break;
                    case SceneID.Contest:
                        scenePath = "SharedAssets/Games/Scenes/" + "Contest";
                        break;
                    case SceneID.DigFossil:
                        scenePath = "SharedAssets/Games/Scenes/" + "DigFossil";
                        break;
                    case SceneID.SealPreview:
                        scenePath = "SharedAssets/Games/Scenes/" + "SealPreview";
                        break;
                    case SceneID.EvolveDemo:
                        scenePath = "SharedAssets/Games/Scenes/" + "EvolveDemo";
                        break;
                    case SceneID.HatchDemo:
                        scenePath = "SharedAssets/Games/Scenes/" + "HatchDemo";
                        break;
                    case SceneID.GMS:
                        scenePath = "SharedAssets/Games/Scenes/" + "GMS";
                        break;
                    default:
                        scenePath = "SharedAssets/Games/Scenes/";
                        break;
                }

                SceneBrowser.Navigate(scenePath, false);

                if (connector != null)
                {
                    if (connector.sceneID == SceneID.Field && _targetSceneID == SceneID.Contest)
                        SwitchNotification.SetFocusHandlingModeNotify();

                    if (connector.sceneID == SceneID.Contest && _targetSceneID == SceneID.Field)
                        SwitchNotification.SetFocusHandlingModeSuspend();
                }
            }

            // 2
            while (SceneBrowser.isRequested || connector == null || connector.sceneID != _targetSceneID)
                yield return null;

            yield return connector.PrepareOperation();

            // 3 & 4
            while (Fader.isBusy)
                yield return null;

            _fieldObjectHolder.gameObject.SetActive(false);
            _battleObjectHolder.gameObject.SetActive(false);

            if (CPU_BOOST_ON())
                yield return null;

            // 5
            yield return connector.SetupOperation();

            // 6
            if (CPU_BOOST_OFF())
                yield return null;

            // 7
            switch (connector.sceneID)
            {
                case SceneID.Battle:
                case SceneID.SealPreview:
                case SceneID.EvolveDemo:
                case SceneID.HatchDemo:
                case SceneID.Field:
                    if (connector.sceneID == SceneID.Field)
                    {
                        if (PlayerWork.evolveRequets.Count == 0)
                        {
                            Fader.valid = true;
                            Fader.FadeIn();
                        }

                        if (UIManager.Instance)
                        {
                            UIManager.Instance.NowLoadingClose();
                        }
                    }
                    break;
                default:
                    Fader.valid = true;
                    Fader.FadeIn();
                    break;
            }

            if (connector.sceneID != SceneID.Title)
            {
                if (!PlayTimeManager.isInitialized)
                    PlayTimeManager.Initialize();
            }

            _switchingNow = false;
            yield return null;
        }
    }

    private void UpdateTargetScene()
    {
        if (PlayerWork.GetLoadResult() != PlayerWork.LoadResult.CORRUPTED)
        {
            if (!afterStarting && PlayerWork.GetInt(EvWork.WORK_INDEX.WK_SCENE_GAME_START) == 0)
            {
                _targetSceneID = SceneID.Opening;
                afterStarting = true;
            }
            else if (afterStarting && !playEnding)
            {
                if (PlayerWork.transitionZoneID != ZoneID.UNKNOWN)
                {
                    // No need to assign it anywhere, the constructor sets the singleton instance
                    if (FieldManager.Instance == null)
                        new FieldManager();

                    _targetSceneID = SceneID.Field;
                }
                else if (PlayerWork.isContest)
                {
                    _targetSceneID = SceneID.Contest;
                }
                else if (PlayerWork.isSealPreview)
                {
                    _targetSceneID = SceneID.SealPreview;
                }
                else if (PlayerWork.isEvolveDemo)
                {
                    // Do nothing?
                }
                else if (PlayerWork.isHatchDemo)
                {
                    _targetSceneID = SceneID.HatchDemo;
                }
                else if (PlayerWork.isDigFossil)
                {
                    _targetSceneID = SceneID.DigFossil;
                }
                else if (PlayerWork.isGMS)
                {
                    _targetSceneID = SceneID.GMS;
                }
                else if (PlayerWork.isBattling)
                {
                    _targetSceneID = SceneID.Battle;
                }
                else
                {
                    if (EntityManager.activeFieldPlayer != null)
                    {
                        var pos = EntityManager.activeFieldPlayer.gridPositionDirect;

                        if (!PlayerWork.GetBool(EvWork.FLAG_INDEX.FLAG_STOP_ZONE_PROGRAM))
                        {
                            ZoneID zone = GetGridZoneID(pos);
                            
                            if (zone != ZoneID.UNKNOWN && zone != PlayerWork.zoneID)
                            {
                                PlayerWork.zoneID = zone;
                                FieldManager.Instance.OnZoneChange(true);
                            }
                        }

                        _targetSceneID = SceneID.Field;
                        if (PlayerWork.evolveRequets.Count > 0)
                        {
                            PlayerWork.isPlayerInputActive = false;
                            for (int i = 0; i < PlayerWork.evolveRequets.Count; i++)
                            {
                                bool moreEvolutions;
                                Action onCompleteEvo;
                                if (i == PlayerWork.evolveRequets.Count - 1)
                                {
                                    moreEvolutions = false;
                                    onCompleteEvo = () =>
                                    {
                                        if (PlayerWork.capturedPokemon != null)
                                        {
                                            poketool_poke_memo.SetFromCapture(PlayerWork.capturedPokemon, PlayerWork.playerStatus, PlayerWork.zoneID);
                                            Sequencer.Start(EvolveDemoTools.RegisterZukanCoroutine(PlayerWork.capturedPokemon, () =>
                                            {
                                                PlayerWork.isPlayerInputActive = true;
                                                EncountTools.OnPostRegisterZukan(PlayerWork.capturedPokemon, PlayerWork.capturedBallCountTvTopic);
                                                PlayerWork.capturedBallCountTvTopic = 0;
                                            }));
                                        }
                                        else
                                        {
                                            PlayerWork.isPlayerInputActive = true;
                                            Fader.FadeIn();
                                        }
                                    };
                                }
                                else
                                {
                                    moreEvolutions = true;
                                    onCompleteEvo = null;
                                }

                                EvolveDemoTools.DoEvolve(PlayerWork.evolveRequets[i], null, null, ItemNo.DUMMY_DATA, onCompleteEvo, moreEvolutions);
                            }

                            PlayerWork.evolveRequets.Clear();
                        }
                    }
                    else
                    {
                        _targetSceneID = SceneID.Field;
                    }
                }
            }
            else
            {
                AudioManager.Instance.SetBgmEvent(ItemWork.IsDsPlayer() ? AK.EVENTS.DSPLAYER_ON : AK.EVENTS.DSPLAYER_OFF, false);
                _targetSceneID = SceneID.Title;
            }
        }
        else
        {
            _targetSceneID = SceneID.Title;
        }
    }

    private void OnEnable()
    {
        // Empty
    }

    private void OnDisable()
    {
        // Empty
    }

    private void OnDestroy()
    {
        Sequencer.update -= OnUpdate;
        FieldManager.Instance?.OnDestroy();
        SoftwareKeyboard.Terminate();
        SixAxisSensorManager.Terminate();
    }

    public static AttributeMatrix GetMapAttributeMattrix()
    {
        if (useSubAttribute)
        {
            if (mapInfo[(int)PlayerWork.zoneID].SubAttribute != null)
                return mapInfo[(int)PlayerWork.zoneID].SubAttribute;

            useSubAttribute = false;
        }

        return mapInfo[(int)PlayerWork.zoneID].Attribute;
    }

    public static AttributeMatrix GetMapAttributeMattrix(ZoneID zoneId)
    {
        if (useSubAttribute)
        {
            if (mapInfo[(int)zoneId].SubAttribute != null)
                return mapInfo[(int)zoneId].SubAttribute;

            useSubAttribute = false;
        }

        return mapInfo[(int)zoneId].Attribute;
    }

    public static AttributeMatrix GetMapAttributeExMattrix()
    {
        if (useSubAttribute)
        {
            if (mapInfo[(int)PlayerWork.zoneID].SubAttributeEx != null)
                return mapInfo[(int)PlayerWork.zoneID].SubAttributeEx;

            useSubAttribute = false;
        }

        return mapInfo[(int)PlayerWork.zoneID].AttributeEx;
    }

    public static void GetAttribute(Vector2Int grid, out int code, out int stop, bool debugdraw = false)
    {
        code = 0;
        stop = 0;

        if (PlayerWork.zoneID != ZoneID.UNKNOWN)
            GetAttribute(GetMapAttributeMattrix(), grid, out code, out stop, debugdraw);
    }

    public static void GetAttribute(ZoneID zoneId, Vector2Int grid, out int code, out int stop, bool debugdraw = false)
    {
        code = 0;
        stop = 0;

        if (zoneId != ZoneID.UNKNOWN)
            GetAttribute(GetMapAttributeMattrix(zoneId), grid, out code, out stop, debugdraw);
    }

    public static MapAttributeTable.SheetData GetAttributeTable(int code)
    {
        return Instance.gameSettings.mapAttributeTable[code];
    }

    public static void GetAttribute(AttributeMatrix attributes, Vector2Int grid, out int code, out int stop, bool debugdraw = false)
    {
        code = 0;
        stop = 0;

        if (grid.x > -1 && grid.y > -1 && attributes != null)
        {
            int x = grid.x > -1 ? grid.x : grid.x + 31;
            int y = grid.y > -1 ? grid.y : grid.y + 31;

            var block = attributes[x/32, y/32];
            if (block != null && block.Attributes != null)
            {
                int attribute = block[x%32, y%32];
                if (attribute < 1000)
                {
                    stop = attribute;
                }
                else
                {
                    code = attribute / 1000;
                    stop = attribute % 1000;
                }
            }
        }
    }

    public static MapAttributeExTable.SheetData GetAttributeEx(Vector2Int grid, float height, bool debugdraw = false)
    {
        int attribute = GetAttributeExCodeRaw(grid);

        MapAttributeExTable.SheetData attributeData = null;
        for (int i=0; i<Instance.gameSettings.mapAttributeExTable.Data.Length; i++)
        {
            if (Instance.gameSettings.mapAttributeExTable[i].Code == HeightAttribute(attribute, height))
            {
                attributeData = Instance.gameSettings.mapAttributeExTable[i];
                break;
            }
        }

        if (attributeData == null)
            return null;

        if (debugdraw)
        {
            string str1 = string.Format("{0} :: {1} ::", attributeData.Code, attributeData.EffectWalkSunnyA);
            string str2 = string.Format(" {0} :: Threshold:{1}", attributeData.EffectWalkSunnyB, attribute / 1000000);

            // This line is presumed to have been commented out.
            Debug.Log(str1 + str2);
        }

        return attributeData;
    }

    public static int GetAttributeExCodeRaw(Vector2Int grid)
    {
        if (PlayerWork.zoneID != ZoneID.UNKNOWN)
        {
            var matrix = GetMapAttributeExMattrix();
            if (matrix != null)
            {
                int x = grid.x > -1 ? grid.x : grid.x + 31;
                int y = grid.y > -1 ? grid.y : grid.y + 31;

                var block = matrix[x/32, y/32];
                if (block != null && block.Attributes != null)
                {
                    return block[x % 32, y % 32];
                }
            }
        }

        return 0;
    }

    public static bool IsHighAttribute(int attriRaw, float height)
    {
        return (attriRaw / 1000000) <= (int)(height + 100.5f);
    }

    public static int HeightAttribute(int attri, float height)
    {
        if (IsHighAttribute(attri, height))
            attri /= 1000;

        return attri % 1000;
    }

    public static ZoneID GetGridZoneID(Vector2Int pos)
    {
        var mapdata = mapInfo[(int)PlayerWork.zoneID];
        if (mapdata.ZoneGrid != null)
        {
            int x = pos.x > -1 ? pos.x : pos.x + 31;
            int y = pos.y > -1 ? pos.y : pos.y + 31;
            int index = mapdata.ZoneGrid.Width * (y / 32) + (x / 32);

            if (index < mapdata.ZoneGrid.Length)
                return mapdata.ZoneGrid[index];
        }

        return ZoneID.UNKNOWN;
    }

    private static void SetAssetBundleMemory()
    {
        // This is not a mistake, this is an empty array
        string[] paths = new string[0];
        for (int i=0; i<paths.Length; i++)
            AssetBundleMemory.LoadFromFile(AssetManager.cachePath.CombinePath(paths[i]));
    }

    public static bool CPU_BOOST_ON()
    {
        if (PlayerWork.IsCpuBoostMode == 0)
            return false;

        if (PlayerWork.IsCpuBoostMode > 2)
            Application.backgroundLoadingPriority = ThreadPriority.High;

        if (PlayerWork.IsCpuBoostMode > 1 && fieldCamera != null)
            fieldCamera.CameraComponentEnable(false);

#if SWITCH
        UnityEngine.Switch.Performance.SetCpuBoostMode(Performance.CpuBoostMode.FastLoad);
#else
        PlayerWork.IsCpuBoostMode = 2;
#endif
        return true;
    }

    public static bool CPU_BOOST_OFF()
    {
        if (PlayerWork.IsCpuBoostMode == 0)
            return false;

        Application.backgroundLoadingPriority = ThreadPriority.BelowNormal;

        if (PlayerWork.IsCpuBoostMode > 1 && fieldCamera != null)
            fieldCamera.CameraComponentEnable(true);

#if SWITCH
        UnityEngine.Switch.Performance.SetCpuBoostMode(Performance.CpuBoostMode.Normal);
#else
        PlayerWork.IsCpuBoostMode = 0;
#endif
        return true;
    }

    public enum AfterInitType : int
    {
        LanguageSelect = 0,
	    BackupLoad = 1,
    }

    public enum AfterLoadState : int
    {
        None = 0,
        Msbt = 1,
        Ui = 2,
        Ui2 = 3,
    }

    public enum AfterInitializeType : int
    {
        Language = 0,
	    Backup = 1,
    }
}