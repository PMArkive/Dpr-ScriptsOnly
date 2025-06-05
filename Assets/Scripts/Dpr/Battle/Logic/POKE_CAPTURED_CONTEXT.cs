namespace Dpr.Battle.Logic
{
    public sealed class POKE_CAPTURED_CONTEXT
    {
        public BtlPokePos targetPos;
        public bool isCaptured;
        public bool isZukanRegistered;

        public void Clear()
        {
            targetPos = BtlPokePos.POS_NULL;
            isCaptured = false;
            isZukanRegistered = false;
        }

        public void Set(BtlPokePos pos, bool captured, bool zukanRegistered)
        {
            isCaptured = captured;
            targetPos = pos;
            isZukanRegistered = zukanRegistered;
        }
    }
}