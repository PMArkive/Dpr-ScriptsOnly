using DG.Tweening;
using System;
using UnityEngine;

namespace XLSXContent
{
	[Serializable]
	public class GMSMasterData : ScriptableObject
	{
		public SheetPoints[] Points;
		public SheetPutRank[] PutRank;
		public SheetWindowMessage[] WindowMessage;
		public SheetLangIconData[] LangIconData;
		public SheetResourceData[] ResourceData;
		public SheetGraphicTextName[] GraphicTextName;
		public SheetNGTradePoke[] NGTradePoke;
		public SheetCameraConfig[] CameraConfig;
		public SheetDistanceConfig[] DistanceConfig;
		public SheetValueData[] ValueData;
		
		public SheetPoints this[int index] => Points[index];

		[Serializable]
		public class SheetPoints
		{
			public bool valid_flag;
			public ushort id;
			public ushort index;
			public Vector3 point;
		}

		[Serializable]
		public class SheetPutRank
		{
			public bool valid_flag;
			public ushort id;
			public int rank;
			public int nextRankCount;
			public int texIndex;
			public int rewardItemNo;
			public int rewardNum;
			public string soundEvent;
		}

		[Serializable]
		public class SheetWindowMessage
		{
			public bool valid_flag;
			public ushort id;
			public string msbt;
			public string msgLabel;
		}

		[Serializable]
		public class SheetLangIconData
		{
			public bool valid_flag;
			public ushort id;
			public string texName;
		}

		[Serializable]
		public class SheetResourceData
		{
			public bool valid_flag;
			public ushort id;
			public string assetbundlePath;
		}

		[Serializable]
		public class SheetGraphicTextName
		{
			public bool valid_flag;
			public ushort id;
			public string spriteName;
		}

		[Serializable]
		public class SheetNGTradePoke
		{
			public bool valid_flag;
			public ushort id;
			public int MonsNo;
		}

		[Serializable]
		public class SheetCameraConfig
		{
			public bool valid_flag;
			public ushort id;
			public int initDistLevel;
			public Vector2 moveSpeedOffset;
			public float distDuration;
			public Ease distEaseType;
			public Vector2 moveSpeed;
			public float snapDuration;
			public Ease snapEaseType;
			public float snapThreshold;
			public float addSpeed;
			public float decSpeed;
			public float maxSpeed;
			public float titleCameraSpeed;
			public float traceSpeed;
		}

		[Serializable]
		public class SheetDistanceConfig
		{
			public bool valid_flag;
			public ushort id;
			public float distance;
			public float checkMoveDot;
			public float enableSnapDot;
		}

		[Serializable]
		public class SheetValueData
		{
			public bool valid_flag;
			public int value;
		}
	}
}