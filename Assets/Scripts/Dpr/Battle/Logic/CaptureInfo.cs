namespace Dpr.Battle.Logic
{
    public sealed class CaptureInfo
    {
        private BtlPokePos m_capturedPokePos;
        private BTL_CLIENT_ID m_captguredClientID;

        public CaptureInfo()
        {
            Clear();
        }

        public void Clear()
        {
            m_capturedPokePos = BtlPokePos.POS_NULL;
            m_captguredClientID = BTL_CLIENT_ID.BTL_CLIENT_NULL;
        }

        public BtlPokePos GetCauturedPokePos()
        {
            return m_capturedPokePos;
        }

        public void SetCapturedPokePos(BtlPokePos pos)
        {
            m_capturedPokePos = pos;
        }

        public BTL_CLIENT_ID GetCapturedClientID()
        {
            return m_captguredClientID;
        }

        public void SetCapturedClientID(BTL_CLIENT_ID clientID)
        {
            m_captguredClientID = clientID;
        }
    }
}