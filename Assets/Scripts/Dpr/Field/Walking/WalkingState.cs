namespace Dpr.Field.Walking
{
    public class WalkingState : AIStateBase
    {
        protected WalkData walkModel { get => model.walkData; }

        public WalkingState(AIModel model) : base(model)
        {
            // Empty
        }

        // TODO
        protected override void StateUpdate() { }
    }
}