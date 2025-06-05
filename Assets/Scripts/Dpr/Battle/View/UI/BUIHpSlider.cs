using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Battle.View.UI
{
	public class BUIHpSlider : MonoBehaviour
	{
		public const float HpAllert = 0.5f;
		public const float HpDanger = 0.25f;
		public const float HpDead = 0.0f;

		[SerializeField]
		private Slider _hpSlider;
		[SerializeField]
		private Image _hpImage;
		[SerializeField]
		private Sprite _hpNormal;
		[SerializeField]
		private Sprite _hpAllert;
		[SerializeField]
		private Sprite _hpDanger;

		private const float _actionAfterDelay = 0.25f;

		private Ease _ease;
		private float _duration;
		
		public bool IsPlaying { get; set; }
		
		// TODO
		public static HpStatus GetHpStatus(uint currentHP, uint maxHP) { return default; }
		
		// TODO
		public void Initialize(uint currentHP, uint maxHP, Ease ease, float duration) { }
		
		// TODO
		public bool SetHpBar(uint currentHP, uint maxHP) { return default; }
		
		// TODO
		public bool ChangeBarSprite(Sprite sp) { return default; }
		
		// TODO
		public void PlayDamage(uint afterHP) { }

		public enum HpStatus : int
		{
			Dead = 0,
			Danger = 1,
			Allert = 2,
			Normal = 3,
		}
	}
}