using Dpr.FureaiHiroba;
using Dpr.SubContents;

namespace Dpr.Field.Walking
{
    public class ReturnState : AIStateBase
    {
        private float time;
        private bool isNearPlayer;
        private const int happy1 = 43;
        private const int happy2 = 44;
        private const int happy3 = 45;
        private static readonly int[] Happys = new int[3] { happy2 , happy1, happy3 };

        private FureaiPokeModel fureaiModel { get => model.fureaiModel; }
        private PokeSanpoModel sanpoModel { get => model.sanpoModel; }
        private AIFureaiModel model { get => base.model as AIFureaiModel; }

        public ReturnState(AIFureaiModel model) : base(model)
        {
            // Empty
        }

        public override void CommonUpdate()
        {
            base.CommonUpdate();

            var playerTf = EntityManager.activeFieldPlayer.transform;

            sanpoModel.Update(deltaTime, playerTf, model.transform);
            model.walkData.LookAtTarget(EntityManager.activeFieldPlayer.transform.position, deltaTime, 3.0f);

            if (model.charaModel.CollidedCount > 10)
                AICommon.Warp(model, false);
        }

        protected override void StateUpdate()
        {
            var walkData = model.walkData;

            // Result ignored
            _ = model.route;

            if (fureaiModel.sanpoModel.isAddWalking && !isNearPlayer)
            {
                var animID = Utils.GetExistAnim(walkData.entity, Happys);
                Play(new PlayAnim(animID), () => isNearPlayer = true);
            }

            if (isNearPlayer)
                model.OnPlayerNear.Invoke();
            else
                walkData.Move(deltaTime, 10.0f);
        }

        public override void Enter()
        {
            isNearPlayer = false;
        }
    }
}