using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class PokeWalkingActionSeikaku : ScriptableObject
    {
        public SheetSheet1[] Sheet1;

        public SheetSheet1 this[int index] => Sheet1[index];

        [Serializable]
        public class SheetSheet1
        {
            public int SeikakuID;
            public float PositionHosei;
            public float SpeedDownStartDistanceHosei;
            public float SpeedDownEndDistanceHosei;
            public float WalkStartDistanceHosei;
            public float RunStartDistanceHosei;
            public int StopKakurituHosei;
            public int KyoroKakurituHosei;
            public int LookOtherPokeKakurituHosei;
        }
    }
}