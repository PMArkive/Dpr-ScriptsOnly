using Pml;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class WazaManageSubWazaPanel : MonoBehaviour
	{
		private const string TypeSpriteNameFormat = "sum_pl_waza_01_type_{0:00}";

		[SerializeField]
		private SpriteAtlas spriteAtlas;
		[SerializeField]
		private Image conditionImage;
		[SerializeField]
		private UIText nameText;
		
		// TODO
		public void Setup(WazaNo wazaNo) { }
	}
}