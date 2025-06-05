using Dpr.EvScript;
using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class TownMapTable : ScriptableObject
    {
        public SheetData[] Data;

        public SheetData this[int index] => Data[index];

        [Serializable]
        public class SheetData
        {
	        public ZoneID zoneID;
            public int Width;
            public int Index1;
            public int Index2;
            public int Index3;
            public Vector2 NowPosXZ;
            public Vector2 TownPosXZ;
            public Vector2 MarkingMapPosXZ;
            public string GuideText1;
            public string GuideText2;
            public string TownMapName;
            public EvWork.WORK_INDEX ViewFlag;
            public EvWork.SYSFLAG_INDEX ColorOnFlag;
            public string SymbolName;
            public EvWork.SYSFLAG_INDEX AddGuideFlag;
            public EvWork.SYSFLAG_INDEX ChangFacilityFlag;
            public int ChangFacilityNo;
            public string Facility00;
            public string Facility01;
            public string Facility02;
            public string Facility03;
            public string Facility04;
            public string Facility05;
            public string Facility06;
            public string FacilitySP;
            public bool FlyingAvailablePlace;
            public int MapInfoLocatorIndex;
            public bool AreaHideFlag;
        }
    }
}