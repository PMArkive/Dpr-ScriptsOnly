namespace Dpr.Battle.Logic
{
    public class EventVarSetStack
    {
        private const uint STACK_SIZE = 32;
        private EventVarSet[] m_varSets = new EventVarSet[STACK_SIZE];
        private uint m_stackPointer;

        public EventVarSetStack()
        {
            m_stackPointer = 0;
            createVarSets();
            ToEmpty();
        }

        private void createVarSets()
        {
            for (int i=0; i<m_varSets.Length; i++)
                m_varSets[i] = new EventVarSet();
        }

        public void ToEmpty()
        {
            m_stackPointer = 0;

            for (int i=0; i<m_varSets.Length; i++)
                m_varSets[i] = null;
        }

        public virtual void Dispose()
        {
            // Empty
        }

        public EventVarSet GetCurrent()
        {
            return m_varSets[m_stackPointer];
        }

        public void Push()
        {
            if (m_stackPointer < m_varSets.Length - 1)
                m_stackPointer++;
        }

        public void Pop()
        {
            if (m_stackPointer != 0)
            {
                GetCurrent().Clear();
                m_stackPointer--;
            }
        }
    }
}