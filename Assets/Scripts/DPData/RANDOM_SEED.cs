using System;

namespace DPData
{
    [Serializable]
    public struct RANDOM_SEED
    {
        public string group_name;
        public string name;
        public int sex;
        public int region_code;
        public ulong seed;
        public ulong random;
        public long time_stmp;
        public int user_id;
    }
}