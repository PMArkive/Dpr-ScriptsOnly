using Dpr;
using FieldCommon;
using GameData;
using System;

public class FieldNomoseGymSwitchEntity : FieldEventEntity
{
    public int WaterLevel;
    public string WaterEventLabel;
    [NonSerialized]
    public FieldFloatMove HeightMove = new FieldFloatMove();
    private float DefaultHeightValue;
    private float PushedHeightValue;

    protected override void Awake()
    {
        float ToWorldValue(float localValue)
        {
            var pos = transform.localPosition;
            pos[1] = localValue;
            return transform.parent.TransformPoint(pos)[1];
        }

        base.Awake();

        HeightMove.EaseFunc = FieldFloatMove.EaseInOutSin;
        isLanding = false;
        DefaultHeightValue = ToWorldValue(0.0f);
        PushedHeightValue = DataManager.FieldCommonParam[(int)ParamIndx.NomoseSwitchOfs].param;
    }

    protected override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);

        if (!enabled)
            return;

        if (!HeightMove.IsBusy)
            return;
        
        HeightMove.Update(deltaTime);
        SetHeight(HeightMove.CurrentValue);
    }

    public bool IsPushed()
    {
        if (EntityManager.fieldNomoseGymWater.Length == 0)
            return false;

        return EntityManager.fieldNomoseGymWater[0].WaterLevel == WaterLevel;
    }

    public void Setup()
    {
        HeightMove.SetValue(GetHeightValue(IsPushed()));
        SetHeight(HeightMove.CurrentValue);
    }

    public void ChangeState(int level)
    {
        HeightMove.MoveTime(GetHeightValue(WaterLevel == level), DataManager.FieldCommonParam[(int)ParamIndx.NomoseSwitchTime].param);
    }

    private float GetHeightValue(bool pushed)
    {
        if (pushed)
            return PushedHeightValue;
        else
            return DefaultHeightValue;
    }

    private void SetHeight(float height)
    {
        var pos = worldPosition;
        pos.y = height;
        SetPositionDirect(pos);
    }
}