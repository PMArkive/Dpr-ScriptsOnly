using NexPlugin;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NexAssets
{
	public class DataStore_Upload : DataStore_Core
	{
		// TODO
		public ASYNCSTATE PostObjectAsync(NexPlugin.DataStorePreparePostParam param, byte[] dataArray, [Optional] DataStore.PostCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE PostObjectAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE PostMetaAsync(NexPlugin.DataStorePreparePostParam param, [Optional] DataStore.PostCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE PostMetaAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE PostMetaByIdAsync(ulong dataId, NexPlugin.DataStorePreparePostParam param, [Optional] AsyncResultCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE PostMetaByIdAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE PostMetaByDataListAsync(List<ulong> dataIdList, NexPlugin.DataStorePreparePostParam param, bool transactional, [Optional] DataStore.ResultListCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		public ASYNCSTATE PostMetaByDataListAsync(Dictionary<ulong, NexPlugin.DataStorePreparePostParam> paramList, bool transactional, [Optional] DataStore.ResultListCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE PostMetaByDataListAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE CompleteSuspendedPostObjectAsync(List<ulong> dataIdList, [Optional] AsyncResultCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE CompleteSuspendedPostObjectAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE UpdateObjectAsync(NexPlugin.DataStorePrepareUpdateParam param, byte[] dataArray, [Optional] AsyncResultCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE UpdateObjectAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE ChangeMetaAsync(NexPlugin.DataStoreChangeMetaParam param, [Optional] AsyncResultCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE ChangeMetaAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE ChangeMetaByDataListAsync(List<ulong> dataIdList, NexPlugin.DataStoreChangeMetaParam param, bool transactional, [Optional] DataStore.ResultListCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		public ASYNCSTATE ChangeMetaByDataListAsync(List<NexPlugin.DataStoreChangeMetaParam> paramList, bool transactional, [Optional] DataStore.ResultListCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE ChangeMetaByDataListAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE PerpetuateObjectAsync(ushort slotId, ulong dataId, bool deleteFlag, [Optional] AsyncResultCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE PerpetuateObjectAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE UnperpetuateObjectAsync(ushort slotId, bool deleteFlag, [Optional] AsyncResultCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE UnperpetuateObjectAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE RateObjectAsync(NexPlugin.DataStoreRatingTarget target, NexPlugin.DataStoreRateObjectParam param, [Optional] DataStore.RatingInfoCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE RateObjectAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE RateObjectByDataListAsync(List<NexPlugin.DataStoreRatingTarget> targetList, NexPlugin.DataStoreRateObjectParam param, bool transactional, [Optional] DataStore.RatingInfoListCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		public ASYNCSTATE RateObjectByDataListAsync(List<NexPlugin.DataStoreRatingTarget> targetList, List<NexPlugin.DataStoreRateObjectParam> paramList, bool transactional, [Optional] DataStore.RatingInfoListCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE RateObjectByDataListAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE ResetRatingAsync(DataStoreRatingTarget param, ulong accessPassword, [Optional] AsyncResultCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE ResetRatingAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE ResetRatingAllSlotAsync(ulong dataId, [Optional] AsyncResultCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE ResetRatingAllSlotAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE ResetRatingByDataListAsync(List<ulong> dataIdList, bool transactional, [Optional] DataStore.ResultListCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE ResetRatingByDataListAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE RateObjectWithPostingAsync(NexPlugin.DataStoreRatingTarget target, NexPlugin.DataStoreRateObjectParam rateParam, NexPlugin.DataStorePreparePostParam postParam, [Optional] DataStore.RatingInfoCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE RateObjectWithPostingAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE RateObjectsWithPostingAsync(List<NexPlugin.DataStoreRatingTarget> targetList, NexPlugin.DataStoreRateObjectParam rateParam, NexPlugin.DataStorePreparePostParam postParam, bool transactional, [Optional] DataStore.RatingInfoListCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		public ASYNCSTATE RateObjectsWithPostingAsync(List<NexPlugin.DataStoreRatingTarget> targetList, List<NexPlugin.DataStoreRateObjectParam> rateParamList, List<NexPlugin.DataStorePreparePostParam> postParamList, bool transactional, [Optional] DataStore.RatingInfoListCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE RateObjectsWithPostingAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE TouchObjectAsync(NexPlugin.DataStoreTouchObjectParam param, [Optional] AsyncResultCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE TouchObjectAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }

		private class POSTDATA_ARG : CORE_ARG
		{
			public NexPlugin.DataStorePreparePostParam param;
			public byte[] dataArray;
			public int timeOut;
			public DataStore.PostCB callback;
		}

		private class POSTMETAID_ARG : CORE_ARG
		{
			public NexPlugin.DataStorePreparePostParam param;
			public ulong dataId;
			public int timeOut;
			public AsyncResultCB callback;
		}

		private class POSTMETA_BYLIST_ARG : CORE_ARG
		{
			public List<ulong> dataIdList;
			public List<NexPlugin.DataStorePreparePostParam> paramList;
			public bool transactional;
			public int timeOut;
			public DataStore.ResultListCB callback;
		}

		private class COMPDATA_ARG : CORE_ARG
		{
			public List<ulong> dataIdList;
			public int timeOut;
			public AsyncResultCB callback;
		}

		private class UPDATEDATA_ARG : CORE_ARG
		{
			public NexPlugin.DataStorePrepareUpdateParam param;
			public byte[] dataArray;
			public int timeOut;
			public AsyncResultCB callback;
		}

		private class CHANGEMETA_ARG : CORE_ARG
		{
			public NexPlugin.DataStoreChangeMetaParam param;
			public int timeOut;
			public AsyncResultCB callback;
		}

		private class CHANGEMETA_BYLIST_ARG : CORE_ARG
		{
			public List<ulong> dataIdList;
			public List<NexPlugin.DataStoreChangeMetaParam> paramList;
			public bool transactional;
			public int timeOut;
			public DataStore.ResultListCB callback;
		}

		private class PERPETUATE_ARG : CORE_ARG
		{
			public ulong dataId;
			public ushort slotId;
			public bool deleteFlag;
			public int timeOut;
			public AsyncResultCB callback;
		}

		private class UNPERPETUATE_ARG : CORE_ARG
		{
			public ushort slotId;
			public bool deleteFlag;
			public int timeOut;
			public AsyncResultCB callback;
		}

		private class RATING_ARG : CORE_ARG
		{
			public NexPlugin.DataStoreRatingTarget target;
			public NexPlugin.DataStoreRateObjectParam param;
			public int timeOut;
			public DataStore.RatingInfoCB callback;
		}

		private class RATING_BYLIST_ARG : CORE_ARG
		{
			public List<NexPlugin.DataStoreRatingTarget> targetList;
			public List<NexPlugin.DataStoreRateObjectParam> paramList;
			public bool transactional;
			public int timeOut;
			public DataStore.RatingInfoListCB callback;
		}

		private class RESETRATING_ARG : CORE_ARG
		{
			public NexPlugin.DataStoreRatingTarget param;
			public ulong accessPassword;
			public int timeOut;
			public AsyncResultCB callback;
		}

		private class RESETRATINGALLSLOT_ARG : CORE_ARG
		{
			public ulong dataId;
			public int timeOut;
			public AsyncResultCB callback;
		}

		private class RESETRATING_BYLIST_ARG : CORE_ARG
		{
			public List<ulong> dataIdList;
			public bool transactional;
			public int timeOut;
			public DataStore.ResultListCB callback;
		}

		private class RATEWITH_POST_ARG : CORE_ARG
		{
			public NexPlugin.DataStoreRatingTarget target;
			public NexPlugin.DataStoreRateObjectParam rateParam;
			public NexPlugin.DataStorePreparePostParam postParam;
			public int timeOut;
			public DataStore.RatingInfoCB callback;
		}

		private class RATEWITH_POST_LIST_ARG : CORE_ARG
		{
			public List<NexPlugin.DataStoreRatingTarget> targetList;
			public List<NexPlugin.DataStoreRateObjectParam> rateParamList;
			public List<NexPlugin.DataStorePreparePostParam> postParamList;
			public bool transactional;
			public int timeOut;
			public DataStore.RatingInfoListCB callback;
		}

		private class TOUCH_OBJECT_ARG : CORE_ARG
		{
			public NexPlugin.DataStoreTouchObjectParam param;
			public int timeOut;
			public AsyncResultCB callback;
		}
	}
}