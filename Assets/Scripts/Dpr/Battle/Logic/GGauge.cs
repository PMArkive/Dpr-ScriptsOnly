namespace Dpr.Battle.Logic
{
    public sealed class GGauge
    {
        public const byte MAX_VALUE = 7;

        private byte m_value;

        public GGauge()
        {
            Initialize();
        }

        public void Initialize()
        {
            m_value = MAX_VALUE;
        }

        public void CopyFrom(in GGauge src)
        {
            m_value = src.m_value;
        }

        public byte GetValue()
        {
            return m_value;
        }

        public bool IsFull()
        {
            return m_value >= MAX_VALUE;
        }

        public void IncValue()
        {
            if (!IsFull())
                m_value++;
        }

        public void SetEmpty()
        {
            m_value = 0;
        }
    }
}