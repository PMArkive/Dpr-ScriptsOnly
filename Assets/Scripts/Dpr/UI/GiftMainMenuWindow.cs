using UnityEngine;

namespace Dpr.UI
{
	public class GiftMainMenuWindow : GiftSubWindow
	{
		[SerializeField]
		private Cursor cursor;
		[SerializeField]
		private GiftMenuItem[] menuItems;
		private IndexSelector indexSelector;
		
		public MenuType SelectedMenuType { get; set; }
		
		// TODO
		protected override void OnInitialize() { }
		
		// TODO
		public override void OnUpdate(float deltaTime) { }
		
		// TODO
		public override void Show() { }

		public enum MenuType : int
		{
            None = -1,
            ReceiveInternet = 0,
			ReceiveSerialCode = 1,
			ShowHistory = 2,
		}
	}
}