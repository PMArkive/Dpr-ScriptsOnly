using System;
using UnityEngine;

namespace XLSXContent
{
	[Serializable]
	public class ContestMasterDatas : ScriptableObject
	{
		public SheetContestData[] ContestData;
		public SheetBgmData[] BgmData;
		public SheetRewardData[] RewardData;
		public SheetRewardItemData[] RewardItemData;
		public SheetRankData[] RankData;
		public SheetConditionScoreData[] ConditionScoreData;
		public SheetFurScoreData[] FurScoreData;
		public SheetSealData[] SealData;
		public SheetItemData[] ItemData;
		public SheetNPCData[] NPCData;
		public SheetNPCLevelData[] NPCLevelData;
		public SheetNPCCapsuleData[] NPCCapsuleData;
		
		public SheetContestData this[int index] => ContestData[index];

		[Serializable]
		public class SheetContestData
		{
			public bool valid_flag;
			public ushort id;
			public int category;
			public int rank;
			public float brClearPersent;
			public float shClearPersent;
			public int maxVisualScore;
			public int brMaxDanceScore;
			public int shMaxDanceScore;
			public int maxWazaScore;
			public int rankPoint;
			public int styleCompatibility;
			public int beautifulCompatibility;
			public int cuteCompatibility;
			public int cleverCompatibility;
			public int strongCompatibility;
			public int furCompatibility;
			public bool canCaptureSingleMode;
			public bool canCaptureMultiMode;
			public int lotMainPhoto;
			public int lotWazaPhoto;
			public int brBgmId;
			public int shBgmId;
			public string brNotesSeq;
			public string shNotesSeq;
			public bool isSaveClearFlag;
			public string brTitleTexName;
			public string shTitleTexName;
			public string brRankTexName;
			public string shRankTexName;
			public string brMedalTexName;
			public string shMedalTexName;
			public EffectContestID monitorID;
			public int rewardID;
		}

		[Serializable]
		public class SheetBgmData
		{
			public bool valid_flag;
			public ushort id;
			public string mainTriggerEvent;
			public string seqFileName;
			public int bgmSigunature;
			public int restNum;
			public int lineNum;
			public int bpm;
			public string iconFileName;
		}

		[Serializable]
		public class SheetRewardData
		{
			public bool valid_flag;
			public ushort id;
			public uint rewardRibbonNo;
			public int[] rewardItemNoArray;
			public int[] probabilityArray;
		}

		[Serializable]
		public class SheetRewardItemData
		{
			public bool valid_flag;
			public ushort id;
			public int itemNo;
			public int itemCount;
		}

		[Serializable]
		public class SheetRankData
		{
			public bool valid_flag;
			public ushort id;
			public int rank;
			public int needPoint;
			public ArenaID arenaID;
		}

		[Serializable]
		public class SheetConditionScoreData
		{
			public bool valid_flag;
			public ushort id;
			public int rank;
			public int conditionValue;
			public int bestCompatibility;
			public int okayCompatibility;
			public float visualScoreFactor;
		}

		[Serializable]
		public class SheetFurScoreData
		{
			public bool valid_flag;
			public ushort id;
			public int score;
		}

		[Serializable]
		public class SheetSealData
		{
			public bool valid_flag;
			public ushort id;
			public int sealNo;
			public int stylePoint;
			public int beautifulPoint;
			public int cutePoint;
			public int cleverPoint;
			public int strongPoint;
			public int tutorialPoint;
			public int furPoint;
		}

		[Serializable]
		public class SheetItemData
		{
			public bool valid_flag;
			public ushort id;
			public int itemNo;
			public int stylePoint;
			public int beautifulPoint;
			public int cutePoint;
			public int cleverPoint;
			public int strongPoint;
			public int tutorialPoint;
			public int furPoint;
		}

		[Serializable]
		public class SheetNPCData
		{
			public bool valid_flag;
			public ushort id;
			public ushort monsNo;
			public string monsLabelName;
			public string trainerLabelName;
			public int trainerType;
			public int npcLevel;
			public bool entryStyleContest;
			public bool entryBeautifulContest;
			public bool entryCuteContest;
			public bool entryCleverContest;
			public bool entryStrongContest;
			public bool entryTutorial;
			public bool entryDPContest;
			public int entryRank;
			public ushort waza1;
			public ushort waza2;
			public ushort waza3;
			public ushort waza4;
			public int[] probabilityArray;
			public int styleValue;
			public int beautifulValue;
			public int cuteValue;
			public int cleverValue;
			public int strongValue;
			public int furValue;
			public int useCapsuleNo;
			public int styleVisualScore;
			public int beautifulVisualScore;
			public int cuteVisualScore;
			public int cleverVisualScore;
			public int strongVisualScore;
			public int tutorialVisualScore;
			public int furVisualScore;
		}

		[Serializable]
		public class SheetNPCLevelData
		{
			public bool valid_flag;
			public ushort id;
			public int npcLevel;
			public float visualScoreFactor;
			public float tapTimingRandMin;
			public float tapTimingRandMax;
			public int densityOrder;
			public int UseComboPersent;
		}

		[Serializable]
		public class SheetNPCCapsuleData
		{
			public bool valid_flag;
			public ushort id;
			public int ballId;
			public SealID sealID1;
			public Vector3 position1;
			public SealID sealID2;
			public Vector3 position2;
			public SealID sealID3;
			public Vector3 position3;
			public SealID sealID4;
			public Vector3 position4;
			public SealID sealID5;
			public Vector3 position5;
			public SealID sealID6;
			public Vector3 position6;
			public SealID sealID7;
			public Vector3 position7;
			public SealID sealID8;
			public Vector3 position8;
			public SealID sealID9;
			public Vector3 position9;
			public SealID sealID10;
			public Vector3 position10;
			public SealID sealID11;
			public Vector3 position11;
			public SealID sealID12;
			public Vector3 position12;
			public SealID sealID13;
			public Vector3 position13;
			public SealID sealID14;
			public Vector3 position14;
			public SealID sealID15;
			public Vector3 position15;
			public SealID sealID16;
			public Vector3 position16;
			public SealID sealID17;
			public Vector3 position17;
			public SealID sealID18;
			public Vector3 position18;
			public SealID sealID19;
			public Vector3 position19;
			public SealID sealID20;
			public Vector3 position20;
		}
	}
}