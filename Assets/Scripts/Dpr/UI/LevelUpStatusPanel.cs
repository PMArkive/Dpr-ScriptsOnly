using UnityEngine;

namespace Dpr.UI
{
	public class LevelUpStatusPanel : MonoBehaviour
	{
		private const float AppearMoveX = -10.0f;
		private const float FadeDuration = 0.3f;

		[SerializeField]
		private CanvasGroup canvasGroup;
		[SerializeField]
		private LevelUpStatusText[] levelUpStatusTexts;

        public bool IsAnimation { get; set; }
        public bool IsShow { get; set; }

        private int state;
		
		// TODO
		public void SetStatus(UILevelUp.PokemonStatus beforeStatus, UILevelUp.PokemonStatus currentStatus) { }
		
		// TODO
		public void Show() { }
		
		// TODO
		public void HideImmediate() { }
		
		// TODO
		public void Next() { }
		
		// TODO
		private void FadeInAddStatusValues() { }
		
		// TODO
		private void FadeOutAddStatusValues() { }
		
		// TODO
		private void Hide() { }
	}
}