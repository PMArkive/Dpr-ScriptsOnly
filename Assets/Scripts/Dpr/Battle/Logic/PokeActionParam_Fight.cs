using Pml;

namespace Dpr.Battle.Logic
{
    public sealed class PokeActionParam_Fight
    {
        public BtlPokePos targetPos;
        public byte aimTargetID;
        public WazaNo waza;
        public bool gFlag;
        public bool forbidGWaza;
        public bool forceGWaza;

        // TODO
        public void CopyFrom(PokeActionParam_Fight src) { }

        // TODO
        public void Clear() { }
    }
}