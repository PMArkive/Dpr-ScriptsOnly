using System;

namespace DPData
{
    [Serializable]
    public struct PLAYER_DATA
    {
        public CONFIG config;
        public MYSTATUS mystatus;
        public PLAYTIME playtime;
        public CONTEST_DATA contestdata;
    }
}
