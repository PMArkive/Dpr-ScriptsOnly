using Dpr.NetworkUtils;
using System;

public class UnionBattleContextMenu : UnionContextMenu
{
	public Action<int, int, int> _setMatchPlayerData;
	
	public BattleRecruitmentStateModel battleRecruitmentModel { get; set; }
	public BattleJoinStateModel battleJoinModel { get; set; }
	
	// TODO
	public void SetCallBack(Action<int, int, int> setMacthFunc) { }
	
	// TODO
	public void ClearCallBack() { }
	
	// TODO
	public void CreateContextBattleTypeMenu(string mFileName, string[] MenuMessagesList, int stationIndex) { }
	
	// TODO
	public void ShowBattleJoinYesNoWindow(int targetIndex, Action<int, BattleModeID> decide, Action<int> cancel) { }
	
	// TODO
	public void ShowBattleRecruitmentYesNoWindow(int targetIndex) { }
	
	// TODO
	public void ShowBattleJoinOtherYesNoWindow(int targetIndex, Action<int> decide, Action cancel) { }
	
	// TODO
	public void SetActionFade(Action fadeFunc) { }
	
	// TODO
	public void SetTransitionType() { }
	
	// TODO
	private void SendRuleSelectState(int targetIndex) { }
	
	// TODO
	private void SendIsMatchWaitData() { }
	
	// TODO
	private void SendRequestIsMatchWaitData(int stationIndex) { }
}