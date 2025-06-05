using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class WazaOboeTable : ScriptableObject
    {
        public SheetWazaOboe[] WazaOboe;

        [Serializable]
        public class SheetWazaOboe
        {
            public int id;
            public ushort[] ar;
        }
    }
}