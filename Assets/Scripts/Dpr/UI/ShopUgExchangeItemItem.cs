using Pml.Item;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class ShopUgExchangeItemItem : ShopItemItem
	{
		[SerializeField]
		private Image _tradeItemIcon;
		private Param _param;
		
		public Param param { get => _param; }
		
		// TODO
		public bool IsUnderGroundItem() { return default; }
		
		// TODO
		public void Setup(Param param) { }

		public class Param
		{
			public string unitText = string.Empty;
			public int tradeUgItemNo;
			public int category;
			public int ugItemID;
			public int price;
			public int unit;
			public string itemLabel;
			
			public int GetItemNo()
			{
				return UgItemManager.Instance.GetItemId(ugItemID);
			}
		}
	}
}