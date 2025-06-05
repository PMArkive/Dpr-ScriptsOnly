using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class TownMapGuideTable : ScriptableObject
    {
        public SheetGuide[] Guide;

        public SheetGuide this[int index] => Guide[index];

        [Serializable]
        public class SheetGuide
        {
	        public int Id;
            public int TownMapX;
            public int TownMapY;
            public string MSFile;
            public string MSLabel;
        }
    }
}