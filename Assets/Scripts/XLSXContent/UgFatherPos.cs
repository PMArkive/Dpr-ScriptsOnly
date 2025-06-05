using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class UgFatherPos : ScriptableObject
    {
        public SheetPos[] Pos;

        public SheetPos this[int index] => Pos[index];

        [Serializable]
        public class SheetPos
        {
            public int ID;
            public int ugfatherCategory;
            public ZoneID ZoneID;
            public Vector2Int Locator;
        }
    }
}