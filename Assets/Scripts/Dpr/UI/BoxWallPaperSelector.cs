using System;
using UnityEngine;

namespace Dpr.UI
{
	public class BoxWallPaperSelector : MonoBehaviour
	{
		[SerializeField]
		private UIScrollView _wallPaperScroller;

		private float _openPosX;
		private float _closePosX;
		private Action _onCancel;
		private Action _onChange;
		private Action _onDecide;
		private int _maxCount;
		
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
		public void Open(int index) { }
		
		// TODO
		public void Close() { }
		
		// TODO
		public void OnUpdate() { }
		
		// TODO
		private void ChangeWallPaper(int value) { }
	}
}