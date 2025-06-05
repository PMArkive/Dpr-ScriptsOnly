using System;
using UnityEngine;
using UnityEngine.Events;

namespace SmartPoint.Components
{
	public class ToggleButtonRawGroup : MonoBehaviour
	{
		[SerializeField]
		private ToggleButtonRaw[] _toggles;
		[SerializeField]
		private SelectEvent _onSelected;

		private int _activeIndex = -1;
		public ToggleButtonRaw.SubmitEvent onSubmit;
		
		// TODO
		public int activeIndex { get; set; }

		public ToggleButtonRaw activeToggle { get => _toggles[_activeIndex]; }
		
		// TODO
		private void OnEnable() { }
		
		// TODO
		public void Previous() { }
		
		// TODO
		public void Next() { }
		
		// TODO
		private void OnDisable() { }
		
		// TODO
		private void OnClick() { }
		
		// TODO
		public void OnSubmit(int value) { }

		[Serializable]
		public class SelectEvent : UnityEvent<ToggleButtonRaw> { }
	}
}