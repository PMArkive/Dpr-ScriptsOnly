namespace Dpr.Field.Walking
{
    public class SanpoPairState : SanpoStateBase
    {
        public SanpoPairState(AIFureaiModel model) : base(model)
        {
            ActionProbability = 1.0f;
            ActionLotteryInterval = 3.0f;

            AddAction(new SanpoPairDotuki());
            AddAction(new SanpoPairEngi());
            AddAction(new SanpoPairHoe());
        }

        public override void CommonUpdate()
        {
            var pairModel = sanpoModel.PairModel;

            if (pairModel == null)
            {
                corSys.Cancel();
                model.AI.ChangeState(typeof(SanpoState));
            }
            else
            {
                var playerTf = EntityManager.activeFieldPlayer.transform;
                sanpoModel.Update(deltaTime, playerTf, model.transform);

                if (!CheckAddWalking() && !LookPlayer())
                {
                    model.walkData.nowSpeed = 0.0f;
                    model.walkData.LookAtTarget(pairModel.pair.transform.position, deltaTime, 3.0f);
                    model.walkData.totalMoveDistance = 0.0f;

                    if (pairModel.isMaster && corSys != null && corSys.isFinished)
                        base.CommonUpdate();
                }
            }
        }

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