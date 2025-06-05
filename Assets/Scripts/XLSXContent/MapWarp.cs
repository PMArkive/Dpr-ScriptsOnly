using Dpr.EvScript;
using FieldDoor;
using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class MapWarp : ScriptableObject
    {
        public SheetData[] Data;

        public SheetData this[int index] => Data[index];

        [Serializable]
        public class SheetData
        {
            public Vector3 Position;
            public int GruopID;
            public Vector2 Size;
            public ZoneID WarpZone;
            public int WarpIndex;
            public int InputDir;
            public EvWork.FLAG_INDEX FlagIndex;
            public CallLabel ScriptLabel;
            public ExitLabel ExitLabel;
            public string ConnectionName;
        }
    }
}