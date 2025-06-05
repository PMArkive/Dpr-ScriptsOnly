using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NexPlugin
{
    public static class DataStore
    {
        public const ushort MAX_PERIOD = 365;
        public const uint MAX_METABIN_SIZE = 1024;
        public const uint DATASTOREPERMISSION_RECIPIENTIDS_MAX = 100;
        public const ulong INVALID_DATAID = 0;
        public const ushort INVALID_DATA_TYPE = 65535;
        public const ulong INVALID_PASSWORD = 0;
        public const uint MAX_NAME_LENGTH = 64;
        public const uint MAX_SEARCH_RESULT_SIZE = 100;
        public const uint MAX_SEARCH_ANY_RESULT_SIZE = 20;
        public const uint MAX_SEARCH_DATA_TYPE_SIZE = 10;
        public const uint NUM_TAG_SLOT = 16;
        public const uint RATING_SLOT_MAX = 15;
        public const uint NUM_RATING_SLOT = 16;
        public const uint MAX_TAG_LENGTH = 24;
        public const ushort DEFAULT_PERIOD = 90;
        public const uint DEFAULT_HTTP_THREAD_PRIORITY = 16;
        public const uint DEFAULT_RELAY_BUFFER_SIZE = 16384;
        public const uint DEFAULT_HTTP_BUFFER_SIZE = 32768;
        public const uint DEFAULT_DATA_TRANSFER_TIMEOUT_BYTES_PER_SECOND = 167;
        public const int DEFAULT_DATA_TRANSFER_MINIMUM_TIMEOUT = 60000;
        public const uint DEFAULT_HTTP_SEND_SOCKET_BUFFER_SIZE = 65536;
        public const uint DEFAULT_HTTP_RECV_SOCKET_BUFFER_SIZE = 65536;
        public const ushort INVALID_PERSISTENCE_SLOT_ID = 65535;
        public const ushort NUM_PERSISTENCE_SLOT = 16;
        public const uint BATCH_PROCESSING_CAPACITY_POST_OBJECT = 16;
        public const uint BATCH_PROCESSING_CAPACITY = 100;
        public const ulong RESULTRANGE_ANY_OFFSET = 4294967295;
        public const uint RESULTRANGE_DEFAULT_SIZE = 20;

        // TODO
        public static bool PostObjectAsync<T>(out uint asyncId, IntPtr pNgsFacade, DataStorePreparePostParam param, T[] array, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] PostCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool PostMetaAsync(out uint asyncId, IntPtr pNgsFacade, DataStorePreparePostParam param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] PostCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool PostMetaAsync(out uint asyncId, IntPtr pNgsFacade, ulong dataId, DataStorePreparePostParam param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool PostMetaAsync(out uint asyncId, IntPtr pNgsFacade, Dictionary<ulong, DataStorePreparePostParam> param, [Optional] [DefaultParameterValue(true)] bool transactional, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] ResultListCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool PostMetaAsync(out uint asyncId, IntPtr pNgsFacade, List<ulong> dataIds, DataStorePreparePostParam param, [Optional] [DefaultParameterValue(true)] bool transactional, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] ResultListCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool CompleteSuspendedPostObjectAsync(out uint asyncId, IntPtr pNgsFacade, List<ulong> dataIds, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool SearchObjectAsync(out uint asyncId, IntPtr pNgsFacade, DataStoreSearchParam param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] SearchObjectCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool SearchObjectLightAsync(out uint asyncId, IntPtr pNgsFacade, DataStoreSearchParam param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] SearchObjectCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool DeleteObjectAsync(out uint asyncId, IntPtr pNgsFacade, DataStoreDeleteParam param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool DeleteObjectAsync(out uint asyncId, IntPtr pNgsFacade, ulong dataId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool DeleteObjectAsync(out uint asyncId, IntPtr pNgsFacade, List<DataStoreDeleteParam> param, [Optional] [DefaultParameterValue(true)] bool transactional, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] ResultListCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool DeleteObjectAsync(out uint asyncId, IntPtr pNgsFacade, List<ulong> dataIds, [Optional] [DefaultParameterValue(true)] bool transactional, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] ResultListCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool UpdateObjectAsync<T>(out uint asyncId, IntPtr pNgsFacade, DataStorePrepareUpdateParam param, T[] array, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetObjectAsync(out uint asyncId, IntPtr pNgsFacade, DataStorePrepareGetParam param, ulong getBufSize, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetObjectCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool TouchObjectAsync(out uint asyncId, IntPtr pNgsFacade, DataStoreTouchObjectParam param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetMetaAsync(out uint asyncId, IntPtr pNgsFacade, DataStoreGetMetaParam param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetMetaCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetMetaAsync(out uint asyncId, IntPtr pNgsFacade, List<ulong> dataIds, DataStoreGetMetaParam param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetMetaListCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetMetaAsync(out uint asyncId, IntPtr pNgsFacade, List<DataStoreGetMetaParam> param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetMetaListCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool ChangeMetaAsync(out uint asyncId, IntPtr pNgsFacade, DataStoreChangeMetaParam param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool ChangeMetaAsync(out uint asyncId, IntPtr pNgsFacade, List<ulong> dataIds, DataStoreChangeMetaParam param, [Optional] [DefaultParameterValue(true)] bool transactional, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] ResultListCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool ChangeMetaAsync(out uint asyncId, IntPtr pNgsFacade, List<DataStoreChangeMetaParam> param, [Optional] [DefaultParameterValue(true)] bool transactional, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] ResultListCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool RateObjectAsync(out uint asyncId, IntPtr pNgsFacade, DataStoreRatingTarget target, DataStoreRateObjectParam param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] RatingInfoCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool RateObjectAsync(out uint asyncId, IntPtr pNgsFacade, List<DataStoreRatingTarget> target, DataStoreRateObjectParam param, [Optional] [DefaultParameterValue(true)] bool transactional, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] RatingInfoListCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool RateObjectAsync(out uint asyncId, IntPtr pNgsFacade, List<DataStoreRatingTarget> target, List<DataStoreRateObjectParam> param, [Optional] [DefaultParameterValue(true)] bool transactional, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] RatingInfoListCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool RateObjectWithPostingAsync(out uint asyncId, IntPtr pNgsFacade, DataStoreRatingTarget target, DataStoreRateObjectParam rateParam, DataStorePreparePostParam postParam, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] RatingInfoCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool RateObjectsWithPostingAsync(out uint asyncId, IntPtr pNgsFacade, List<DataStoreRatingTarget> target, List<DataStoreRateObjectParam> rateParam, List<DataStorePreparePostParam> postParam, [Optional] [DefaultParameterValue(true)] bool transactional, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] RatingInfoListCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool RateObjectsWithPostingAsync(out uint asyncId, IntPtr pNgsFacade, List<DataStoreRatingTarget> target, DataStoreRateObjectParam rateParam, DataStorePreparePostParam postParam, [Optional] [DefaultParameterValue(true)] bool transactional, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] RatingInfoListCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetRatingAsync(out uint asyncId, IntPtr pNgsFacade, DataStoreRatingTarget target, [Optional] [DefaultParameterValue(0ul)] ulong accessPassword, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] RatingInfoCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetRatingAsync(out uint asyncId, IntPtr pNgsFacade, ulong dataId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] RatingInfoAllSlotCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetRatingAsync(out uint asyncId, IntPtr pNgsFacade, List<ulong> dataIds, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] RatingInfosListCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetRatingAsync(out uint asyncId, IntPtr pNgsFacade, DataStoreRatingTarget target, [Optional] [DefaultParameterValue(0ul)] ulong accessPassword, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] RatingInfoWithLogCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool ResetRatingAsync(out uint asyncId, IntPtr pNgsFacade, DataStoreRatingTarget target, [Optional] [DefaultParameterValue(0ul)] ulong accessPassword, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool ResetRatingAsync(out uint asyncId, IntPtr pNgsFacade, ulong dataId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool ResetRatingAsync(out uint asyncId, IntPtr pNgsFacade, List<ulong> dataIds, [Optional] [DefaultParameterValue(true)] bool transactional, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] ResultListCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetPersistenceInfoAsync(out uint asyncId, IntPtr pNgsFacade, ulong principalId, ushort persistenceSlotId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetPersistenceInfoCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetPersistenceInfoAsync(out uint asyncId, IntPtr pNgsFacade, ulong principalId, List<ushort> persistenceSlotIds, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetPersistenceInfoListCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool PerpetuateObjectAsync(out uint asyncId, IntPtr pNgsFacade, ushort persistenceSlotId, ulong dataId, [Optional] [DefaultParameterValue(true)] bool deleteLastObject, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool UnperpetuateObjectAsync(out uint asyncId, IntPtr pNgsFacade, ushort persistenceSlotId, [Optional] [DefaultParameterValue(false)] bool deleteLastObject, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetPasswordInfoAsync(out uint asyncId, IntPtr pNgsFacade, ulong dataId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetPasswordInfoCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetPasswordInfoAsync(out uint asyncId, IntPtr pNgsFacade, List<ulong> dataIds, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetPasswordInfoListCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static extern bool SetHttpThreadPriority(uint priority);

        // TODO
        public static extern bool GetHttpThreadPriority(ref uint priority);

        // TODO
        public static extern bool SetRelayBufferSize(uint relayBufferSize);

        // TODO
        public static extern bool GetRelayBufferSize(ref uint relayBufferSize);

        // TODO
        public static extern bool SetHttpBufferSize(uint httpBufferSize);

        // TODO
        public static extern bool GetHttpBufferSize(ref uint httpBufferSize);

        // TODO
        public static extern bool SetDataTransferTimeout(uint timeoutBytesPerSecond, int minimumTimeoutMilliSecond);

        // TODO
        public static extern bool SetHttpSendSocketBufferSize(uint size);

        // TODO
        public static extern bool GetHttpSendSocketBufferSize(ref uint size);

        // TODO
        public static extern bool SetHttpRecvSocketBufferSize(uint size);

        // TODO
        public static extern bool GetHttpRecvSocketBufferSize(ref uint size);

        public delegate void PostCB(AsyncResult asyncResult, ulong dataId);
        public delegate void ResultListCB(AsyncResult asyncResult, List<DataStoreResult> resultList);
        public delegate void SearchObjectCB(AsyncResult asyncResult, DataStoreSearchResult result);
        public delegate void GetObjectCB(AsyncResult asyncResult, byte[] data);
        public delegate void GetMetaCB(AsyncResult asyncResult, DataStoreMetaInfo info);
        public delegate void GetMetaListCB(AsyncResult asyncResult, List<DataStoreMetaInfo> info, List<DataStoreResult> resultList);
        public delegate void RatingInfoCB(AsyncResult asyncResult, DataStoreRatingInfo info);
        public delegate void RatingInfoAllSlotCB(AsyncResult asyncResult, Dictionary<sbyte, DataStoreRatingInfo> info);
        public delegate void RatingInfoWithLogCB(AsyncResult asyncResult, DataStoreRatingInfo info, DataStoreRatingLog log);
        public delegate void RatingInfoListCB(AsyncResult asyncResult, List<DataStoreRatingInfo> info, List<DataStoreResult> resultList);
        public delegate void RatingInfosListCB(AsyncResult asyncResult, List<Dictionary<sbyte, DataStoreRatingInfo>> info, List<DataStoreResult> resultList);
        public delegate void GetPersistenceInfoCB(AsyncResult asyncResult, DataStorePersistenceInfo info);
        public delegate void GetPersistenceInfoListCB(AsyncResult asyncResult, List<DataStorePersistenceInfo> info, List<DataStoreResult> resultList);
        public delegate void GetPasswordInfoCB(AsyncResult asyncResult, DataStorePasswordInfo info);
        public delegate void GetPasswordInfoListCB(AsyncResult asyncResult, List<DataStorePasswordInfo> info, List<DataStoreResult> resultList);

        public enum Permission : int
        {
            PERMISSION_PUBLIC = 0,
            PERMISSION_FRIEND = 1,
            PERMISSION_SPECIFIED = 2,
            PERMISSION_PRIVATE = 3,
            PERMISSION_SPECIFIED_FRIEND = 4,
        }

        [Flags]
        public enum DataFlag : int
        {
            DATA_FLAG_NONE = 0,
            DATA_FLAG_NEED_REVIEW = 1,
            DATA_FLAG_PERIOD_FROM_LAST_REFERRED = 2,
            DATA_FLAG_USE_READ_LOCK = 4,
            DATA_FLAG_USE_NOTIFICATION_ON_POST = 8,
            DATA_FLAG_USE_NOTIFICATION_ON_UPDATE = 16,
            DATA_FLAG_NOT_USE_FILESERVER = 32,
            DATA_FLAG_NEED_COMPLETION = 64,
        }

        [Flags]
        public enum ModificationFlag : int
        {
            MODIFICATION_FLAG_NONE = 0,
            MODIFICATION_FLAG_NAME = 1,
            MODIFICATION_FLAG_ACCESS_PERMISSION = 2,
            MODIFICATION_FLAG_UPDATE_PERMISSION = 4,
            MODIFICATION_FLAG_PERIOD = 8,
            MODIFICATION_FLAG_METABINARY = 16,
            MODIFICATION_FLAG_TAGS = 32,
            MODIFICATION_FLAG_UPDATED_TIME = 64,
            MODIFICATION_FLAG_DATA_TYPE = 128,
            MODIFICATION_FLAG_STATUS = 512,
        }

        public enum DataStatus : int
        {
            DATA_STATUS_NONE = 0,
            DATA_STATUS_PENDING = 2,
            DATA_STATUS_REJECTED = 5,
        }

        [Flags]
        public enum ComparisonFlag : int
        {
            COMPARISON_FLAG_NONE = 0,
            COMPARISON_FLAG_NAME = 1,
            COMPARISON_FLAG_ACCESS_PERMISSION = 2,
            COMPARISON_FLAG_UPDATE_PERMISSION = 4,
            COMPARISON_FLAG_PERIOD = 8,
            COMPARISON_FLAG_METABINARY = 16,
            COMPARISON_FLAG_TAGS = 32,
            COMPARISON_FLAG_DATA_TYPE = 64,
            COMPARISON_FLAG_STATUS = 256,
            COMPARISON_FLAG_ALL = 65535,
        }

        public enum SearchType : int
        {
            SEARCH_TYPE_PUBLIC = 1,
            SEARCH_TYPE_SEND_FRIEND = 2,
            SEARCH_TYPE_SEND_SPECIFIED = 3,
            SEARCH_TYPE_SEND_SPECIFIED_FRIEND = 4,
            SEARCH_TYPE_SEND = 5,
            SEARCH_TYPE_FRIEND = 6,
            SEARCH_TYPE_RECEIVED_SPECIFIED = 7,
            SEARCH_TYPE_RECEIVED = 8,
            SEARCH_TYPE_PRIVATE = 9,
            SEARCH_TYPE_OWN = 10,
            SEARCH_TYPE_OWN_PENDING = 12,
            SEARCH_TYPE_OWN_REJECTED = 13,
            SEARCH_TYPE_OWN_ALL = 14,
        }

        public enum SearchTarget : int
        {
            SEARCH_TARGET_ANYBODY = 0,
            SEARCH_TARGET_FRIEND = 1,
        }

        public enum SearchSortColumn : int
        {
            SEARCH_SORT_COLUMN_DATAID = 0,
            SEARCH_SORT_COLUMN_CREATED_TIME = 5,
            SEARCH_SORT_COLUMN_UPDATED_TIME = 6,
            SEARCH_SORT_COLUMN_RATING0 = 64,
            SEARCH_SORT_COLUMN_RATING1 = 65,
            SEARCH_SORT_COLUMN_RATING2 = 66,
            SEARCH_SORT_COLUMN_RATING3 = 67,
            SEARCH_SORT_COLUMN_RATING4 = 68,
            SEARCH_SORT_COLUMN_RATING5 = 69,
            SEARCH_SORT_COLUMN_RATING6 = 70,
            SEARCH_SORT_COLUMN_RATING7 = 71,
            SEARCH_SORT_COLUMN_RATING8 = 72,
            SEARCH_SORT_COLUMN_RATING9 = 73,
            SEARCH_SORT_COLUMN_RATING10 = 74,
            SEARCH_SORT_COLUMN_RATING11 = 75,
            SEARCH_SORT_COLUMN_RATING12 = 76,
            SEARCH_SORT_COLUMN_RATING13 = 77,
            SEARCH_SORT_COLUMN_RATING14 = 78,
            SEARCH_SORT_COLUMN_RATING15 = 79,
            SEARCH_SORT_COLUMN_RATING_AVERAGE0 = 96,
            SEARCH_SORT_COLUMN_RATING_AVERAGE1 = 97,
            SEARCH_SORT_COLUMN_RATING_AVERAGE2 = 98,
            SEARCH_SORT_COLUMN_RATING_AVERAGE3 = 99,
            SEARCH_SORT_COLUMN_RATING_AVERAGE4 = 100,
            SEARCH_SORT_COLUMN_RATING_AVERAGE5 = 101,
            SEARCH_SORT_COLUMN_RATING_AVERAGE6 = 102,
            SEARCH_SORT_COLUMN_RATING_AVERAGE7 = 103,
            SEARCH_SORT_COLUMN_RATING_AVERAGE8 = 104,
            SEARCH_SORT_COLUMN_RATING_AVERAGE9 = 105,
            SEARCH_SORT_COLUMN_RATING_AVERAGE10 = 106,
            SEARCH_SORT_COLUMN_RATING_AVERAGE11 = 107,
            SEARCH_SORT_COLUMN_RATING_AVERAGE12 = 108,
            SEARCH_SORT_COLUMN_RATING_AVERAGE13 = 109,
            SEARCH_SORT_COLUMN_RATING_AVERAGE14 = 110,
            SEARCH_SORT_COLUMN_RATING_AVERAGE15 = 111,
        }

        public enum SearchSortOrder : int
        {
            SEARCH_SORT_ORDER_ASC = 0,
            SEARCH_SORT_ORDER_DESC = 1,
        }

        [Flags]
        public enum ResultFlag : int
        {
            RESULT_FLAG_TAGS = 1,
            RESULT_FLAG_RATINGS = 2,
            RESULT_FLAG_METABINARY = 4,
            RESULT_FLAG_PERMITTED_IDS = 8,
        }

        public enum RatingLockType : int
        {
            RATING_LOCK_NONE = 0,
            RATING_LOCK_INTERVAL = 1,
            RATING_LOCK_PERIOD = 2,
            RATING_LOCK_PERMANENT = 3,
        }

        public enum RatingFlag : int
        {
            RATING_FLAG_MODIFIABLE = 4,
            RATING_FLAG_ROUND_MINUS = 8,
            RATING_FLAG_DISABLE_SELF_RATING = 16,
        }

        [Flags]
        internal enum RatingInternalFlag : int
        {
            RATING_INTERNAL_FLAG_USE_RANGE_MIN = 2,
            RATING_INTERNAL_FLAG_USE_RANGE_MAX = 4,
        }

        public enum RatingLockPeriod : int
        {
            RATING_LOCK_PERIOD_MON = -1,
            RATING_LOCK_PERIOD_TUE = -2,
            RATING_LOCK_PERIOD_WED = -3,
            RATING_LOCK_PERIOD_THU = -4,
            RATING_LOCK_PERIOD_FRI = -5,
            RATING_LOCK_PERIOD_SAT = -6,
            RATING_LOCK_PERIOD_SUN = -7,
            RATING_LOCK_PERIOD_DAY1 = -17,
        }

        public enum SearchResultTotalCountType : int
        {
            SEARCH_RESULT_TOTAL_EXACT = 0,
            SEARCH_RESULT_TOTAL_MINIMUM = 1,
            SEARCH_RESULT_TOTAL_ESTIMATE = 2,
            SEARCH_RESULT_TOTAL_DISABLED = 3,
        }
    }
}