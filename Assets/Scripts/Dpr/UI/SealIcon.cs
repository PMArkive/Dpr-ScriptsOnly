using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class SealIcon : MonoBehaviour
	{
		[SerializeField]
		protected Image iconImage;
		[SerializeField]
		private Image typeIconImage;
		
		// TODO
		public void Set(SealInfo sealInfo) { }
		
		// TODO
		public void Set(int sealId) { }
		
		public void Clear()
		{
			UI_Image.set_sprite(this.Length,0);
		}
		
		public void SetEnable(bool isEnable)
		{
			this.Length.enabled = isEnable & 1;
			Behaviour.set_enabled(this[0],isEnable & 1);
		}
	}
}