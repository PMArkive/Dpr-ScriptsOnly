using nn;
using nn.account;
using System.Runtime.InteropServices;

namespace NexPlugin
{
	public static class SmartDeviceVoiceChat
	{
		public const uint DEFAULT_CHANNELID = 0;
		public const uint DEFAULT_HTTP_THREAD_PRIORITY = 16;
		public const uint INVALID_ROOMID = 0;
		
		// TODO
		public static bool ShowAppPageAsync(out uint asyncId, SmartDeviceVoiceChatShowAppPageParam param, [Optional] ShowAppPageCB callback)
		{
			asyncId = default;
			return default;
		}
		
		// TODO
		public static bool ChangeVoiceChatChannelAsync(out uint asyncId, SmartDeviceVoiceChatChangeVoiceChatChannelParam param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetAvailabilityAsync(out uint asyncId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetAvailabilityCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool JoinRoomAsync(out uint asyncId, SmartDeviceVoiceChatJoinRoomParam param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] JoinRoomCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool LeaveRoomAsync(out uint asyncId, SmartDeviceVoiceChatLeaveRoomParam param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool LeaveRoom(SmartDeviceVoiceChatLeaveRoomParam param) { return default; }

		public static extern bool GetLastAccountNnResult(ref Result result);
		public static extern bool GetHttpThreadPriority(ref uint priority);
		public static extern bool SetHttpThreadPriority(uint httpThreadPriority);
		public static extern bool SetUserHandle(UserHandle userHandle);

		public enum ShowAppResultStatus : int
		{
			SHOW_APP_RESULT_STATUS_ERROR = 0,
			SHOW_APP_RESULT_STATUS_CANCELED = 1,
		}

		public delegate void GetAvailabilityCB(AsyncResult asyncResult, bool availability);
		public delegate void JoinRoomCB(AsyncResult asyncResult, SmartDeviceVoiceChatJoinRoomResult result);
		public delegate void ShowAppPageCB(AsyncResult asyncResult, SmartDeviceVoiceChatShowAppPageResult result);
	}
}