using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class SearchIndexData : ScriptableObject
    {
        public SheetIndexTable[] IndexTable;
        public SheetMonsterName[] MonsterName;
        public SheetWazaName[] WazaName;
        public SheetTokusei[] Tokusei;
        public SheetItemName[] ItemName;

        public SheetIndexTable this[int index] => IndexTable[index];

        [Serializable]
        public class SheetIndexTable
        {
            public string MessageID;
            public int IndexGroup;
            public int IndexCategory;
            public bool IsCategoryEnable;
        }

        [Serializable]
        public class SheetMonsterName
        {
            public string MessageID;
            public int IndexGroup;
        }

        [Serializable]
        public class SheetWazaName
        {
            public string MessageID;
            public int IndexGroup;
        }

        [Serializable]
        public class SheetTokusei
        {
            public string MessageID;
            public int IndexGroup;
        }

        [Serializable]
        public class SheetItemName
        {
            public string MessageID;
            public int IndexGroup;
        }
    }
}