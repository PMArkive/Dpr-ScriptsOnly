using Audio;
using Dpr;
using FieldCommon;
using GameData;
using System;
using UnityEngine;

public class FieldEventTrainEntity : FieldEventEntity
{
    public float[] TrainPosListZ = new float[3];
    [NonSerialized]
    public int CurrentPosIndex;
    private int NextPosIndex;
    private MovePhase Phase;
    private FieldFloatMove MoveRate = new FieldFloatMove();
    private FieldFloatMove WaitArrival = new FieldFloatMove();
    private bool IsMoveEnd;
    private bool IsRidePlayer;

    public bool IsBusy { get => Phase != MovePhase.Idle; }

    public void Move(int posIndex, bool isRidePlayer)
    {
        NextPosIndex = posIndex;
        IsRidePlayer = isRidePlayer;
        Phase = MovePhase.Start;
        Play(AnimationIndex.Start);
        IsMoveEnd = false;
    }

    private void Play(AnimationIndex animationIndex)
    {
        Play((int)animationIndex);
    }

    private float CalcAccDist(float accTime, float maxSpeed)
    {
        if (accTime <= 0.0f)
            return 0.0f;

        float time = 0.0f;
        float dist = 0.0f;

        while (true)
        {
            time = Mathf.Min(time + 0.03333334f, accTime);
            dist += Mathf.Lerp(0.0f, maxSpeed, time / accTime) * 0.03333334f;

            if (accTime <= time)
                break;
        }

        return dist;
    }

    private float ToWorldValue(float localValue)
    {
        var pos = transform.localPosition;
        pos.z = localValue;
        return transform.parent.TransformPoint(pos).z;
    }

    protected override void Awake()
    {
        base.Awake();

        isLanding = false;
        CurrentPosIndex = 2;

        var pos = transform.localPosition;
        pos.z = TrainPosListZ[CurrentPosIndex];
        transform.localPosition = pos;
    }

    protected override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);

        if (!enabled)
            return;

        if (Phase == MovePhase.Idle)
            return;

        MoveRate.Update(deltaTime);

        if (WaitArrival.IsBusy)
        {
            WaitArrival.Update(deltaTime);
            if (!WaitArrival.IsBusy)
                AudioManager.Instance.PlaySe(AK.EVENTS.S_FI237, null);
        }

        float accTime = DataManager.FieldCommonParam[(int)ParamIndx.Train_AccTime].param;
        float decTime = DataManager.FieldCommonParam[(int)ParamIndx.Train_DecTime].param;
        float maxSpeed = DataManager.FieldCommonParam[(int)ParamIndx.Train_MaxSpeed].param;

        float worldZ = ToWorldValue(TrainPosListZ[NextPosIndex]);

        float newWorldZ;

        switch (Phase)
        {
            case MovePhase.Start:
                if (isCompleted)
                {
                    Play(AnimationIndex.Move_Low);
                    MoveRate.SetValue(0.0f);
                    MoveRate.MoveTime(1.0f, accTime);
                    Phase = MovePhase.Acc;
                }
                return;

            case MovePhase.Acc:
                if (MoveRate.IsBusy)
                {
                    maxSpeed = Mathf.Lerp(0.0f, maxSpeed, MoveRate.CurrentValue);
                }
                else
                {
                    Play(AnimationIndex.Move_High);
                    float accDist = CalcAccDist(decTime, maxSpeed);
                    float time = (Mathf.Abs(worldZ - worldPosition.z) - accDist) / maxSpeed + 0.03333334f;
                    MoveRate.SetValue(0.0f);
                    MoveRate.MoveTime(1.0f, time);
                    WaitArrival.SetValue(0.0f);
                    WaitArrival.MoveTime(1.0f, Mathf.Max(0.0f, decTime + time - 1.5f));
                    Phase = MovePhase.Move;
                }
                break;

            case MovePhase.Move:
                if (!MoveRate.IsBusy)
                {
                    Play(AnimationIndex.Move_Low);
                    MoveRate.SetValue(0.0f);
                    MoveRate.MoveTime(1.0f, decTime);
                    Phase = MovePhase.Dec;
                }
                break;

            case MovePhase.Dec:
                if (MoveRate.IsBusy)
                {
                    maxSpeed = Mathf.Lerp(maxSpeed, 0.0f, MoveRate.CurrentValue);
                }
                else
                {
                    Play(AnimationIndex.Stop);
                    Phase = MovePhase.Stop;
                    maxSpeed = 1000.0f;
                }
                break;

            case MovePhase.Stop:
                if (isCompleted)
                {
                    Play(AnimationIndex.Idle);
                    IsMoveEnd = true;
                    CurrentPosIndex = NextPosIndex;
                    NextPosIndex = -1;
                    Phase = MovePhase.Idle;

                    if (IsRidePlayer)
                    {
                        if (EntityManager.activeFieldPlayer != null)
                        {
                            var pos = Vec2ToVec3Position(GridToPosition(EntityManager.activeFieldPlayer.gridPosition), EntityManager.activeFieldPlayer.worldPosition.y);
                            EntityManager.activeFieldPlayer.worldPosition = pos;
                        } 
                    }
                }
                return;
        }

        if (maxSpeed <= 0.0f)
            return;

        if (IsMoveEnd)
            return;

        if (worldZ <= worldPosition.z)
        {
            newWorldZ = worldPosition.z - maxSpeed * deltaTime;
            if (newWorldZ < worldZ)
            {
                IsMoveEnd = true;
                newWorldZ = worldZ;
            }
        }
        else
        {
            newWorldZ = worldPosition.z + maxSpeed * deltaTime;
            if (newWorldZ > worldZ)
            {
                IsMoveEnd = true;
                newWorldZ = worldZ;
            }
        }

        if (IsRidePlayer)
        {
            if (EntityManager.activeFieldPlayer != null)
                EntityManager.activeFieldPlayer.worldPosition.z += newWorldZ - worldPosition.z;
        }

        worldPosition.z = newWorldZ;
    }

    public enum Define : int
    {
        TRAIN_POS_1 = 0,
        TRAIN_POS_2 = 1,
        TRAIN_POS_3 = 2,
        MOVE_TYPE_CALL = 3,
        MOVE_TYPE_RIDE = 4,
        TRAIN_SAME_POS = 5,
        TRAIN_DIF_POS = 6,
    }

    private enum MovePhase : int
    {
        Idle = 0,
        Start = 1,
        Acc = 2,
        Move = 3,
        Dec = 4,
        Stop = 5,
    }

    private enum AnimationIndex : int
    {
        Idle = 0,
        Start = 1,
        Move_Low = 2,
        Move_High = 3,
        Stop = 4,
    }
}