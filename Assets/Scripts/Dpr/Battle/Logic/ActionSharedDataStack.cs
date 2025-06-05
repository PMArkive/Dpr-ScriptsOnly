namespace Dpr.Battle.Logic
{
    public sealed class ActionSharedDataStack
    {
        private ActionSharedData[] m_data = Arrays.InitializeWithDefaultInstances<ActionSharedData>(6);
        private byte m_index;

        public ActionSharedDataStack()
        {
            Initialize();
        }

        public void Initialize()
        {
            m_index = 0;
            clear(GetCurrentData());
        }

        public ActionSharedData GetCurrentData()
        {
            return m_data[m_index];
        }

        public void Push()
        {
            m_index++;
            clear(GetCurrentData());
        }

        public void Pop()
        {
            if (m_index != 0)
                m_index--;
        }

        private void clear(ActionSharedData data)
        {
            data.wazaMessageParam.Clear();
            data.wazaEffectParams.Clear();
            data.magicCoatParam.Clear();
            data.isWazaFailMessageDisplayed = false;
            data.isWazaFailMessageRoundUp = false;
            data.isInterruptAction = false;
        }
    }
}