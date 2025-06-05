using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class PokeWalkingFormation : ScriptableObject
    {
        public SheetSheet1[] Sheet1;

        public SheetSheet1 this[int index] => Sheet1[index];

        [Serializable]
        public class SheetSheet1
        {
            public int PokeNum;
            public Vector2 Offset1;
            public Vector2 Offset2;
            public Vector2 Offset3;
            public Vector2 Offset4;
            public Vector2 Offset5;
            public Vector2 Offset6;
        }
    }
}