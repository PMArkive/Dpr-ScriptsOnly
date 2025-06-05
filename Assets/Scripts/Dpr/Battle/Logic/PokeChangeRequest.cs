﻿namespace Dpr.Battle.Logic
{
    public sealed class PokeChangeRequest
    {
        private readonly MainModule m_pMainModule;
        private BtlPokePos[] m_requestPos = new BtlPokePos[5];
        private byte m_requestCount;

        public PokeChangeRequest(MainModule pMainModule)
        {
            m_pMainModule = pMainModule;
            m_requestCount = 0;
        }

        // TODO
        public void Clear() { }

        // TODO
        public void Request(BtlPokePos pos) { }

        // TODO
        public void RequestEmptyPos(in PosPoke posPoke) { }

        // TODO
        private void addRequest(BtlPokePos pos) { }

        // TODO
        public bool IsExist() { return false; }

        // TODO
        public bool IsExist(BTL_CLIENT_ID clientID) { return false; }

        // TODO
        public byte GetCount() { return 0; }

        // TODO
        public byte GetCount(BTL_CLIENT_ID clientID) { return 0; }

        // TODO
        public BtlPokePos GetRequestPos(byte index) { return BtlPokePos.POS_1ST_0; }
    }
}