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
		
		// TODO
		public void HidePointIcon() { }
		
		// TODO
		public void OnChangeDistance(bool isMaxZoom) { }
		
		// TODO
		public void UpdateView() { }
		
		// TODO
		private void SetIconImageVisible(bool visible) { }
		
		// TODO
		private void UpdateMonsIcon() { }
		
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