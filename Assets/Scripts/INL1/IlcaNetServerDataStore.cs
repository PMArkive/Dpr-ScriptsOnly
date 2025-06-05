using NexAssets;
using NexPlugin;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace INL1
{
	public class IlcaNetServerDataStore : IlcaNetServer
	{
		private static IlcaNetDataStoreCompleteCallback compDataStoreCallback = null;
		private static IlcaNetDataStoreCompleteCallback2 compDataStoreCallback2 = null;
		private static Stopwatch sp = new Stopwatch();
		private static TimeSpan span;
		private static MonoBehaviour s_callobj;
		private static DataStore_Upload uploader = new DataStore_Upload();
		private static DataStore_Download downloader = new DataStore_Download();
		private static List<DataStoreRatingTarget> directSetRatingList;
		private static RateObjectParam directSetRatingParameter;
		private static ulong directGetRatingParameter;
		private static GetMetaParam directGetMetaParameter = null;
		private static ChangeMetaParam directChangeMetaParameter = null;
		private static byte[] dataUpdate = null;
		private static PrepareUpdateParam directUpdateParameter = null;
        private static byte[] dataUpload = null;
        private static PreparePostParam directUploadParameter = null;
        private static SearchParam directSearchParameter = null;
        private static ulong dataDownloadID = 0;
		private static uint maxDownloadDataBufferSize = 0;
		private static PrepareGetParam directDownloadParameter = null;
		private static ulong dataDeleteID;
		private static DeleteParam directDeleteParameter = null;
		
		// TODO
		private static IEnumerator UpdateDataStore() { return default; }
		
		// TODO
		private static void UpdateSetRating() { }
		
		// TODO
		public static bool SetRatingAsync(MonoBehaviour callobj, List<DataStoreRatingTarget> targetList, RateObjectParam directSetRatingParameterArg, IlcaNetDataStoreCompleteCallback2 compCallback) { return default; }
		
		// TODO
		private static bool SetRatingAsync(MonoBehaviour callobj, IlcaNetDataStoreCompleteCallback2 compCallback, List<DataStoreRatingTarget> targetList, RateObjectParam directSetRatingParameterArg) { return default; }
		
		// TODO
		private static void ErrorFinalSetRatingCallback() { }
		
		// TODO
		private static void CompSetRatingCallback(AsyncResult asyncResult, List<DataStoreRatingInfo> info, List<DataStoreResult> resultList) { }
		
		// TODO
		private static void UpdateGetRating() { }
		
		// TODO
		public static bool GetRatingAsync(MonoBehaviour callobj, ulong directGetRatingParameter, IlcaNetDataStoreCompleteCallback2 compCallback) { return default; }
		
		// TODO
		private static bool GetRatingAsync(MonoBehaviour callobj, IlcaNetDataStoreCompleteCallback2 compCallback, ulong directGetRatingParameter) { return default; }
		
		// TODO
		private static void ErrorFinalGetRatingCallback() { }
		
		// TODO
		private static void CompGetRatingCallback(AsyncResult asyncResult, Dictionary<sbyte, DataStoreRatingInfo> info) { }
		
		// TODO
		private static void UpdateGetMeta() { }
		
		// TODO
		public static bool GetMetaAsync(MonoBehaviour callobj, GetMetaParam directGetMetaParameter, IlcaNetDataStoreCompleteCallback2 compCallback) { return default; }
		
		// TODO
		private static bool GetMetaAsync(MonoBehaviour callobj, IlcaNetDataStoreCompleteCallback2 compCallback, GetMetaParam directGetMetaParameter) { return default; }
		
		// TODO
		private static void ErrorFinalGetMetaCallback() { }
		
		// TODO
		private static void CompGetMetaCallback(AsyncResult asyncResult, DataStoreMetaInfo info) { }
		
		// TODO
		private static void UpdateChangeMeta() { }
		
		// TODO
		public static bool ChangeMetaAsync(MonoBehaviour callobj, ChangeMetaParam directChangeMetaParameter, IlcaNetDataStoreCompleteCallback2 compCallback) { return default; }
		
		// TODO
		private static bool ChangeMetaAsync(MonoBehaviour callobj, IlcaNetDataStoreCompleteCallback2 compCallback, ChangeMetaParam directChangeMetaParameter) { return default; }
		
		// TODO
		private static void ErrorFinalChangeMetaCallback() { }
		
		// TODO
		private static void CompChangeMetaCallback(AsyncResult asyncResult) { }
		
		// TODO
		private static void UpdateUpdate() { }
		
		// TODO
		public static bool UpdateAsync(MonoBehaviour callobj, byte[] data, PrepareUpdateParam directUpdataParameter, IlcaNetDataStoreCompleteCallback compCallback) { return default; }
		
		// TODO
		private static bool UpdateAsync(MonoBehaviour callobj, byte[] data, IlcaNetDataStoreCompleteCallback compCallback, PrepareUpdateParam directUpdateParameter) { return default; }
		
		// TODO
		private static void ErrorFinalUpdateCallback() { }
		
		// TODO
		private static void CompUpdateCallback(AsyncResult asyncResult) { }
		
		// TODO
		private static void UpdateUpload() { }
		
		// TODO
		public static bool UploadAsync(MonoBehaviour callobj, byte[] data, PreparePostParam directUploadParameter, IlcaNetDataStoreCompleteCallback compCallback) { return default; }
		
		// TODO
		private static bool UploadAsync(MonoBehaviour callobj, byte[] data, IlcaNetDataStoreCompleteCallback compCallback, PreparePostParam directUploadParameter) { return default; }
		
		// TODO
		private static void ErrorFinalUploadCallback() { }
		
		// TODO
		private static void CompUploadCallback(AsyncResult asyncResult, ulong dataId) { }
		
		// TODO
		private static void UpdateSearch() { }
		
		// TODO
		public static bool SearchAsync(MonoBehaviour callobj, SearchParam directSearchParameter, IlcaNetDataStoreCompleteCallback compCallback) { return default; }
		
		// TODO
		private static bool SearchAsync(MonoBehaviour callobj, IlcaNetDataStoreCompleteCallback compCallback, SearchParam directSearchParameter) { return default; }
		
		// TODO
		private static void ErrorFinalSearceCallback() { }
		
		// TODO
		private static void CompSearchCallback(AsyncResult asyncResult, DataStoreSearchResult searchResult) { }
		
		// TODO
		private static void UpdateDownload() { }
		
		// TODO
		public static bool DownloadAsync(MonoBehaviour callobj, PrepareGetParam directDownloadParameter, uint dataBufferSize, IlcaNetDataStoreCompleteCallback compCallback) { return default; }
		
		// TODO
		private static bool DownloadAsync(MonoBehaviour callobj, ulong dataID, uint dataBufferSize, IlcaNetDataStoreCompleteCallback compCallback, PrepareGetParam directDownloadParameter) { return default; }
		
		// TODO
		private static void ErrorFinalDownloadCallback() { }
		
		// TODO
		private static void CompDownloadCallback(AsyncResult asyncResult, byte[] buf) { }
		
		// TODO
		private static void UpdatetDelete() { }
		
		// TODO
		public static bool DeleteAsync(MonoBehaviour callobj, DeleteParam directDeleteParameter, IlcaNetDataStoreCompleteCallback compCallback) { return default; }
		
		// TODO
		private static bool DeleteAsync(MonoBehaviour callobj, ulong dataID, IlcaNetDataStoreCompleteCallback compCallback, DeleteParam directDeleteParameter) { return default; }
		
		// TODO
		private static void ErrorFinalDeleteCallback() { }
		
		// TODO
		private static void CompDeleteCallback(AsyncResult asyncResult) { }

		public class PreparePostParam : NexPlugin.DataStorePreparePostParam { }

		public class SearchParam : NexPlugin.DataStoreSearchParam { }

		public class PrepareGetParam : NexPlugin.DataStorePrepareGetParam { }

		public class DeleteParam : NexPlugin.DataStoreDeleteParam { }

		public class PrepareUpdateParam : NexPlugin.DataStorePrepareUpdateParam { }

		public class GetMetaParam : NexPlugin.DataStoreGetMetaParam { }

		public class ChangeMetaParam : NexPlugin.DataStoreChangeMetaParam { }

		public class RateObjectParam : NexPlugin.DataStoreRateObjectParam { }

		public delegate void IlcaNetDataStoreCompleteCallback(bool isSuccess, IlcaNetDataStoreCallbackEventType eve, ulong dataId, DataStoreSearchResult searchResult, byte[] data);
		public delegate void IlcaNetDataStoreCompleteCallback2(bool isSuccess, IlcaNetDataStoreCallbackEventType eve, DataStoreMetaInfo minfo, Dictionary<sbyte, DataStoreRatingInfo> rinfo);
	}
}