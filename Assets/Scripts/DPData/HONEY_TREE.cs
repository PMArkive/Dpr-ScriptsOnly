using System;

namespace DPData
{
    [Serializable]
    public struct HONEY_TREE
    {
        public long LastUpdateMinutes;
        public byte TreeNo;
        public HONEY_DATA[] HoneyData;
    }
}