using Dpr.FureaiHiroba;

namespace Dpr.Field.Walking
{
    public class UgPokeController : WalkingCharacterController
    {
        public override void SetModel(WalkingCharacterModel model)
        {
            this.model = model;
            this.AI = new AI(this);
            this.effectManager = new PokeEffect(transform);

            AISetting();
        }

        public override void AISetting()
        {
            AI.AddState<UG_NormalState>();
            AI.AddState<UG_FoundState>();
            AI.AddState<UG_TeleporterState>();
            AI.AddState<UG_TeleporterFoundState>();
        }

        public override AIModel CreateAIModel()
        {
            return new AIUgModel(this);
        }

        protected override void ModelUpdate(float deltaTime)
        {
            model.Update(null, 1.0f, 1.0f);
            model.walkData.Update(deltaTime);
        }

        public override void MyLateUpdate(float deltaTime)
        {
            model.collisionModel.LateUpdate(deltaTime);
        }

        public override void MyUpdate(float deltaTime)
        {
            base.MyUpdate(deltaTime);
        }

        public override void CheckAttribute()
        {
            // Empty
        }
    }
}