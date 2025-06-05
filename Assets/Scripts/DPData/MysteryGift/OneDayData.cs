using System;

namespace DPData.MysteryGift
{
    [Serializable]
    public struct OneDayData
    {
        public long timestamp;
        public ushort deliveryId;
        public short reserved_short01;
        public short reserved_short02;
        public short reserved_short03;
    }
}