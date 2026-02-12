using UnityEngine;

namespace Dpr.UI
{
	public class GiftMenuItem : MonoBehaviour
	{
		[SerializeField]
		public GiftMainMenuWindow.MenuType ItemMenuType = GiftMainMenuWindow.MenuType.None;
        [SerializeField]
		public GameObject buttonEffectObject;
		
		public void Select()
		{
			GameObject.SetActive(this[0],1);
		}
		
		public void Unselect()
		{
			GameObject.SetActive(this[0],0);
		}
	}
}