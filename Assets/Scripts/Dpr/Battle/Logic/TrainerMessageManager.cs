namespace Dpr.Battle.Logic
{
    public sealed class TrainerMessageManager
    {
        private readonly MainModule m_pMainModule;
        private ClientData[] m_clientData = Arrays.InitializeWithDefaultInstances<ClientData>((int)BTL_CLIENT_ID.BTL_CLIENT_NUM);

        public TrainerMessageManager(MainModule pMainModule)
        {
            m_pMainModule = pMainModule;
            ClearClientData();
        }

        // TODO
        private void ClearClientData() { }

        // TODO
        public bool IsMessageExist(byte clientID, TrainerMessageID messageID) { return false; }

        // TODO
        public void Done(byte clientID, TrainerMessageID messageID) { }

        private sealed class ClientData
        {
            public bool[] isDone = new bool[(int)TrainerMessageID.MESSAGE_NUM];
        }
    }
}