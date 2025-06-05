using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class ShopTradeItemDescriptionPanel : MonoBehaviour
	{
		[SerializeField]
		private Image _icon;
		[SerializeField]
		private UIText _name;
		[SerializeField]
		private UIText _price;
		[SerializeField]
		private UIText _stockNum;

		private ShopExchangeItemItem.Param _param;
		
		// TODO
		public void Setup(ShopBase.ShopType shopType, ShopExchangeItemItem.Param param) { }
		
		// TODO
		public void UpdateStockNum() { }
	}
}