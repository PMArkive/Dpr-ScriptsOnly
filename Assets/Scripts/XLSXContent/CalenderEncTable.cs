using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class CalenderEncTable : ScriptableObject
    {
        public Sheetdata[] data;
        public Sheetweather[] weather;

        public Sheetdata this[int index] => data[index];

        [Serializable]
        public class Sheetdata
        {
            public int month;
            public int day;
            public int add_rate;
            public int add_hatching;
        }

        [Serializable]
        public class Sheetweather
        {
            public SYS_WEATHER r212b;
            public SYS_WEATHER r213;
            public SYS_WEATHER r216;
            public SYS_WEATHER l3;
            public SYS_WEATHER c9;
        }
    }
}