using Dpr.Message;
using Dpr.NetworkUtils;
using System;

public class BattleJoinStateModel : NetStateModel
{
	public BattleJoinState currentState { get; set; }
	public int sexId { get; set; }
	public OnlinePlayerCharacter opcCharacter { get; set; }
	public UnionBattleContextMenu contextMenu { get; set; }
	public UnionBattleRuleWindow unionBattleRuleWindow { get; set; }
	
	public BattleJoinStateModel()
	{
		contextMenu = new UnionBattleContextMenu();
		contextMenu.battleJoinModel = this;
		contextMenu.SetTransitionType();
	}
	
	// TODO
	protected override void Start() { }
	
	// TODO
	public void SetFadeCallBack(Action fadeAction) { }
	
	// TODO
	public void InitCharaState() { }
	
	// TODO
	public void ChangeBattleJoinState(BattleJoinState state) { }
	
	// TODO
	public void BattleRuleApprovalCancel(CancelModel cancelModel) { }
	
	// TODO
	public void BattleRuleSelectCancel(CancelModel cancelModel) { }
	
	// TODO
	public void BattleRuleSelectEndCancel(CancelModel cancelModel) { }
	
	// TODO
	public override void CloseWindow() { }
	
	// TODO
	public void OpenSwitchMsg(int sexId) { }
	
	// TODO
	public void OpenSwitchFadeMsg(int sexId) { }
	
	// TODO
	public override void OpenSwitchCancelMsg(bool isCancel) { }
	
	// TODO
	public void ShowBattleJoinYesNoMenu(int staIndex) { }
	
	// TODO
	public void SetBattleStateDebugWindowText(string nameTxt, BattleModeID battleModeId, MessageEnumData.MsgLangId langId) { }
	
	// TODO
	public void ShowBattleStateWindow(int index, BattleModeID battleModeId) { }
	
	// TODO
	public void HideBattleStateWindow() { }
	
	// TODO
	private void Decide(int targetIndex, BattleModeID battleModeID) { }
	
	// TODO
	private void Cancel(int targetIndex) { }
	
	// TODO
	public override bool IsCancelable() { return default; }

	public enum BattleJoinState : int
	{
		NONE = 0,
		RULE_APPROVAL = 1,
		RULE_SELECT = 2,
		CANCEL_MINE = 3,
		CANCEL_OPPONENT = 4,
		BATTLE_RULE_SELECT_END = 5,
		BATTLE = 6,
	}
}