namespace Dpr.Battle.Logic
{
    public class Random
    {
        private Xoroshiro128Plus.Xoroshiro128Plus m_randomEngine = new Xoroshiro128Plus.Xoroshiro128Plus();
        private ulong m_seed;

        public void Initialize()
        {
            Initialize(GenerateSeed());
        }

        public void Initialize(ulong seed)
        {
            m_seed = seed;
            m_randomEngine = new Xoroshiro128Plus.Xoroshiro128Plus(seed);
        }

        public ulong GetSeed()
        {
            return m_seed;
        }

        public ulong GetValue()
        {
            return m_randomEngine.NextULong();
        }

        public ulong GetValue(ulong max)
        {
            var value = GetValue();

            if (max == 0)
                return 0;
            else
                return value % max;
        }

        private static ulong GenerateSeed()
        {
            return (ulong)UnityEngine.Random.Range(int.MinValue, int.MaxValue);
        }

        public static int GetPublicRand(int range)
        {
            return UnityEngine.Random.Range(0, range);
        }
    }
}