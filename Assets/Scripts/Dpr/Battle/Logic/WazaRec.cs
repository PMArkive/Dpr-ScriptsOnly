using Pml;

namespace Dpr.Battle.Logic
{
    public sealed class WazaRec
    {
        public const int TURN_MAX = 20;
        public const int RECORD_MAX = 400;
        private uint m_ptr;
        private RECORD[] m_record;

        // TODO
        public WazaRec() { }

        // TODO
        public void CopyFrom(in WazaRec src) { }

        // TODO
        public void Init() { }

        // TODO
        public void Add(WazaNo waza, uint turn, byte pokeID) { }

        // TODO
        public void SetEffectiveLast() { }

        // TODO
        public bool IsUsedWaza(WazaNo waza, uint turn) { return false; }

        // TODO
        public uint GetUsedWazaCount(WazaNo waza, uint turn) { return 0; }

        // TODO
        public WazaNo GetPrevEffectiveWaza(uint turn) { return WazaNo.NULL; }

        private class RECORD
        {
            public uint turn;
            public WazaNo wazaID;
            public byte pokeID;
            public bool fEffective;

            // TODO
            public void CopyFrom(RECORD src) { }

            // TODO
            public RECORD() { }
        }
    }
}