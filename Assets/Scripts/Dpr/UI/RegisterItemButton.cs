using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class RegisterItemButton : MonoBehaviour
	{
		[SerializeField]
		private Image baseImage;
		[SerializeField]
		private Image itemIconImage;
		
		public ushort ItemNo { get; set; }
		public bool IsSet { get; set; }
		
		// TODO
		public void Setup(ushort itemNo) { }
		
		// TODO
		public void SetBaseSprite(Sprite sprite) { }
	}
}