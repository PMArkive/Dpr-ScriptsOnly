namespace Dpr.Battle.Logic
{
    public sealed class TimeLimit
    {
        private ushort[] m_clientLimitTime = new ushort[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];

        public void CopyFrom(in TimeLimit src)
        {
            for (int i=0; i<m_clientLimitTime.Length; i++)
                m_clientLimitTime[i] = src.m_clientLimitTime[i];
        }

        public void Clear()
        {
            for (int i=0; i<m_clientLimitTime.Length; i++)
                m_clientLimitTime[i] = 0;
        }

        public ushort GetClientLimitTime(byte clientID)
        {
            if (clientID < m_clientLimitTime­.Length)
                return m_clientLimitTime[clientID];
            else
                return 0;
        }

        public void SetClientLimitTime(byte clientID, ushort time)
        {
            if (clientID < m_clientLimitTime­.Length)
                m_clientLimitTime[clientID] = time;
        }
    }
}