using nn;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NexPlugin
{
	public static class Subscriber
	{
		public const uint MAX_TOPIC_CONTENT_SIZE = 100;
		public const uint MAX_TIMELINE_CONTENT_SIZE = 100;
		public const uint MAX_FOLLOWING_SIZE = 20;
		public const uint NUM_RESERVED_TOPICS = 128;
		public const uint INVALID_RESERVED_TOPIC_NUM = 4294967295;
		public const uint MAX_GET_FOLLOWER_SIZE = 1000;
		public const uint MAX_CONTENT_MESSAGE_LEN = 140;
		public const uint MAX_CONTENT_BINARY_SIZE = 256;
		public const uint MAX_POST_CONTENT_TOPIC_SIZE = 10;
		public const uint MAX_GET_CONTENT_PARAMS_SIZE = 3;
		public const byte STATUS_KEY_SIZE = 8;
		public const uint MAX_STATUS_BINARY_SIZE = 128;
		public const uint MAX_GET_STATUS_USER_SIZE = 100;
		public const uint DEFAULT_RMC_INTERVAL = 5000;
		
		// TODO
		public static bool PostContentAsync(out uint asyncId, IntPtr pNgsFacade, SubscriberPostContentParam param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] PostContentCB callback)
		{
			asyncId = default;
			return default;
		}
		
		// TODO
		public static bool GetContentAsync(out uint asyncId, IntPtr pNgsFacade, SubscriberGetContentParam param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetContentCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetContentAsync(out uint asyncId, IntPtr pNgsFacade, List<SubscriberGetContentParam> param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetContentsCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool DeleteContentAsync(out uint asyncId, IntPtr pNgsFacade, List<uint> topics, ulong contentId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetFriendUserStatusesAsync(out uint asyncId, IntPtr pNgsFacade, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetSubscriberUserStatusInfoCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetFriendUserStatusesAsync(out uint asyncId, IntPtr pNgsFacade, List<byte> keys, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetSubscriberUserStatusInfoCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetUserStatusesAsync(out uint asyncId, IntPtr pNgsFacade, List<ulong> users, List<byte> keys, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetSubscriberUserStatusInfoCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool UpdateUserStatusAsync(out uint asyncId, IntPtr pNgsFacade, List<SubscriberUserStatusParam> param, [Optional] [DefaultParameterValue(false)] bool isNotify, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
        {
            asyncId = default;
            return default;
        }

        public static extern bool EnableFriendUserStatusesCache(IntPtr pNgsFacade);
		public static extern bool DisableFriendUserStatusesCache(IntPtr pNgsFacade);
		
		// TODO
		public static bool GetFriendUserStatusesCacheMode(IntPtr pNgsFacade, out bool result)
        {
            result = default;
            return default;
        }

        // TODO
        public static bool GetFriendUserStatusesCacheLastResult(IntPtr pNgsFacade, out Result result)
        {
            result = default;
            return default;
        }

        // TODO
        public static bool GetFriendUserStatuses(IntPtr pNgsFacade, out List<SubscriberUserStatusInfo> infos, out Result result)
        {
            infos = default;
            result = default;
            return default;
        }

        // TODO
        public static bool GetFriendUserStatuses(IntPtr pNgsFacade, List<ulong> users, out List<SubscriberUserStatusInfo> infos, out Result result)
        {
            infos = default;
            result = default;
            return default;
        }

        public static extern bool GetUserStatusRevision(IntPtr pNgsFacade, out uint revision);

		public delegate void PostContentCB(AsyncResult asyncResult, ulong contentId);
		public delegate void GetContentCB(AsyncResult asyncResult, List<SubscriberContent> contents);
		public delegate void GetContentsCB(AsyncResult asyncResult, List<List<SubscriberContent>> contents);
		public delegate void GetSubscriberUserStatusInfoCB(AsyncResult asyncResult, List<SubscriberUserStatusInfo> infos);
	}
}