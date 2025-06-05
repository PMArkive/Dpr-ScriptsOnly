namespace Dpr.Field.Walking
{
    public class SanpoPairState : SanpoStateBase
    {
        // TODO
        public SanpoPairState(AIFureaiModel model) : base(model)
        {
            ActionProbability = 1.0f;
            ActionLotteryInterval = 3.0f;
        }

        // TODO
        public override void CommonUpdate() { }

        public override void Exit()
        {
            // Empty
        }

        protected override void StateUpdate()
        {
            // Empty
        }
    }
}