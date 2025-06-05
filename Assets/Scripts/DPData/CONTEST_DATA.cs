using System;

namespace DPData
{
    [Serializable]
    public struct CONTEST_DATA
    {
        public CON_PHOTO_DATA[] photoDatas;
        public uint contestRankPoint;
    }
}