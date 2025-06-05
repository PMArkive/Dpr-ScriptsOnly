namespace Dpr.Battle.Logic
{
    public sealed class ClientSeq_WinWild
    {
        private MainModule m_mainModule;
        private BTL_CLIENT m_client;
        private POKECON m_pokecon;
        private BattleViewBase m_viewSystem;
        private int m_seq;
        private bool m_isFinished;
        private BTLV_STRPARAM m_strParam = new BTLV_STRPARAM();

        public ClientSeq_WinWild()
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

        // TODO
        public void Update() { }

        // TODO
        private bool IsNusiWinEffectEnable() { return false; }

        public class SetupParam
        {
            public MainModule mainModule;
            public BTL_CLIENT client;
            public POKECON pokecon;
            public BattleViewBase viewSystem;
        }

        public enum Sequence : int
        {
            SEQ_MONEY_MESSAGE_START = 0,
            SEQ_MONEY_MESSAGE_WAIT = 1,
            SEQ_WIN_VS_NUSI_EFFECT_START = 2,
            SEQ_WIN_VS_NUSI_EFFECT_WAIT = 3,
            SEQ_WIN_VS_NUSI_MESSAGE_START = 4,
            SEQ_WIN_VS_NUSI_MESSAGE_WAIT = 5,
            SEQ_EXIT = 6,
        }
    }
}