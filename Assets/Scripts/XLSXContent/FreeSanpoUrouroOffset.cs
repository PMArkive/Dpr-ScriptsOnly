using System;
using UnityEngine;

namespace XLSXContent
{
	[Serializable]
	public class FreeSanpoUrouroOffset : ScriptableObject
	{
		public SheetSheet1[] Sheet1;
		
		public SheetSheet1 this[int index] => Sheet1[index];

		[Serializable]
		public class SheetSheet1
		{
			public int PositionID;
			public int LeftUpX;
			public int LeftUpZ;
			public int RightDownX;
			public int RightDownZ;
		}
	}
}