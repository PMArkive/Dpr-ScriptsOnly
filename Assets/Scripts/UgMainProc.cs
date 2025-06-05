using Pml.PokePara;
using Pml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLSXContent;
using Dpr.Field.Walking;

public class UgMainProc
{
    private List<SimbolMons> _ugMons = new List<SimbolMons>();
    public static UgWalkingAIManager walkingManager = new UgWalkingAIManager();
    public static bool isEntering = false;
    private List<AIUgModel> ugAIs = new List<AIUgModel>();
    private float NoHitTime;
    private static CheckFormParam[] _checkFormParams = new CheckFormParam[14]
    {
        new CheckFormParam() { monsNo = MonsNo.ANNOON,     maxFormNo = 28 },
        new CheckFormParam() { monsNo = MonsNo.POWARUN,    maxFormNo = 4 },
        new CheckFormParam() { monsNo = MonsNo.DEOKISISU,  maxFormNo = 4 },
        new CheckFormParam() { monsNo = MonsNo.MINOMUTTI,  maxFormNo = 3 },
        new CheckFormParam() { monsNo = MonsNo.MINOMADAMU, maxFormNo = 3 },
        new CheckFormParam() { monsNo = MonsNo.GAAMEIRU,   maxFormNo = 3 },
        new CheckFormParam() { monsNo = MonsNo.THERIMU,    maxFormNo = 2 },
        new CheckFormParam() { monsNo = MonsNo.KARANAKUSI, maxFormNo = 2 },
        new CheckFormParam() { monsNo = MonsNo.TORITODON,  maxFormNo = 2 },
        new CheckFormParam() { monsNo = MonsNo.ROTOMU,     maxFormNo = 6 },
        new CheckFormParam() { monsNo = MonsNo.GIRATHINA,  maxFormNo = 2 },
        new CheckFormParam() { monsNo = MonsNo.SHEIMI,     maxFormNo = 2 },
        new CheckFormParam() { monsNo = MonsNo.ARUSEUSU,   maxFormNo = 18 },
        new CheckFormParam() { monsNo = MonsNo.TAMAGO,     maxFormNo = 2 },
    };

    // TODO
    public void Init() { }

    // TODO
    private void OnSceneInit() { }

    // TODO
    public void EncountMonsLot(int randmark) { }

    // TODO
    public void CreatePoke(PokemonParam param, Vector3 pos) { }

    // TODO
    public IEnumerator CreateObject() { return null; }

    // TODO
    private void OnZoneChange() { }

    // TODO
    public void SaveSymbols() { }

    // TODO
    public void LoadSymbols() { }

    // TODO
    private static bool CheckFormNo(MonsNo monsNo, ushort formNo) { return false; }

    // TODO
    public bool update(float time) { return false; }

    // TODO
    private bool IsPlayerHit(Vector3 pos, SimbolMons mons) { return false; }

    // TODO
    public void Destroy() { }

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