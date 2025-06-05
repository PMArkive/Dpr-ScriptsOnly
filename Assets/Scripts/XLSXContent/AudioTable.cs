using System;
using UnityEngine;

namespace XLSXContent
{
	[Serializable]
	public class AudioTable : ScriptableObject
	{
		public SheetGroup[] Group;
		public SheetBgm[] Bgm;
		public SheetSe[] Se;
		public SheetVoice[] Voice;

        public SheetGroup this[int index] => Group[index];

		[Serializable]
		public class SheetGroup
		{
			public string Group;
			public string Type;
		}

		[Serializable]
		public class SheetBgm
		{
			public string Label;
			public string EventName;
			public string Group;
		}

		[Serializable]
		public class SheetSe
		{
			public string Label;
			public string BankName;
			public string PlayEventName;
			public string StopEventName;
			public string Group;
		}

		[Serializable]
		public class SheetVoice
		{
			public string Label;
			public string BankName;
			public string PlayEventName;
			public string StopEventName;
			public string Group;
		}
	}
}