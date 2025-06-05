namespace Dpr.SecretBase
{
	public class StateField : StateBase<StatuePlacementEditController.State, StatuePlacementEditController>
	{
		private PlacementData prev;
		
		public StateField() : base(StatuePlacementEditController.State.Field)
		{
			// Empty
		}
		
		// TODO
		public override void Enter(StatuePlacementEditController owner) { }
		
		// TODO
		public override void Execute(StatuePlacementEditController owner) { }
		
		// TODO
		public override void Exit(StatuePlacementEditController owner) { }
		
		// TODO
		private void UpdateCursor(StatuePlacementEditController owner) { }
		
		// TODO
		private bool IsEnableInput() { return default; }
	}
}