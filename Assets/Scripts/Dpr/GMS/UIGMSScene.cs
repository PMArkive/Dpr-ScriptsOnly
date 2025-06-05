using DG.Tweening;
using Dpr.UI;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.GMS
{
	public class UIGMSScene : MonoBehaviour
	{
		private readonly int launchAnimHash = Animator.StringToHash("LaunchAnim");
		private readonly int launchAnimInHash = Animator.StringToHash("LaunchAnimIn");
        private readonly int idleAnimHash = Animator.StringToHash("LaunchAnimIdle");

        [SerializeField]
		private SubkeyguideObj subkeyguideObj;
		[SerializeField]
		private PutPointObj putCompAnimObj;
		[SerializeField]
		private PutPointObj putCompObj;
		[SerializeField]
		private RawImage sceneBGRawImage;
		[SerializeField]
		private RawImage rtRawImage;
		[SerializeField]
		private Image titleLogoImage01;
		[SerializeField]
		private Image preTitleLogoImage;
		[SerializeField]
		private Image titleLogoImage02;
		private Canvas launchAnimCanvas;
		private DOTweenAnimation headerFadeTween;
		private CanvasGroup headerCanvasGroup;
		private Animator launchAnimator;
		private AnimState animState;
		private Sprite titleSpr;
		private Sprite preTitleSpr;
		private bool bIsPlayLaunchAnim;
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void OnFinalize() { }
		
		// TODO
		private void ReleaseSprite() { }
		
		public bool IsPlayLaunchAnim { get => bIsPlayLaunchAnim; }
		
		// TODO
		public void Setup(int maxPutNum) { }
		
		// TODO
		public void SetSceneBGTexture(Texture2D bgTexture) { }
		
		// TODO
		public void SetRenderTexture(RenderTexture rt) { }
		
		// TODO
		public void SetTitleLogoSpr(Sprite titleLogoSpr, Sprite preTitleLogoSpr) { }
		
		// TODO
		public void ShowHeader() { }
		
		// TODO
		public void HideHeader() { }
		
		// TODO
		public void ShowPutNumText(int putNum, bool isComp) { }
		
		// TODO
		public void HidePutNumText() { }
		
		// TODO
		public void SetSubkeyguideActive(bool active) { }
		
		// TODO
		public void StartSceneAnim(int putNum, bool isComp) { }
		
		// TODO
		public void StartOnBackTopAnim(int putNum, bool isComp) { }
		
		// TODO
		public void PlayEndAnim() { }
		
		// TODO
		public void OnUpdate() { }
		
		// TODO
		private void UpdateLaunchAnim() { }
		
		// TODO
		private void UpdateEndAnim() { }
		
		// TODO
		private bool CheckTransitionAnim(int animHash) { return default; }
		
		// TODO
		public void PlayAnimationSE(GMSSoundPlayer.PlaySE_ID seID) { }

		[Serializable]
		private class SubkeyguideObj
		{
			public Image bgImg;
			public Image iconImg;
			public UIText text;
			private bool isShow = true;
			
			// TODO
			public void SetComponentEnabled(bool enabled) { }
		}

		[Serializable]
		public class PutPointObj
		{
			public GameObject putPointContent;
			public UIText putPointNumText;
			public GameObject putPointCompContent;
			public UIText putPointCompNumText;
			private int currentPutPointNum = -1;
			
			// TODO
			public void Setup(int maxPutNum) { }
			
			// TODO
			public void Show(int putNum, bool isComp) { }
			
			// TODO
			public void Hide() { }
			
			// TODO
			private void ShowNormalUI(int putNum) { }
			
			// TODO
			private void SetPutPointNumText(int putNum) { }
			
			// TODO
			private void HideNormalUI() { }
			
			// TODO
			private void SetNormalUIActive(bool active) { }
			
			// TODO
			private void ShowCompleteUI() { }
			
			// TODO
			private void HideCompleteUI() { }
			
			// TODO
			private void SetCompleteUIActive(bool active) { }
		}

		private enum AnimState : int
		{
			LaunchAnim = 0,
			EndAnim = 1,
		}
	}
}