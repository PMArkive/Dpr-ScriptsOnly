using System;
using UnityEngine;

namespace XLSXContent
{
	[Serializable]
	public class SecretbaseUpgrade : ScriptableObject
	{
		public Sheetinfo[] info;
		
		public Sheetinfo this[int index] => info[index];

		[Serializable]
		public class Sheetinfo
		{
			public ushort id;
			public byte Width;
			public byte Height;
			public byte[] ImpossibleField;
			public float[] Rotate;
			public float[] ZoomOffset;
			public float[] Yoffset;
			public Vector3 ReturnPos;
		}
	}
}