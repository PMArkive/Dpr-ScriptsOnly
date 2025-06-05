using Dpr.FureaiHiroba;

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

        // TODO
        public override void CommonUpdate()
        {
            base.CommonUpdate();
        }

        // TODO
        protected override void StateUpdate() { }

        public override void Enter()
        {
            isNearPlayer = false;
        }
    }
}