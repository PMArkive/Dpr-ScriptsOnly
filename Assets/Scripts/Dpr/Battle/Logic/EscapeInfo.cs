namespace Dpr.Battle.Logic
{
    public sealed class EscapeInfo
    {
        private PARAM m_param = new PARAM();

        public uint GetCount()
        {
            return m_param.count;
        }

        private void clear()
        {
            m_param.count = 0;

            for (int i=0; i<m_param.clientID.Length; i++)
                m_param.clientID[i] = (byte)BTL_CLIENT_ID.BTL_CLIENT_NULL;
        }

        public EscapeInfo()
        {
            Clear();
        }

        public void Clear()
        {
            clear();
        }

        // TODO
        public void Add(byte clientID) { }

        // TODO
        public BtlResult CheckWinner(in MainModule mainModule, byte myClientID, BtlCompetitor competitorType) { return BtlResult.BTL_RESULT_LOSE; }

        // TODO
        public void Copy(EscapeInfo dst) { }

        private class PARAM
        {
            public uint count;
            public byte[] clientID = new byte[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
        }
    }
}