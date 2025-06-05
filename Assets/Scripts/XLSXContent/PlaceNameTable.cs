using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class PlaceNameTable : ScriptableObject
    {
        public SheetDprPlaceName[] DprPlaceName;

        public SheetDprPlaceName this[int index] => DprPlaceName[index];

        [Serializable]
        public class SheetDprPlaceName
        {
	        public int Index;
            public string MessageFile;
            public string MessageLabel;
        }
    }
}