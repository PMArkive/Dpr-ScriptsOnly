namespace Dpr.Battle.Logic
{
    public sealed class EventVarStack
    {
        private const uint EVENTVAL_STACK_DEPTH = 96;
        private EventVar[] m_variables = new EventVar[EVENTVAL_STACK_DEPTH];
        private uint m_sp;

        public EventVarStack()
        {
            m_sp = 0;
            createVariables();
            ToEmpty();
        }

        private void createVariables()
        {
            for (int i=0; i<m_variables.Length; i++)
                m_variables[i] = new EventVar();
        }

        public void ToEmpty()
        {
            m_sp = 0;
            for (int i=0; i<m_variables.Length; i++)
                m_variables[i].SetLabel(EventVar.Label.INVALID);
        }

        public bool IsEmpty()
        {
            return m_sp == 0;
        }

        public void Push()
        {
            if (m_sp >= EVENTVAL_STACK_DEPTH)
                return;

            for (; m_sp<EVENTVAL_STACK_DEPTH; m_sp++)
            {
                if (m_variables[m_sp].GetLabel() == EventVar.Label.INVALID)
                    break;
            }

            if (m_sp >= EVENTVAL_STACK_DEPTH - 1)
                return;

            m_variables[m_sp].SetLabel(EventVar.Label.SYS_SEPARATE);
            m_sp++;
        }

        public void Pop()
        {
            if (IsEmpty())
                return;

            for (uint i=m_sp; i<EVENTVAL_STACK_DEPTH; i++)
            {
                if (m_variables[i].GetLabel() == EventVar.Label.INVALID)
                    break;
                else
                    m_variables[i].SetLabel(EventVar.Label.INVALID);
            }

            m_sp--;
            m_variables[m_sp].SetLabel(EventVar.Label.INVALID);

            for (uint i=m_sp; !IsEmpty(); i--)
            {
                m_sp = i - 1;

                if (m_variables[m_sp].GetLabel() == EventVar.Label.SYS_SEPARATE)
                {
                    m_sp = i;
                    break;
                }
            }
        }

        public EventVar GetNewPoint(EventVar.Label label)
        {
            EventVar result = null;

            for (uint i=m_sp; i<m_variables.Length; i++)
            {
                result = m_variables[i];
                var varLabel = result.GetLabel();
                if (varLabel == EventVar.Label.INVALID || varLabel == label)
                    break;
            }

            return result;
        }
    }
}