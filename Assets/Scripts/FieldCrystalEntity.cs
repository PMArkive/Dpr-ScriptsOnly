using Dpr.EvScript;

public class FieldCrystalEntity : FieldObjectEntity
{
	protected override void Awake()
	{
		EventParams.ContactLabel = "dummy";
		EventParams.VanishFlagIndex = 1;
		EventParams.WorkIndex = EvWork.WORK_INDEX.SCWK_WK_SAVE_SIZE;
		EventParams.TalkRange = 1.25f;
		EventParams.TalkBit = 15;
    }
	
	public bool IsContact()
	{
		return EvDataManager.Instanse.CanContact2(this, EntityManager.activeFieldPlayer.worldPosition);
	}
}