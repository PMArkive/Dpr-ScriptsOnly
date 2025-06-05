using UnityEngine;

namespace Dpr.SecretBase
{
	public class StatuePoseController : MonoBehaviour
	{
		private int MotionPrefixLength = "pm0000_00_00_".Length;
		private StatueEffectData statueData;
		private SkinnedMeshRenderer[] renderers;
		private Step step;
		
		// TODO
		public void Initialize(StatueEffectData statueData, SkinnedMeshRenderer[] renderers) { }
		
		// TODO
		private void LateUpdate() { }
		
		// TODO
		private void PlayAnimation() { }
		
		// TODO
		private void StopAnimation() { }
		
		// TODO
		private void DisableAnimator() { }
		
		// TODO
		private void OnEnable() { }

		private enum Step : int
		{
			FirstFrame = 0,
			PlayAnimation = 1,
			StopAnimation = 2,
			ShowModel = 3,
			DisableAnimator = 4,
			Idle = 5,
		}
	}
}