using UnityEngine;

namespace Dpr.UI
{
	[RequireComponent(typeof(Canvas))]
	public class UIOverwriteSorting : MonoBehaviour
	{
		private Canvas _canvas;
		private int _sortingOrder;
		
		private void Awake()
		{
			_canvas = GetComponent<Canvas>();
			_sortingOrder = _canvas.sortingOrder;
		}
		
		private void OnEnable()
		{
			if (_canvas.overrideSorting)
				_canvas.sortingOrder = _sortingOrder + _canvas.rootCanvas.sortingOrder;
		}
	}
}