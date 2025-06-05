namespace Dpr.Battle.Logic
{
    public sealed class AiPokeChangeJudge : AiJudge
    {
        private readonly MainModule m_mainModule;
        private BTL_CLIENT m_client;
        private readonly BattleEnv m_pBattleEnv;
        private BTL_POKEPARAM m_targetFrontPoke;
        private Random m_randGenerator = new Random();
        private AiScript m_script;
        private AiScriptHandler m_scriptHandler;
        private AiScriptCommandHandler m_scriptCommandHandler;
        private uint m_seq;
        private bool m_isFinished;
        private byte m_judgePokeCount;
        private byte m_judgePokeIndex;
        private JudgePokeData[] m_judgePokeData = Arrays.InitializeWithDefaultInstances<JudgePokeData>(DefineConstants.BTL_PARTY_MEMBER_MAX);
        private JudgeResult m_result = new JudgeResult();

        public AiPokeChangeJudge(AiScript aiScript, MainModule mainModule, BattleEnv pBattleEnv, BattleSimulator pBattleSimulator, ulong randSeed, uint scriptBit, byte myClientID) :
            base(myClientID, BtlAiScriptNo.BTL_AISCRIPT_NO_POKECHANGE_MIN, BtlAiScriptNo.BTL_AISCRIPT_NO_POKECHANGE_MAX, scriptBit)
        {
            m_mainModule = mainModule;
            m_pBattleEnv = pBattleEnv;
            m_targetFrontPoke = null;
            m_script = aiScript;
            m_scriptHandler = null;
            m_scriptCommandHandler = null;

            m_seq = 0;
            m_isFinished = true;

            m_randGenerator.Initialize(randSeed);
            m_scriptHandler = new AiScriptHandler();
            m_scriptCommandHandler = new AiScriptCommandHandler(mainModule, pBattleSimulator, pBattleEnv, randSeed);
        }

        // TODO
        public override void Dispose() { }

        // TODO
        public void StartJudge(BTL_POKEPARAM targetFrontPoke) { }

        // TODO
        public override void UpdateJudge() { }

        // TODO
        private void InitJudgePokeData() { }

        // TODO
        private void StartScript() { }

        // TODO
        private BTL_POKEPARAM GetCurrentJudgePokeParam() { return null; }

        // TODO
        private void RegisterScriptResult() { }

        // TODO
        private void SetupJudgeResult() { }

        // TODO
        private int GetBestScoredJudgePokeIndex() { return 0; }

        public override bool IsJudgeFinished()
        {
            return m_isFinished;
        }

        public JudgeResult GetJudgeResult()
        {
            return m_result;
        }

        public class JudgeResult
        {
            public bool isPokeChangeEnable;
            public int score;
            public int inPokePartyIndex;
        }

        private class JudgePokeData
        {
            public byte inPartyIndex;
            public bool isChangeEnable;
            public int score;
        }

        public enum SeqUpdateJudge : int
        {
            SEQ_INIT = 0,
            SEQ_SCRIPT_START = 1,
            SEQ_SCRIPT_WAIT = 2,
            SEQ_SCRIPT_END = 3,
            SEQ_TO_NEXT_POKE = 4,
            SEQ_TO_NEXT_SCRIPT = 5,
            SEQ_END = 6,
        }
    }
}