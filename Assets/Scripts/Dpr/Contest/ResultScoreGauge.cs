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
		
		// TODO
		public void SetGaugeRatio(float ratio) { }
		
		// TODO
		public void ShowMedal(Sprite medalSpr, int animHash) { }
	}
}