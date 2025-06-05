namespace Pml.Local
{
    public static class Random
    {
        public static uint GetValue()
        {
            _ = PmlUse.Instance;
            return (uint)UnityEngine.Random.Range(int.MinValue, int.MaxValue);
        }

        public static uint GetValue(uint max)
        {
            var val = GetValue();
            return max == 0 ? val : val % max;
        }
    }
}