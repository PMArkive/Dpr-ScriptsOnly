using Pml;
using UnityEngine;

namespace Dpr.UI
{
	public class ShopBuyItemItem : ShopItemItem
	{
		[SerializeField]
		private Vector2[] _iconSizes = new Vector2[]
		{
			new Vector2(80.0f, 80.0f),
			new Vector2(40.0f, 40.0f),
		};

		private Param _param;
		
		public Param param { get => _param; }
		
		// TODO
		public void Setup(ShopBase.ShopType shopType, Param param) { }
		
		// TODO
		public void SetMessageItemName(int argIndex, int amount) { }
		
		// TODO
		public void SetMessagePocketName(int argIndex) { }
		
		// TODO
		public void AddItem(int amount) { }

		public class Param
		{
			public int itemId;
			public int price;
			
			public ItemNo GetItemNo()
			{
				return (ItemNo)itemId;
			}
			
			public SealID GetSealId()
			{
                return (SealID)itemId;
            }
			
			public int GetUgItemId()
			{
				return itemId;
			}
		}
	}
}