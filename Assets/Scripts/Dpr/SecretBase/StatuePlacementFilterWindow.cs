using Dpr.Message;
using Dpr.UI;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.SecretBase
{
	public class StatuePlacementFilterWindow : MonoBehaviour
	{
		[SerializeField]
		private GameObject topItemPrefab;
		[SerializeField]
		private GameObject detailItemPrefab;
		[SerializeField]
		private RectTransform topContentsRoot;
		[SerializeField]
		private RectTransform detailContentsRoot;
		[SerializeField]
		private GameObject topWindow;
		[SerializeField]
		private GameObject detailWindow;
		[SerializeField]
		private RectTransform detailWindowRect;
		[SerializeField]
		private VerticalLayoutGroup detailLayoutGroup;
		[SerializeField]
		private GameObject window;
		[SerializeField]
		private StatuePlacementFilterInfo filterInfo;
		[SerializeField]
		private SecretBaseAudioManager audioManager;
		[SerializeField]
		private IndexSelector topItemSelector;
		[SerializeField]
		private IndexSelector detailItemSelector;

		private List<FillterTopItem> topItems = new List<FillterTopItem>();
		private Dictionary<int, List<FilterDetailItem>> detailItems = new Dictionary<int, List<FilterDetailItem>>();
		private int[] detailItemIndices = new int[(int)TopItemType.Max];
		private State currentState;
		private bool isReset;
		private bool isDisplay;
		private float dest;
		private float detailContentHeight;
		private float viewport;

		private readonly float scrollSpeed = 0.5f;
		private readonly float itemSize = 56.0f;

		private Action<FilterResult> OnApplied;
		private Action<bool> OnCancel;
		
		// TODO
		public void Initialize(Action<FilterResult> OnApplied, Action<bool> OnCancel) { }
		
		// TODO
		public void Show() { }
		
		// TODO
		public void Close() { }
		
		// TODO
		private void InitializeDetail_Top(MessageMsgFile msgFile) { }
		
		// TODO
		private void InitializeDetail_Type(MessageMsgFile msgFile) { }
		
		// TODO
		private void InitializeDetail_Size(MessageMsgFile msgFile) { }
		
		// TODO
		private void InitializeDetail_Category(MessageMsgFile msgFile) { }
		
		// TODO
		private void AddDetail(TopItemType type, string[] subjects) { }
		
		// TODO
		public void OnUpdate() { }
		
		// TODO
		private void OnUpdate_TopSelect() { }
		
		// TODO
		private void ResetFillter() { }
		
		// TODO
		private void ApplyFilter() { }
		
		// TODO
		private void OnUpdate_DetailSelect() { }
		
		// TODO
		private void CalcScroll() { }
		
		// TODO
		private void CalcScrollImmediate() { }
		
		// TODO
		private void ShowDetailItemList() { }
		
		// TODO
		private void ShowTopItemList() { }
		
		// TODO
		private void ApplyTopItemText() { }
		
		// TODO
		private void UpdateTopIndex(int move) { }
		
		// TODO
		private void UpdateDetailIndex(int topItemIndex, int move) { }

		private enum TopItemType : int
		{
			Type1 = 0,
			Type2 = 1,
			Size = 2,
			Category = 3,
			Max = 4,
		}

		private enum State : int
		{
			TopSelect = 0,
			DetailSelect = 1,
		}

		public class FilterResult
		{
			public int type1;
			public int type2;
			public int size;
			public int category;
			public int legend;
			
			public FilterResult()
			{
				// Empty, declared explicitly
			}
			
			public FilterResult(int type1, int type2, int size, int category, int legend)
			{
				this.type1 = type1;
				this.type2 = type2;
				this.size = size;
				this.category = category;
				this.legend = legend;
			}
		}
	}
}