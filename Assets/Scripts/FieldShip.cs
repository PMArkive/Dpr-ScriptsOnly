using Dpr;
using Effect;
using UnityEngine;

public class FieldShip
{
    private FieldEventEntity Ship;
    private FieldFloatMove ShipSpeed = new FieldFloatMove();
    private Vector3 MoveVector = Vector3.zero;
    private FieldFloatMove CameraOffsetRate = new FieldFloatMove();
    private Vector3 CameraOffsetA;
    private Vector3 CameraOffsetB;
    private FieldFloatMove ShipOffset = new FieldFloatMove();
    private GameObject CameraAttachObject;
    private GameObject BlurEffectRotate;
    private GameObject BlurEffectParent;
    private EffectInstance BlurEffect;
    private EffectInstance ShipEffect;
    private bool IsAttachPlayer;
    private MapType Type;

    public MovePhase Phase { get; set; }
    public MoveSeaPhase SeaPhase { get; set; }

    // TODO
    public void Terminate() { }

    // TODO
    public bool FindAndSetShip(string name) { return false; }

    // TODO
    public void PlayIdle() { }

    // TODO
    private void PlayShipEffect(EffectFieldID id) { }

    // TODO
    public void Update(float deltaTime) { }

    // TODO
    public void StartShip(DIR dir) { }

    // TODO
    public void NormalUpdate(float deltaTime) { }

    // TODO
    public void StartShipSeaMap(DIR dir) { }

    // TODO
    public void SeaUpdate(float deltaTime) { }

    private enum MapType : int
    {
        None = 0,
        Normal = 1,
        Sea = 2,
    }

    public enum MovePhase : int
    {
        None = 0,
        AdjustCamera = 1,
        MoveShip = 2,
    }

    public enum MoveSeaPhase : int
    {
        None = 0,
        AppearShip = 1,
        WaitShip = 2,
        AccShip = 3,
        Finish = 4,
    }
}