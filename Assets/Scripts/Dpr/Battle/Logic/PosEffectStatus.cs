namespace Dpr.Battle.Logic
{
    public sealed class PosEffectStatus
    {
        private Data m_data = new Data();

        public PosEffectStatus(BtlPokePos pos, BtlPosEffect posEffect)
        {
            m_data.pos = pos;
            m_data.posEffect = posEffect;
            m_data­.isEffective = false;
        }

        public void CopyFrom(in PosEffectStatus src)
        {
            m_data.CopyFrom(src.m_data);
        }

        // TODO
        public bool SetEffect(in PosEffect.EffectParam effectParam) { return false; }

        // TODO
        public void RemoveEffect() { }

        // TODO
        public bool IsEffective() { return false; }

        // TODO
        public PosEffect.EffectParam GetEffectParam() { return default; }

        // TODO
        public void SetEffectParam(in PosEffect.EffectParam effectParam) { }

        // TODO
        public BtlPokePos GetPokePos() { return BtlPokePos.POS_1ST_0; }

        // TODO
        public BtlPosEffect GetPosEffect() { return BtlPosEffect.BTL_POSEFF_NEGAIGOTO; }

        private class Data
        {
            public BtlPokePos pos;
            public BtlPosEffect posEffect;
            public bool isEffective;
            public PosEffect.EffectParam effectParam;

            public void CopyFrom(Data src)
            {
                pos = src.pos;
                posEffect = src.posEffect;
                isEffective = src.isEffective;
                effectParam = src.effectParam;
            }
        }
    }
}