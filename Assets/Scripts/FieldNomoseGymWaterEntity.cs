using DPData;
using Dpr;
using FieldCommon;
using GameData;
using System;
using UnityEngine;

public class FieldNomoseGymWaterEntity : FieldObjectEntity
{
    public float[] WaterHeightLevel;
    public int WaterHeightDefaultLevel;
    [NonSerialized]
    public int WaterLevel;
    [NonSerialized]
    public FieldFloatMove HeightMove = new FieldFloatMove();
    private MovePhase Phase;
    private float SwayTime;

    public bool IsBusy()
    {
        return Phase != MovePhase.None;
    }

    protected override void Awake()
    {
        base.Awake();
        HeightMove.EaseFunc = FieldFloatMove.EaseInOutSin;
        isLanding = false;
        WaterLevel = WaterHeightDefaultLevel;
    }

    protected override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);

        if (!enabled)
            return;

        switch (Phase)
        {
            case MovePhase.Move1st:
                if (!HeightMove.IsBusy)
                {
                    HeightMove.MoveTime(WaterHeightLevel[WaterLevel], SwayTime);
                    Phase = MovePhase.Move2nd;
                }
                break;

            case MovePhase.Move2nd:
                if (!HeightMove.IsBusy)
                    Phase = MovePhase.None;
                break;
        }

        if (HeightMove.IsBusy)
        {
            HeightMove.Update(deltaTime);
            SetHeight(HeightMove.CurrentValue);
        }
    }

    public void Setup()
    {
        HeightMove.SetValue(WaterHeightLevel[WaterLevel]);
        SetHeight(HeightMove.CurrentValue);
    }

    public void ApplySaveData(in FIELD_OBJ_SAVE_DATA saveData)
    {
        WaterLevel = saveData.height;
    }

    public void CreateSaveData(ref FIELD_OBJ_SAVE_DATA saveData)
    {
        saveData.height = WaterLevel;
    }

    public void MoveHeight(int level)
    {
        int levelDiff = Mathf.Abs(level - WaterLevel);
        WaterLevel = level;

        var targetHeight = WaterHeightLevel[level];
        float swayOffset = (targetHeight - HeightMove.CurrentValue) * DataManager.FieldCommonParam[(int)ParamIndx.NomoseWaterSwayOfsRate].param;
        float time;
        if (levelDiff > 1)
            time = DataManager.FieldCommonParam[(int)ParamIndx.NomoseWaterTime2Lv].param;
        else
            time = DataManager.FieldCommonParam[(int)ParamIndx.NomoseWaterTime1Lv].param;

        float swayTime = DataManager.FieldCommonParam[(int)ParamIndx.NomoseWaterSwayTimeRate].param;
        Phase = swayOffset == 0.0f ? MovePhase.Move2nd : MovePhase.Move1st;

        if (swayOffset != 0.0f)
            targetHeight += swayOffset;

        SwayTime = time * swayTime;
        HeightMove.MoveTime(targetHeight, time);
    }

    private void SetHeight(float height)
    {
        var pos = worldPosition;
        pos.y = height;
        SetPositionDirect(pos);
    }

    private enum MovePhase : int
    {
        None = 0,
        Move1st = 1,
        Move2nd = 2,
    }
}