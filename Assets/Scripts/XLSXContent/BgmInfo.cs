using System;
using UnityEngine;

namespace XLSXContent
{
	[Serializable]
	public class BgmInfo : ScriptableObject
	{
		public SheetBgmData[] BgmData;
		
        public SheetBgmData this[int index] => BgmData[index];

		[Serializable]
		public class SheetBgmData
		{
			public bool valid_flag;
			public ushort id;
			public string triggerEvent;
			public string seqFileName;
			public int bpm;
			public int introSpan;
		}
	}
}