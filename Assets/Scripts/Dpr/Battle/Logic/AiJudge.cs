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

        public void ChangeAiBit(uint targetScriptBit)
        {
        	this.m_targetScriptBit = targetScriptBit;
        }

        public uint GetAiBit()
        {
        	return this.m_targetScriptBit;
        }

        protected BtlAiScriptNo GetCurrentScriptNo()
        {
        	return this.Length;
        }

        // TODO
        protected void ResetScriptNo() { }

        // TODO
        protected void UpdateScriptNo() { }

        private BtlAiScriptNo GetNextScriptNo(BtlAiScriptNo minScriptNo, BtlAiScriptNo maxScriptNo)
        {
        	if (minScriptNo <= maxScriptNo) {
        	  do {
        	    if ((this.m_targetScriptBit & 1 << (ulong)(minScriptNo & 0x1f)) != 0) {
        	      return minScriptNo;
        	    }
        	    minScriptNo = minScriptNo + 1;
        	  } while (minScriptNo <= maxScriptNo);
        	}
        	return (BtlAiScriptNo)8;
        }

        protected bool IsAllScriptFinished()
        {
        	return this.m_maxScriptNo < this.Length;
        }
    }
}