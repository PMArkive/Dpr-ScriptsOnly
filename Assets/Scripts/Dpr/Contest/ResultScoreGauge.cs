using Dpr.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Contest
{
	public class ResultScoreGauge : MonoBehaviour
	{
		private UIText nameText;
		private RectTransform rect;
		private Image gaugeImage;
		private Image medalImage;
		private Animator medalAnimator;
		
		// TODO
		public void Create(int index) { }
		
		// TODO
		public void Setup(string name) { }
		
		public void SetGaugeRatio(float ratio)
		{
			UI_Image.fillAmount = this.gaugeImage;
		}
		
		public void ShowMedal(Sprite medalSpr, int animHash)
		{
			this.medalAnimator.enabled = 1;
			this.medalAnimator.enabled = 1;
			this.medalAnimator.Play(animHash);
			UI_Image.set_sprite(this.medalImage,medalSpr);
			this.medalImage.enabled = 1;
		}
	}
}