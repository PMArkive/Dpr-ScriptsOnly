using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class DistributionTable : ScriptableObject
    {
        public SheetMapDistribution[] MapDistribution;
        public SheetDiamond_FieldTable[] Diamond_FieldTable;
        public SheetDiamond_DungeonTable[] Diamond_DungeonTable;
        public SheetPearl_FieldTable[] Pearl_FieldTable;
        public SheetPearl_DungeonTable[] Pearl_DungeonTable;

        public SheetMapDistribution this[int index] => MapDistribution[index];

        [Serializable]
        public class SheetMapDistribution
        {
	        public int MapID;
            public Vector2Int[] LightUpGridXZ;
            public bool DistributionHideFlag;
        }

        [Serializable]
        public class SheetDiamond_FieldTable : SheetDistributionTable { }

        [Serializable]
        public class SheetDiamond_DungeonTable: SheetDistributionTable { }

        [Serializable]
        public class SheetPearl_FieldTable: SheetDistributionTable { }

        [Serializable]
        public class SheetPearl_DungeonTable: SheetDistributionTable { }
    }
}