using Audio;
using Dpr.EvScript;
using UnityEngine;

public class FieldEventLiftEntity : FieldEventEntity
{
    public LiftAxisType LiftAxis = LiftAxisType.Y;
    public float LiftValueA;
    public float LiftValueB;
    public string LiftEventLabel;
    public bool LiftFixB;
    [SearchableEnum]
    public EvWork.FLAG_INDEX LiftFlag = EvWork.FLAG_INDEX.FLAG_END_SAVE_SIZE;
    public LiftSEType LiftSE;
    public bool MoveAfterWalk = true;

    public bool IsLiftB { get; set; }
    public bool IsLiftEnable { get; set; }
    public float LiftWorldValueA { get; set; }
    public float LiftWorldValueB { get; set; }

    protected override void Awake()
    {
        float ToWorldValue(float localValue)
        {
            var pos = transform.localPosition;
            pos[(int)LiftAxis] = localValue;
            return transform.parent.TransformPoint(pos)[(int)LiftAxis];
        }

        base.Awake();

        checkHeight = true;
        LiftWorldValueA = ToWorldValue(LiftValueA);
        LiftWorldValueB = ToWorldValue(LiftValueB);
    }

    public void Setup()
    {
        var pos = EntityManager.activeFieldPlayer.worldPosition;
        pos.y = EntityManager.activeFieldPlayer.Height;
        IsLiftEnable = true;
        isLanding = false;

        if (LiftFlag == EvWork.FLAG_INDEX.FLAG_END_SAVE_SIZE)
            IsLiftB = Mathf.Abs(LiftWorldValueB - pos[(int)LiftAxis]) < Mathf.Abs(LiftWorldValueA - pos[(int)LiftAxis]);
        else
            IsLiftB = EvDataManager.Instanse.GetFlag(LiftFlag) != 0;

        if (IsLiftB)
        {
            worldPosition[(int)LiftAxis] = LiftWorldValueB;
            if (LiftFixB)
                IsLiftEnable = false;
        }
        else
        {
            worldPosition[(int)LiftAxis] = LiftWorldValueA;
        }
    }

    public bool IsCompleteMoved()
    {
        float axisPosition = 0.0f;
        switch (LiftAxis)
        {
            case LiftAxisType.X:
                axisPosition = transform.position.x;
                break;

            case LiftAxisType.Y:
                axisPosition = transform.position.y;
                break;

            case LiftAxisType.Z:
                axisPosition = transform.position.z;
                break;
        }

        float targetPosition = IsLiftB ? LiftWorldValueA : LiftWorldValueB;

        return Mathf.Approximately(axisPosition, targetPosition);
    }

    public void PlayStartSE()
    {
        switch (LiftSE)
        {
            case LiftSEType.DEFAULT:
                AudioManager.Instance.PlaySe(AK.EVENTS.S_FI118, null);
                break;

            case LiftSEType.LEAGUE:
                AudioManager.Instance.PlaySe(AK.EVENTS.S_FI114, null);
                break;

            case LiftSEType.MIO_GYM_X:
                AudioManager.Instance.PlaySe(AK.EVENTS.S_FI110_UP, null);
                break;

            case LiftSEType.MIO_GYM_Y:
                if (IsLiftB)
                {
                    if (LiftWorldValueA <= LiftWorldValueB)
                        AudioManager.Instance.PlaySe(AK.EVENTS.S_FI110_DOWN, null);
                    else
                        AudioManager.Instance.PlaySe(AK.EVENTS.S_FI110_UP, null);
                }
                else
                {
                    if (LiftWorldValueB <= LiftWorldValueA)
                        AudioManager.Instance.PlaySe(AK.EVENTS.S_FI110_DOWN, null);
                    else
                        AudioManager.Instance.PlaySe(AK.EVENTS.S_FI110_UP, null);
                }
                break;
        }
    }

    public void PlayEndSE()
    {
        switch (LiftSE)
        {
            case LiftSEType.DEFAULT:
                AudioManager.Instance.PlaySe(AK.EVENTS.STOP_SE, null);
                AudioManager.Instance.PlaySe(AK.EVENTS.S_FI119, null);
                break;

            case LiftSEType.LEAGUE:
                AudioManager.Instance.PlaySe(AK.EVENTS.STOP_SE, null);
                AudioManager.Instance.PlaySe(AK.EVENTS.S_FI115, null);
                break;

            case LiftSEType.MIO_GYM_X:
                AudioManager.Instance.PlaySe(AK.EVENTS.STOP_SE, null);
                AudioManager.Instance.PlaySe(AK.EVENTS.S_FI111, null);
                break;

            case LiftSEType.MIO_GYM_Y:
                AudioManager.Instance.PlaySe(AK.EVENTS.STOP_SE, null);
                AudioManager.Instance.PlaySe(AK.EVENTS.S_FI111, null);
                break;
        }
    }

    public void StopSE()
    {
        if (LiftSE != LiftSEType.LEAGUE)
            return;

        AudioManager.Instance.PlaySe(AK.EVENTS.STOP_SE, null);
    }

    public enum LiftAxisType : int
    {
        X = 0,
        Y = 1,
        Z = 2,
    }

    public enum LiftSEType : int
    {
        NONE = 0,
        DEFAULT = 1,
        LEAGUE = 2,
        MIO_GYM_X = 3,
        MIO_GYM_Y = 4,
    }
}