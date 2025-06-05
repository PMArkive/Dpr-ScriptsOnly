namespace Dpr.SecretBase
{
	public class StateFillterWindow : StateBase<StatuePlacementEditController.State, StatuePlacementEditController>
	{
		private string prevFooter;
		public StatuePlacementEditController Owner;
		
		public StateFillterWindow() : base(StatuePlacementEditController.State.FillterWindow)
		{
			// Empty
		}
		
		// TODO
		public override void Enter(StatuePlacementEditController owner) { }
		
		// TODO
		public override void Execute(StatuePlacementEditController owner) { }
		
		// TODO
		public override void Exit(StatuePlacementEditController owner) { }

		public enum State : int
		{
			FillterSelect = 0,
			PokeType1 = 1,
			PokeType2 = 2,
			Size = 3,
			Category = 4,
			Legend = 5,
		}
	}
}