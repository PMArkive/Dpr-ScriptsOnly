using NexPlugin;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NexAssets
{
	public class Ranking : Common
	{
        // TODO: cctor

        private static Dictionary<int, FunctionInfo> FunctionInfos;
		private static List<ApiCallsFrequency> s_ApiCallsFrequencyList;
		
		// TODO
		public ASYNCSTATE GetRankingAsync(NexAssets.RankingGetRankingParam param, [Optional] [DefaultParameterValue(0ul)] ulong uniqueId, [Optional] [DefaultParameterValue(0ul)] ulong principalId, [Optional] [DefaultParameterValue(false)] bool principalIdUseCurrentLogin, [Optional] NexPlugin.Ranking.GetRankingCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		public ASYNCSTATE GetRankingAsync(NexPlugin.Ranking.RankingMode rankingMode, uint category, NexPlugin.RankingOrderParam param, [Optional] [DefaultParameterValue(0ul)] ulong uniqueId, [Optional] [DefaultParameterValue(0ul)] ulong principalId, [Optional] [DefaultParameterValue(false)] bool principalIdUseCurrentLogin, [Optional] NexPlugin.Ranking.GetRankingCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE GetRankingAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE GetRankingByPIDListAsync(NexAssets.RankingGetRankingParam param, List<ulong> principalIdList, [Optional] [DefaultParameterValue(0ul)] ulong uniqueId, [Optional] NexPlugin.Ranking.GetRankingCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		public ASYNCSTATE GetRankingByPIDListAsync(List<ulong> principalIdList, NexPlugin.Ranking.RankingMode rankingMode, uint category, NexPlugin.RankingOrderParam param, [Optional] [DefaultParameterValue(0ul)] ulong uniqueId, [Optional] NexPlugin.Ranking.GetRankingCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE GetRankingByPIDListAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE GetRankingByUIDListAsync(NexAssets.RankingGetRankingParam param, List<ulong> nexUniqueIdList, [Optional] [DefaultParameterValue(0ul)] ulong uniqueId, [Optional] NexPlugin.Ranking.GetRankingCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		public ASYNCSTATE GetRankingByUIDListAsync(List<ulong> nexUniqueIdList, NexPlugin.Ranking.RankingMode rankingMode, uint category, NexPlugin.RankingOrderParam param, [Optional] [DefaultParameterValue(0ul)] ulong uniqueId, [Optional] NexPlugin.Ranking.GetRankingCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE GetRankingByUIDListAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE GetApproxOrderAsync(NexAssets.RankingGetRankingParam param, uint score, [Optional] [DefaultParameterValue(0ul)] ulong uniqueId, [Optional] [DefaultParameterValue(0ul)] ulong principalId, [Optional] [DefaultParameterValue(false)] bool principalIdUseCurrentLogin, [Optional] NexPlugin.Ranking.GetApproxOrderCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		public ASYNCSTATE GetApproxOrderAsync(uint category, NexPlugin.RankingOrderParam param, uint score, [Optional] [DefaultParameterValue(0ul)] ulong uniqueId, [Optional] [DefaultParameterValue(0ul)] ulong principalId, [Optional] [DefaultParameterValue(false)] bool principalIdUseCurrentLogin, [Optional] NexPlugin.Ranking.GetApproxOrderCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE GetApproxOrderAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE UploadScoreAsync(NexAssets.RankingScoreData scoreData, uint score, [Optional] [DefaultParameterValue(0ul)] ulong uniqueId, [Optional] AsyncResultCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		public ASYNCSTATE UploadScoreAsync(NexPlugin.RankingScoreData param, [Optional] [DefaultParameterValue(0ul)] ulong uniqueId, [Optional] AsyncResultCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE UploadScoreAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE DeleteScoreAsync(uint category, [Optional] [DefaultParameterValue(0ul)] ulong uniqueId, [Optional] AsyncResultCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		public ASYNCSTATE DeleteScoreAsync([Optional] [DefaultParameterValue(0ul)] ulong uniqueId, [Optional] AsyncResultCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE DeleteScoreAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE UploadCommonDataAsync(List<byte> param, [Optional] [DefaultParameterValue(0ul)] ulong uniqueId, [Optional] AsyncResultCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE UploadCommonDataAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE GetCommonDataAsync([Optional] [DefaultParameterValue(0ul)] ulong uniqueId, [Optional] NexPlugin.Ranking.GetCommonDataCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE GetCommonDataAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE DeleteCommonDataAsync([Optional] [DefaultParameterValue(0ul)] ulong uniqueId, [Optional] AsyncResultCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE DeleteCommonDataAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE GetStatsAsync(NexAssets.RankingGetRankingParam param, [Optional] NexPlugin.Ranking.GetStatsCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		public ASYNCSTATE GetStatsAsync(uint category, NexPlugin.RankingOrderParam param, NexPlugin.Ranking.StatsFlag flags, [Optional] NexPlugin.Ranking.GetStatsCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE GetStatsAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE ChangeAttributesAsync(uint category, NexPlugin.RankingChangeAttributesParam param, [Optional] [DefaultParameterValue(0ul)] ulong uniqueId, [Optional] AsyncResultCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		public ASYNCSTATE ChangeAttributesAsync(NexPlugin.RankingChangeAttributesParam param, [Optional] [DefaultParameterValue(0ul)] ulong uniqueId, [Optional] AsyncResultCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE ChangeAttributesAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE GetCachedTopXRankingAsync(uint category, NexPlugin.RankingOrderParam param, [Optional] NexPlugin.Ranking.GetCachedTopXRankingCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE GetCachedTopXRankingAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE GetCachedTopXRankingsAsync(List<uint> categorieList, NexPlugin.RankingOrderParam param, [Optional] NexPlugin.Ranking.GetCachedTopXRankingsCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		public ASYNCSTATE GetCachedTopXRankingsAsync(List<uint> categorieList, List<NexPlugin.RankingOrderParam> paramList, [Optional] NexPlugin.Ranking.GetCachedTopXRankingsCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE GetCachedTopXRankingsAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		private bool ApiCallsFrequencyCheck(int type) { return default; }

		private class GETRANK_ARG : CORE_ARG
		{
			public NexPlugin.Ranking.RankingMode rankingMode;
			public uint category;
			public NexPlugin.RankingOrderParam param;
			public ulong uniqueId;
			public bool principalIdUseCurrentLogin;
			public ulong principalId;
			public int timeOut;
			public NexPlugin.Ranking.GetRankingCB callback;
		}

		private class GETRANK_BYPIDLIST_ARG : CORE_ARG
		{
			public NexPlugin.Ranking.RankingMode rankingMode;
			public uint category;
			public NexPlugin.RankingOrderParam param;
			public ulong uniqueId;
			public List<ulong> principalIdList;
			public int timeOut;
			public NexPlugin.Ranking.GetRankingCB callback;
		}

		private class GETRANK_BYUIDLIST_ARG : CORE_ARG
		{
			public NexPlugin.Ranking.RankingMode rankingMode;
			public uint category;
			public NexPlugin.RankingOrderParam param;
			public ulong uniqueId;
			public List<ulong> nexUniqueIdList;
			public int timeOut;
			public NexPlugin.Ranking.GetRankingCB callback;
		}

		private class GET_APPROX_ARG : CORE_ARG
		{
			public uint category;
			public NexPlugin.RankingOrderParam param;
			public uint score;
			public ulong uniqueId;
			public bool principalIdUseCurrentLogin;
			public ulong principalId;
			public int timeOut;
			public NexPlugin.Ranking.GetApproxOrderCB callback;
		}

		private class UPLOADRANK_ARG : CORE_ARG
		{
			public NexPlugin.RankingScoreData param;
			public ulong uniqueId;
			public int timeOut;
			public AsyncResultCB callback;
		}

		private class DELETERANK_ARG : CORE_ARG
		{
			public ulong uniqueId;
			public uint? category;
			public int timeOut;
			public AsyncResultCB callback;
		}

		private class UPLOADCOMMON_ARG : CORE_ARG
		{
			public List<byte> param;
			public ulong uniqueId;
			public int timeOut;
			public AsyncResultCB callback;
		}

		private class GETCOMMON_ARG : CORE_ARG
		{
			public ulong uniqueId;
			public int timeOut;
			public NexPlugin.Ranking.GetCommonDataCB callback;
		}

		private class DELETECOMMON_ARG : CORE_ARG
		{
			public ulong uniqueId;
			public int timeOut;
			public AsyncResultCB callback;
		}

		private class GETSTATS_ARG : CORE_ARG
		{
			public uint category;
			public NexPlugin.RankingOrderParam param;
			public NexPlugin.Ranking.StatsFlag flags;
			public int timeOut;
			public NexPlugin.Ranking.GetStatsCB callback;
		}

		private class CHANGE_ATTRIBUTE_ARG : CORE_ARG
		{
			public uint? category;
			public NexPlugin.RankingChangeAttributesParam param;
			public ulong uniqueId;
			public int timeOut;
			public AsyncResultCB callback;
		}

		private class GET_CACHERANK_ARG : CORE_ARG
		{
			public uint category;
			public NexPlugin.RankingOrderParam param;
			public int timeOut;
			public NexPlugin.Ranking.GetCachedTopXRankingCB callback;
		}

		private class GET_CACHERANK_LIST_ARG : CORE_ARG
		{
			public List<uint> categorieList;
			public List<NexPlugin.RankingOrderParam> paramList;
			public int timeOut;
			public NexPlugin.Ranking.GetCachedTopXRankingsCB callback;
		}

		private enum Functions : int
		{
			Group1 = 0,
			Group2 = 1,
			GetRanking = 2,
			DeleteScore = 3,
			DeleteAllScores = 4,
			UploadScore = 5,
			GetCommonData = 6,
			DeleteCommonData = 7,
			UploadCommonData = 8,
			GetStats = 9,
			GetApproxOrder = 10,
			GetRankingByPIDList = 11,
			GetRankingByUniqueIdList = 12,
			ChangeAttributes = 13,
			ChangeAllAttributes = 14,
			GetCachedTopXRanking = 15,
			GetCachedTopXRankings = 16,
		}
	}
}