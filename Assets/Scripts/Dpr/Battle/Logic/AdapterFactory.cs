using Dpr.Battle.Logic.Net;

namespace Dpr.Battle.Logic
{
    public sealed class AdapterFactory
    {
        private Adapter[] m_adapter = new Adapter[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
        private Client m_iPtrNetClient;

        public AdapterFactory(Client iPtrNetClient)
        {
            Dispose();
            m_iPtrNetClient = iPtrNetClient;
        }

        public void Dispose()
        {
            for (int i=0; i<m_adapter.Length; i++)
                m_adapter[i] = null;
        }

        public Adapter Create(BtlCommMode commMode, byte clientID)
        {
            if (m_adapter[clientID] == null)
                m_adapter[clientID] = new Adapter(clientID, commMode != BtlCommMode.BTL_COMM_NONE, m_iPtrNetClient);

            return m_adapter[clientID];
        }
    }
}