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
		
		public void Setup(int maxPutNum)
		{
			GMS_UIGMSScene_PutPointObj.Setup(this.putCompObj);
			GMS_UIGMSScene_PutPointObj.Setup(this.putCompAnimObj,maxPutNum);
		}
		
		public void SetSceneBGTexture(Texture2D bgTexture)
		{
			UI_RawImage.set_texture(this.sceneBGRawImage,bgTexture);
		}
		
		public void SetRenderTexture(RenderTexture rt)
		{
			UI_RawImage.set_texture(this.rtRawImage,rt);
		}
		
		// TODO
		public void SetTitleLogoSpr(Sprite titleLogoSpr, Sprite preTitleLogoSpr) { }
		
		// TODO
		public void ShowHeader() { }
		
		// TODO
		public void HideHeader() { }
		
		public void ShowPutNumText(int putNum, bool isComp)
		{
			GMS_UIGMSScene_PutPointObj.Show(this.putCompObj,putNum,isComp & 1);
		}
		
		public void HidePutNumText()
		{
			var uVar1 = this.putCompObj.putPointContent.activeSelf;
			if (uVar1) {
			  this.putCompObj.putPointContent.SetActive(0);
			}
			uVar1 = GameObject.get_activeSelf(this.putCompObj[0]);
			if (uVar1) {
			  GameObject.SetActive(this.putCompObj[0],0);
			}
		}
		
		public void SetSubkeyguideActive(bool active)
		{
			if (((this.subkeyguideObj.isShow == 0 ^ active) & 1) != 0) {
			}
			active = active & 1;
			this.subkeyguideObj.isShow = active;
			this.subkeyguideObj.bgImg.enabled = active;
			this.subkeyguideObj.Length.enabled = active;
			Behaviour.set_enabled(this.subkeyguideObj[0],active);
		}
		
		public void StartSceneAnim(int putNum, bool isComp)
		{
			this.launchAnimCanvas.enabled = 1;
			this.animState = (AnimState)0;
			GMS_UIGMSScene_PutPointObj.Show(this.putCompAnimObj,putNum,isComp & 1);
			this.launchAnimator.enabled = 1;
			this.launchAnimator.Play(this.Length);
			this.bIsPlayLaunchAnim = true;
		}
		
		// TODO
		public void StartOnBackTopAnim(int putNum, bool isComp) { }
		
		public void PlayEndAnim()
		{
			this.animState = (AnimState)1;
			this.launchAnimCanvas.enabled = 0;
		}
		
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
			
			public void SetComponentEnabled(bool enabled)
			{
				if (((!this.isShow ^ enabled) & 1) != 0) {
				}
				enabled = enabled & 1;
				this.isShow = enabled;
				this.bgImg.enabled = enabled;
				this.Length.enabled = enabled;
				Behaviour.set_enabled(this[0],enabled);
			}
		}

		[Serializable]
		public class PutPointObj
		{
			public GameObject putPointContent;
			public UIText putPointNumText;
			public GameObject putPointCompContent;
			public UIText putPointCompNumText;
			private int currentPutPointNum = -1;
			
			public void Setup(int maxPutNum)
			{
				GMS_UIGMSScene_PutPointObj.Setup(this.putCompObj);
				GMS_UIGMSScene_PutPointObj.Setup(this.putCompAnimObj,maxPutNum);
			}
			
			// TODO
			public void Show(int putNum, bool isComp) { }
			
			public void Hide()
			{
				if ((this.putPointContent.activeSelf & 1) != 0) {
				  this.putPointContent.SetActive(0);
				}
				if ((GameObject.get_activeSelf(this[0]) & 1) != 0) {
				  GameObject.SetActive(this[0],0);
				}
			}
			
			// TODO
			private void ShowNormalUI(int putNum) { }
			
			// TODO
			private void SetPutPointNumText(int putNum) { }
			
			private void HideNormalUI()
			{
				if ((this.putPointContent.activeSelf & 1) != 0) {
				  this.putPointContent.SetActive(0);
				}
			}
			
			private void SetNormalUIActive(bool active)
			{
				if (((this.putPointContent.activeSelf ^ active) & 1) != 0) {
				  this.putPointContent.SetActive(active & 1);
				}
			}
			
			private void ShowCompleteUI()
			{
				if ((GameObject.get_activeSelf(this[0]) & 1) != 0) {
				}
				GameObject.SetActive(this[0],1);
			}
			
			private void HideCompleteUI()
			{
				if ((GameObject.get_activeSelf(this[0]) & 1) != 0) {
				  GameObject.SetActive(this[0],0);
				}
			}
			
			private void SetCompleteUIActive(bool active)
			{
				if (((GameObject.get_activeSelf(this[0]) ^ active) & 1) != 0) {
				  GameObject.SetActive(this[0],active & 1);
				}
			}
		}

		private enum AnimState : int
		{
			LaunchAnim = 0,
			EndAnim = 1,
		}
	}
}