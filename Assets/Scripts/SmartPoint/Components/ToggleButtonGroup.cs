using System;
using UnityEngine;
using UnityEngine.Events;

namespace SmartPoint.Components
{
	public class ToggleButtonGroup : MonoBehaviour
	{
		[SerializeField]
		private ToggleButton[] _toggles;
		[SerializeField]
		private SelectEvent _onSelected;

		private ToggleButton _activeToggle;
		
		public ToggleButton activeToggle { get => _activeToggle; }
		
		// TODO
		private void OnEnable() { }
		
		// TODO
		private void OnDisable() { }
		
		// TODO
		private void OnClick() { }

		[Serializable]
		public class SelectEvent : UnityEvent<ToggleButton> { }
	}
}