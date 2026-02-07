using Pml.PokePara;
using Pml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLSXContent;
using Dpr.Field.Walking;
using Dpr.SubContents;
using GameData;
using Dpr;
using Dpr.UnderGround;
using System.Linq;

public class UgMainProc
{
    private List<SimbolMons> _ugMons = new List<SimbolMons>();
    public static UgWalkingAIManager walkingManager = new UgWalkingAIManager();
    public static bool isEntering = false;
    private List<AIUgModel> ugAIs = new List<AIUgModel>();
    private float NoHitTime;
    private static CheckFormParam[] _checkFormParams = new CheckFormParam[14]
    {
        new CheckFormParam() { monsNo = MonsNo.ANNOON,     maxFormNo = FormNo.ANNOON_MAX },
        new CheckFormParam() { monsNo = MonsNo.POWARUN,    maxFormNo = FormNo.POWARUN_MAX },
        new CheckFormParam() { monsNo = MonsNo.DEOKISISU,  maxFormNo = FormNo.DEOKISISU_MAX },
        new CheckFormParam() { monsNo = MonsNo.MINOMUTTI,  maxFormNo = FormNo.MINOMUTTI_MAX },
        new CheckFormParam() { monsNo = MonsNo.MINOMADAMU, maxFormNo = FormNo.MINOMADAMU_MAX },
        new CheckFormParam() { monsNo = MonsNo.GAAMEIRU,   maxFormNo = FormNo.GAAMEIRU_MAX },
        new CheckFormParam() { monsNo = MonsNo.THERIMU,    maxFormNo = FormNo.THERIMU_MAX },
        new CheckFormParam() { monsNo = MonsNo.KARANAKUSI, maxFormNo = FormNo.KARANAKUSI_MAX },
        new CheckFormParam() { monsNo = MonsNo.TORITODON,  maxFormNo = FormNo.TORITODON_MAX },
        new CheckFormParam() { monsNo = MonsNo.ROTOMU,     maxFormNo = FormNo.ROTOMU_MAX },
        new CheckFormParam() { monsNo = MonsNo.GIRATHINA,  maxFormNo = FormNo.GIRATHINA_MAX },
        new CheckFormParam() { monsNo = MonsNo.SHEIMI,     maxFormNo = FormNo.SHEIMI_MAX },
        new CheckFormParam() { monsNo = MonsNo.ARUSEUSU,   maxFormNo = FormNo.ARUSEUSU_MAX },
        new CheckFormParam() { monsNo = MonsNo.TAMAGO,     maxFormNo = FormNo.TAMAGO_MAX },
    };

    public void Init()
    {
        FieldManager.Instance.OnZoneChangeEvent += OnZoneChange;
        FieldManager.Instance.OnSceneInitEvent += OnSceneInit;
    }

    private void OnSceneInit()
    {
        for (int i=0; i<_ugMons.Count; i++)
        {
            var go = _ugMons[i].gameObject;
            if (go != null && go.activeInHierarchy)
            {
                if (!_ugMons[i].Active)
                    _ugMons[i].gameObject.SetActive(false);
            }
        }
    }

    // TODO
    public void EncountMonsLot(int randmark) { }

    public void CreatePoke(PokemonParam param, Vector3 pos)
    {
        var monsno = param.GetMonsNo();

        if (monsno == MonsNo.TAMAGO)
            return;

        var moveType = UgResManager.GetUgPokeData(monsno).movetype;
        var sm = new SimbolMons
        {
            pokeParam = param,
            catalog = Utils.GetPokemonCatalog(param),
            defaultPos = pos,
            moveType = moveType,
            Active = true
        };

        _ugMons.Add(sm);

        UgResManager.AppendAsset(param, gmo =>
        {
            if (sm.isLoaded)
                return;

            sm.isLoaded = true;
            sm.gameObject = UnityEngine.Object.Instantiate(gmo);
            sm.transform = sm.gameObject.GetComponent<Transform>();
            sm.transform.position = sm.defaultPos;

            var catalog = DataManager.GetPokemonCatalog(param.GetMonsNo(), param.GetFormNo(), param.GetSex(), false, false);

            sm.transform.localScale = Vector3.one * catalog.FieldChikaScale;

            // Returned value is unused
            _ = param.IsRare();

            sm.entity = sm.gameObject.GetComponent<FieldPokemonEntity>();
            sm.entity.EventParams.SaveObject = false;

            var walkingCharacter = walkingManager.ToWalkingCharacter(sm.entity);
            walkingCharacter.model.collisionModel.isIgnoreCollision = true;
            walkingCharacter.model.SetPokemonParam(sm.pokeParam);

            var ugAI = walkingCharacter.model.AI.aiModel as AIUgModel;
            ugAI.moveType = (MoveType)moveType;
            ugAIs.Add(ugAI);

            ugAI.InitPos = sm.defaultPos;
            walkingCharacter.view.isWaitMotionMove = catalog.Waitmoving;

            var patcheel = sm.gameObject.GetComponent<PatcheelPattern>();
            if (patcheel != null)
                patcheel.SetPattern(sm.pokeParam.GetPersonalRnd());
        });
    }

    public IEnumerator CreateObject()
    {
        yield return UgResManager.DispathAsset();

        yield return null;

        UgFieldManager.Instance.OnDestroyCallBack = () => Destroy();
    }

    private void OnZoneChange()
    {
        Utils.WaitFrame(3, () =>
        {
            var doors = EntityManager.fieldDoorObjects.Where(x => x != null).Select(x => x.transform.position);
            ugAIs.ForEach(x =>
            {
                x.entrancePosition.Clear();
                x.entrancePosition.AddRange(doors);
            });
            OnSceneInit();
        });
    }

    // TODO
    public void SaveSymbols() { }

    // TODO
    public void LoadSymbols() { }

    private static bool CheckFormNo(MonsNo monsNo, ushort formNo)
    {
        if (formNo >= FormNo.MAX_FORM_NUM)
            return false;

        CheckFormParam foundFormParam = null;
        for (int i=0; i<_checkFormParams.Length; i++)
        {
            var formParam = _checkFormParams[i];
            if (formParam.monsNo == monsNo)
            {
                foundFormParam = formParam;
                break;
            }
        }

        if (foundFormParam == null)
        {
            if (formNo == 0)
                return true;
            else
                return false;
        }
        else if (formNo < foundFormParam.maxFormNo)
        {
            return true;
        }

        return false;
    }

    // TODO
    public bool update(float time) { return false; }

    private bool IsPlayerHit(Vector3 pos, SimbolMons mons)
    {
        var player = EntityManager.activeFieldPlayer;

        if ((player.IsSwim() && mons.moveType != Ug.MoveType.Water) ||
            (!player.IsSwim() && mons.moveType == Ug.MoveType.Water))
            return false;

        var pos1 = player.worldPosition;
        pos1.y = 0.0f;
        var pos2 = pos;
        pos2.y = 0.0f;

        // Weird that there's a +0, but it's there
        return Utils.IsInDistance(pos1, pos2, mons.catalog.BodySize + 0.0f);
    }

    public void Destroy()
    {
        walkingManager.Destroy(true);
        ugAIs.ForEach(x => x.Destroy());
        _ugMons.ForEach(x =>
        {
            x.pokeParam = null;
            x.catalog = null;
            x.gameObject = null;
            x.transform = null;
            x.entity = null;
        });

        ugAIs.Clear();
        _ugMons.Clear();

        UgResManager.AssetBundleUnload();

        FieldManager.Instance.OnZoneChangeEvent -= OnZoneChange;
        FieldManager.Instance.OnSceneInitEvent -= OnSceneInit;
    }

    private class SimbolMons
    {
        public PokemonParam pokeParam;
        public PokemonInfo.SheetCatalog catalog;
        public Vector3 defaultPos;
        public bool Active;
        public bool isLoaded;
        public Ug.MoveType moveType;
        public GameObject gameObject;
        public Transform transform;
        public FieldPokemonEntity entity;

        public void Destroy()
        {
            pokeParam = null;
            catalog = null;
            gameObject = null;
            transform = null;
            entity = null;
        }
    }

    private class CheckFormParam
    {
        public MonsNo monsNo;
        public ushort maxFormNo;
    }
}