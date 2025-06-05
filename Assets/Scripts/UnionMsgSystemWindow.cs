using Dpr.MsgWindow;
using System;
using System.Collections.Generic;

public class UnionMsgSystemWindow : UnionBaseMsgWindow
{
	public OpcState.OnlineState playerOnlineState = (OpcState.OnlineState)(-1);
	public int stationIndex;
	public bool isRecruiment;
	public Action<OpcState.OnlineState> _setOpcState;
	public Action<OpcState.OnlineState, NetStateModel.StateModelType> _createModel;
	public Action<int, OpcState.OnlineState, bool> _startCommunication;
	
	// TODO
	public void SetOnlineState(OpcState.OnlineState state) { }
	
	// TODO
	public void SetStationIndex(int index) { }
	
	// TODO
	public void SetIsRecruiment(bool flag) { }
	
	// TODO
	public void OpenGreetingMsgWindow(int index) { }
	
	// TODO
	public void SetMessage(string msgFileName, string[] messageList) { }
	
	// TODO
	public void SetMessage(List<UnionTextData.MsgStringParamData> msgStringParamDataList) { }
	
	// TODO
	public void SetMessageTalkBattle() { }
	
	// TODO
	public void SetMessageTalkTrade() { }
	
	// TODO
	public void SetMessageTalkRecode() { }
	
	// TODO
	public void SetMessageTalkGreeting() { }
	
	// TODO
	public void SetMessageTalkBallDeco() { }
	
	// TODO
	public void OpenMessageTalkBattle(int sexId) { }
	
	// TODO
	public void OpenMessageTalkTrade(int sexId) { }
	
	// TODO
	public void OpenMessageTalkRecode(int sexId) { }
	
	// TODO
	public void OpenMessageTalkGreeting(int sexId) { }
	
	// TODO
	public void OpenMessageTalkBallDeco(int sexId) { }
	
	// TODO
	public void ClearMessage() { }
	
	// TODO
	public void StateAction() { }
	
	// TODO
	public MsgWindowParam GetDefMassageParam() { return default; }
	
	// TODO
	public void SetCloseWindowCallBackChangeOpcState() { }
	
	// TODO
	public void OpenGreetAfterMeesage() { }
	
	// TODO
	public void StateCommunication() { }

	public enum SystemBattleMessageType : int
	{
		CHECK_NICKNAME = 0,
		INTERNET = 1,
		NONE = 2,
	}

	public enum MessageStateTalkBattle : int
	{
		TALK_RANDOM_BOY01 = 0,
		TALK_RANDOM_BOY02 = 1,
		TALK_RANDOM_BOY03 = 2,
		TALK_RANDOM_BOY04 = 3,
		TALK_RANDOM_GIRL01 = 4,
		TALK_RANDOM_GIRL02 = 5,
		TALK_RANDOM_GIRL03 = 6,
		TALK_RANDOM_GIRL04 = 7,
	}

	public enum MessageStateTalkTrade : int
	{
		TALK_RANDOM_BOY01 = 0,
		TALK_RANDOM_BOY02 = 1,
		TALK_RANDOM_GIRL01 = 2,
		TALK_RANDOM_GIRL02 = 3,
	}

	public enum MessageStateTalkRecode : int
	{
		TALK_RANDOM_BOY01 = 0,
		TALK_RANDOM_BOY02 = 1,
		TALK_RANDOM_BOY03 = 2,
		TALK_RANDOM_BOY04 = 3,
		TALK_RANDOM_GIRL01 = 4,
		TALK_RANDOM_GIRL02 = 5,
		TALK_RANDOM_GIRL03 = 6,
		TALK_RANDOM_GIRL04 = 7,
	}

	public enum MessageStateGreeting : int
	{
		TALK_RANDOM_BOY01 = 0,
		TALK_RANDOM_BOY02 = 1,
		TALK_RANDOM_GIRL01 = 2,
		TALK_RANDOM_GIRL02 = 3,
	}

	public enum MessageStateBallDeco : int
	{
		TALK_RANDOM_BOY01 = 0,
		TALK_RANDOM_GIRL01 = 1,
	}
}