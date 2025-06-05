using UnityEngine;
using UnityEngine.UI;

namespace Dpr.DigFossil
{
	public class DigBuildup : MonoBehaviour, IDigBuildup
	{
		[SerializeField]
		private Image main;
		[SerializeField]
		private Image top;
		[SerializeField]
		private Image under;
		[SerializeField]
		private Image topCorner;
		[SerializeField]
		private Image underCorner;
		
		// TODO
		public void SetSprite(in Sprite inMain, in Sprite inTop, in Sprite inUnder, in Sprite inTopCorner, in Sprite inUnderCorner) { }
		
		// TODO
		private void SetTexture(ref Image refImage, in Sprite inSprite) { }

		public DigBuildup()
		{
			// Empty, explicitely declared
		}

		void IDigBuildup.SetSprite(in Sprite inMain, in Sprite inTop, in Sprite inUnder, in Sprite inTopCorner, in Sprite inUnderCorner)
			=> SetSprite(inMain, inTop, inUnder, inTopCorner, inUnderCorner);
	}
}