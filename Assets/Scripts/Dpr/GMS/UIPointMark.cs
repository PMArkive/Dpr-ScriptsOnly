using Dpr.Contest;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.GMS
{
	public class UIPointMark : MonoBehaviour, IPoolObject
	{
		private static readonly Vector3 ON_SELECT_SCALE = new Vector3(1.5f, 1.5f, 1.5f);

		[SerializeField]
		private GameObject iconContent;
		[SerializeField]
		private Image pointImage;
		[SerializeField]
		private Image monsIconImage;
		[SerializeField]
		private Image monsShadowImage;
		private GMSPointDataModel refPointData;
		private RectTransform rect;
		private RectTransform contentRect;
		private Sprite hasDataIconSpr;
		private Sprite noDataIconSpr;
		private Vector3 defaultScale;
		private bool isModeBrowsing;
		private bool isSelect;
		private bool isMaxZoom;
		private bool isInitialize;
		
		// TODO
		public bool IsActive() { return default; }
		
		public RectTransform Rect { get => rect; }
		public bool IsInitialize { get => isInitialize; }
		
		// TODO
		public void Initialize(Sprite hasDataIconSpr, Sprite noDataIconSpr) { }
		
		// TODO
		public void ResetParam() { }
		
		// TODO
		private void SetRectTransformComponent() { }
		
		// TODO
		public void ShowPoint(GMSPointDataModel targetPointData, bool isModeBrowsing, bool isMaxZoom) { }
		
		public void HidePointIcon()
		{
			this.refPointData = null;
			this.isModeBrowsing = false;
			if ((this.Length.activeSelf & 1) != 0) {
			  this.Length.SetActive(0);
			}
			ExtensionMethods.SetActive(0);
		}
		
		public void OnChangeDistance(bool isMaxZoom)
		{
			if (this.isModeBrowsing) {
			  this.isMaxZoom = isMaxZoom & 1;
			  if (this.isSelect) {
			    GMS_UIPointMark.ChangeIconScale(isMaxZoom & 1);
			  }
			  if ((this.refPointData != null) && (this.refPointData.bHasData != 0)) {
			    GMS_UIPointMark.SetIconImageVisible(isMaxZoom & 1);
			  }
			  if ((this.Length.activeSelf & 1) != 0) {
			    this.Length.SetActive(0);
			  }
			}
		}
		
		// TODO
		public void UpdateView() { }
		
		// TODO
		private void SetIconImageVisible(bool visible) { }
		
		private void UpdateMonsIcon()
		{
			if ((this.refPointData != null) && (this.refPointData.bHasData != 0)) {
			  if (this.refPointData.markIndex < this.refPointData.historyDataArray.Length) {
			    var uVar3 = *
			             (this.refPointData.historyDataArray + (int)this.refPointData.markIndex * 8[0] +
			             0x18);
			    UI_Image.set_sprite(this.monsIconImage,uVar3);
			    UI_Image.set_sprite(this.monsShadowImage,uVar3);
			  }
			}
		}
		
		// TODO
		public void OnSelect(bool isMaxZoom) { }
		
		// TODO
		public void UnSelect() { }
		
		// TODO
		private void ChangeIconScale(bool isScaleUp) { }
		
		// TODO
		public void UpdatePosition() { }
	}
}