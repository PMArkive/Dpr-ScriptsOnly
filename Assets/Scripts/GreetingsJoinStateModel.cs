using System;

public class GreetingsJoinStateModel : NetStateModel
{	
	public GreetingsJoinState currentState { get; set; }
	public UnionMsgGreetingsWindow unionMsg { get; set; }
	public int sexId { get; set; }
	public OnlinePlayerCharacter opcCharacter { get; set; }
	public UnionGreetingsContextMenu contextMenu { get; set; }
	
	public GreetingsJoinStateModel()
	{
		contextMenu = new UnionGreetingsContextMenu();
		contextMenu.GreetingsJoinStateModel = this;
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
	public void ChangeGreetingsJoinState(GreetingsJoinState state) { }
	
	// TODO
	public void GreetingsWaitCancel(CancelModel cancelModel) { }
	
	// TODO
	public void OpenSwitchMsg(int sexId) { }
	
	// TODO
	public void OpenSwitchFadeMsg(int sexId) { }
	
	// TODO
	public override void OpenSwitchCancelMsg(bool isCancel) { }

	public enum GreetingsJoinState : int
	{
		NONE = 0,
		WAIT = 1,
		CANCEL_MINE = 2,
		CANCEL_OPPONENT = 3,
		GREETINGS = 4,
	}
}