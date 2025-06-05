using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class FreeSanpoKuse : ScriptableObject
    {
        public SheetSheet1[] Sheet1;

        public SheetSheet1 this[int index] => Sheet1[index];

        [Serializable]
        public class SheetSheet1
        {
            public int PokeID;
            public bool kw33_moveA01;
            public bool kw33_moveB01;
            public bool kw33_moveC01;
            public bool kw33_moveD01;
            public bool ba01_landAorC;
            public bool ba01_land01;
            public bool kw32_happyA01;
            public bool kw32_happyB01;
            public bool kw32_happyC01;
        }
    }
}