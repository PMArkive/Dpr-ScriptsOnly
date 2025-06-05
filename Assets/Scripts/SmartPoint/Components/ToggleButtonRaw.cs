using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SmartPoint.Components
{
	[RequireComponent(typeof(RawImage))]
	public class ToggleButtonRaw : Button
	{
		[SerializeField]
		private Color _targetColor = Color.white;
		[SerializeField]
		private bool _isTarget;
		[SerializeField]
		private GameObject _targetObject;
		[SerializeField]
		private int _value;

		private RawImage _image;
		private Color _sourceColor;
		public SubmitEvent onSubmit;
		
		public int value { get => _value; }
		public bool isTarget
        {
            get => _isTarget;
            set
            {
                if (_isTarget == value)
                    return;

                _isTarget = value;

                if (_targetObject != null)
                    _targetObject.SetActive(value);

                UpdateImage();
            }
        }

        // TODO
        public override void OnPointerClick(PointerEventData eventData) { }
		
		// TODO
		protected override void Awake() { }
		
		// TODO
		protected override void Start() { }
		
		// TODO
		public override void OnSubmit(BaseEventData eventData) { }
		
		// TODO
		private void UpdateImage() { }

		[Serializable]
		public class SubmitEvent : UnityEvent<int> { }
	}
}