using Dpr.MsgWindow;

public class UnionMsgBallDecoWindow : UnionBaseMsgWindow
{
    public BallDecoMsgState _currentState { get; set; }

    public int index;
	
	// TODO
	public override void Init() { }
	
	// TODO
	public void OpenMsgWindow(BallDecoMsgState state, UnionTextData.SpeakerID speakerID = UnionTextData.SpeakerID.SYSTEM) { }
	
	// TODO
	public void CloseMsgWindow() { }
	
	// TODO
	public MsgWindowParam GetNowMessage() { return default; }
	
	// TODO
	public bool GetIsFinishMessage() { return default; }
	
	// TODO
	private void SetMessages() { }

	public enum BallDecoMsgState : int
	{
		ISBALLDECO = 0,
		BALLDECO_BOY = 1,
		BALLDECO_GIRL = 2,
		SORRY_BOY = 3,
		SORRY_GIRL = 4,
		CAMCEL = 5,
		CAMCEL_BOY = 6,
		CAMCEL_GIRL = 7,
		BALLDECO_START = 8,
		BALLDECO_READY_OK_BOY = 9,
		BALLDECO_READY_OK_GIRL = 10,
		NONE = 11,
	}
}