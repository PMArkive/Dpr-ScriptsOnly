using System;

namespace DPData
{
    [Serializable]
    public struct RECORD_HEAD
    {
        public string username;
        public byte reserved_byte1;
        public byte reserved_byte2;
        public int language;
        public byte sex;
        public byte reserved_byte4;
        public byte reserved_byte5;
        public byte reserved_byte6;
        public int body_type;
        public uint uniqueID;
        public int reserved_int2;
    }
}