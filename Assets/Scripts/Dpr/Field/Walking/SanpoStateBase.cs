using Dpr.FureaiHiroba;

namespace Dpr.Field.Walking
{
    public abstract class SanpoStateBase : AIStateBase
    {
        private static readonly int[] RankToEmoticonNo = new int[6] { 0, 0, 0, 3, 3, 2 };

        protected AIFureaiModel model { get => base.model as AIFureaiModel; }
        protected PokeSanpoModel sanpoModel { get => model.sanpoModel; }
        protected WalkData walkModel { get => model.walkData; }

        public SanpoStateBase(AIFureaiModel model) : base(model)
        {
            // Empty
        }

        // TODO
        protected bool CheckAddWalking() { return false; }

        // TODO
        protected bool LookPlayer() { return false; }

        // TODO
        protected override void StateUpdate()
        {
            // Empty
        }
    }
}