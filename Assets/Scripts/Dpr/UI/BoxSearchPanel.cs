using Dpr.Message;
using Pml.PokePara;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.UI
{
	public class BoxSearchPanel : MonoBehaviour
	{
		[SerializeField]
		private UIScrollView _searchTypeScroller;

		private float _openPosX;
		private float _closePosX;
		private Action _onClose;
		private Action _onChange;
		private Action _onExecute;
		private Action _onDecide;
		private int _maxCount;
		private int _indexCategory;
		private BoxMark _markIndex;
		private List<string> _selectedItemList;
		
		public int CurrentIndex { get; set; }
		public int CurrentDepth { get; set; }
		public int MaxDepth { get; set; }
		public BoxWindow.SEARCH_DATA SearchData { get; set; }
		public BoxWindow.SearchType SearchType { get => BoxWindow.SearchMsgData[CurrentIndex].type; }
		public int[] DepthIndexes { get; set; }
		public List<int> LastSelectValues { get; set; }
		public List<BoxWindow.SearchItemData> SearchItemList { get; set; }
		
		// TODO
		public void Initialize(BoxWindow.SEARCH_DATA searchData, Action onClose, Action onDecide, Action onExecute, Action onChange) { }
		
		// TODO
		private void OnRequiredItemData(IUIButton button) { }
		
		// TODO
		private void OnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void OnUnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		public void Open(int index, int markColors) { }
		
		// TODO
		public void Close() { }
		
		// TODO
		public void OnUpdate() { }
		
		// TODO
		private void ChangeSearchItem(int value) { }
		
		// TODO
		public void SetSelectedItemText(string selectedText) { }
		
		// TODO
		private void SetDepth(BoxWindow.SearchType searchType) { }
		
		// TODO
		private void SetSearchItemTexts() { }
		
		// TODO
		public void CreateSearchDataList(int depthValue = 0, int subIndex = 0) { }
		
		// TODO
		private void CreateSearchDataListCore(int indexGroup, MessageMsgFile defaultMsgFile) { }
		
		// TODO
		private string GetCalcTextID(string baseTextID, int index) { return default; }
		
		// TODO
		private void AddSearchList(MessageMsgFile msgFile, string messageID, [Optional] Sprite sprite) { }
		
		// TODO
		private int GetCountOfIndexGroup(BoxWindow.SearchType type, int group) { return default; }
		
		// TODO
		public void SetSearchData(BoxWindow.SEARCH_DATA searchData, int subIndex, bool isApplyPanel = false) { }
		
		// TODO
		public int GetSubIndex() { return default; }
		
		// TODO
		public void ClearSearchData() { }
		
		// TODO
		private int GetNoFromMessageID(string messageID) { return default; }
	}
}