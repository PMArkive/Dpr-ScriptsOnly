using System;

namespace DPData
{
    [Serializable]
    public struct BTLTOWER_SAVEWORK
    {
        public uint max_master_rank;
        public int play_mode;
        public int old_playmode;
        public uint btl_point;
        public uint day_challeng_cnt;
        public BTLTOWER_CLASSDATA[] class_data;
        public uint challenge_cnt;
    }
}