namespace Dpr.Battle.Logic
{
    public sealed class EventVarSet
    {
        private EventVar[] m_pVariables = new EventVar[(ushort)EventVar.Label.NUM];

        public EventVarSet()
        {
            Clear();
        }

        public void Clear()
        {
            for (int i=0; i<m_pVariables.Length; i++)
                m_pVariables[i] = null;
        }

        public EventVar GetVariable(EventVar.Label label)
        {
            if ((ushort)label < m_pVariables.Length)
                return m_pVariables[(ushort)label];
            else
                return null;
        }

        public void SetVariable(EventVar variable)
        {
            var label = variable.GetLabel();

            if ((ushort)label < m_pVariables.Length)
                m_pVariables[(ushort)label] = variable;
        }
    }
}