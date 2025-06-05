using System;

namespace DPData
{
    [Serializable]
    public struct TV_STR_DATA
    {
        public string value;
        public byte language;
        public byte genderId;
        public byte reserved2;
        public byte reserved3;
    }
}