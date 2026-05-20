using System.Numerics;

namespace Dpr.Field.Walking
{
    public class GotoSanpoState : SanpoStateBase
    {
        private float stateTime;

        public GotoSanpoState(AIFureaiModel model) : base(model)
        {
            // Empty
        }

        protected override void StateUpdate()
        {
            stateTime += deltaTime;

            var walkData = model.walkData;
            var route = model.route;
            var tf = model.transform;
            var playerTf = EntityManager.activeFieldPlayer.transform;

            sanpoModel.Update(deltaTime, playerTf, model.transform);

            if (stateTime <= 3.0f || !CheckAddWalking() || route.IsNullOrEmpty())
            {
                var routePoint = route[0];

                walkData.LookAtTarget(routePoint, deltaTime, 10.0f);

                var dist = Vector2.Distance(new Vector2(tf.position.x, tf.position.z), new Vector2(routePoint.x, routePoint.z));

                if (dist < 2.0f && route.Count != 1)
                    route.RemoveAt(0);

                if (dist < 0.5f && route.Count == 1)
                {
                    walkData.nowSpeed = 0.0f;
                    var pair = model.fureaiModel.sanpoModel.PairModel;
                    model.AI.ChangeState(pair == null ? typeof(SanpoState) : typeof(SanpoPairState));
                }

                walkData.isNeedRun = true;
                walkData.Move(deltaTime, 10.0f, 2.5f, dist);
            }
        }

        public override void Enter()
        {
            model.charaModel.collisionModel.isIgnoreCollision = true;
            stateTime = 0.0f;
        }

        public override void Exit()
        {
            model.charaModel.collisionModel.isIgnoreCollision = false;
        }
    }
}