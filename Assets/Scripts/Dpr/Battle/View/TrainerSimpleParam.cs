using Dpr.Battle.Logic;
using Dpr.Trainer;

namespace Dpr.Battle.View
{
    public struct TrainerSimpleParam
    {
        public TrainerType trainerType;
        public string modelID;
        public int colorID;
        public int hatVariation;
        public int shoesVariation;
        public HandDominance dominanceHand;
        public HandDominance holdBallHand;
        public float loseLoopTime;
        public TrainerAge trainerAge;
        public int blinkIntervalMin;
        public int blinkIntervalMax;
        public int blinkTwiceRate;

        public static TrainerSimpleParam Factory(TrainerType trainerType)
        {
            var trainer = TrainerSystem.GetTrainerType(trainerType);
            var blinkData = BattleDataTableManager.Instance.BattleDataTable.GetAgeEyeBlinkData(trainer.Age);

            TrainerSimpleParam param = new TrainerSimpleParam
            {
                trainerType = trainerType,
                modelID = trainer.ModelID,
                colorID = 0,
                hatVariation = 0,
                shoesVariation = 0,
                dominanceHand = trainer.Hand,
                holdBallHand = trainer.HoldBallHand,
                loseLoopTime = trainer.LoseLoopTime,
                trainerAge = trainer.Age,
                blinkIntervalMin = blinkData.min,
                blinkIntervalMax = blinkData.max,
                blinkTwiceRate = blinkData.twiceRate,
            };

            return param;
        }
    }
}