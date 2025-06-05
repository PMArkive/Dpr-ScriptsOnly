using System;
using UnityEngine;

namespace DPData
{
    [Serializable]
    public struct UgSecretBase
    {
        public short zoneID;
        public short posX;
        public short posY;
        public byte direction;
        public byte expansionStatus;
        public int goodCount;
        public UgStoneStatue[] ugStoneStatue;
        public bool isEnable;

        public bool isNull { get => zoneID == 0; }

        // TODO
        public Vector2Int ReturnPos() { return Vector2Int.zero; }
    }
}