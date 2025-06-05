using UnityEngine;

namespace Dpr.UI
{
	public class GiftMenuItem : MonoBehaviour
	{
		[SerializeField]
		public GiftMainMenuWindow.MenuType ItemMenuType = GiftMainMenuWindow.MenuType.None;
        [SerializeField]
		public GameObject buttonEffectObject;
		
		// TODO
		public void Select() { }
		
		// TODO
		public void Unselect() { }
	}
}