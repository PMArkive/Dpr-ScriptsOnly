using Dpr.EvScript;
using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class StopData : ScriptableObject
    {
        public SheetData[] Data;

        public SheetData this[int index] => Data[index];

        [Serializable]
        public class SheetData
        {
            public string ID;
            public Vector2 Position;
            public int HeightLayer;
            public Vector2 Size;
            public string ContactLabel;
            public int Param;
            public EvWork.WORK_INDEX Work;
        }
    }
}