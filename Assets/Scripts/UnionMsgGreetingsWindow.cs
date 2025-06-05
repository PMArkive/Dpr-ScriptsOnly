public class UnionMsgGreetingsWindow : UnionBaseMsgWindow
{
	public GreetingsMsgState _currentState { get; set; }

    public int index;

    // TODO
    public override void Init() { }
	
	// TODO
	public void OpenMsgWindow(GreetingsMsgState state, UnionTextData.SpeakerID speakerID = UnionTextData.SpeakerID.SYSTEM) { }
	
	// TODO
	public void CloseMsgWindow() { }
	
	// TODO
	public bool GetIsFinishMessage() { return default; }
	
	// TODO
	private void SetMessages() { }

	public enum GreetingsMsgState : int
	{
		ISGREETINGS = 0,
		GREETINGS_BOY = 1,
		GREETINGS_GIRL = 2,
		SORRY_BOY = 3,
		SORRY_GIRL = 4,
		CAMCEL = 5,
		CAMCEL_BOY = 6,
		CAMCEL_GIRL = 7,
		GREETINGS_START = 8,
		GREETINGS_READY_OK_BOY = 9,
		GREETINGS_READY_OK_GIRL = 10,
		NONE = 11,
	}
}