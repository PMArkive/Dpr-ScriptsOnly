using SmartPoint.AssetAssistant;
using UnityEngine;

public class TairyouHasseiPokeManager
{
    private const int GRID_SIZE = 12;
    private const int POKE_MAX = 8;
    private const float DIS = 4.0f;

    private TairyouHasseiPoke[] _objects;
    private AssetRequestOperation _operation;
    private float _defaultScale;
    private byte _loadingState;
    private GameObject _parent;
    private ZoneID _targetZone = ZoneID.UNKNOWN;
    public static bool ForceStop;
    private static TairyouHasseiPokeManager instance;

    public TairyouHasseiPokeManager()
    {
        if (instance == null)
            instance = this;

        _objects = new TairyouHasseiPoke[POKE_MAX];
        _operation = null;
        _defaultScale = 0.0f;
        _parent = new GameObject();
        _parent.name = "Tairyou";
        _loadingState = 0;
    }

    // TODO
    public bool ZoneChange(bool walk) { return false; }

    // TODO
    public void Update(float time) { }

    // TODO
    private void Loading() { }

    // TODO
    private void ObjectStart(int i, FieldPokemonEntity entity) { }

    // TODO
    private void ObjectEnd(int i) { }

    // TODO
    private void ObjectReset(int i) { }

    // TODO
    private bool CheckDisappearOrder(int objectIndex) { return false; }

    // TODO
    private void ObjectUpdate(int i, float time) { }

    // TODO
    public bool StopUpdate(int i, float time) { return false; }

    // TODO
    private bool CheckAttribute(ref Vector2Int outgrid, out EffectFieldID effet)
    {
        effet = EffectFieldID.NONE;
        return false;
    }

    // TODO
    private bool ZoneCheck(ref Vector2Int grid) { return false; }

    // TODO
    public static void ForceStopObject() { }
}