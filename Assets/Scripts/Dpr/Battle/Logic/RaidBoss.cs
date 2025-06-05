using Pml;

namespace Dpr.Battle.Logic
{
    public static class RaidBoss
    {
        // TODO: cctor

        public const byte REINFORCE_TURN_MIN = 1;
        public const byte REINFORCE_TURN_MAX = 3;

        private static readonly GetCaptureValueCoefForSpGDuplicationTableElem[] GetCaptureValueCoefForSpGDuplicationTable;
        private static readonly GetCaptureValueCoefByCaptureDifficultyTableElem[] GetCaptureValueCoefByCaptureDifficultyTable;

        // TODO
        public static BtlPokePos SelectTargetPos(in SelectTargetParam param) { return BtlPokePos.POS_1ST_0; }

        // TODO
        private static uint calcTargetWeight(BTL_POKEPARAM target) { return 0; }

        // TODO
        public static bool CheckAngryCondition(BTL_POKEPARAM boss) { return false; }

        // TODO
        public static uint CalcNextAngryHP(BTL_POKEPARAM boss) { return 0; }

        // TODO
        public static void GetCaptureValueCoef(ref int pCoef, ref bool pIsMustSuccess, MainModule pMainModule, BTL_POKEPARAM pBoss) { }

        // TODO
        public static int GetCaptureValueCoefForSpGDuplication(MonsNo monsno) { return 0; }

        // TODO
        public static void GetCaptureValueCoefByCaptureDifficulty(ref int pCoef, ref bool pIsMustSuccess, RaidBossCaptureDifficulty difficulty) { }

        // TODO
        public static bool ShouldSkipCaptureSequence(MainModule pMainModule) { return false; }

        public class SelectTargetParam
        {
            public BattleEnv pBattleEnv;
            public Random pRandom;
            public bool[] isSelectEnable = new bool[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
            public bool equalizeWeight;

            public SelectTargetParam()
            {
                pBattleEnv = null;
                pRandom = null;
                equalizeWeight = false;
                for (int i=0; i<isSelectEnable.Length; i++)
                    isSelectEnable[i] = true;
            }
        }

        private struct GetCaptureValueCoefForSpGDuplicationTableElem
        {
            public MonsNo monsno;
            public int coef;

            public GetCaptureValueCoefForSpGDuplicationTableElem(MonsNo monsno, int coef)
            {
                this.monsno = monsno;
                this.coef = coef;
            }
        }

        private struct GetCaptureValueCoefByCaptureDifficultyTableElem
        {
            public RaidBossCaptureDifficulty difficulty;
            public int coef;

            public GetCaptureValueCoefByCaptureDifficultyTableElem(RaidBossCaptureDifficulty difficulty, int coef)
            {
                this.difficulty = difficulty;
                this.coef = coef;
            }
        }
    }
}