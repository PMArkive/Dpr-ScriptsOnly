namespace Dpr.Battle.Logic
{
    public sealed class GRightsManager
    {
        private readonly MainModule m_pMainModule;
        private GRights[] m_gRights = new GRights[(int)BtlSide.BTL_SIDE_NUM];

        public GRightsManager(MainModule pMainModule, BattleEnv pBattleEnv)
        {
            m_pMainModule = pMainModule;

            createGRights(pMainModule, pBattleEnv);
            Initialize();
        }

        // TODO
        private void createGRights(MainModule pMainModule, BattleEnv pBattleEnv) { }

        // TODO
        public void Initialize() { }

        // TODO
        public void CopyFrom(in GRightsManager src) { }

        // TODO
        public void AddClient(BTL_CLIENT_ID clientID) { }

        public GRights GetGRights(BtlSide side)
        {
            return m_gRights[(int)side];
        }
    }
}