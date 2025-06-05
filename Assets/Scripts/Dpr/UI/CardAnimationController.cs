using System.Collections.Generic;
using UnityEngine;

namespace Dpr.UI
{
	public class CardAnimationController : MonoBehaviour
	{
		private readonly int AnimParamFromCardId = Animator.StringToHash("FromCardId");
		private readonly int AnimParamToCardId = Animator.StringToHash("ToCardId");
        private readonly int AnimParamFromCaseId = Animator.StringToHash("FromCaseId");
        private readonly int AnimParamToCaseId = Animator.StringToHash("ToCaseId");

        private List<Animator> animators;
		private Animator mainAnimator;
		private CardModelViewController cardModelViewController;
		private bool isOpened;
		
		public bool IsShowBadgeCase { get; set; }
		public bool IsCardFront { get; set; }
		public bool IsOpen { get; set; }
		public bool IsAnimation { get => mainAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f; }
		
		// TODO
		public bool IsAnimationAll { get; }
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void RegisterAnimator(Animator animator, bool isMain) { }
		
		// TODO
		public void RegisterCardModelViewController(CardModelViewController cardModelViewController) { }
		
		// TODO
		public void ShowCard() { }
		
		// TODO
		public void SwitchCardFrontBack() { }
		
		// TODO
		public void ShowBadgeCase() { }
		
		// TODO
		public void OpenCover() { }
		
		// TODO
		public void CloseCover() { }
		
		// TODO
		public void SetEnviromentLight(int isEnable) { }
		
		// TODO
		public void RebindMain() { }
		
		// TODO
		private void SetAnimatorParams(int fromCard, int toCard, int fromCase, int toCase) { }
	}
}