using System;
using UnityEngine;

namespace XLSXContent
{
	[Serializable]
	public class Pedestal : ScriptableObject
	{
		public SheetInfo[] Info;
		
		public SheetInfo this[int index] => Info[index];

		[Serializable]
		public class SheetInfo
		{
			public ushort pedestalId;
			public int ugItemID;
			public string ItemNameLabel;
			public string DescriptionTextLabel;
			public byte Width;
			public byte Height;
			public float Offset;
			public float RotateSpeed;
			public bool Legend;
			public byte ModelIndex;
			public string AssetBundleName;
			public ushort sort;
		}
	}
}