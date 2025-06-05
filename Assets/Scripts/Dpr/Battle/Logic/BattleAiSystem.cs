namespace Dpr.Battle.Logic
{
    public static class BattleAiSystem
    {
        public const int BASIC_RAND_RANGE = 256;

        private static bool[] s_isTokuseiOpened = new bool[PokeID.NUM];
        private static ulong s_commonRandValue;

        public static void InitSystem()
        {
            for (int i=0; i<PokeID.NUM; i++)
                s_isTokuseiOpened[i] = false;
        }

        // TODO
        public static void QuitSystem() { }

        // TODO
        public static void NotifyTokuseiOpen(byte pokeID) { }

        // TODO
        public static bool IsTokuseiOpened(byte pokeID) { return false; }

        // TODO
        public static void SetCommonRand(ulong randValue) { }

        // TODO
        public static ulong GetCommonRand() { return 0; }
    }
}