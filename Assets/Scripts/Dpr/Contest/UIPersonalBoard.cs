using Dpr.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Contest
{
	public class UIPersonalBoard : MonoBehaviour
	{
		private UIText bestCntText;
		private UIText greaCntText;
		private UIText niceCntText;
		private UIText missCntText;
		private Image contestTitleImage;
		private Image rankTitleImage;
		private Image medalImage;
		private Image visualGaugeImage;
		private Image danceGaugeImage;
		private Image wazaGaugeImage;
		
		// TODO
		public void Initialize() { }
		
		// TODO
		private void SetTextComponents() { }
		
		// TODO
		private void SetText() { }
		
		// TODO
		private void SetImageComponents() { }
		
		// TODO
		public void SetCountTexts(string bestCntStr, string greatCntStr, string niceCntStr, string missCntStr) { }
		
		// TODO
		public void SetGaugeRatio(float visualRatio, float danceRatio, float wazaRatio) { }
		
		// TODO
		public void SetTitleSpr(Sprite contestTitleSpr, Sprite rankTitleSpr) { }
		
		// TODO
		public void SetMedalSpr(Sprite medalSpr) { }
	}
}