using System.Runtime.InteropServices;
using UnityEngine.Events;

namespace Dpr.UI
{
	public class UIInputButton
	{
		private UnityAction<int, State> _onCallbacked;
		private UIInputController _input;
		private float _longPressTime = 0.5f;
		private int _button;
		private float _pressTime;
		
		public UIInputButton()
		{
			// Empty, declared explicitly
		}
		
		public UIInputButton(int button, UnityAction<int, State> onCallbacked, [Optional] UIInputController input, bool isAutoUpdate = true, float longPressTime = 0.5f)
		{
			Setup(button, onCallbacked, input, isAutoUpdate, longPressTime);
		}
		
		// TODO
		public void Setup(int button, UnityAction<int, State> onCallbacked, [Optional] UIInputController input, bool isAutoUpdate = true, float longPressTime = 0.5f) { }
		
		// TODO
		public void OnUpdate(float deltaTime) { }

		public enum State : int
		{
			LongPressed = 0,
			Clicked = 1,
		}
	}
}