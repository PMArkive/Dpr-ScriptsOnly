using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class BagCategoryButton : UISwitchImageButton
	{
		[SerializeField]
		private Image newIconImage;
		
		public void SetNewIconEnable(bool isEnabled)
		{
			newIconImage.enabled = isEnabled;
		}
	}
}