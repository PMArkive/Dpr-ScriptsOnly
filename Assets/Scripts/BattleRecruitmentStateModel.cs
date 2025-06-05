using Dpr.Message;
using Dpr.NetworkUtils;
using System;

public class BattleRecruitmentStateModel : NetStateModel
{	
	public BattleRecruitmentState currentState { get; set; }
	public int sexId { get; set; }
	public OnlinePlayerCharacter opcCharacter { get; set; }
	public UnionBattleContextMenu contextMenu { get; set; }
	public UnionBattleRuleWindow unionBattleRuleWindow { get; set; }

    public int targetStationIndex;

    public BattleRecruitmentStateModel()
	{
		contextMenu = new UnionBattleContextMenu();
		contextMenu.battleRecruitmentModel = this;
		contextMenu.SetTransitionType();
	}
	
	// TODO
	protected override void Start() { }
	
	// TODO
	public void SetMsgWindow() { }
	
	// TODO
	public void SetFadeCallBack(Action fadeAction) { }
	
	// TODO
	public void InitCharaState() { }
	
	// TODO
	public void ChangeBattleRecruitmentState(BattleRecruitmentState state) { }
	
	// TODO
	public void ShowMessageBattleRecuruiment() { }
	
	// TODO
	private void ShowMessageSpoken() { }
	
	// TODO
	public override bool IsCancelable() { return default; }
	
	// TODO
	public void BattleRecruitmentCancel(CancelModel cancelModel) { }
	
	// TODO
	public void BattleSpokenCancel(CancelModel cancelModel) { }
	
	// TODO
	public void TargetBattleRuleCheckCancel(CancelModel cancelModel) { }
	
	// TODO
	public void BattleRuleSelectWait(CancelModel cancelModel) { }
	
	// TODO
	public void BattleRuleCheckCancel(CancelModel cancelModel) { }
	
	// TODO
	public void CancelMine() { }
	
	// TODO
	public void CancelOpponent() { }
	
	// TODO
	public void Battle() { }
	
	// TODO
	public override void CloseWindow() { }
	
	// TODO
	public void OpenSwitchMsg(int sexId) { }
	
	// TODO
	public void OpenSwitchFadeMsg(int sexId) { }
	
	// TODO
	public override void OpenSwitchCancelMsg(bool isCancel) { }
	
	// TODO
	public void ShowBattleRecruitmentYesNoMenu(int stationIndex) { }
	
	// TODO
	public void SetBattleStateWindowText(string nameTxt, BattleModeID battleModeID, MessageEnumData.MsgLangId langId) { }
	
	// TODO
	public void ShowBattleStateWindow(int index, BattleModeID battleModeID) { }
	
	// TODO
	public void HideBattleStateWindow() { }

	public enum BattleRecruitmentState : int
	{
		NONE = 0,
		BATTLE_RECRUITMENT = 1,
		SPOKEN = 2,
		BATTLE_RULE_CHECK_TARGET = 3,
		BATTLE_RULE_SELECT_WAIT = 4,
		BATTLE_RULE_CHECK_MINE = 5,
		CANCEL_MINE = 6,
		CANCEL_OPPONENT = 7,
		BATTLE = 8,
	}
}