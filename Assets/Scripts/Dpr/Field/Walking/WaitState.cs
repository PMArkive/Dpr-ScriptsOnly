namespace Dpr.Field.Walking
{
    public class WaitState : AIStateBase
    {
        public WaitState(AIModel model) : base(model)
        {
            // Empty
        }

        protected override void StateUpdate()
        {
            var walkData = model.walkData;
            _ = model.route;

            walkData.LookAtTarget(LookTarget.position, deltaTime, 10.0f);
        }
    }
}