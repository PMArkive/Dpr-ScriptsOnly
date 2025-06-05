namespace Dpr.Contest.Dbg
{
	public class MenuInput
	{
		private GameController.LogicalInput localInput = new GameController.LogicalInput();
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void OnFinalize() { }
		
		// TODO
		private void AssignInputGoNextScene() { }
		
		// TODO
		private void AssignInputOpenMenu() { }
		
		// TODO
		public bool IsInputGoNextScene() { return default; }
		
		// TODO
		public bool IsInputOpenMenu() { return default; }
		
		// TODO
		private bool IsButtonPush(int assignValue) { return default; }

		private enum KeyAssignId : int
		{
			GoNextScene = 0,
			OpenMenu = 1,
		}

		private class KeyAssignValue
		{
			public const int GoNextScene = 1;
			public const int OpenMenu = 2;
		}
	}
}