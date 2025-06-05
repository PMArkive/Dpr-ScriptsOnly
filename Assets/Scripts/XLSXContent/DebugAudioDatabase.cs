using System;
using UnityEngine;

namespace XLSXContent
{
	[Serializable]
	public class DebugAudioDatabase : ScriptableObject
	{
		public SheetState[] State;
		
		public SheetState this[int index] => State[index];

		[Serializable]
		public class SheetState
		{
			public string NAME;
			public float STATEID;
		}
	}
}