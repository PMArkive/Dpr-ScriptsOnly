using System;

public class RecodeRecruitmentStateModel : NetStateModel
{
	public RecodeRecruitmentState currentState { get; set; }
	public UnionMsgRecodeWindow unionMsg { get; set; }
	public int sexId { get; set; }
	public OnlinePlayerCharacter opcCharacter { get; set; }
	public UnionRecodeContextMenu contextMenu { get; set; }
	
	public RecodeRecruitmentStateModel()
	{
		contextMenu = new UnionRecodeContextMenu();
		contextMenu.recodeRecruitmentModel = this;
		contextMenu.SetTransitionType();
	}
	
	// TODO
	protected override void Start() { }
	
	// TODO
	public void SetFadeCallBack(Action fadeAction) { }
	
	// TODO
	public void InitCharaState() { }
	
	// TODO
	public void ChangeRecodeRecruitmentState(RecodeRecruitmentState state) { }
	
	// TODO
	public override void CloseWindow() { }
	
	// TODO
	public void RecodeRecruitmentCancel(CancelModel cancelModel) { }
	
	// TODO
	public void Cancel() { }
	
	// TODO
	public void RecodeSpokenCancel(CancelModel cancelModel) { }
	
	// TODO
	public override void OpenSwitchCancelMsg(bool isCancel) { }
	
	// TODO
	public void ShowRecodeYesNoMenu(int index, Action noFunc) { }

	public enum RecodeRecruitmentState : int
	{
		NONE = 0,
		RECODE_RECRUITMENT = 1,
		SELECT = 2,
		CANCEL_MINE = 3,
		CANCEL_OPPONENT = 4,
		TRADE = 5,
	}
}