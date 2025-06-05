namespace Dpr.Battle.Logic
{
    public sealed class SideEffectManager
    {
        private SideEffectStatus[][] m_sideEffects = RectangularArrays.RectangularDefaultArray<SideEffectStatus>((int)BtlSide.BTL_SIDE_NUM, (int)BtlSideEffect.BTL_SIDEEFF_MAX);

        public SideEffectManager()
        {
            CreateEffectStatusArray();
        }

        // TODO
        public void CreateEffectStatusArray() { }

        private void DeleteEffectStatusArray()
        {
            for (var i = BtlSideEffect.BTL_SIDEEFF_START; i != BtlSideEffect.BTL_SIDEEFF_MAX; i++)
                m_sideEffects[(int)BtlSide.BTL_SIDE_1ST][(int)i] = null;

            for (var i = BtlSideEffect.BTL_SIDEEFF_START; i != BtlSideEffect.BTL_SIDEEFF_MAX; i++)
                m_sideEffects[(int)BtlSide.BTL_SIDE_2ND][(int)i] = null;
        }

        public void CopyFrom(in SideEffectManager src)
        {
            for (var i = BtlSideEffect.BTL_SIDEEFF_START; i != BtlSideEffect.BTL_SIDEEFF_MAX; i++)
                m_sideEffects[(int)BtlSide.BTL_SIDE_1ST][(int)i].CopyFrom(src.m_sideEffects[(int)BtlSide.BTL_SIDE_1ST][(int)i]);

            for (var i = BtlSideEffect.BTL_SIDEEFF_START; i != BtlSideEffect.BTL_SIDEEFF_MAX; i++)
                m_sideEffects[(int)BtlSide.BTL_SIDE_2ND][(int)i].CopyFrom(src.m_sideEffects[(int)BtlSide.BTL_SIDE_2ND][(int)i]);
        }

        // TODO
        public void RemoveAllSideEffect() { }

        // TODO
        public bool SwapSideEffect(BtlSide side1, BtlSide side2, BtlSideEffect effect) { return false; }

        // TODO
        public SideEffectStatus GetSideEffectStatus(BtlSide side, BtlSideEffect effect) { return null; }

        // TODO
        public SideEffectStatus GetSideEffectStatusConst(BtlSide side, BtlSideEffect effect) { return null; }
    }
}