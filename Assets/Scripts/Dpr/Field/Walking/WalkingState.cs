namespace Dpr.Field.Walking
{
    public class WalkingState : AIStateBase
    {
        protected WalkData walkModel { get => model.walkData; }

        public WalkingState(AIModel model) : base(model)
        {
            // Empty
        }

        protected override void StateUpdate()
        {
            if (!walkModel.isNeedWalk && !walkModel.isNeedRun)
            {
                walkModel.nowSpeed = 0.0f;
            }
            else
            {
                walkModel.priority = walkModel.yoyakuPriority;
                walkModel.Move(deltaTime, 1.0f);
            }

            var speed = walkModel.isNeedRun ? 10.0f : 6.0f;

            walkModel.LookAtTarget(walkModel.TargetPosition, deltaTime, speed);

            if (model.charaModel.walkData.CollidedCount > 20)
            {
                AICommon.Warp(model, false);
                model.charaModel.walkData.CollidedCount = 0;
            }
        }
    }
}