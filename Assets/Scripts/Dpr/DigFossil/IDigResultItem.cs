using UnityEngine;

namespace Dpr.DigFossil
{
	public interface IDigResultItem
	{
		void Initialize(Sprite sprite, DigMasterDataManager.DepositItemData data);

		void Show();

		void Hide();
		
		int LabelID { get; }
		
		int UgItemId { get; }
		
		GameObject gameObject { get; }
	}
}