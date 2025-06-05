namespace Dpr.Battle.Logic
{
    public sealed class PosEffectManager
    {
        // BUG?: There's only 5 positions in battle, but for some reason this is initialized with 6
        private PosEffectStatus[][] m_posEffects = RectangularArrays.RectangularDefaultArray<PosEffectStatus>(PokemonPosition.BTL_EXIST_POS_MAX, (int)BtlPosEffect.BTL_POSEFF_MAX);

        public PosEffectManager()
        {
            CreateEffectStatusArray();
        }

        // TODO
        public void CreateEffectStatusArray() { }

        private void DeleteEffectStatusArray()
        {
            for (var i = BtlPosEffect.BTL_POSEFF_NEGAIGOTO; i < BtlPosEffect.BTL_POSEFF_MAX; i++)
                m_posEffects[(int)BtlPokePos.POS_1ST_0][(int)i] = null;

            for (var i = BtlPosEffect.BTL_POSEFF_NEGAIGOTO; i < BtlPosEffect.BTL_POSEFF_MAX; i++)
                m_posEffects[(int)BtlPokePos.POS_2ND_0][(int)i] = null;

            for (var i = BtlPosEffect.BTL_POSEFF_NEGAIGOTO; i < BtlPosEffect.BTL_POSEFF_MAX; i++)
                m_posEffects[(int)BtlPokePos.POS_1ST_1][(int)i] = null;

            for (var i = BtlPosEffect.BTL_POSEFF_NEGAIGOTO; i < BtlPosEffect.BTL_POSEFF_MAX; i++)
                m_posEffects[(int)BtlPokePos.POS_2ND_1][(int)i] = null;

            for (var i = BtlPosEffect.BTL_POSEFF_NEGAIGOTO; i < BtlPosEffect.BTL_POSEFF_MAX; i++)
                m_posEffects[(int)BtlPokePos.POS_RAID_BOSS][(int)i] = null;

            for (var i = BtlPosEffect.BTL_POSEFF_NEGAIGOTO; i < BtlPosEffect.BTL_POSEFF_MAX; i++)
                m_posEffects[(int)BtlPokePos.POS_NULL][(int)i] = null;
        }

        // TODO
        public void CopyFrom(in PosEffectManager src) { }

        // TODO
        public void RemoveAllPosEffect() { }

        // TODO
        public PosEffectStatus GetPosEffectStatus(BtlPokePos pos, BtlPosEffect effect) { return null; }

        // TODO
        public PosEffectStatus GetPosEffectStatusConst(BtlPokePos pos, BtlPosEffect effect) { return null; }
    }
}