using Dpr.MsgWindow;
using Dpr.NetworkUtils;
using Dpr.UI;
using System;

public class BallDecoMatching : UIWindow
{
	private Action _onClose;
	private const string MESSAGE_FILE = "ss_net_net_btl";
	private const string MESSAGE_FILE_UNION = "dlp_net_union_room";
	private int _otherStationIndex;
	private bool _isTradingBallDeco;
	private bool _isReceivedBallDeco;
	private bool _isSendBallDeco;
	private bool _isEndTrading;
	private bool _isShowingCloseMessage;
	private float _waitProgressTime;
	private bool _waitingTime;
	private bool _isError;
	public bool isOpen;
	private bool _playingSE;
	private bool _successCopy;
	private NetDataAttachSealNetData _receiveData;
	
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
	private void StartBallDecoTrade() { }
	
	// TODO
	private void WaitMinTime() { }
	
	// TODO
	private void StartBallDecoTradeFlow() { }
	
	// TODO
	private void BallDecoEnd() { }
	
	// TODO
	public void ReceiveData(INetData netData) { }
	
	// TODO
	private void ReceiveBallDecoData(NetDataAttachSealNetData data) { }
	
	// TODO
	private void SendBallDecoData() { }
}