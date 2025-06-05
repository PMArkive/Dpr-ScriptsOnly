namespace Dpr.Field.Walking
{
    public class SanpoState : SanpoStateBase
    {
        // TODO
        public SanpoState(AIFureaiModel model) : base(model)
        {
            ActionProbability = 1.0f;
            ActionLotteryInterval = 0.2f;
        }

        // TODO
        public override void CommonUpdate() { }

        protected override void StateUpdate()
        {
            // Empty
        }
    }
}