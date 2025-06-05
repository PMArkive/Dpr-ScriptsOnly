using Dpr.BallDeco;
using Pml;

namespace Dpr.Battle.View
{
    public struct BtlvBallInfo
    {
        public static readonly BtlvBallInfo Default = new BtlvBallInfo()
        {
            sealCnt = 0,
            ballId = BallId.MONSUTAABOORU,
            hasCapsule = false,
            isStrangeBall = false,
            affixSealDatas = null,
        };
        public BallId ballId;
        public bool hasCapsule;
        public bool isStrangeBall;
        public AffixSealData[] affixSealDatas;
        public byte sealCnt;

        public bool HasBallSeal { get => affixSealDatas != null && sealCnt != 0; }

        public void Clear()
        {
            ballId = BallId.NULL;
            isStrangeBall = false;
            affixSealDatas = null;
            sealCnt = 0;
        }
    }
}