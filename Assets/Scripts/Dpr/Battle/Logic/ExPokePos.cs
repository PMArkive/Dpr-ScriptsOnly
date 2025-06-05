namespace Dpr.Battle.Logic
{
    public sealed class ExPokePos
    {
        private ExPosType m_type;
        private BtlPokePos m_basePos;

        // TODO
        public ExPokePos() { }

        // TODO
        public ExPokePos(ExPosType type, BtlPokePos basePos) { }

        // TODO
        public ExPokePos(in ExPokePos src) { }

        // TODO
        public ExPokePos CopyFrom(in ExPokePos rhl) { return null; }

        // TODO
        public byte ExpandPos(BtlRule rule, BtlMultiMode multiMode, BtlPokePos[] dst) { return 0; }

        // TODO
        private void expandPos_single(ExpandResult result, BtlMultiMode multiMode) { }

        // TODO
        private void expandPokePos_double(ExpandResult result, BtlMultiMode multiMode) { }

        // TODO
        private void expandPokePos_raid(ExpandResult result, BtlMultiMode multiMode) { }

        // TODO
        public byte ExpandExistPokeID(BtlRule rule, BtlMultiMode multiMode, POKECON pokeCon, byte[] pokeIDAry) { return 0; }

        public enum ExPosType : int
        {
            BASE_POS = 0,
            NEXT_FRIENDS = 1,
            AREA_ENEMY = 2,
            AREA_OTHERS = 3,
            AREA_MYTEAM = 4,
            AREA_FRIENDS = 5,
            AREA_ALL = 6,
            FULL_ENEMY = 7,
            FULL_FRIENDS = 8,
            FULL_ALL = 9,
        }

        private class ExpandResult
        {
            public BtlPokePos[] pos;
            public byte count;

            // TODO
            public ExpandResult() { }

            // TODO
            public void Add(BtlPokePos addPos) { }
        }
    }
}