using Dpr.MsgWindow;

public class UnionMsgBattleWindow : UnionBaseMsgWindow
{	
	public BattleMsgState _currentState { get; set; }

    public int index;

    public OnlinePlayerCharacter onlinePlayer { set; get; }
	public int sexId { set; get; }
	
	// TODO
	public override void Init() { }
	
	// TODO
	public void CloseMsgWindow() { }
	
	// TODO
	public MsgWindowParam GetNowMessage() { return default; }
	
	// TODO
	public bool GetIsFinishMessage() { return default; }
	
	// TODO
	public void OpenSwitchMsg(int sexId) { }
	
	// TODO
	public void OpenSwitchFadeMsg(int sexId) { }
	
	// TODO
	private void SetMessages() { }

	public enum BattleMsgState : int
	{
		ISBATTLE = 0,
		BATTLE_BOY = 1,
		BATTLE_GIRL = 2,
		TARGET_SELECT_WAIT = 3,
		SORRY_BOY = 4,
		SORRY_GIRL = 5,
		CAMCEL = 6,
		CAMCEL_BOY = 7,
		CAMCEL_GIRL = 8,
		BATTLE_START = 9,
		BATTLE_READY_OK_BOY = 10,
		BATTLE_READY_OK_GIRL = 11,
		NONE = 12,
	}
}