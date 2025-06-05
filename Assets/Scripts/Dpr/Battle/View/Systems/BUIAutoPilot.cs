using Dpr.UI;
using System.Collections;

namespace Dpr.Battle.View.Systems
{
	public class BUIAutoPilot
	{
		private float _cursorWait;
		private float _executeWait;
		private AutoPilotCommand[] _autoPilotData = new AutoPilotCommand[]
		{
            AutoPilotCommand.SetDumyBag,
			AutoPilotCommand.WaitForStandbyAction,
			AutoPilotCommand.ExecuteActionButton,
			AutoPilotCommand.WaitForStandbyWaza,
			AutoPilotCommand.ExecuteWazaButton,
			AutoPilotCommand.WaitForStandbyAction,
			AutoPilotCommand.SelectActionBag,
			AutoPilotCommand.ExecuteActionButton,
			AutoPilotCommand.WaitForOpenBag,
			AutoPilotCommand.SelectBagBallTab,
			AutoPilotCommand.ExecuteBagSelectItem,
			AutoPilotCommand.WaitForOpenContextMenu,
			AutoPilotCommand.ExecuteContextMenuDecision,
			AutoPilotCommand.WaitForCloseBag,
			AutoPilotCommand.ResetDumyBag,
        };

        public AutoPilotState State { get; set; }

        private static AutoPilotMode _mode;
		private BattleViewUISystem _uiSystem;
		
		public bool IsRunning { get => State == AutoPilotState.Running; }
		
		// TODO
		public void BeginAutoPilot(AutoPilotMode mode, float cursorWait, float executeWait) { }
		
		// TODO
		public IEnumerator ExecuteAutoPilot() { return default; }
		
		// TODO
		private IEnumerator WaitForOpenUIWindow<T>(float wait = 0.0f) { return default; }
		
		// TODO
		private IEnumerator WaitForCloseUIWindow<T>(float wait = 0.0f) { return default; }
		
		// TODO
		private IEnumerator PushUIWindowButton(UIWindow uiWindow, int button, float wait) { return default; }

		public enum AutoPilotMode : int
		{
			None = 0,
			Capture = 1,
		}

		public enum AutoPilotState : int
		{
			None = 0,
			Running = 1,
			Done = 2,
		}

		public enum AutoPilotCommand : int
		{
			None = 0,
			WaitForStandbyAction = 1,
			WaitForStandbyWaza = 2,
			ExecuteActionButton = 3,
			ExecuteWazaButton = 4,
			SelectActionBag = 5,
			WaitForOpenBag = 6,
			WaitForCloseBag = 7,
			SelectBagBallTab = 8,
			ExecuteBagSelectItem = 9,
			WaitForOpenContextMenu = 10,
			ExecuteContextMenuDecision = 11,
			SetDumyBag = 12,
			ResetDumyBag = 13,
		}
	}
}