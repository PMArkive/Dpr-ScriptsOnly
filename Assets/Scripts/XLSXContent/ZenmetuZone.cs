using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class ZenmetuZone : ScriptableObject
    {
        public Sheetdata[] data;

        public Sheetdata this[int index] => data[index];

        [Serializable]
        public class Sheetdata
        {
            public ZoneID zoneID;
            public int gridX;
            public int gridZ;
            public int height;
            public int dir;
            public ZoneID townMapZoneID;
            public int locators;
        }
    }
}