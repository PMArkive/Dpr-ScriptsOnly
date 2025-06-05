using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class UgItemTable : ScriptableObject
    {
        public Sheettable[] table;

        public Sheettable this[int index] => table[index];

        [Serializable]
        public class Sheettable
        {
            public int UgItemID;
            public int ItemTableID;
            public int TamatableID;
            public int PedestaltableID;
            public int StonestatueeffectID;
        }
    }
}