namespace NexPlugin
{
	public class SmartDeviceVoiceChatJoinRoomParam
	{
		internal ulong sessionId;
		internal uint gameMode;
		internal uint channelId;
		
		public SmartDeviceVoiceChatJoinRoomParam()
		{
			sessionId = 0;
			gameMode = 0;
			channelId = 0;
		}
		
		// TODO
		public void SetSessionId(ulong sessionId_) { }
		
		// TODO
		public ulong GetSessionId() { return default; }
		
		// TODO
		public void SetGameMode(uint gameMode_) { }
		
		// TODO
		public uint GetGameMode() { return default; }
		
		// TODO
		public void SetChannelId(uint channelId_) { }
		
		// TODO
		public uint GetChannelId() { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}