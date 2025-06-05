using Pml;
using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class UgSpecialPokemon : ScriptableObject
    {
        public SheetSheet1[] Sheet1;

        public SheetSheet1 this[int index] => Sheet1[index];

        [Serializable]
        public class SheetSheet1
        {
            public int id;
            public MonsNo monsno;
            public int version;
            public int Dspecialrate;
            public int Pspecialrate;
        }
    }
}