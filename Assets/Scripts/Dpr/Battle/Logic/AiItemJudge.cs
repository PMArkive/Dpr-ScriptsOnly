using Pml;

namespace Dpr.Battle.Logic
{
    public sealed class AiItemJudge : AiJudge
    {
        private readonly MainModule m_mainModule;
        private readonly BattleEnv m_pBattleEnv;
        private BTL_POKEPARAM m_poke;
        private Random m_randGenerator = new Random();
        private AiScript m_script;
        private AiScriptHandler m_scriptHandler;
        private AiScriptCommandHandler m_scriptCommandHandler;
        private ushort m_itemNo;
        private int m_score;
        private uint m_seq;
        private bool m_isFinished;

        public AiItemJudge(AiScript aiScript, MainModule mainModule, BattleEnv pBattleEnv, BattleSimulator pBattleSimulator, ulong randSeed, uint scriptBit, byte myClientID) :
            base(myClientID, BtlAiScriptNo.BTL_AISCRIPT_NO_ITEM_MIN, BtlAiScriptNo.BTL_AISCRIPT_NO_ITEM_MAX, scriptBit)
        {
            m_mainModule = mainModule;
            m_pBattleEnv = pBattleEnv;
            m_poke = null;
            m_script = aiScript;
            m_scriptHandler = null;
            m_scriptCommandHandler = null;
            m_itemNo = (ushort)ItemNo.DUMMY_DATA;
            m_score = 0;
            m_isFinished = true;

            m_randGenerator.Initialize(randSeed);
            m_scriptHandler = new AiScriptHandler();
            m_scriptCommandHandler = new AiScriptCommandHandler(mainModule, pBattleSimulator, pBattleEnv, randSeed);
        }

        // TODO
        public override void Dispose() { }

        // TODO
        public void StartJudge(BTL_POKEPARAM poke, ushort itemNo) { }

        // TODO
        public override void UpdateJudge() { }

        // TODO
        private void StartScript() { }

        private void RegisterScriptResult()
        {
            m_score += m_scriptHandler.GetScriptResult().score;
        }

        public override bool IsJudgeFinished()
        {
            return m_isFinished;
        }

        public int GetScore()
        {
            return m_score;
        }

        private enum UpdateJudgeSeq : int
        {
            SEQ_SCRIPT_START = 0,
            SEQ_SCRIPT_WAIT = 1,
            SEQ_TO_NEXT_SCRIPT = 2,
            SEQ_END = 3,
        }
    }
}