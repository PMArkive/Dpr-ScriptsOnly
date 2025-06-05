using System;
using System.Collections.Generic;

public class UnionFrontDeskMsgWindow : UnionBaseMsgWindow
{
	private const int MESSAGE_INDEX_FRONTDESK = 1;
	private const int MESSAGE_INDEX_NOT_FRONTDESK = 3;

	private bool isFrontDesk;
	public Action _trasitionFunc;
	public Action<bool> _talkEnd;
	public Action _talkStart;
	
	// TODO
	public void SetFrontDesk(bool flag) { }
	
	// TODO
	public void SetMessage(string msgFileName, string[] messageList) { }
	
	// TODO
	public void SetMessage(List<UnionTextData.MsgStringParamData> msgStringParamDataList) { }
	
	// TODO
	public void ClearMessage() { }
	
	// TODO
	public void SetMessageTalkStart() { }
	
	// TODO
	public void SetMessageTalkStartColiseum() { }
	
	// TODO
	private void SetOhanasiMessage() { }
	
	// TODO
	private void SetDescriptionMessage() { }
	
	// TODO
	private void SetDescriptionMessageGlobal() { }
	
	// TODO
	public void SetTradeMessage() { }
	
	// TODO
	public void SetMessageShowIcon(int index, bool isShowIcon) { }
	
	// TODO
	public void OpenMsgChangeInternetMode(int index) { }
	
	// TODO
	public void OpenMsgInternetCheck(int index) { }
	
	// TODO
	public void OpenMessageStartInternetCheck() { }
	
	// TODO
	public void OpenMessageStartInternet() { }
	
	// TODO
	private void OpenMessageTransitionComm() { }
	
	// TODO
	private void SwitchOpenTransitionCommMessage() { }
	
	// TODO
	public void OpenMessageStartDescription() { }
	
	// TODO
	public void OpenMessageDescription(int index, bool isGlobal) { }
	
	// TODO
	public void OpenMessageOhanasi(bool isGlobal) { }
	
	// TODO
	public void OpenTradePaneltyMessage() { }
	
	// TODO
	public void ReturnStartMenu() { }
	
	// TODO
	public void OpenMessageDescriptionColiseum(int index) { }
	
	// TODO
	private void SetDescriptionMessageColiseum() { }
	
	// TODO
	public void OpenTalkEndMessageColiseum() { }
	
	// TODO
	public void OpenTalkNotChangeRuleMessage() { }
	
	// TODO
	public void OpenBattleRuleSelectMessage() { }
	
	// TODO
	public void OpenMsgChangeRuleCheck() { }
	
	// TODO
	public void TalkEnd() { }
	
	// TODO
	public void SetStartMessageNo(int startIndex) { }
}