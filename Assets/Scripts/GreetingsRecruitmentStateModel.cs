using System;

public class GreetingsRecruitmentStateModel : NetStateModel
{
	public GreetingsRecruitmentState currentState { get; set; }
	public UnionMsgGreetingsWindow unionMsg { get; set; }
	public int sexId { get; set; }
	public OnlinePlayerCharacter opcCharacter { get; set; }
	public UnionGreetingsContextMenu contextMenu { get; set; }
	
	public GreetingsRecruitmentStateModel()
	{
		contextMenu = new UnionGreetingsContextMenu();
		contextMenu.GreetingsRecruitmentModel = this;
		contextMenu.SetTransitionType();
	}
	
	// TODO
	protected override void Start() { }
	
	// TODO
	public void SetFadeCallBack(Action fadeAction) { }
	
	// TODO
	public void InitCharaState() { }
	
	// TODO
	public void ChangeGreetingsRecruitmentState(GreetingsRecruitmentState state) { }
	
	// TODO
	public override void CloseWindow() { }
	
	// TODO
	public void GreetingRecruimentcancel(CancelModel cancelModel) { }
	
	// TODO
	public void Cancel() { }
	
	// TODO
	public void GreetingsSpokenCancel(CancelModel cancelModel) { }
	
	// TODO
	public override void OpenSwitchCancelMsg(bool isCancel) { }
	
	// TODO
	public void ShowGreetingsYesNoMenu(int index, Action noFunc) { }

	public enum GreetingsRecruitmentState : int
	{
		NONE = 0,
		GREETINGS_RECRUITMENT = 1,
		SELECT = 2,
		CANCEL_MINE = 3,
		CANCEL_OPPONENT = 4,
		GREETINGS = 5,
	}
}