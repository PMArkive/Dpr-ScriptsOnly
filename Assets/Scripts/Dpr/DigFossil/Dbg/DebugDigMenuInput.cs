namespace Dpr.DigFossil.Dbg
{
	public class DebugDigMenuInput
	{
		private GameController.LogicalInput localInput = new GameController.LogicalInput();
		
		public void Initialize()
		{
			AssignInputGoContestScene();
			GameController.Subscribe(localInput);
		}
		
		public void OnFinalize()
		{
            GameController.Remove(localInput);
        }
		
		private void AssignInputGoContestScene()
		{
			localInput.Assign((int)KeyAssignId.GoDigFossilScene, GameController.ButtonMask.Minus);
		}

		// TODO
		public bool IsInputOnKeywaitButtonPush() { return default; }
		
		// TODO
		private bool IsButtonPush(int assignValue) { return default; }

		private enum KeyAssignId : int
		{
			GoDigFossilScene = 0,
		}

		private class KeyAssignValue
		{
			public const int GoDigFossilScene = 1;
		}
	}
}