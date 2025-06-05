using Dpr.EvScript;

public class FieldMistPlate
{
    private FieldEventEntity MistPlateEntity;

    public void Setup(ZoneID zoneId)
    {
        switch (zoneId)
        {
            case ZoneID.C10:
            case ZoneID.R224:
                MistPlateEntity = EvDataManager.Instanse.GetFieldEventEntity("P_D_010_HeightFog_01");
                break;

            case ZoneID.R206:
                MistPlateEntity = EvDataManager.Instanse.GetFieldEventEntity("P_R_206_HeightFog_01");
                break;

            default:
                MistPlateEntity = null;
                break;
        }

        Update(zoneId);
    }

    public void Terminate()
    {
        MistPlateEntity = null;
    }

    // TODO
    public void Update(ZoneID zoneId) { }

    public void SetVisible(bool visible)
    {
        if (MistPlateEntity != null && MistPlateEntity.isActiveAndEnabled != visible)
            MistPlateEntity.SetActive(visible);
    }
}