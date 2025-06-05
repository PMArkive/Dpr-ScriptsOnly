using System;

namespace DPData
{
    [Serializable]
    public struct SYSTEMDATA
    {
        public GMTIME StartTime;
        public GMTIME SaveTime;
        public GMTIME PenaltyTime;
        public GMTIME DailyEventLastTime;
        public byte[] nxSnapshot;
        public uint fd_bgmEvnet;
        public long reserved_long0;
        public long reserved_long1;
        public long reserved_long2;
        public long reserved_long3;
        public long reserved_long4;
        public long reserved_long5;
    }
}