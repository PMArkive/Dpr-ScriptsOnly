using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class TamaTable : ScriptableObject
    {
        public Sheettable[] table;

        public Sheettable this[int index] => table[index];

        [Serializable]
        public class Sheettable
        {
            public int TamaID;
            public int UgItemID;
            public string ItemNameLabel;
            public string DescriptionTextLabel;
        }
    }
}