using System;

public class BallDecoJoinStateModel : NetStateModel
{	
	public BallDecoJoinState currentState { get; set; }
	public UnionMsgBallDecoWindow unionMsg { get; set; }
	public int sexId { get; set; }
	public OnlinePlayerCharacter opcCharacter { get; set; }
	public UnionBallDecoContextMenu contextMenu { get; set; }
	
	// TODO
	public BallDecoJoinStateModel() { }
	
	// TODO
	protected override void Start() { }
	
	// TODO
	public void SetFadeCallBack(Action fadeAction) { }
	
	// TODO
	public void InitCharaState() { }
	
	// TODO
	public override void CloseWindow() { }
	
	// TODO
	public void ChangeBallDecoJoinState(BallDecoJoinState state) { }
	
	// TODO
	public void BallDecoWaitCancel(CancelModel cancelModel) { }
	
	// TODO
	public void OpenSwitchMsg(int sexId) { }
	
	// TODO
	public void OpenSwitchFadeMsg(int sexId) { }
	
	// TODO
	public override void OpenSwitchCancelMsg(bool isCancel) { }

	public enum BallDecoJoinState : int
	{
		NONE = 0,
		WAIT = 1,
		CANCEL_MINE = 2,
		CANCEL_OPPONENT = 3,
		BALL_DECO = 4,
	}
}