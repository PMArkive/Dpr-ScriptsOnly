using Dpr.NetworkUtils;
using Dpr.SubContents;
using INL1;
using System;

public class SessionManager
{
	private NetDataParser dataParser;
	public Action<INetData> OnReceiveData;
	public Action<SessionEventData> OnSessionEventCallback;
	public Action OnErrorSession;
	
	// TODO
	public void Init() { }
	
	// TODO
	public void Clear() { }
	
	// TODO
	public void SetCallBack() { }
	
	// TODO
	public void Destroy() { }
	
	// TODO
	public void StartSession(MatchingParam param) { }
	
	// TODO
	private void OnReceivePacket(PacketReader pr) { }
	
	// TODO
	private void OnSessionEvent(SessionEventData data) { }
	
	// TODO
	public void OnFinishedSession() { }
}