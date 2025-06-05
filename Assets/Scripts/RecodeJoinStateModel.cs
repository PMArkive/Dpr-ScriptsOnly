using System;

public class RecodeJoinStateModel : NetStateModel
{
	public RecodeJoinState currentState { get; set; }
	public UnionMsgRecodeWindow unionMsg { get; set; }
	public int sexId { get; set; }
	public OnlinePlayerCharacter opcCharacter { get; set; }
	public UnionRecodeContextMenu contextMenu { get; set; }
	
	public RecodeJoinStateModel()
	{
		contextMenu = new UnionRecodeContextMenu();
		contextMenu.recodeJoinStateModel = this;
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
	public void ChangeRecodeJoinState(RecodeJoinState state) { }
	
	// TODO
	public void RecodeWaitCancel(CancelModel cancelModel) { }
	
	// TODO
	public void OpenSwitchMsg(int sexId) { }
	
	// TODO
	public void OpenSwitchFadeMsg(int sexId) { }
	
	// TODO
	public override void OpenSwitchCancelMsg(bool isCancel) { }

	public enum RecodeJoinState : int
	{
		NONE = 0,
		WAIT = 1,
		CANCEL_MINE = 2,
		CANCEL_OPPONENT = 3,
		RECODE = 4,
	}
}