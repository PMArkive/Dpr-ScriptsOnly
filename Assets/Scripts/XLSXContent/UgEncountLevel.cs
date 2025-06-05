using Pml;
using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class UgEncountLevel : ScriptableObject
    {
        public SheetData[] Data;

        public SheetData this[int index] => Data[index];

        [Serializable]
        public class SheetData
        {
            public int MinLv;
            public int MaxLv;
        }
    }
}