using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class GimmickGraphics : ScriptableObject
    {
        public SheetData[] Data;

        public SheetData this[int index] => Data[index];

        [Serializable]
        public class SheetData
        {
            public string AssetPath;
        }
    }
}