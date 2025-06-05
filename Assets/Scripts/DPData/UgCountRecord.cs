using System;

namespace DPData
{
    [Serializable]
    public struct UgCountRecord
    {
        public short DigFossilPlayCount;
        public short NumStatueBroadcastOnTV;
        public int NumTimesSecretBaseBroadcastOnTVWereLiked;
        public int SomeoneSecretBaseLikeCount;
        public int NumSuccessfulLightStoneSearches;
        public long reserved_long01;
        public long reserved_long02;

        // TODO
        public void IncrementDigFossilPlayCount() { }
    }
}