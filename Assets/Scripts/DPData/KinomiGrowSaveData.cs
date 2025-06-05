using System;

namespace DPData
{
    [Serializable]
    public struct KinomiGrowSaveData
    {
        public const int KinomiGrowsCount = 128;
        public KinomiGrow[] kinomiGrows;
        public long LastUpdateMinutes;
    }
}