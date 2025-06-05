using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class UgMiniMap : ScriptableObject
    {
        public SheetMap[] Map;
        public SheetIcon[] Icon;
        public SheetMapGroup[] MapGroup;

        public SheetMap this[int index] => Map[index];

        [Serializable]
        public class SheetMap
        {
            public int mapGroupID;
            public ZoneID zoneid;
            public Vector2 MapOffset;
            public bool IsPlayerPos;
        }

        [Serializable]
        public class SheetIcon
        {
            public int mapGroupID;
            public ZoneID zoneid;
            public bool IsEast;
            public Vector2 ImagePos;
            public int Default;
            public int Open;
        }

        [Serializable]
        public class SheetMapGroup
        {
            public int ID;
            public ZoneID[] zoneid;
        }
    }
}