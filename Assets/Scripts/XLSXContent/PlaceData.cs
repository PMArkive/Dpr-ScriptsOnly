using Dpr.EvScript;
using Dpr.Trainer;
using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class PlaceData : ScriptableObject
    {
        public SheetData[] Data;

        [Serializable]
        public class SheetData
        {
            public string ID;
            public ZoneID zoneID;
            public TrainerID TrainerID;
            public int ObjectGraphicIndex;
            public int ColorIndex;
            public Vector2 Position;
            public int HeightLayer;
            public bool HeightIgnore;
            public Vector2 Size;
            public int Rotation;
            public Vector2 MoveLimit;
            public int EventType;
            public int MoveCode;
            public int MoveParam0;
            public int MoveParam1;
            public int MoveParam2;
            public string TalkLabel;
            public string ContactLabel;
            public EvWork.FLAG_INDEX Work;
            public int Dowsing;
            public bool LoadFirst;
            public EvWork.FLAG_INDEX DoNotLoad;
            public float TalkToRange;
            public Vector2 TalkToSize;
            public int TalkBit;
        }
    }
}