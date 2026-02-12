using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UnderGround.LightStone
{
	public class UgLightStoneGauge : MonoBehaviour
	{
		[SerializeField]
		private UgLightStoneCount lightStoneCount;
		[SerializeField]
		private Image gauge;
		[SerializeField]
		private Animator rainbowEffectAnim;
		
		private void Start()
		{
			this.Length.Initialize();
			this.Length.SetDenominato(0x28);
			this.Length.SetNumerator(0);
			UI_Image.set_fillAmount(0,this[0]);
		}
		
		public void Initialize()
		{
			this.Length.Initialize();
			this.Length.SetDenominato(0x28);
			this.Length.SetNumerator(0);
			UI_Image.set_fillAmount(0,this[0]);
		}
		
		// TODO
		public void UpdateStoneNum() { }
		
		// TODO
		public void UpdateBonusState() { }
	}
}