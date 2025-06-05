using UnityEngine;
using UnityEngine.EventSystems;

namespace SmartPoint.Components
{
	public class DragMove : MonoBehaviour, IDragHandler, IEventSystemHandler, IBeginDragHandler
	{
		private Vector2 _dragPosition;
		private Vector2 _savedPosition;
		private float _savedHeight;
		private RectTransform _target;
		
		// TODO
		private void Awake() { }
		
		// TODO
		private void Update() { }
		
		// TODO
		public void OnBeginDrag(PointerEventData eventData) { }
		
		// TODO
		public void OnDrag(PointerEventData eventData) { }
		
		// TODO
		private void SetPosition(Vector2 position) { }
		
		// TODO
		public void OnEndDrag(PointerEventData eventData) { }
	}
}