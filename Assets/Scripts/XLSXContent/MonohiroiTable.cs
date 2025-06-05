using Pml;
using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class MonohiroiTable : ScriptableObject
    {
        public SheetMonoHiroi[] MonoHiroi;

        public SheetMonoHiroi this[int index] => MonoHiroi[index];

        [Serializable]
        public class SheetMonoHiroi
        {
            public ItemNo ID;
            public byte[] Ratios;
        }
    }
}