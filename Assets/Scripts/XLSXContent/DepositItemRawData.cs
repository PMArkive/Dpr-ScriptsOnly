using System;
using UnityEngine;

namespace XLSXContent
{
	[Serializable]
	public class DepositItemRawData : ScriptableObject
	{
		public SheetDeposit[] Deposit;
		
		public SheetDeposit this[int index] => Deposit[index];

		[Serializable]
		public class SheetDeposit
		{
			public short itemId;
			public int MSLabelId;
			public string shape;
			public short turn;
			public short offsetSize;
			public short offsetX;
			public short offsetY;
			public bool bIsOnly;
			public bool bIsRare;
			public int ratio1;
			public int ratio2;
			public int ratio3;
			public int ratio4;
			public int ratio5;
			public int ratio6;
		}
	}
}