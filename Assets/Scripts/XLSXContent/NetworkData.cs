using Dpr.NetworkUtils;
using System;
using UnityEngine;

namespace XLSXContent
{
	[Serializable]
	public class NetworkData : ScriptableObject
	{
		public SheetErrorLogInfo[] ErrorLogInfo;
		public SheetErrorDialogInfo[] ErrorDialogInfo;
		
		public SheetErrorLogInfo this[int index] => ErrorLogInfo[index];

		[Serializable]
		public class SheetErrorLogInfo
		{
			public SessionErrorType errorID;
			public string errorLog;
		}

		[Serializable]
		public class SheetErrorDialogInfo
		{
			public uint errorCode;
			public uint errorLevel;
			public int viewType;
			public string useTitleMsbtName;
			public string useTitleLabelName;
			public string useDetailMsbtName;
			public string useDetailLabelName;
		}
	}
}