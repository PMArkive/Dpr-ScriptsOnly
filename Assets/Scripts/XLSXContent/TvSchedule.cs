using System;
using UnityEngine;

namespace XLSXContent
{
	[Serializable]
	public class TvSchedule : ScriptableObject
	{
		public SheetTimeTable[] TimeTable;
		
		public SheetTimeTable this[int index] => TimeTable[index];

		[Serializable]
		public class SheetTimeTable
		{
			public byte hour;
			public byte minute;
			public byte mon;
			public byte tue;
			public byte wed;
			public byte thu;
			public byte fri;
			public byte sat;
			public byte sun;
		}
	}
}