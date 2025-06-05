using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SmartPoint.Components
{
	public class LayoutScrollView : MonoBehaviour
	{
		[SerializeField]
		private Margin _margin;
		[SerializeField]
		private RectTransform _contentTemplate;
		[SerializeField]
		private Vector2 _cellSpacing = new Vector2(0.0f, 0.0f);
		[SerializeField]
		private StartAxis _startAxis;
		[SerializeField]
		private WrapType _wrapType;
		[SerializeField]
		private int _maxColumnCount = 1;
		[SerializeField]
		private Vector2 _minCellSize = new Vector2(20.0f, 20.0f);
		[SerializeField]
		private LayoutCellItem _presetDatas;

		private Canvas _canvas;
		private ScrollRect _scrollRect;
		private RectTransform _viewRectTransform;
		private RectTransform _contentRectTransform;
		private List<LayoutCellObserver> _cellVisibilityPool = new List<LayoutCellObserver>();
		private List<Cell> _cells = new List<Cell>();
		private bool skipFirstCall;
		
		public Margin margin { get => _margin; }
		public Rect clientRect { get => _viewRectTransform.rect; }
		public StartAxis startAxis { get => _startAxis; }
		public WrapType wrapType { get => _wrapType; }
		public float wrapPoint
		{
			get
			{
				return _startAxis == StartAxis.Horizontal ?
					(_viewRectTransform.sizeDelta.x - _margin.left - _margin.right) :
					(_viewRectTransform.sizeDelta.y - _margin.top - _margin.bottom);
			}
		}
		public int cellCount { get => _cells.Count; }
		public List<Cell> cells { get => _cells; }
		public ScrollRect scrollRect { get => _scrollRect; }
		public RectTransform contentRectTransform { get => _contentRectTransform; }
		public RectTransform templateRectTransform { get => _contentTemplate; }
		
		// TODO
		private void Awake() { }
		
		// TODO
		public List<Cell> SwapBuffer(List<Cell> targetCells) { return default; }
		
		// TODO
		private void OnEnable() { }
		
		// TODO
		private void OnDisable() { }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		public void ForceUpdate(float deltaTime) { }
		
		// TODO
		public void AutoScroll(Cell cell) { }
		
		// TODO
		public void UpdateContent() { }
		
		// TODO
		public void OnValueChanged(Vector2 scrollPosition) { }
		
		// TODO
		private void UpdateCells(Rect clipRect) { }
		
		// TODO
		private LayoutCellObserver GetCellObserver() { return default; }
		
		// TODO
		public void Clear(bool cellClear = true) { }
		
		// TODO
		public Cell AddCell(object value) { return default; }
		
		// TODO
		public Cell InsertCell(object value) { return default; }
		
		// TODO
		public void Remove(Cell cell) { }
		
		// TODO
		public Cell GetCellByValue(object value) { return default; }
		
		// TODO
		public void RemoveByValue(object value) { }
		
		// TODO
		public void RemoveFirstCell() { }

		public enum StartCorner : int
		{
			UpperLeft = 0,
			UpperRight = 1,
			LowerLeft = 2,
			LowerRight = 3,
		}

		public enum StartAxis : int
		{
			Horizontal = 0,
			Vertical = 1,
		}

		public enum WrapType : int
		{
			ViewportRect = 0,
			FixedCount = 1,
		}

		[Serializable]
		public struct Margin
		{
			public float left;
			public float bottom;
			public float top;
			public float right;
		}

		public struct GameObjectHolder
		{
			public bool enabled;
			public GameObject gameObject;
		}

		public class Cell
		{
			public bool rebuild;
			public bool calculate;
			public Vector2 size;
			public Vector2 localScale;
			public Vector2 localPosition;
			public bool hide;
			public int clippingX;
			public int clippingY;
			public bool visibility;
			public bool erase;
			public bool dirty;
			public object value;
			public LayoutCellObserver observer;
			
			// TODO
			public void Close() { }
		}
	}
}