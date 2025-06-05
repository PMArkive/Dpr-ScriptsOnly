using System;

public class UnionTradeContextMenu : UnionContextMenu
{
	public Action<int> _TradeOk;
	public Action<int> _TradeNo;

	public TradeRecruitmentStateModel tradeRecruitmentModel { get; set; }
	public TradeJoinStateModel TradeJoinStateModel { get; set; }
	
	// TODO
	public void ShowTradeYesNoWindow(int targetIndex, Action noFunc) { }
	
	// TODO
	public void SetActionFade(Action fadeFunc) { }
	
	// TODO
	public void SetTransitionType() { }
}