using Pml;
using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class MonohiroiSonota : ScriptableObject
    {
        public SheetSheet1[] Sheet1;

        public SheetSheet1 this[int index] => Sheet1[index];

        [Serializable]
        public class SheetSheet1
        {
            public int PokeID;
            public SealID ItemA;
            public SealID ItemB;
            public SealID ItemC;
            public ItemNo ItemD;
            public SealID ItemE;
            public SealID ItemF;
            public SealID ItemG;
            public SealID ItemH;
            public SealID ItemI;
            public ItemNo ItemJ;
        }
    }
}