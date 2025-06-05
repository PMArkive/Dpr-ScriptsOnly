using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NexPlugin
{
	public static class Ranking2
	{
		public const int MAX_BINARY_DATA_LENGTH = 100;
		public const uint MAX_CHART_GET_LENGTH = 20;
		public const uint MAX_PUT_MULTI_SCORES = 20;
		public const uint MAX_RANKING_LENGTH = 100;
		public const int MAX_USERNAME_LENGTH = 20;

		public const bool SCORE_ORDER_ASC = false;
		public const bool SCORE_ORDER_DESC = true;

		// TODO
		public static bool PutScoreAsync(out uint asyncId, IntPtr pNgsFacade, Ranking2ScoreData scoreData, [Optional] [DefaultParameterValue(0ul)] ulong nexUniqueId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
		{
			asyncId = default;
			return default;
		}
		
		// TODO
		public static bool PutScoreAsync(out uint asyncId, IntPtr pNgsFacade, List<Ranking2ScoreData> scoreDataList, [Optional] [DefaultParameterValue(0ul)] ulong nexUniqueId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool PutCommonDataAsync(out uint asyncId, IntPtr pNgsFacade, Ranking2CommonData commonData, [Optional] [DefaultParameterValue(0ul)] ulong nexUniqueId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetCommonDataAsync(out uint asyncId, IntPtr pNgsFacade, [Optional] [DefaultParameterValue(Ranking2GetOptionFlags.NOTHING)] Ranking2GetOptionFlags optionFlags, [Optional] [DefaultParameterValue(0ul)] ulong principalId, [Optional] [DefaultParameterValue(0ul)] ulong nexUniqueId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetCommonDataCB callback)
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
        public static bool GetRankingAsync(out uint asyncId, IntPtr pNgsFacade, Ranking2GetParam getParam, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetRankingCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetRankingAsync(out uint asyncId, IntPtr pNgsFacade, Ranking2GetByListParam getParam, List<ulong> principalIdList, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetRankingCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetCategorySettingAsync(out uint asyncId, IntPtr pNgsFacade, uint category, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetCategorySettingCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetRankingChartAsync(out uint asyncId, IntPtr pNgsFacade, Ranking2ChartInfoInput info, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetRanking2ChartInfoCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetRankingChartAsync(out uint asyncId, IntPtr pNgsFacade, List<Ranking2ChartInfoInput> info, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetRanking2ChartInfoListCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetEstimateScoreRankAsync(out uint asyncId, IntPtr pNgsFacade, Ranking2EstimateScoreRankInput info, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetRanking2EstimateScoreRankCB callback)
        {
            asyncId = default;
            return default;
        }

        public enum Ranking2SortFlags : int
		{
			NOTHING = 0,
			MOVE_TO_TOP_IN_TIE = 4,
		}

		public enum Ranking2GetOptionFlags : int
		{
			NOTHING = 0,
		}

		public enum Ranking2Mode : byte
		{
			USER_RANKING = 0,
			NEAR_RANKING = 1,
			RANGE_RANKING = 2,
			FRIEND_RANKING = 3,
			MIN = 0,
			MAX = 3,
		}

		public enum Ranking2ResetMode : byte
		{
			NOTHING = 0,
			EVERYDAY = 1,
			EVERYWEEK = 2,
			MULTI_MONTH = 3,
			MULTI_MONTH_WEEKDAY = 4,
			MIN = 0,
			MAX = 4,
		}

		public delegate void GetCommonDataCB(AsyncResult asyncResult, Ranking2CommonData data);
		public delegate void GetRankingCB(AsyncResult asyncResult, Ranking2Info info);
		public delegate void GetCategorySettingCB(AsyncResult asyncResult, Ranking2CategorySetting setting);
		public delegate void GetRanking2ChartInfoCB(AsyncResult asyncResult, Ranking2ChartInfo info);
		public delegate void GetRanking2ChartInfoListCB(AsyncResult asyncResult, List<Ranking2ChartInfo> info);
        public delegate void GetRanking2EstimateScoreRankCB(AsyncResult asyncResult, Ranking2EstimateScoreRankOutput info);
	}
}