using System;

public class UnionBallDecoContextMenu : UnionContextMenu
{
	public static readonly int TAG_INDEX;
	public Action<int> _TradeOk;
	public Action<int> _TradeNo;

	public BallDecoRecruitmentStateModel ballDecoRecruitmentModel { get; set; }
	public BallDecoJoinStateModel ballDecoJoinStateModel { get; set; }
	
	// TODO
	public void ShowBallDecoYesNoWindow(int targetIndex, Action noFunc) { }
	
	// TODO
	public void SetActionFade(Action fadeFunc) { }
	
	// TODO
	public void SetTransitionType() { }
	
	// TODO
	public int GetTagIndex() { return default; }
}