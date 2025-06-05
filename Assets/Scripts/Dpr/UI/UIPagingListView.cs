using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.UI
{
	public class UIPagingListView : MonoBehaviour
	{
		[SerializeField]
		private RectTransform contents;
		[SerializeField]
		private GameObject itemPrefab;
		[SerializeField]
		private IndexSelector itemIndexSelector;
		[SerializeField]
		private IndexSelector pagingIndexSelector;

		private int viewItemMaxCount;
		private int contentsItemCount;
		private List<IUIButton> itemButtonList;

		public event Action<IUIButton> OnRequiredItemData;
		
		public int PageIndex { get => pagingIndexSelector.CurrentIndex; }
		public int PageCount { get; set; }
		public IUIButton SelectedItem { get; set; }
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void Setup(int count, int showPageIndex = 0, int selectIndex = 0) { }
		
		// TODO
		private void SetupContents() { }
		
		// TODO
		private void UpdatePageContents() { }
		
		// TODO
		private void UpdateSelectItem() { }
		
		// TODO
		public bool MoveSelect(int value) { return default; }
		
		// TODO
		public void ResumeSelectMove() { }
		
		// TODO
		public bool MovePage(int value) { return default; }
		
		// TODO
		public void ResumePageMove() { }
	}
}