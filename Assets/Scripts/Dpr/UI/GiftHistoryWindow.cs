using DPData.MysteryGift;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.UI
{
	public class GiftHistoryWindow : GiftSubWindow
	{
		[SerializeField]
		private UIScrollView scrollView;
		[SerializeField]
		private GiftContentsPanel contentsPanel;
		[SerializeField]
		private Cursor cursor;
		private List<RecvData> recvDataList;
		
		// TODO
		protected override void OnInitialize() { }
		
		// TODO
		public override void OnUpdate(float deltaTime) { }
		
		// TODO
		public override void Show() { }
		
		// TODO
		public void Setup(RecvData[] recvDatas) { }
		
		// TODO
		private void OnRequiredItemData(IUIButton button) { }
		
		// TODO
		private void OnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void OnUnSelectItemScrollViewItem(IUIButton button) { }
	}
}