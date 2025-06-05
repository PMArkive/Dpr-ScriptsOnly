using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class HirobaEnterablePoke : ScriptableObject
    {
        public SheetEnterablePoke[] EnterablePoke;

        public SheetEnterablePoke this[int index] => EnterablePoke[index];

        [Serializable]
        public class SheetEnterablePoke
        {
            public int PokeID;
            public int ZenkokuPokeID;
        }
    }
}