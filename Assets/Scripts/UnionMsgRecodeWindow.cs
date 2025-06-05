using Dpr.MsgWindow;

public class UnionMsgRecodeWindow : UnionBaseMsgWindow
{
	public RecodeMsgState _currentState { get; set; }

    public int index;

    // TODO
    public override void Init() { }
	
	// TODO
	public void OpenMsgWindow(RecodeMsgState state, UnionTextData.SpeakerID speakerID = UnionTextData.SpeakerID.SYSTEM) { }
	
	// TODO
	public void CloseMsgWindow() { }
	
	// TODO
	public MsgWindowParam GetNowMessage() { return default; }
	
	// TODO
	public bool GetIsFinishMessage() { return default; }
	
	// TODO
	private void SetMessages() { }

	public enum RecodeMsgState : int
	{
		ISRECODE = 0,
		RECODE_BOY = 1,
		RECODE_GIRL = 2,
		SORRY_BOY = 3,
		SORRY_GIRL = 4,
		CAMCEL = 5,
		CAMCEL_BOY = 6,
		CAMCEL_GIRL = 7,
		RECODE_START = 8,
		RECODE_READY_OK_BOY = 9,
		RECODE_READY_OK_GIRL = 10,
		NONE = 11,
	}
}