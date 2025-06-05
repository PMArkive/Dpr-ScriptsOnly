using AttributeData;
using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class MapAttributeTable : ScriptableObject
    {
        public SheetData[] Data;

        public SheetData this[int index] => Data[index];

        [Serializable]
        public class SheetData
        {
            public int Code;
            public MapAttribute Attribute;
            public bool Entry;
            public bool Water;
            public bool Encount;
            public string FieldEncount;
        }
    }
}