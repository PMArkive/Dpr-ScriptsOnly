using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class HirobaPokeTalk : ScriptableObject
    {
        public SheetSheet1[] Sheet1;

        public SheetSheet1 this[int index] => Sheet1[index];

        [Serializable]
        public class SheetSheet1
        {
            public int RankID;
            public int ID;
            public string TextLabelName;
        }
    }
}