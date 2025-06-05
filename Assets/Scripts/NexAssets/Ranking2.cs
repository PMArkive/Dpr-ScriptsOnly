using NexPlugin;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NexAssets
{
	public class Ranking2 : Common
	{
        // TODO: cctor

        private static Dictionary<int, FunctionInfo> FunctionInfos;
		private static List<ApiCallsFrequency> s_ApiCallsFrequencyList;
		
		// TODO
		public ASYNCSTATE GetRankingAsync(NexPlugin.Ranking2GetParam param, [Optional] NexPlugin.Ranking2.GetRankingCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE GetRankingAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE GetRankingByPIDListAsync(NexPlugin.Ranking2GetByListParam param, List<ulong> principalIdList, [Optional] NexPlugin.Ranking2.GetRankingCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE GetRankingByPIDListAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE PutScoreAsync(NexAssets.Ranking2ScoreData param, uint score, [Optional] [DefaultParameterValue(0ul)] ulong uniqueId, [Optional] AsyncResultCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		public ASYNCSTATE PutScoreAsync(NexPlugin.Ranking2ScoreData param, [Optional] [DefaultParameterValue(0ul)] ulong uniqueId, [Optional] AsyncResultCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE PutScoreAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE PutScoreListAsync(List<NexPlugin.Ranking2ScoreData> paramList, [Optional] [DefaultParameterValue(0ul)] ulong uniqueId, [Optional] AsyncResultCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE PutScoreListAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE PutCommonDataAsync(NexPlugin.Ranking2CommonData param, [Optional] [DefaultParameterValue(0ul)] ulong uniqueId, [Optional] AsyncResultCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE PutCommonDataAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE GetCommonDataAsync(NexPlugin.Ranking2.Ranking2GetOptionFlags optionFlags, [Optional] [DefaultParameterValue(0ul)] ulong principalId, [Optional] [DefaultParameterValue(0ul)] ulong uniqueId, [Optional] [DefaultParameterValue(false)] bool principalIdUseCurrentLogin, [Optional] NexPlugin.Ranking2.GetCommonDataCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE GetCommonDataAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE DeleteCommonDataAsync([Optional] [DefaultParameterValue(0ul)] ulong uniqueId, [Optional] AsyncResultCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE DeleteCommonDataAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE GetCategorySettingAsync(uint category, [Optional] NexPlugin.Ranking2.GetCategorySettingCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE GetCategorySettingAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE GetEstimateScoreRankAsync(NexAssets.Ranking2EstimateScoreRankInput param, uint score, [Optional] NexPlugin.Ranking2.GetRanking2EstimateScoreRankCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		public ASYNCSTATE GetEstimateScoreRankAsync(NexPlugin.Ranking2EstimateScoreRankInput param, [Optional] NexPlugin.Ranking2.GetRanking2EstimateScoreRankCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE GetEstimateScoreRankAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE GetRankingChartAsync(NexAssets.Ranking2ChartInfoInput param, [Optional] NexPlugin.Ranking2.GetRanking2ChartInfoCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		public ASYNCSTATE GetRankingChartAsync(NexPlugin.Ranking2ChartInfoInput param, [Optional] NexPlugin.Ranking2.GetRanking2ChartInfoCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE GetRankingChartAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE GetRankingChartsAsync(List<NexPlugin.Ranking2ChartInfoInput> param, [Optional] NexPlugin.Ranking2.GetRanking2ChartInfoListCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE GetRankingChartsAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		private bool ApiCallsFrequencyCheck(int type) { return default; }

		private class GETRANKING_ARG : CORE_ARG
		{
			public NexPlugin.Ranking2GetParam param;
			public int timeOut;
			public NexPlugin.Ranking2.GetRankingCB callback;
		}

		private class GETRANKINGBYLIST_ARG : CORE_ARG
		{
			public NexPlugin.Ranking2GetByListParam param;
			public List<ulong> principalIdList;
			public int timeOut;
			public NexPlugin.Ranking2.GetRankingCB callback;
		}

		private class PUTSCORE_ARG : CORE_ARG
		{
			public NexPlugin.Ranking2ScoreData param;
			public ulong uniqueId;
			public int timeOut;
			public AsyncResultCB callback;
		}

		private class PUTSCORELIST_ARG : CORE_ARG
		{
			public List<NexPlugin.Ranking2ScoreData> paramList;
			public ulong uniqueId;
			public int timeOut;
			public AsyncResultCB callback;
		}

		private class PUTCOMMON_ARG : CORE_ARG
		{
			public NexPlugin.Ranking2CommonData param;
			public ulong uniqueId;
			public int timeOut;
			public AsyncResultCB callback;
		}

		private class GETCOMMON_ARG : CORE_ARG
		{
			public NexPlugin.Ranking2.Ranking2GetOptionFlags optionFlags;
			public ulong uniqueId;
			public bool principalIdUseCurrentLogin;
			public ulong principalId;
			public int timeOut;
			public NexPlugin.Ranking2.GetCommonDataCB callback;
		}

		private class DELETECOMMON_ARG : CORE_ARG
		{
			public ulong uniqueId;
			public int timeOut;
			public AsyncResultCB callback;
		}

		private class GETCATEGORY_ARG : CORE_ARG
		{
			public uint category;
			public int timeOut;
			public NexPlugin.Ranking2.GetCategorySettingCB callback;
		}

		private class GETESTIMATESCORERANK_ARG : CORE_ARG
		{
			public NexPlugin.Ranking2EstimateScoreRankInput param;
			public int timeOut;
			public NexPlugin.Ranking2.GetRanking2EstimateScoreRankCB callback;
		}

		private class GETRANKINGCHART_ARG : CORE_ARG
		{
			public NexPlugin.Ranking2ChartInfoInput param;
			public int timeOut;
			public NexPlugin.Ranking2.GetRanking2ChartInfoCB callback;
		}

		private class GETRANKINGCHARTS_ARG : CORE_ARG
		{
			public List<NexPlugin.Ranking2ChartInfoInput> param;
			public int timeOut;
			public NexPlugin.Ranking2.GetRanking2ChartInfoListCB callback;
		}

		private enum Functions : int
		{
			GetRanking = 0,
			GetRankingPid = 1,
			GetCategorySetting = 2,
			PutScore = 3,
			PutCommonData = 4,
			GetCommonData = 5,
			DeleteCommonData = 6,
			GetEstimateScoreRank = 7,
			GetRankingChart = 8,
			GetRankingCharts = 9,
		}
	}
}