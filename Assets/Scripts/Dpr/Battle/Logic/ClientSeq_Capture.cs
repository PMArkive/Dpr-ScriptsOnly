namespace Dpr.Battle.Logic
{
    public sealed class ClientSeq_Capture
    {
        private MainModule m_mainModule;
        private BTL_CLIENT m_client;
        private POKECON m_pokecon;
        private BattleViewBase m_viewSystem;
        private int m_seq;
        private bool m_isFinished;

        public ClientSeq_Capture()
        {
            m_mainModule = null;
            m_client = null;
            m_pokecon = null;
            m_viewSystem = null;

            Start();
        }

        public void Setup(in SetupParam setupParam)
        {
            m_mainModule = setupParam.mainModule;
            m_client = setupParam.client;
            m_pokecon = setupParam.pokecon;
            m_viewSystem = setupParam.viewSystem;
        }

        public void Start()
        {
            m_seq = 0;
            m_isFinished = false;
        }

        public bool IsFinished()
        {
            return m_isFinished;
        }

        public void Update()
        {
            if (!m_isFinished)
                m_isFinished = true;
        }

        public class SetupParam
        {
            public MainModule mainModule;
            public BTL_CLIENT client;
            public POKECON pokecon;
            public BattleViewBase viewSystem;
        }

        private enum Sequence : int
        {
            SEQ_EXIT = 0,
        }
    }
}