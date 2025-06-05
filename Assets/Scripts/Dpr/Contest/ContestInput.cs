namespace Dpr.Contest
{
	public class ContestInput
	{
		private GameController.LogicalInput localInput = new GameController.LogicalInput();
		
		// TODO
		public void Subscribe() { }
		
		// TODO
		public void Remove() { }
		
		// TODO
		private void AssignTap() { }
		
		// TODO
		private void AssignWaza() { }
		
		// TODO
		private void AssignDecide() { }
		
		// TODO
		public bool IsPushPositiveButton() { return default; }
		
		// TODO
		public bool IsOnPositiveButton() { return default; }
		
		// TODO
		public bool IsPushWazaButton() { return default; }
		
		// TODO
		public bool IsPushDecideButton() { return default; }
		
		// TODO
		private bool IsButtonPush(int assignValue) { return default; }
		
		// TODO
		private bool IsButtonOn(int assignValue) { return default; }
		
		// TODO
		private bool IsButtonRelease(int assignValue) { return default; }

		private enum KeyAssignId : int
		{
			Tap = 0,
			Waza = 1,
			Decide = 2,
		}

		private class KeyAssignIdValue
		{
			public const int Tap = 1;
			public const int Waza = 2;
			public const int Decide = 4;
		}
	}
}