namespace Dpr.Field.Walking
{
	public class NpcWalkingState : WalkingState
	{
		public NpcWalkingState(AIModel model) : base(model)
		{
			model.charaModel.collisionModel = new NpcCollitionModel(model.charaModel.walkData);
		}
		
		// TODO
		protected override void StateUpdate() { }
	}
}