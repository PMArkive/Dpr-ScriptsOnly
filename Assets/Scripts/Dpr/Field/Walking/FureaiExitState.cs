using Dpr.FureaiHiroba;
using System;

namespace Dpr.Field.Walking
{
    public class FureaiExitState : AIStateBase
    {
        public Action OnPlayerNear;
        private float time;
        private bool isRouteNull;

        private FureaiPokeModel fureaiModel { get => model.fureaiModel; }
        private AIFureaiModel model { get => base.model as AIFureaiModel; }

        public FureaiExitState(AIFureaiModel model) : base(model)
        {
            // Empty
        }

        // TODO
        protected override void StateUpdate() { }
    }
}