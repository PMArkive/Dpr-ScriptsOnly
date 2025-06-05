using System.Collections.Generic;
using UnityEngine;

namespace NexAssets
{
	public class DataStore_Core : Common
	{
        // TODO: cctor

        [SerializeField]
		private DataStoreBaseParam dataStoreBaseParam;
		private static Dictionary<int, FunctionInfo> FunctionInfos;
		private static List<ApiCallsFrequency> s_ApiCallsFrequencyList;
		
		// TODO
		public uint GetHttpThreadPrioritySetting() { return default; }
		
		// TODO
		public uint GetHttpBufferSizeSetting() { return default; }
		
		// TODO
		public uint GetTimeoutBytesPerSecondSetting() { return default; }
		
		// TODO
		public int GetMinimumTimeoutMilliSecondSetting() { return default; }
		
		// TODO
		public uint GetHttpSendSocketBufferSizeSetting() { return default; }
		
		// TODO
		public uint GetHttpRecvSocketBufferSizeSetting() { return default; }
		
		// TODO
		public bool SetHttpThreadPriority() { return default; }
		
		// TODO
		public bool SetHttpThreadPriority(uint priority) { return default; }
		
		// TODO
		public bool GetHttpThreadPriority(ref uint priority) { return default; }
		
		// TODO
		public bool SetHttpBufferSize() { return default; }
		
		// TODO
		public bool SetHttpBufferSize(uint bufferSize) { return default; }
		
		// TODO
		public bool GetHttpBufferSize(ref uint bufferSize) { return default; }
		
		// TODO
		public bool SetDataTransferTimeout() { return default; }
		
		// TODO
		public bool SetDataTransferTimeout(uint timeoutBytesPerSecond, int minimumTimeoutMilliSecond) { return default; }
		
		// TODO
		public bool SetHttpSendSocketBufferSize() { return default; }
		
		// TODO
		public bool SetHttpSendSocketBufferSize(uint size) { return default; }
		
		// TODO
		public bool GetHttpSendSocketBufferSize(ref uint size) { return default; }
		
		// TODO
		public bool SetHttpRecvSocketBufferSize() { return default; }
		
		// TODO
		public bool SetHttpRecvSocketBufferSize(uint size) { return default; }
		
		// TODO
		public bool GetHttpRecvSocketBufferSize(ref uint size) { return default; }
		
		// TODO
		protected bool ApiCallsFrequencyCheck(int type) { return default; }

		protected enum Functions : int
		{
			SearchObject = 0,
			GetObject = 1,
			PostObject = 2,
			PostObject2 = 3,
			PostObject4 = 4,
			PostObject5 = 5,
			UpdateObject = 6,
			GetRating = 7,
			GetRatings = 8,
			GetRatingWithLog = 9,
			CompleteSuspendedPostObject = 10,
			DeleteObject = 11,
			DeleteObjects = 12,
			ChangeMeta = 13,
			ChangeMetas = 14,
			GetMeta = 15,
			GetMetas = 16,
			GetMetasParam = 17,
			RateObject = 18,
			RateObjects = 19,
			RateObjectWithPosting = 20,
			RateObjectsWithPosting = 21,
			ResetRating = 22,
			ResetRatings = 23,
			TouchObject = 24,
			GetPersistenceInfo = 25,
			GetPersistenceInfos = 26,
			PerpetuateObject = 27,
			UnperpetuateObject = 28,
			GetPasswordInfo = 29,
			GetPasswordInfos = 30,
			SearchObjectLight = 31,
		}
	}
}