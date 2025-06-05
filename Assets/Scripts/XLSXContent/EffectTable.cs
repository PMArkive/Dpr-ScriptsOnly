using System;
using UnityEngine;

namespace XLSXContent
{
	[Serializable]
	public class EffectTable : ScriptableObject
	{
		public SheetEffects[] Effects;
		
		public SheetEffects this[int index] => Effects[index];

		[Serializable]
		public class SheetEffects
		{
			public string Label;
			public string AssetBundleName;
			public string Type;
			public int PoolCount;
			public string Category;
			public string Group;
		}
	}
}