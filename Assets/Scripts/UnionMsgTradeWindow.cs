using Dpr.MsgWindow;

public class UnionMsgTradeWindow : UnionBaseMsgWindow
{
	public TradeMsgState _currentState { get; set; }

    public int index;

    // TODO
    public override void Init() { }
	
	// TODO
	public void CloseMsgWindow() { }
	
	// TODO
	public MsgWindowParam GetNowMessage() { return default; }
	
	// TODO
	public bool GetIsFinishMessage() { return default; }
	
	// TODO
	private void SetMessages() { }

	public enum TradeMsgState : int
	{
		ISTRADE = 0,
		TRADE_BOY = 1,
		TRADE_GIRL = 2,
		SORRY_BOY = 3,
		SORRY_GIRL = 4,
		CAMCEL = 5,
		CAMCEL_BOY = 6,
		CAMCEL_GIRL = 7,
		TRADE_START = 8,
		TRADE_READY_OK_BOY = 9,
		TRADE_READY_OK_GIRL = 10,
		NONE = 11,
	}
}