using Dpr.MsgWindow;
using System;
using System.Collections.Generic;

public class TradeSecurityStateMessageWindow
{
	private const int NET_WAITING_MESSAGE_INDEX = 0;
	private const int NET_ERORR_TRADE_MESSAGE_INDEX = 1;

	public MsgWindow msgWindow;
	private List<MsgWindowParam> messageParamList = new List<MsgWindowParam>();
	private int messageIndex;
	private Action _Error;
	
	public TradeSecurityStateMessageWindow()
	{
		// Empty, explicitly declared
	}
	
	// TODO
	public void InitMessage() { }
	
	// TODO
	public void OpenMessageNetWaiting() { }
	
	// TODO
	public void OpenMessageNetErrorTrade() { }
	
	// TODO
	public void OpenMessage(int index, bool isShowIcon) { }
	
	// TODO
	public void CloseWindow() { }
	
	// TODO
	private MsgWindowParam CreateMsgWindowParam(string msgFileName, string labelName) { return default; }
	
	// TODO
	public MsgWindowParam GetCurrentMessageParam() { return default; }
}