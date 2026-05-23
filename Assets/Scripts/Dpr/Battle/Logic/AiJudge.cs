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

        public abstract void UpdateJudge();

        public abstract bool IsJudgeFinished();

        public AiJudge(byte myClientID, BtlAiScriptNo minScriptNo, BtlAiScriptNo maxScriptNo, uint targetScriptBit)
        {
            m_minScriptNo = minScriptNo;
            m_maxScriptNo = maxScriptNo;
            m_myClientID = myClientID;
            m_currentScriptNo = BtlAiScriptNo.BTL_AISCRIPT_NO_NULL;
            m_targetScriptBit = targetScriptBit;
        }

        public virtual void Dispose()
        {
            // Empty
        }

        protected byte GetMyClientID()
        {
            return m_myClientID;
        }

        public void ChangeAiBit(uint targetScriptBit)
        {
            m_targetScriptBit = targetScriptBit;
        }

        public uint GetAiBit()
        {
            return m_targetScriptBit;
        }

        protected BtlAiScriptNo GetCurrentScriptNo()
        {
            return m_currentScriptNo;
        }

        protected void ResetScriptNo()
        {
            m_currentScriptNo = GetNextScriptNo(m_minScriptNo, m_maxScriptNo);
        }

        protected void UpdateScriptNo()
        {
            m_currentScriptNo++;
            m_currentScriptNo = GetNextScriptNo(m_currentScriptNo, m_maxScriptNo);
        }

        private BtlAiScriptNo GetNextScriptNo(BtlAiScriptNo minScriptNo, BtlAiScriptNo maxScriptNo)
        {
            for (var i=minScriptNo; i<=maxScriptNo; i++)
            {
                if ((m_targetScriptBit & (1 << (int)i)) != 0)
                    return i;
            }

            return BtlAiScriptNo.BTL_AISCRIPT_NO_NULL;
        }

        protected bool IsAllScriptFinished()
        {
            return m_currentScriptNo > m_maxScriptNo;
        }
    }
}