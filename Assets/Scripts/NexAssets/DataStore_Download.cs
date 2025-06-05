using NexPlugin;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NexAssets
{
	public class DataStore_Download : DataStore_Core
	{
		// TODO
		public ASYNCSTATE SearchObjectAsync(NexPlugin.DataStoreSearchParam param, [Optional] DataStore.SearchObjectCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE SearchObjectAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE SearchObjectLightAsync(NexPlugin.DataStoreSearchParam param, [Optional] DataStore.SearchObjectCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE SearchObjectLightAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE GetObjectAsync(NexPlugin.DataStorePrepareGetParam param, ulong bufSize, [Optional] DataStore.GetObjectCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE GetObjectAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE DeleteObjectAsync(NexPlugin.DataStoreDeleteParam param, [Optional] AsyncResultCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE DeleteObjectAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE DeleteObjectByDataListAsync(List<NexPlugin.DataStoreDeleteParam> paramList, bool transactional, [Optional] DataStore.ResultListCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE DeleteObjectByDataListAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE GetMetaAsync(NexPlugin.DataStoreGetMetaParam param, [Optional] DataStore.GetMetaCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE GetMetaAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE GetMetaByDataListAsync(List<ulong> dataIdList, NexPlugin.DataStoreGetMetaParam param, [Optional] DataStore.GetMetaListCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		public ASYNCSTATE GetMetaByDataListAsync(List<NexPlugin.DataStoreGetMetaParam> paramList, [Optional] DataStore.GetMetaListCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE GetMetaByDataListAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE GetPersistenceInfoAsync(ulong principalId, ushort slotId, [Optional] DataStore.GetPersistenceInfoCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE GetPersistenceInfoAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE GetPersistenceInfoByDataListAsync(ulong principalId, List<ushort> slotIdList, [Optional] DataStore.GetPersistenceInfoListCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE GetPersistenceInfoByDataListAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE GetRatingAsync(NexPlugin.DataStoreRatingTarget param, ulong accessPassword, [Optional] DataStore.RatingInfoCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE GetRatingAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE GetRatingAllSlotAsync(ulong dataId, [Optional] DataStore.RatingInfoAllSlotCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE GetRatingAllSlotAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE GetRatingWithLogAsync(NexPlugin.DataStoreRatingTarget param, ulong accessPassword, [Optional] DataStore.RatingInfoWithLogCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE GetRatingWithLogAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE GetRatingByDataListAsync(List<ulong> dataIdList, [Optional] DataStore.RatingInfosListCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE GetRatingByDataListAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE GetPasswordInfoAsync(ulong dataId, [Optional] DataStore.GetPasswordInfoCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE GetPasswordInfoAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE GetPasswordInfoByDataListAsync(List<ulong> dataIdList, [Optional] DataStore.GetPasswordInfoListCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE GetPasswordInfoByDataListAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }

		private class SEARCHDATA_ARG : CORE_ARG
		{
			public NexPlugin.DataStoreSearchParam param;
			public int timeOut;
			public DataStore.SearchObjectCB callback;
		}

		private class SEARCHDATA_LIGHT_ARG : CORE_ARG
		{
			public NexPlugin.DataStoreSearchParam param;
			public int timeOut;
			public DataStore.SearchObjectCB callback;
		}

		private class GETDATA_ARG : CORE_ARG
		{
			public ulong bufSize;
			public NexPlugin.DataStorePrepareGetParam param;
			public int timeOut;
			public DataStore.GetObjectCB callback;
		}

		private class DELETEDATA_ARG : CORE_ARG
		{
			public NexPlugin.DataStoreDeleteParam param;
			public int timeOut;
			public AsyncResultCB callback;
		}

		private class DELETEDATA_BYLIST_ARG : CORE_ARG
		{
			public List<NexPlugin.DataStoreDeleteParam> paramList;
			public bool transactional;
			public int timeOut;
			public DataStore.ResultListCB callback;
		}

		private class GETMETA_ARG : CORE_ARG
		{
			public NexPlugin.DataStoreGetMetaParam param;
			public int timeOut;
			public DataStore.GetMetaCB callback;
		}

		private class GETMETA_BYLIST_ARG : CORE_ARG
		{
			public List<ulong> dataIdList;
			public List<NexPlugin.DataStoreGetMetaParam> paramList;
			public int timeOut;
			public DataStore.GetMetaListCB callback;
		}

		private class GETPERSISTENCE_ARG : CORE_ARG
		{
			public ulong principalId;
			public ushort slotId;
			public int timeOut;
			public DataStore.GetPersistenceInfoCB callback;
		}

		private class GETPERSISTENCE_BYLIST_ARG : CORE_ARG
		{
			public ulong principalId;
			public List<ushort> slotIdList;
			public int timeOut;
			public DataStore.GetPersistenceInfoListCB callback;
		}

		private class GETRATING_ARG : CORE_ARG
		{
			public DataStoreRatingTarget param;
			public ulong accessPassword;
			public int timeOut;
			public DataStore.RatingInfoCB callback;
		}

		private class GETRATINGALLSLOT_ARG : CORE_ARG
		{
			public ulong dataId;
			public int timeOut;
			public DataStore.RatingInfoAllSlotCB callback;
		}

		private class GETRATING_BYDATALIST_ARG : CORE_ARG
		{
			public List<ulong> dataIdList;
			public int timeOut;
			public DataStore.RatingInfosListCB callback;
		}

		private class GETRATINGWITHLOG_ARG : CORE_ARG
		{
			public NexPlugin.DataStoreRatingTarget param;
			public ulong accessPassword;
			public int timeOut;
			public DataStore.RatingInfoWithLogCB callback;
		}

		private class GETPASS_ARG : CORE_ARG
		{
			public ulong dataId;
			public int timeOut;
			public DataStore.GetPasswordInfoCB callback;
		}

		private class GETPASS_BYLIST_ARG : CORE_ARG
		{
			public List<ulong> dataIdList;
			public int timeOut;
			public DataStore.GetPasswordInfoListCB callback;
		}
	}
}