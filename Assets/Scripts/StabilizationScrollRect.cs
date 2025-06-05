using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StabilizationScrollRect : ScrollRect, IPointerUpHandler, IEventSystemHandler
{
	private static List<RaycastResult> _raycastResults = new List<RaycastResult>();
	private GameObject _lastPressedObject;
	private Vector2 _startingPoint;
	private Vector2 _offsetVector;
	[SerializeField]
	[Range(0.001f, 0.1f)]
	private float _horizontalThreshold = 0.01f;
	[SerializeField]
	[Range(0.001f, 0.1f)]
	private float _verticalThreshold = 0.01f;
    private bool _isMoving;
	private bool _isDragging;
	
	// TODO
	public void OnPointerUp(PointerEventData eventData) { }
	
	// TODO
	public override void OnInitializePotentialDrag(PointerEventData eventData) { }
	
	// TODO
	private bool DecideMoving(PointerEventData eventData) { return default; }
	
	// TODO
	public override void OnBeginDrag(PointerEventData eventData) { }
	
	// TODO
	public override void OnDrag(PointerEventData eventData) { }
	
	// TODO
	public override void OnEndDrag(PointerEventData eventData) { }
	
	// TODO
	protected void DetachObject(PointerEventData eventData, bool click = false) { }
	
	// TODO
	protected void ExecutePointerUpEvent(RaycastResult result, PointerEventData eventData) { }
	
	// TODO
	protected void ExecuteClickEvent(RaycastResult result, PointerEventData eventData) { }
	
	// TODO
	protected bool IsLeftButtonPressEvent(PointerEventData eventData) { return default; }
	
	// TODO
	protected PointerEventData Clone(PointerEventData e) { return default; }
}