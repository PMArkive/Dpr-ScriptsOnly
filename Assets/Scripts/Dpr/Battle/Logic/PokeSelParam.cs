namespace Dpr.Battle.Logic
{
    public sealed class PokeSelParam
    {
        private BTL_CLIENT_ID m_clientID;
        private BTL_PARTY m_party;
        private byte m_numSelect;
        private bool m_bDisabledPutPosSequence;
        private byte[] m_prohibit = new byte[DefineConstants.BTL_PARTY_MEMBER_MAX];

        // TODO
        public BTL_PARTY GetParty() { return null; }

        // TODO
        public void Init(BTL_CLIENT_ID clientID, BTL_PARTY party, byte numSelect) { }

        // TODO
        public void SetProhibitFighting(byte numCover) { }

        // TODO
        public void SetProhibit(PokeselReason reason, byte idx) { }

        // TODO
        public BTL_CLIENT_ID GetClientID() { return BTL_CLIENT_ID.BTL_CLIENT_PLAYER; }

        // TODO
        public byte GetNumSelect() { return 0; }

        // TODO
        public void DisablePutPosSequence() { }

        // TODO
        public bool IsDisabledPutPosSequence() { return false; }
    }
}