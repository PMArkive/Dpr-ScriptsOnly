using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class ZukanCompareWindow : UIWindow
	{
		private const int StopLoadModelCount = -1;
		private const int StartLoadModelCount = 3;

		private static readonly int TransAnimatorStateInitialize = Animator.StringToHash("Ini");
		private static readonly int TransAnimatorStateWait = Animator.StringToHash("Wait");
        private static readonly int TransAnimatorParamTransId = Animator.StringToHash("transId");

        private const string TransAnimatorLayerName = "Trans";
		private const int TransIdIn = 1;
		private const int TransIdOut = 2;

		[SerializeField]
		private ZukanCompareStatusPanel statusPanel;
		[SerializeField]
		private ZukanCompareHeightController zukanCompareHeightController;
		[SerializeField]
		private ZukanCompareWeightController zukanCompareWeightController;
		[SerializeField]
		private Image arrowLeftImage;
		[SerializeField]
		private Image arrowRightImage;
		[SerializeField]
		private Image arrowUpImage;
		[SerializeField]
		private Image arrowDownImage;
		[SerializeField]
		private Animator transAnimator;
		[SerializeField]
		private ZukanCompareAnimationEvent zukanCompareAnimationEvent;

        public ZukanInfo CurrentZukanInfo { get; set; }

        private List<ZukanInfo> selectableZukanInfoList;
		private IndexSelector indexSelector;
		private bool isShowHeightPanel;
		private int animatorTransLayer;
		private int loadModelCount;
		private State currentState;
		private bool isSwitchPanel;
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		public void Open(Param param, UIWindowID prevWindowId) { }
		
		// TODO
		public IEnumerator OpOpen(Param param, UIWindowID prevWindowId) { return default; }
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { }
		
		// TODO
		public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return default; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void UpdateTrans(float deltaTime) { }
		
		// TODO
		private void UpdatePokemonSelect(float deltaTime) { }
		
		// TODO
		private void UpdateFormSelect(float deltaTime) { }
		
		// TODO
		private void UpdateLoadModelRequest(float deltaTime) { }
		
		// TODO
		private void UpdateKeyGuide() { }
		
		// TODO
		private void ShowHeightWeightPanel(bool isShowHeight) { }
		
		// TODO
		private void Setup() { }
		
		// TODO
		private void RequestLoadModel() { }

		public class Param
		{
			public ZukanInfo CurrentZukanInfo;
			public List<ZukanInfo> SelectableZukanInfoList;
		}

		private enum State : int
		{
			None = 0,
			FadeOut = 1,
			WaitFadeOut = 2,
			WaitLoad = 3,
			Show = 4,
		}
	}
}