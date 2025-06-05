using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NexPlugin
{
	public static class Ranking
	{
		public const byte MAX_COMMON_DATA_SIZE = 255;
		public const uint MAX_RANGE_RANKING_ORDER = 1000;
		public const uint MAX_ACCURATE_ORDER = 5000;
		
		// TODO
		public static bool UploadCommonDataAsync(out uint asyncId, IntPtr pNgsFacade, List<byte> commonData, [Optional] [DefaultParameterValue(0ul)] ulong nexUniqueId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
		{
			asyncId = default;
			return default;
		}
		
		// TODO
		public static bool DeleteCommonDataAsync(out uint asyncId, IntPtr pNgsFacade, [Optional] [DefaultParameterValue(0ul)] ulong nexUniqueId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetCommonDataAsync(out uint asyncId, IntPtr pNgsFacade, [Optional] [DefaultParameterValue(0ul)] ulong nexUniqueId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetCommonDataCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool UploadScoreAsync(out uint asyncId, IntPtr pNgsFacade, RankingScoreData scoreData, [Optional] [DefaultParameterValue(0ul)] ulong nexUniqueId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool DeleteScoreAsync(out uint asyncId, IntPtr pNgsFacade, uint category, [Optional] [DefaultParameterValue(0ul)] ulong nexUniqueId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool DeleteScoreAsync(out uint asyncId, IntPtr pNgsFacade, [Optional] [DefaultParameterValue(0ul)] ulong nexUniqueId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetRankingAsync(out uint asyncId, IntPtr pNgsFacade, RankingMode rankingMode, uint category, RankingOrderParam orderParam, [Optional] [DefaultParameterValue(0ul)] ulong nexUniqueId, [Optional] [DefaultParameterValue(0ul)] ulong principalId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetRankingCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetRankingByPIDListAsync(out uint asyncId, IntPtr pNgsFacade, List<ulong> principalIdList, RankingMode rankingMode, uint category, RankingOrderParam orderParam, [Optional] [DefaultParameterValue(0ul)] ulong nexUniqueId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetRankingCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetRankingByUIDListAsync(out uint asyncId, IntPtr pNgsFacade, List<ulong> nexUniqueIdList, RankingMode rankingMode, uint category, RankingOrderParam orderParam, [Optional] [DefaultParameterValue(0ul)] ulong nexUniqueId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetRankingCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetApproxOrderAsync(out uint asyncId, IntPtr pNgsFacade, uint category, RankingOrderParam orderParam, uint score, [Optional] [DefaultParameterValue(0ul)] ulong nexUniqueId, [Optional] [DefaultParameterValue(0ul)] ulong principalId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetApproxOrderCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetStatsAsync(out uint asyncId, IntPtr pNgsFacade, uint category, RankingOrderParam orderParam, StatsFlag flags, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetStatsCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool ChangeAttributesAsync(out uint asyncId, IntPtr pNgsFacade, uint category, RankingChangeAttributesParam changeParam, [Optional] [DefaultParameterValue(0ul)] ulong nexUniqueId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool ChangeAttributesAsync(out uint asyncId, IntPtr pNgsFacade, RankingChangeAttributesParam changeParam, [Optional] [DefaultParameterValue(0ul)] ulong nexUniqueId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetCachedTopXRankingAsync(out uint asyncId, IntPtr pNgsFacade, uint category, RankingOrderParam orderParam, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetCachedTopXRankingCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetCachedTopXRankingsAsync(out uint asyncId, IntPtr pNgsFacade, List<uint> categories, RankingOrderParam orderParam, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetCachedTopXRankingsCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetCachedTopXRankingsAsync(out uint asyncId, IntPtr pNgsFacade, List<uint> categories, List<RankingOrderParam> orderParams, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetCachedTopXRankingsCB callback)
        {
            asyncId = default;
            return default;
        }

        public enum RankingMode : int
		{
			RANKING_MODE_RANGE = 0,
			RANKING_MODE_NEAR = 1,
			RANKING_MODE_FRIEND_RANGE = 2,
			RANKING_MODE_FRIEND_NEAR = 3,
			RANKING_MODE_USER = 4,
		}

		public enum FilterGroupIndex : int
		{
			FILTER_GROUP_INDEX_0 = 0,
			FILTER_GROUP_INDEX_1 = 1,
			FILTER_GROUP_INDEX_2 = 2,
			FILTER_GROUP_INDEX_3 = 3,
			FILTER_GROUP_INDEX_NONE = 255,
		}

		public enum OrderBy : int
		{
			ORDER_BY_ASC = 0,
			ORDER_BY_DESC = 1,
		}

		public enum UpdateMode : int
		{
			UPDATE_MODE_NORMAL = 0,
			UPDATE_MODE_DELETE_OLD = 1,
		}

		public enum OrderCalculation : int
		{
			ORDER_CALCULATION_113 = 0,
			ORDER_CALCULATION_123 = 1,
		}

		public enum TimeScope : int
		{
			TIME_SCOPE_CUSTOM_0 = 0,
			TIME_SCOPE_CUSTOM_1 = 1,
			TIME_SCOPE_ALL = 2,
		}

		[Flags]
		public enum ModificationFlag : int
		{
			MODIFICATION_FLAG_NONE = 0,
			MODIFICATION_FLAG_GROUP0 = 1,
			MODIFICATION_FLAG_GROUP1 = 2,
			MODIFICATION_FLAG_GROUP2 = 4,
			MODIFICATION_FLAG_GROUP3 = 8,
			MODIFICATION_FLAG_PARAM = 16,
		}

		[Flags]
		public enum StatsFlag : int
		{
			STATS_FLAG_TOTAL = 1,
			STATS_FLAG_SUM = 2,
			STATS_FLAG_MIN = 4,
			STATS_FLAG_MAX = 8,
			STATS_FLAG_AVERAGE = 16,
		}

		public delegate void GetCommonDataCB(AsyncResult asyncResult, List<byte> data);
		public delegate void GetRankingCB(AsyncResult asyncResult, RankingResult info);
		public delegate void GetApproxOrderCB(AsyncResult asyncResult, uint rank);
		public delegate void GetStatsCB(AsyncResult asyncResult, RankingStats stats);
		public delegate void GetCachedTopXRankingCB(AsyncResult asyncResult, RankingCachedResult info);
		public delegate void GetCachedTopXRankingsCB(AsyncResult asyncResult, List<RankingCachedResult> info);
	}
}