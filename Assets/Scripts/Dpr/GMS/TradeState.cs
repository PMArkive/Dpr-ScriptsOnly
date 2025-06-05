namespace Dpr.GMS
{
	public enum TradeState : int
	{
		None = 0,
		StartPreSave = 1,
		StartConnect = 2,
		WaitInternetGo = 3,
		ValidateCheck = 4,
		PreTradeSave = 5,
		StartConnectGMSServer = 6,
		Trading = 7,
		FinishTrade = 8,
		TradeDemo = 9,
		FinishTradeDemo = 10,
		ShowApplicationError = 11,
		ProcessFailed = 12,
		Fatal = 13,
		Finish = 14,
	}
}