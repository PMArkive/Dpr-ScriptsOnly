using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class GrowTable : ScriptableObject
    {
        public SheetData[] Data;

        [Serializable]
        public class SheetData
        {
            public uint[] exps;
        }
    }
}