using Dpr.FureaiHiroba;
using SmartPoint.AssetAssistant;
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

        protected override void StateUpdate()
        {
            time += Sequencer.elapsedTime;

            var walkData = model.walkData;

            // Result ignored
            _ = model.route;

            model.walkData.isNeedRun = true;

            walkData.Move(deltaTime, 20.0f);
            walkData.LookAtTarget(EntityManager.activeFieldPlayer.transform.position, deltaTime, 10.0f);

            if (playerDistance < 3.5f || time > 2.5f)
                OnPlayerNear?.Invoke();
        }
    }
}