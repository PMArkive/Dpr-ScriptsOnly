using UnityEngine;

public class FieldTvRedGyaradosEntity : FieldEventEntity
{
    protected static readonly int ID_BLINKCYCLE = Shader.PropertyToID("_BlinkCycle");
    protected static readonly int ID_SCROLLSPEED = Shader.PropertyToID("_ScrollSpeed");
    protected static readonly int ID_LINEALPHA = Shader.PropertyToID("_LineAlpha");

    private Material MonitorMaterial;

    protected override void Awake()
    {
        base.Awake();
        SetActive(false);
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        if (MonitorMaterial == null)
            MonitorMaterial = GetComponent<MeshRenderer>().material;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        Destroy(MonitorMaterial);
        MonitorMaterial = null;
    }

    public static FieldTvRedGyaradosEntity GetTvRedGyarados()
    {
        var machine = GameObject.Find("P_RO_001_Machine_01");
        if (machine != null)
            return machine.GetComponent<FieldTvRedGyaradosEntity>();

        return null;
    }

    public void SetActive(bool active)
    {
        if (MonitorMaterial == null)
            return;

        SetMaterialProperty(ID_BLINKCYCLE, active ? 1.5f : 0.0f);
        SetMaterialProperty(ID_SCROLLSPEED, active ? 0.05f : 0.0f);
        SetMaterialProperty(ID_LINEALPHA, active ? 0.04f : 0.0f);
    }

    private void SetMaterialProperty(int property, float value)
    {
        MonitorMaterial.SetFloat(property, value);
    }
}