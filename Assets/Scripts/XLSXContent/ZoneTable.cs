using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class ZoneTable : ScriptableObject
    {
        public ZoneID[] ZoneIDs;
        public int Width;

        public ZoneID this[int index] { get => ZoneIDs[index]; }

        public ZoneID this[int gridX, int gridY] { get => ZoneIDs[gridX + Width * gridY]; }

        public int Length { get => ZoneIDs.Length; }
    }
}