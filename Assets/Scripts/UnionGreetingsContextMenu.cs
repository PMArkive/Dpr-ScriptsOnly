using System;

public class UnionGreetingsContextMenu : UnionContextMenu
{
	public static readonly int TAG_INDEX;
	public Action<int> _TradeOk;
	public Action<int> _TradeNo;

	public GreetingsRecruitmentStateModel GreetingsRecruitmentModel { get; set; }
	public GreetingsJoinStateModel GreetingsJoinStateModel { get; set; }
	
	// TODO
	public void ShowGreetingsYesNoWindow(int targetIndex, Action noFunc) { }
	
	// TODO
	public void SetActionFade(Action fadeFunc) { }
	
	// TODO
	public void SetTransitionType() { }
	
	// TODO
	public int GetTagIndex() { return default; }
}