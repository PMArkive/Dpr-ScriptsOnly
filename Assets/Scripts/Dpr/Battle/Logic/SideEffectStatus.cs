namespace Dpr.Battle.Logic
{
    public sealed class SideEffectStatus
    {
        private DATA m_data = new DATA();

        public SideEffectStatus(BtlSideEffect sideEffect)
        {
            m_data.sideEffect = sideEffect;
        }

        public void CopyFrom(in SideEffectStatus src)
        {
            m_data.CopyFrom(src.m_data);
        }

        // TODO
        public void SwapFrom(SideEffectStatus target) { }

        // TODO
        public bool AddEffect(in BTL_SICKCONT contParam) { return false; }

        // TODO
        public bool RemoveEffect() { return false; }

        // TODO
        public bool IsEffective() { return false; }

        // TODO
        public uint GetAddCount() { return 0; }

        // TODO
        public uint GetMaxTurnCount() { return 0; }

        // TODO
        public uint GetCurrentTurnCount() { return 0; }

        // TODO
        public uint GetRemainingTurn() { return 0; }

        // TODO
        public uint GetTurnUpCount() { return 0; }

        // TODO
        public byte GetCausePokeID() { return 0; }

        // TODO
        public void IncTurnCount() { }

        // TODO
        public bool IsTurnPassed() { return false; }

        public BTL_SICKCONT GetContParam()
        {
            return m_data.contParam;
        }

        private class DATA
        {
            public BtlSideEffect sideEffect;
            public BTL_SICKCONT contParam;
            public uint turn_counter;
            public uint add_counter;

            public void CopyFrom(DATA src)
            {
                sideEffect = src.sideEffect;
                contParam = src.contParam;
                turn_counter = src.turn_counter;
                add_counter = src.add_counter;
            }
        }
    }
}