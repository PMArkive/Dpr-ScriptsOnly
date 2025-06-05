using Dpr;
using FieldCommon;
using GameData;
using UnityEngine;

public class FieldNagisaGymGearEntity : FieldEventEntity
{
    [SerializeField]
    [Range(0.0f, 1.0f)]
    public int GearGroupNo;
    public GearRotateDegType GearRotateButton;
    public GearRotateAxisType GearRotateAxis = GearRotateAxisType.Y;
    public string GearRotateEventLabel = string.Empty;
    private FieldFloatMove DegMove = new FieldFloatMove();
    private Vector3 originalLocalEulerAngles;
    private bool IsSetuped;
    private InitSequenceType InitSequence;

    protected override void Awake()
    {
        base.Awake();

        isLanding = false;
        if (IsSetuped)
            return;

        originalLocalEulerAngles = transform.localEulerAngles;
        DegMove.SetValue(0.0f);
    }

    protected override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);

        if (!enabled)
            return;

        switch (InitSequence)
        {
            case InitSequenceType.Wait:
                InitSequence = InitSequenceType.TempShift;
                break;

            case InitSequenceType.TempShift:
                SetRotate(DegMove.CurrentValue + 0.01f);
                InitSequence = InitSequenceType.Fix;
                break;

            case InitSequenceType.Fix:
                SetRotate(DegMove.CurrentValue);
                InitSequence = InitSequenceType.None;
                break;
        }

        if (!DegMove.IsBusy)
            return;

        DegMove.Update(deltaTime);
        SetRotate(DegMove.CurrentValue);
    }

    public void Setup(AreaID areaId)
    {
        if (IsSetuped)
            return;

        int rotation = GimmickWork.GetGearRotate(areaId);
        SetRotate(GearGroupNo == 0 ? rotation : -rotation);
        DegMove.SetValue(rotation);
        IsSetuped = true;
    }

    public void SceneStart()
    {
        InitSequence = InitSequenceType.Wait;
    }

    public static float GetDegRotateType(GearRotateDegType rotateType)
    {
        switch (rotateType)
        {
            case GearRotateDegType.Plus90:
                return 90.0f;

            case GearRotateDegType.Minus90:
                return -90.0f;

            case GearRotateDegType.Plus180:
                return 180.0f;

            case GearRotateDegType.Minus180:
                return -180.0f;

            default:
                return 0.0f;
        }
    }

    public void Rotate(GearRotateDegType rotateType, int triggerGroupNo)
    {
        float deg = GetDegRotateType(rotateType);
        if (GearGroupNo != triggerGroupNo)
            deg = -deg;

        float time;
        switch (rotateType)
        {
            case GearRotateDegType.Plus180:
            case GearRotateDegType.Minus180:
                time = DataManager.FieldCommonParam[(int)ParamIndx.NagisaGearRot180Time].param;
                break;

            default:
                time = DataManager.FieldCommonParam[(int)ParamIndx.NagisaGearRot90Time].param;
                break;

        }

        float repeatDeg = Mathf.Repeat(deg + DegMove.CurrentValue, 360.0f);
        DegMove.SetValue(repeatDeg - deg);
        DegMove.MoveTime(repeatDeg, time);
    }

    public bool IsRotating()
    {
        return DegMove.IsBusy;
    }

    private void SetRotate(float angle)
    {
        if (GearRotateAxis == GearRotateAxisType.X)
            transform.localEulerAngles = new Vector3(originalLocalEulerAngles.x + angle,
                                                     originalLocalEulerAngles.y,
                                                     originalLocalEulerAngles.z);
        else
            transform.localEulerAngles = new Vector3(originalLocalEulerAngles.x,
                                                     originalLocalEulerAngles.y + angle,
                                                     originalLocalEulerAngles.z);
    }

    public enum GearRotateDegType : int
    {
        None = 0,
        Plus90 = 1,
        Minus90 = 2,
        Plus180 = 3,
        Minus180 = 4,
    }

    public enum GearRotateAxisType : int
    {
        X = 0,
        Y = 1,
    }

    public enum InitSequenceType : int
    {
        None = 0,
        Wait = 1,
        TempShift = 2,
        Fix = 3,
    }
}