using DPData;
using Dpr.MsgWindow;
using Dpr.NetworkUtils;
using Dpr.UI;
using System;
using static TvWork;

public class RecodeMatching : UIWindow
{
	private Action _onClose;

	private const string MESSAGE_FILE = "dp_net_communication";

	private RecodeData _recodeData;
	private int _otherStationIndex;
	private bool _isTradingRecode;
	private bool _isReceivedRecode;
	private bool _isSendRecode;
	private bool _isEndTrading;
	private bool _isShowingCloseMessage;
	private float _waitProgressTime;
	private bool _waitingTime;
	private bool _isError;
	public bool isOpen;
	private bool _playingSE;
	private float _seProgressTime;
	
	// TODO
	public void Init() { }
	
	// TODO
	public void Open(int otherStationIndex, Action onClose) { }
	
	// TODO
	public void ForceClose() { }
	
	// TODO
	private void Close() { }
	
	// TODO
	private void CloseFlow() { }
	
	// TODO
	private void OnUpdate(float deltaTime) { }
	
	// TODO
	public void LeaveMine() { }
	
	// TODO
	public void LeaveOther() { }
	
	// TODO
	protected override void OpenMessageWindow(MsgWindowParam messageParam) { }
	
	// TODO
	private void ShowCloseMessage(bool cancel) { }
	
	// TODO
	private void StartRecodeTrade() { }
	
	// TODO
	private void WaitMinTime() { }
	
	// TODO
	private void AddRecodeMatching(int index, RANDOM_SEED groupData, RECORD recodeData, RECORD_HEAD recodeHeadData, TvWork.RecordData tvRecord) { }
	
	// TODO
	private void StartRecodeTradeFlow() { }
	
	// TODO
	private void ApplyTvRecode()
	{
		// TODO
        void SetTvTopic(TopicData topicData, RecordData recordData) { }
    }
	
	// TODO
	private void RecodeTradeEnd() { }
	
	// TODO
	public void ReceiveData(INetData netData) { }
	
	// TODO
	private void ReceiveRecodeData(NetDataRecodeData data) { }
	
	// TODO
	private void SendRecodeData() { }
	
	// TODO
	private void PlaySE() { }
	
	// TODO
	private void StopSE() { }

	private struct RecodeData
	{
		public int staIndex;
		public RECORD recode;
		public RANDOM_SEED group;
		public RECORD_HEAD recodeHeadData;
		public RecordData tvRecord;
	}

	private enum TopicData : int
	{
		PERSONALITY = 0,
		BALL_DECO = 1,
		KASEKIHORI = 2,
		STATUE = 3,
		FASHION = 4,
	}
}