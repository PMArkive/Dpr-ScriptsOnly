using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.UI
{
	public class BoxTextSelector : MonoBehaviour
	{
		[SerializeField]
		private UIScrollView _scroller;

		private float _openPosX;
		private float _closePosX;
		private Action _onCancel;
		private Action _onChange;
		private Action _onDecide;
		private List<BoxWindow.SearchItemData> _selectItems;
		private BoxWindow.SearchType _searchType;
		private int _maxCount;
		private int _currentDepth;

		public int CurrentIndex { get; set; }
		
		// TODO
		public void Initialize(Action onCancel, Action onDecide, Action onChange) { }
		
		// TODO
		private void OnRequiredItemData(IUIButton button) { }
		
		// TODO
		private void OnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void OnUnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		public void Open(BoxWindow.SearchType type, int depth, int index, List<BoxWindow.SearchItemData> items) { }
		
		// TODO
		public void Close() { }
		
		// TODO
		public void Setup(BoxWindow.SearchType type, int depth, int index, List<BoxWindow.SearchItemData> items) { }
		
		// TODO
		public void OnUpdate() { }
		
		// TODO
		private void ChangeItem(int value) { }
		
		// TODO
		public int GetMarkColors() { return default; }
	}
}