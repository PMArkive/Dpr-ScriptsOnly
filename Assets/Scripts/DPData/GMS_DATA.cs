using System;

namespace DPData
{
    [Serializable]
    public struct GMS_DATA
    {
        public GMS_POINT_DATA[] pointDatas;
        public ushort tradeListIndex;
        public ushort browsingListIndex;
        public byte achievementStep;
    }
}