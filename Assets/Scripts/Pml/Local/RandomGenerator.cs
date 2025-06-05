namespace Pml.Local
{
    public sealed class RandomGenerator
    {
        private Xoroshiro128Plus.Xoroshiro128Plus m_rng;
        private ulong m_seed;

        public void Initialize()
        {
            m_seed = GenerateSeed();
            m_rng = new Xoroshiro128Plus.Xoroshiro128Plus(m_seed);
        }

        public void Initialize(ulong seed)
        {
            m_seed = seed;
            m_rng = new Xoroshiro128Plus.Xoroshiro128Plus(m_seed);
        }

        public ulong GetSeed()
        {
            return m_seed;
        }

        public static ulong GenerateSeed()
        {
            return (ulong)UnityEngine.Random.Range(int.MinValue, int.MaxValue);
        }

        public uint GetRand()
        {
            return m_rng.NextUInt();
        }

        public uint GetRand(uint max)
        {
            var val = m_rng.NextUInt();
            return max == 0 ? val : val % max;
        }
    }
}