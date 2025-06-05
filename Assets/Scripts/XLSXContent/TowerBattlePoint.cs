using System;
using UnityEngine;

namespace XLSXContent
{
	[Serializable]
	public class TowerBattlePoint : ScriptableObject
	{
		public Sheetpoint[] point;
		
		public Sheetpoint this[int index] => point[index];

		[Serializable]
		public class Sheetpoint
		{
			public int[] BattlePoint;
		}
	}
}