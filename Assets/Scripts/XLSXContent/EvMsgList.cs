using System;
using UnityEngine;

namespace XLSXContent
{
	[Serializable]
	public class EvMsgList : ScriptableObject
	{
		public Sheetmsg[] msg;
		
		public Sheetmsg this[int index] => msg[index];

		[Serializable]
		public class Sheetmsg
		{
			public string File;
			public string ID;
		}
	}
}