namespace Dpr.Battle.Logic
{
    public sealed class PosPoke
    {
        private State[] m_state;
        private BtlPokePos[] m_lastPosInst;
        private BtlPokePos m_lastPosDmy;

        // TODO
        private void setLastPos(int i, BtlPokePos pos) { }

        // TODO
        private BtlPokePos getLastPos(int i) { return BtlPokePos.POS_1ST_0; }

        // TODO
        public PosPoke() { }

        // TODO
        public void CopyFrom(in PosPoke src) { }

        // TODO
        public void Init(MainModule mainModule, POKECON pokeCon) { }

        // TODO
        private void setInitialFrontPokemon(MainModule mainModule, POKECON pokeCon, BtlPokePos pos) { }

        // TODO
        public void ExtendPos(in MainModule mainModule, BtlPokePos pos) { }

        // TODO
        public void PokeOut(byte pokeID) { }

        // TODO
        public void PokeIn(MainModule mainModule, BtlPokePos pos, byte pokeID, POKECON pokeCon) { }

        // TODO
        private void checkConfrontRec(MainModule mainModule, BtlPokePos pos, POKECON pokeCon) { }

        // TODO
        public void Swap(BtlPokePos pos1, BtlPokePos pos2) { }

        // TODO
        private void updateLastPos(BtlPokePos pos) { }

        // TODO
        public byte GetClientEmptyPos(byte clientID, BtlPokePos[] pos) { return 0; }

        // TODO
        public byte GetClientEmptyPosCount(byte clientID) { return 0; }

        // TODO
        public bool IsExist(byte pokeID) { return false; }

        // TODO
        public bool IsExistFrontPos(MainModule mainModule, byte pokeID) { return false; }

        // TODO
        public BtlPokePos GetPokeExistPos(byte pokeID) { return BtlPokePos.POS_1ST_0; }

        // TODO
        public BtlPokePos GetPokeLastPos(byte pokeID) { return BtlPokePos.POS_1ST_0; }

        // TODO
        public byte GetExistPokeID(BtlPokePos pos) { return 0; }

        private sealed class State
        {
            public bool fEnable;
            public byte clientID;
            public byte existPokeID;

            // TODO
            public void CopyFrom(State src) { }

            // TODO
            public State() { }
        }
    }
}