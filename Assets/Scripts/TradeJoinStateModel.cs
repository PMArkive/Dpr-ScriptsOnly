using System;

public class TradeJoinStateModel : NetStateModel
{
	public TradeJoinState currentState { get; set; }
	public UnionMsgTradeWindow unionMsg { get; set; }
	public int sexId { get; set; }
	public OnlinePlayerCharacter opcCharacter { get; set; }
	public UnionTradeContextMenu contextMenu { get; set; }
	
	public TradeJoinStateModel()
	{
		contextMenu = new UnionTradeContextMenu();
		contextMenu.TradeJoinStateModel = this;
		contextMenu.SetTransitionType();
	}
	
	// TODO
	protected override void Start() { }
	
	// TODO
	public void SetFadeCallBack(Action fadeAction) { }
	
	// TODO
	public void InitCharaState() { }
	
	// TODO
	public override void CloseWindow() { }
	
	// TODO
	public void ChangeTradeJoinState(TradeJoinState state) { }
	
	// TODO
	public void DefaltCancel() { }
	
	// TODO
	public void TradeWaitCancel(CancelModel cancelModel) { }
	
	// TODO
	public void OpenSwitchMsg(int sexId) { }
	
	// TODO
	public void OpenSwitchFadeMsg(int sexId) { }
	
	// TODO
	public override void OpenSwitchCancelMsg(bool isCancel) { }

	public enum TradeJoinState : int
	{
		NONE = 0,
		WAIT = 1,
		CANCEL_MINE = 2,
		CANCEL_OPPONENT = 3,
		TRADE = 4,
	}
}