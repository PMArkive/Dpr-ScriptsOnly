using Dpr;
using FieldCommon;
using GameData;
using UnityEngine;

public class FieldTvEntity : FieldEventEntity
{
    private static readonly string FrameIndexName = "_StartFrameIndex";
    private static readonly string AutoSwitchName = "_AutoSwitch";
    public int FixFrameIndex = -1;
    private Material MonitorMaterial;
    private bool Contacted;
    private int[] CommercialList;
    private int CommercialIndex;
    private FieldFloatMove Time = new FieldFloatMove();

    public void SetView(int frameIndex)
    {
        Contacted = true;
        SetViewCore(frameIndex);
    }

    public void ResetView()
    {
        Contacted = false;
        Time.SetValue(0.0f);
        Time.MoveTime(1.0f, DataManager.FieldCommonParam[(int)ParamIndx.TvCommercialChangeTime].param);
    }

    protected override void Awake()
    {
        base.Awake();
        InitMaterial();
        PlayCommercial();
    }

    protected override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);

        if (Contacted)
            return;

        if (!Time.IsBusy)
            return;

        Time.Update(deltaTime);
        if (!Time.IsBusy)
        {
            CommercialIndex++;
            PlayCommercial();
        } 
    }

    private void PlayCommercial()
    {
        if (FixFrameIndex > -1)
            SetViewCore(FixFrameIndex);

        if (CommercialList == null || CommercialIndex >= CommercialList.Length)
        {
            ResetCommercialList();
            CommercialIndex = 0;
        }

        if (CommercialList != null)
        {
            var data = TvWork.GetTableData(CommercialList[CommercialIndex]);
            SetViewCore(data.SetCRT);
        }

        Time.SetValue(0.0f);
        Time.MoveTime(1.0f, DataManager.FieldCommonParam[(int)ParamIndx.TvCommercialChangeTime].param);
    }

    // TODO: No Clue if this is what this is supposed to do...
    private void ResetCommercialList()
    {
        var array = TvWork.GetCommercialIndexArray();

        if (array != null && array.Length > 1 && CommercialList != null && CommercialList.Length > 0)
        {
            int lastInList = CommercialList[CommercialList.Length - 1];
            if (array[0] == lastInList)
            {
                array[0] = array[CommercialList.Length - 1];
                array[CommercialList.Length - 1] = lastInList;
            }
        }

        CommercialList = array;
    }

    private void InitMaterial()
    {
        if (MonitorMaterial != null)
            return;

        var mats = GetComponent<MeshRenderer>().materials;
        MonitorMaterial = mats[0];
        MonitorMaterial.SetInt(AutoSwitchName, 0);
    }

    private void SetViewCore(int frameIndex)
    {
        if (MonitorMaterial == null)
            return;

        MonitorMaterial.SetInt(FrameIndexName, frameIndex);
    }
}