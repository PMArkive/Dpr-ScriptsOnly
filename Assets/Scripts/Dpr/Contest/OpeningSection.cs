using Effect;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Contest
{
	public class OpeningSection : MonoBehaviour
	{
		private readonly int startAnimHash = Animator.StringToHash("Opening");
		private readonly int endAnimHash = Animator.StringToHash("End");

        private EffectInstance titleLogoFx;
		private EffectData titleLogoFxData;
		private Animator openingAnimator;
		private Transform cameraContent;
		private Transform canvasTransform;
		private Image contestTitleImage;
		private Image medalImage;
		private Image categoryTitleImage;
		private Image rankImage;
		private Vector3 logoFxPos;
		private AnimState animState;
		private bool bRunning;
		private bool bReady;
		
		public bool IsReady { get => bReady; }
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void OnFinalize() { }
		
		// TODO
		private void SetImageComponents() { }
		
		// TODO
		private void LoadFx() { }
		
		// TODO
		public void ResetParam() { }
		
		// TODO
		public void Stop() { }
		
		// TODO
		public void SetMedalSpr(Sprite spr) { }
		
		// TODO
		public void SetContestTitleSpr(Sprite spr) { }
		
		// TODO
		public void SetCategorySpr(Sprite spr) { }
		
		// TODO
		public void SetRankSpr(Sprite spr) { }
		
		// TODO
		public void SetMedalActive(bool active) { }
		
		// TODO
		public void SetRankActive(bool active) { }
		
		// TODO
		public void Setup() { }
		
		// TODO
		public void StartSection() { }
		
		// TODO
		public bool UpdateSection() { return default; }
		
		// TODO
		private void CheckStratAnimation() { }
		
		// TODO
		private void CheckFinishAnimation() { }
		
		// TODO
		private void OnFinishSection() { }
		
		// TODO
		public void PlayAllPlayerAnimation(int animationIndex) { }
		
		// TODO
		public void PlayLeftMostTrainerAnim(int animationIndex) { }
		
		// TODO
		public void PlayLeftTrainerAnim(int animationIndex) { }
		
		// TODO
		public void PlayRightTrainerAnim(int animationIndex) { }
		
		// TODO
		public void PlayRightMostTrainerAnim(int animationIndex) { }
		
		// TODO
		private void PlayTrainerMotion(int playerIndex, int animationIndex) { }
		
		// TODO
		public void PlayTitleFx() { }
		
		// TODO
		public void StopTitleFx() { }

		private enum AnimState : int
		{
			WaitStartPlayAnim = 0,
			PlayingAnim = 1,
			End = 2,
		}
	}
}