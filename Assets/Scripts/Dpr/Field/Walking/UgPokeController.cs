namespace Dpr.Field.Walking
{
    public class UgPokeController : WalkingCharacterController
    {
        // TODO
        public override void SetModel(WalkingCharacterModel model) { }

        // TODO
        public override void AISetting() { }

        public override AIModel CreateAIModel()
        {
            return new AIUgModel(this);
        }

        // TODO
        protected override void ModelUpdate(float deltaTime) { }

        public override void MyLateUpdate(float deltaTime)
        {
            model.collisionModel.LateUpdate(deltaTime);
        }

        // TODO
        public override void MyUpdate(float deltaTime) { }

        public override void CheckAttribute()
        {
            // Empty
        }
    }
}