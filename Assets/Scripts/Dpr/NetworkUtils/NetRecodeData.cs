using DPData;

namespace Dpr.NetworkUtils
{
    public struct NetRecodeData
    {
        public RECORD recodeData;
        public RANDOM_SEED randomSeed;
        public UnionWork.TvRecodeData tvRecode;
        public TV_STR_DATA PersonalityPlayerName;
        public TV_STR_DATA KasekihoriPlayerName;
        public TV_STR_DATA StatuePlayerName;
        public TV_STR_DATA FashionPlayerName;
        public RECORD_HEAD recodeHeadData;
        public int PersonalityBranchData;
        public int BallDecorationBranchData;
        public int Trainer;
        public int KasekihoriBranchData;
        public int ItemNo;
        public int StatueBranchData;
        public int StatueCount;
        public int FashionBranchData;
        public int Style;
        public int PlaceNo;
        public byte myVersion;
        public byte PersonalityIsNotEmpty;
        public byte BallDecorationIsNotEmpty;
        public byte KasekihoriIsNotEmpty;
        public byte StatueIsNotEmpty;
        public byte FashionIsNotEmpty;
    }
}