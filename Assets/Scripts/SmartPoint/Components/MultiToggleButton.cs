using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SmartPoint.Components
{
	[RequireComponent(typeof(Image))]
	public class MultiToggleButton : Button
	{
		[SerializeField]
		private Sprite[] _sprites;
		[SerializeField]
		private int _index;

		private Image _image;
		
		public int index { get => _index; }
		
		// TODO
		public override void OnPointerClick(PointerEventData eventData) { }
		
		// TODO
		protected override void Awake() { }
		
		// TODO
		protected override void Start() { }
		
		// TODO
		private void SetImage() { }
	}
}