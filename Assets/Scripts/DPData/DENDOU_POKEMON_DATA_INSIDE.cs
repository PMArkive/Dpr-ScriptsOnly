using System;

namespace DPData
{
    [Serializable]
    public struct DENDOU_POKEMON_DATA_INSIDE
    {
        public uint monsno;
        public byte level;
        public ushort formNumber;
        public uint personalRandom;
        public uint idNumber;
        public int sex;
        public int rareType;
        public string nickname;
        public string oyaname;
        public ushort[] waza;
    }
}