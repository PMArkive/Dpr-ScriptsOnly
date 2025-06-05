using System;

public class TradeRecruitmentStateModel : NetStateModel
{
	public TradeRecruitmentState currentState { get; set; }
	public UnionMsgTradeWindow unionMsg { get; set; }
	public int sexId { get; set; }
	public OnlinePlayerCharacter opcCharacter { get; set; }
	public UnionTradeContextMenu contextMenu { get; set; }
	
	public TradeRecruitmentStateModel()
	{
		contextMenu = new UnionTradeContextMenu();
		contextMenu.tradeRecruitmentModel = this;
		contextMenu.SetTransitionType();
	}
	
	// TODO
	protected override void Start() { }
	
	// TODO
	public void ChangeTradeRecruitmentState(TradeRecruitmentState state) { }
	
	// TODO
	public void SetFadeCallBack(Action fadeAction) { }
	
	// TODO
	public void InitCharaState() { }
	
	// TODO
	public override void CloseWindow() { }
	
	// TODO
	public void RecruitmentCancel(CancelModel cancelModel) { }
	
	// TODO
	public void DefaltCancel() { }
	
	// TODO
	public void Cancel() { }
	
	// TODO
	public void TradeSpokenCancel(CancelModel cancelModel) { }
	
	// TODO
	public override void OpenSwitchCancelMsg(bool isCancel) { }
	
	// TODO
	public void ShowTradeYesNoMenu(int index, Action noFunc) { }
}