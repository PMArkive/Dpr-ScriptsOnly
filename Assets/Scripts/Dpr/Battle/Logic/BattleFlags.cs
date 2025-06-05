namespace Dpr.Battle.Logic
{
    public sealed class BattleFlags
    {
        private bool[] m_flags = Arrays.InitializeWithDefaultInstances<bool>(1);

        public BattleFlags()
        {
            Initialize();
        }

        public void Initialize()
        {
            for (int i=0; i<m_flags.Length; i++)
                m_flags[i] = false;
        }

        public void CopyFrom(in BattleFlags src)
        {
            for (int i=0; i<m_flags.Length; i++)
                m_flags[i] = src.m_flags[i];
        }

        public bool Get(Flag flag)
        {
            return m_flags[(int)flag];
        }

        public void Set(Flag flag)
        {
            m_flags[(int)flag] = true;
        }

        public void Remove(Flag flag)
        {
            m_flags[(int)flag] = false;
        }

        public enum Flag : ushort
        {
            FIRST_POKEIN_DONE = 0,
            NUM = 1,
        }
    }
}