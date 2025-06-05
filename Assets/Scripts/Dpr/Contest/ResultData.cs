using Pml;
using UnityEngine;
using XLSXContent;

namespace Dpr.Contest
{
	public class ResultData
	{
		public ContestMasterDatas.SheetRankData[] rankData;
		public ContestMasterDatas.SheetContestData useContestData;
		public ContestConfigDatas.SheetResultCameraTween cameraParam;
		public ContestConfigDatas.SheetResultMotion motionData;
		public ResultID resultID;
		public Sprite resultTitleSpr;
		public Sprite medalSpr;
		public Sprite contestTitleSpr;
		public Sprite rankTitleSpr;
		public ResultPlayerDataModel[] playerDataModelArray;
		public int userIndex;
		public int userPoint;
		public int userRank;
		public int maxTotalScore;
		public int bestPerformerNum;
		public bool isPlayVoice;
		public string playVoiceEventName;
		public CategoryID categoryID;
		public RankID rankID;
		public MonsNo monsNo;
		public WazaNo wazaNo;
		public uint playerFashion;
		public bool isMultiMode;
		public int multiResult;
	}
}