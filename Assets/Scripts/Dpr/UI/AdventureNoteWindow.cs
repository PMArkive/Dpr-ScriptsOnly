using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
	public class AdventureNoteWindow : AdventureBase
	{
		[SerializeField]
		private UIScrollView _itemListScrollView;
		[SerializeField]
		private Cursor _cursor;
		private List<AdventureNoteItem.Param> _itemParams = new List<AdventureNoteItem.Param>();
		private AdventureNoteItem _selectItem;
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		public void Open(UIWindowID prevWindowId) { }
		
		// TODO
		public IEnumerator OpOpen(UIWindowID prevWindowId) { return default; }
		
		// TODO
		private void SetupKeyguide() { }
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { }
		
		// TODO
		public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return default; }
		
		// TODO
		private void OnRequiredItemData(IUIButton button) { }
		
		// TODO
		private void OnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void OnUnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private bool UpdateSelect(float deltaTime) { return default; }
		
		// TODO
		private bool MoveSelect(int move) { return default; }
	}
}