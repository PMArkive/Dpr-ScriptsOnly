using Dpr.FureaiHiroba;

namespace Dpr.Field.Walking
{
    public class PokeWalkingState : WalkingState
    {
        private FureaiPokeModel fureaiModel { get => model.fureaiModel; }
        private AIFureaiModel model { get => base.model as AIFureaiModel; }

        public PokeWalkingState(AIModel model) : base(model)
        {
            // Empty
        }

        protected override void StateUpdate()
        {
            // No extra code
            base.StateUpdate();
        }
    }
}