namespace Dpr.Field.Walking
{
    public class SanpoState : SanpoStateBase
    {
        public SanpoState(AIFureaiModel model) : base(model)
        {
            ActionProbability = 1.0f;
            ActionLotteryInterval = 0.2f;

            AddAction(new SanpoWait()).lotteryWeight = 40.0f;
            AddAction(new SanpoRun()).lotteryWeight = 5.0f;
            AddAction(new SanpoUroUro()).lotteryWeight = 60.0f;
            AddAction(new SanpoSleep()).lotteryWeight = 5.0f;

            // Result ignored
            _ = EntityManager.activeFieldPlayer.transform;
        }

        public override void CommonUpdate()
        {
            var playerTf = EntityManager.activeFieldPlayer.transform;

            sanpoModel.Update(deltaTime, playerTf, model.transform);

            if (!CheckAddWalking() && !LookPlayer())
            {
                base.CommonUpdate();
                model.walkData.totalMoveDistance = 0.0f;
            }
        }

        protected override void StateUpdate()
        {
            // Empty
        }
    }
}