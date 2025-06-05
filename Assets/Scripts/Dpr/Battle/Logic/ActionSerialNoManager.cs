namespace Dpr.Battle.Logic
{
    public sealed class ActionSerialNoManager
    {
        private uint m_serialNo;

        public ActionSerialNoManager()
        {
            Clear();
        }

        public void CopyFrom(in ActionSerialNoManager src)
        {
            m_serialNo = src.m_serialNo;
        }

        public void Clear()
        {
            m_serialNo = 0;
        }

        public void AssignSerialNo(ActionDesc actionDesc)
        {
            if (m_serialNo == 0)
                m_serialNo = 1;

            actionDesc.serialNo = m_serialNo;
            m_serialNo++;
        }
    }
}