using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class FureaiPokeScaleTable : ScriptableObject
    {
        public SheetTable[] Table;

        public SheetTable this[int index] => Table[index];

        [Serializable]
        public class SheetTable
        {
            public int PokeID;
            public float Hosei;
        }
    }
}