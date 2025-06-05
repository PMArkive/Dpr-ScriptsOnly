using Pml;
using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class UgEncount : ScriptableObject
    {
        public Sheettable[] table;

        public Sheettable this[int index] => table[index];

        [Serializable]
        public class Sheettable
        {
            public MonsNo monsno;
            public int version;
            public int zukanflag;
        }
    }
}