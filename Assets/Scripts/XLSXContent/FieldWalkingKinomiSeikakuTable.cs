using Pml.PokePara;
using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class FieldWalkingKinomiSeikakuTable : ScriptableObject
    {
        public SheetSheet1[] Sheet1;

        public SheetSheet1 this[int index] => Sheet1[index];

        [Serializable]
        public class SheetSheet1
        {
            public Seikaku Seikaku;
            public int TableID;
        }
    }
}