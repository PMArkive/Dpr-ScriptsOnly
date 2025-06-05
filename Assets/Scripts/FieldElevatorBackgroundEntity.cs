using Dpr;
using Dpr.EvScript;
using FieldCommon;
using GameData;
using UnityEngine;

public class FieldElevatorBackgroundEntity : FieldObjectEntity
{
    public float[] BackgroundFloorHeight = new float[5]
    {
        15.0f, 7.5f, 0.0f, -7.5f, -15.0f,
    };

    public int CurrentFloorIndex { get; set; }

    private FieldObjectMove Move = new FieldObjectMove();

    public bool IsBusy { get => Move.IsBusy; }

    protected override void Awake()
    {
        base.Awake();
        isLanding = false;
    }

    public void Setup()
    {
        SetCurrentFloorHeight();
    }

    public void SetCurrentFloorHeight()
    {
        CurrentFloorIndex = GetFloorIndex();
        worldPosition.y = ToWorldValue(BackgroundFloorHeight[CurrentFloorIndex]);
    }

    public void MoveNextFloorHeight(int nextFloor)
    {
        var targetPos = worldPosition;
        targetPos.y = ToWorldValue(BackgroundFloorHeight[nextFloor]);

        int floorDiff = Mathf.Abs(nextFloor - CurrentFloorIndex);
        int param = Mathf.Clamp(floorDiff + 136, (int)ParamIndx.ElevatorBG_Time1, (int)ParamIndx.ElevatorBG_Time4);
        float moveTime = DataManager.FieldCommonParam[param].param;

        Move.SetObjectEntity(this);
        Move.FloatMove.EaseFunc = FieldFloatMove.EaseInOutSin;
        Move.MoveTime(targetPos, moveTime);
        CurrentFloorIndex = nextFloor;
    }

    protected override void ProcessSequence(float deltaTime)
    {
        if (currentSequence == SequenceID.Active)
            UpdateHeight(deltaTime);

        base.ProcessSequence(deltaTime);
    }

    private void UpdateHeight(float deltaTime)
    {
        if (!IsBusy)
            return;

        Move.Update(deltaTime);

        if (!IsBusy)
            Move.Reset();
    }

    private int GetFloorIndex()
    {
        return EvDataManager.Instanse.GetWork(EvWork.WORK_INDEX.WK_ELEVATOR_FLOOR);
    }

    private float ToWorldValue(float localValue)
    {
        var pos = transform.localPosition;
        pos.y = localValue;
        return transform.parent.TransformPoint(pos).y;
    }
}