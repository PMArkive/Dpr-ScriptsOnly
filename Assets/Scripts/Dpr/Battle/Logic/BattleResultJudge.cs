namespace Dpr.Battle.Logic
{
    public static class BattleResultJudge
    {
        // TODO
        public static BtlResult CheckBattleResult(in MainModule mainModule, in POKECON pokecon, in DeadRec deadRec, in TimeLimit timeLimit, out ResultCause judgeCause)
        {
            judgeCause = ResultCause.RESULT_CAUSE_OTHER;
            return BtlResult.BTL_RESULT_LOSE;
        }

        // TODO
        private static BtlSide JudgeWinSide(in MainModule mainModule, in POKECON pokecon, in DeadRec deadRec, in TimeLimit timeLimit, out ResultCause judgeCause)
        {
            judgeCause = ResultCause.RESULT_CAUSE_OTHER;
            return BtlSide.BTL_SIDE_1ST;
        }

        // TODO
        private static void GetPokeCountBySide(byte[] alivePokeCount, byte[] totalPokeCount, byte[] timeOverCount, in MainModule mainModule, in POKECON pokecon, in TimeLimit timeLimit) { }

        // TODO
        private static BtlSide JudgeWinSide_UniqueAlive(in MainModule mainModule, byte[] alivePokeCount) { return BtlSide.BTL_SIDE_1ST; }

        // TODO
        private static BtlSide JudgeWinSide_UniqueTimeOver(byte[] timeOverCount, in MainModule mainModule) { return BtlSide.BTL_SIDE_1ST; }

        // TODO
        private static BtlSide JudgeWinSide_DeadBoth(byte[] alivePokeCount, byte[] totalPokeCount, in MainModule mainModule, in DeadRec deadRec) { return BtlSide.BTL_SIDE_1ST; }

        // TODO
        private static BtlSide JudgeWinSide_ByDeadPokeCount(in MainModule mainModule, byte[] alivePokeCount, byte[] totalPokeCount) { return BtlSide.BTL_SIDE_1ST; }

        // TODO
        private static BtlSide JudgeWinSide_ByRemainedHpRatio(in MainModule mainModule, int[] remainedHpRatio) { return BtlSide.BTL_SIDE_1ST; }

        // TODO
        private static BtlSide JudgeWinSide_ByRemainedHpTotal(in MainModule mainModule, int[] remainedHpTotal) { return BtlSide.BTL_SIDE_1ST; }

        // TODO
        private static void CalcHPRatio(ref int HP_sum, ref int HP_ratio, in MainModule mainModule, in POKECON pokecon, in BtlSide targetSide) { }
    }
}