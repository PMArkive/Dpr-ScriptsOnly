namespace Dpr.SecretBase
{
	public class StateSelectFromStatueWindow : StateBase<StatuePlacementEditController.State, StatuePlacementEditController>
	{
		private PlacementData placement;
		private int selectIndex = -1;
		
		public StateSelectFromStatueWindow() : base(StatuePlacementEditController.State.SelectFromStatueWindow)
		{
			// Empty
		}
		
		// TODO
		public void Enter_SelectFromStatueWindow(PlacementData data) { }
		
		// TODO
		public override void Enter(StatuePlacementEditController owner) { }
		
		// TODO
		public override void Execute(StatuePlacementEditController owner) { }
		
		// TODO
		public override void Exit(StatuePlacementEditController owner) { }
	}
}