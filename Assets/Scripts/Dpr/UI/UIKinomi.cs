using Dpr.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.U2D;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class UIKinomi : UIWindow
	{
		private const string PoffinMessageFileName = "dp_poffin_main";

		[SerializeField]
		private SpriteAtlas iconSpriteAtlas;
		[SerializeField]
		private RectTransform upArrowTransform;
		[SerializeField]
		private RectTransform downArrowTransform;
		[SerializeField]
		private UIText numberText;
		[SerializeField]
		private UIText nameText;
		[SerializeField]
		private Image iconImage;
		[SerializeField]
		private UIText sizeText;
		[SerializeField]
		private UIText hardnessText;
		[SerializeField]
		private UIText descriptionText;
		[SerializeField]
		private RaderChart raderChart;

		private readonly int _animStateIn = Animator.StringToHash("in");
		private readonly int _animStateOut = Animator.StringToHash("out");

        private UIMsgWindowController msgWindowController;
		private List<KinomiInfo> kinomiInfos;
		private IndexSelector indexSelector;
		
		public int SelectedKinomiItemId { get => kinomiInfos[indexSelector.CurrentIndex].ItemId; }
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		public void Open(List<ItemInfo> itemInfoList, ItemInfo selectedItemInfo, UnityAction<UIWindow> onClosedAction) { }
		
		// TODO
		public IEnumerator OpOpen() { return default; }
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_) { }
		
		// TODO
		public IEnumerator OpClose(UnityAction<UIWindow> onClosed_) { return default; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void OnUpdateDefault(float deltaTime) { }
		
		// TODO
		private void UpdateKeyGuide() { }
		
		// TODO
		private void UpdateKinomiInfo() { }
	}
}