using System;
using UnityEngine;

namespace XLSXContent
{
	[Serializable]
	public class UgPokemonPos : ScriptableObject
	{
		public SheetSheet1[] Sheet1;
		
		public SheetSheet1 this[int index] => Sheet1[index];

		[Serializable]
		public class SheetSheet1
		{
			public ZoneID ZoneID;
			public Vector3[] Locator;
		}
	}
}