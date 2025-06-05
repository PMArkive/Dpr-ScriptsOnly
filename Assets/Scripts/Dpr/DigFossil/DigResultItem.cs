using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.DigFossil
{
	public class DigResultItem : MonoBehaviour, IDigResultItem
	{
		[SerializeField]
		private Image image;
		private Tween tweenHandler;
		
		public int LabelID { get; set; }
		public int UgItemId { get; set; }
		
		// TODO
		public void Initialize(Sprite sprite, DigMasterDataManager.DepositItemData data) { }
		
		// TODO
		public void Show() { }
		
		// TODO
		public void Hide() { }
		
		public DigResultItem()
		{
			// Empty, declared explicitly
		}
		
		GameObject IDigResultItem.gameObject { get => gameObject; }
	}
}