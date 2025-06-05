using System;

public class BallDecoRecruitmentStateModel : NetStateModel
{	
	public BallDecoRecruitmentState currentState { get; set; }
	public UnionMsgBallDecoWindow unionMsg { get; set; }
	public int sexId { get; set; }
	public OnlinePlayerCharacter opcCharacter { get; set; }
	public UnionBallDecoContextMenu contextMenu { get; set; }
	
	public BallDecoRecruitmentStateModel()
	{
		contextMenu = new UnionBallDecoContextMenu();
		contextMenu.ballDecoRecruitmentModel = this;
		contextMenu.SetTransitionType();
	}
	
	// TODO
	protected override void Start() { }
	
	// TODO
	public void SetFadeCallBack(Action fadeAction) { }
	
	// TODO
	public void ChangeBallDecoRecruitmentState(BallDecoRecruitmentState state) { }
	
	// TODO
	public void InitCharaState() { }
	
	// TODO
	public override void CloseWindow() { }
	
	// TODO
	public void BallDecoRecruitmentCancel(CancelModel cancelModel) { }
	
	// TODO
	public void Cancel() { }
	
	// TODO
	public void BallDecoSpokenCancel(CancelModel cancelModel) { }
	
	// TODO
	public override void OpenSwitchCancelMsg(bool isCancel) { }
	
	// TODO
	public void ShowBalldecoYesNoMenu(int index, Action noFunc) { }

	public enum BallDecoRecruitmentState : int
	{
		NONE = 0,
		BALLDECO_RECRUITMENT = 1,
		SELECT = 2,
		CANCEL_MINE = 3,
		CANCEL_OPPONENT = 4,
		BALLDECO = 5,
	}
}