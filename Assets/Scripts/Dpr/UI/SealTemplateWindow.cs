using Dpr.Trainer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class SealTemplateWindow : UIWindow
	{
		private static readonly Vector2 MsgWindowAnchorPos = new Vector2(0.0f, 100.0f);

		[SerializeField]
		private UIText trainerTitleText;
		[SerializeField]
		private UIText trainerNameText;
		[SerializeField]
		private Image trainerImage;
		[SerializeField]
		private Image trainerEmblemImage;
		[SerializeField]
		private GameObject playerObject;
		[SerializeField]
		private GameObject npcObject;
		[SerializeField]
		private RectTransform pagingLeftArrow;
		[SerializeField]
		private RectTransform pagingRightArrow;
		[SerializeField]
		private UIText listPageNumberText;
		[SerializeField]
		private UIPagingListView listView;
		[SerializeField]
		private CapsuleViewController capsuleViewController;
		private List<SealTemplateWindow.SealTemplateInfo> sealTemplateInfos;
		private CapsuleInfo currentCapsuleInfo;
		private Keyguide keyguide;
		private bool isShowCapsuleView;
		
		public bool IsCopyRequest { get; set; }
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		protected override void OnAddContextMenuYesNoItemParams(List<ContextMenuItem.Param> contextMenuItemParams) { }
		
		// TODO
		public void Open(SealTemplateID sealTemplateId, UIWindowID prevWindowId) { }
		
		// TODO
		public void Open(string playerName, CapsuleInfo capsuleInfo, UIWindowID prevWindowId) { }
		
		// TODO
		public IEnumerator OpOpen(UIWindowID prevWindowId)
		{
            IEnumerator Init() { return default; }

            return default;
		}
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { }
		
		// TODO
		public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return default; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void OnUpdateCapsuleView(float deltaTime) { }
		
		// TODO
		private void OnUpdateListView(float deltaTime) { }
		
		// TODO
		private void OnUpdatePreview(float deltaTime) { }
		
		// TODO
		private void UpdateKeyGuide() { }
		
		// TODO
		private void SetupTrainer(SealTemplateID sealTemplateId) { }
		
		// TODO
		private void SetupPlayer(string playerName, CapsuleInfo capsuleInfo) { }
		
		// TODO
		private void SetupSealData(CapsuleInfo capsuleInfo) { }
		
		// TODO
		private void SetupListView() { }
		
		// TODO
		private void OnReverseCapsule2D() { }
		
		// TODO
		private void OnRequiredItemData(IUIButton button) { }
		
		// TODO
		private void UpdateListPageNumberText() { }
		
		// TODO
		private void OpenContextMenu() { }
		
		// TODO
		private IEnumerator ShowPreview() { return default; }
		
		// TODO
		private IEnumerator HidePreview() { return default; }

		private class SealTemplateInfo
		{
			public int SealId;
			public int Count;
		}
	}
}