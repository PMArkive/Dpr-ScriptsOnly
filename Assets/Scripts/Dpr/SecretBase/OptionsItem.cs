using UnityEngine;
using UnityEngine.UI;

namespace Dpr.SecretBase
{
	public class OptionsItem : SelectItemBase<string>
	{
		[SerializeField]
		private Text text;
		[SerializeField]
		private GameObject disable;
		
		// TODO
		public override void SetData(string value) { }
		
		// TODO
		public void SetDisable(bool isDisable) { }
	}
}