using System;
using UnityEngine;

namespace XLSXContent
{
	[Serializable]
	public class TowerDoubleStockTable : ScriptableObject
	{
		public SheetTowerDoubleStock[] TowerDoubleStock;
		
		public SheetTowerDoubleStock this[int index] => TowerDoubleStock[index];

		[Serializable]
		public class SheetTowerDoubleStock
		{
			public uint ID;
			public TowerTrID[] TrainerID;
			public uint[] PokeID;
			public string BattleBGM;
			public string WinBGM;
		}
	}
}