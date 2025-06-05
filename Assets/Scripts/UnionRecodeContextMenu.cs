using System;

public class UnionRecodeContextMenu : UnionContextMenu
{
	public Action<int, int, int> _setMatchPlayerData;
	public Action<int> _sendMatchWait;
	public Action<int> _TradeOk;
	public Action<int> _TradeNo;
	
	public RecodeRecruitmentStateModel recodeRecruitmentModel { get; set; }
	public RecodeJoinStateModel recodeJoinStateModel { get; set; }
	
	// TODO
	public void SetCallBack(Action<int, int, int> setMacthFunc) { }
	
	// TODO
	public void ClearCallBack() { }
	
	// TODO
	public void ShowRecodeYesNoWindow(int targetIndex, Action noFunc) { }
	
	// TODO
	public void SetActionFade(Action fadeFunc) { }
	
	// TODO
	public void SetTransitionType() { }
}