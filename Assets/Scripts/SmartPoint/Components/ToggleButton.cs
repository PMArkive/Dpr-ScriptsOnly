using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SmartPoint.Components
{
	[RequireComponent(typeof(Image))]
	public class ToggleButton : Button
	{
		[SerializeField]
		private Sprite _targetSprite;
		[SerializeField]
		private Color _targetColor = Color.white;
		[SerializeField]
		private bool _isTarget;
		[SerializeField]
		private GameObject _targetObject;
		[SerializeField]
		private int _value;

		private Image _image;
		private Sprite _sourceSprite;
		private Color _sourceColor;
		
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
		private void UpdateImage() { }
	}
}