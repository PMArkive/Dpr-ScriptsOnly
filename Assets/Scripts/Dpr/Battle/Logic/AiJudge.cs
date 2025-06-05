namespace Dpr.Battle.Logic
{
    public abstract class AiJudge
    {
        public const int SCORE_FLAT = 100;
        public const int SCORE_DISCOURAGE = 0;
        private BtlAiScriptNo m_minScriptNo;
        private BtlAiScriptNo m_maxScriptNo;
        private BtlAiScriptNo m_currentScriptNo;
        private uint m_targetScriptBit;
        private byte m_myClientID;

        // TODO
        public abstract void UpdateJudge();

        // TODO
        public abstract bool IsJudgeFinished();

        public AiJudge(byte myClientID, BtlAiScriptNo minScriptNo, BtlAiScriptNo maxScriptNo, uint targetScriptBit)
        {
            m_minScriptNo = minScriptNo;
            m_maxScriptNo = maxScriptNo;
            m_myClientID = myClientID;
            m_currentScriptNo = BtlAiScriptNo.BTL_AISCRIPT_NO_NULL;
            m_targetScriptBit = targetScriptBit;
        }

        // TODO
        public virtual void Dispose() { }

        // TODO
        protected byte GetMyClientID() { return 0; }

        // TODO
        public void ChangeAiBit(uint targetScriptBit) { }

        // TODO
        public uint GetAiBit() { return 0; }

        // TODO
        protected BtlAiScriptNo GetCurrentScriptNo() { return BtlAiScriptNo.BTL_AISCRIPT_NO_WAZA_MIN; }

        // TODO
        protected void ResetScriptNo() { }

        // TODO
        protected void UpdateScriptNo() { }

        // TODO
        private BtlAiScriptNo GetNextScriptNo(BtlAiScriptNo minScriptNo, BtlAiScriptNo maxScriptNo) { return BtlAiScriptNo.BTL_AISCRIPT_NO_WAZA_MIN; }

        // TODO
        protected bool IsAllScriptFinished() { return false; }
    }
}