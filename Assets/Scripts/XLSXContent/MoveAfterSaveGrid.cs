using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class MoveAfterSaveGrid : ScriptableObject
    {
        public Sheetdata[] data;

        public Sheetdata this[int index] => data[index];

        [Serializable]
        public class Sheetdata
        {
            public ZoneID zoneID;
            public Vector2Int grid;
            public Vector2Int regrid;
        }
    }
}