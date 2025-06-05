using System;

namespace DPData
{
    [Serializable]
    public struct MV_POKE_DATA
    {
        public int ZoneIDIndex;
        public ulong RndSeed;
        public uint MonsNo;
        public uint Hp;
        public byte Lv;
        public uint Sick;
        public byte EncountStatus;
    }
}