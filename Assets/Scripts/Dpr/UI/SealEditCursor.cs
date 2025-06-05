using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class SealEditCursor : MonoBehaviour
	{
		[SerializeField]
		private Image image;
		[SerializeField]
		private Sprite normalSprite;
		[SerializeField]
		private Sprite selectedSprite;
		[SerializeField]
		private SealIcon sealIcon;
		[SerializeField]
		private GameObject infoTextObject;
		[SerializeField]
		private RectTransform infoTextLeftRectTransform;
		[SerializeField]
		private RectTransform infoTextRightRectTransform;
		[SerializeField]
		private UIText nameText;
		[SerializeField]
		private UIText infoText;
		[SerializeField]
		private Vector2 normalPivot;
		[SerializeField]
		private Vector2 selectedPivot;
		[SerializeField]
		private float correctBorderLessY = 100.0f;
		[SerializeField]
		private float baseYValue = 30.0f;
		[SerializeField]
		private float correctYValue = 30.0f;
		[SerializeField]
		private SealEditSealCountView countView;
		[SerializeField]
		private Color countDefaultColor = Color.white;
		[SerializeField]
		private Color countZeroColor = Color.white;
		[SerializeField]
		private Color countMaxColor = Color.white;

		private RectTransform rectTransform;
		private RectTransform sealIconRectTransform;
		private RectTransform infoTextRectTransform;

		public bool IsSelected { get; set; }
		public int SelectedSealId { get; set; }
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public RectTransform GetRectTransform() { return default; }
		
		// TODO
		public RectTransform GetInfoTextRightRectTransform() { return default; }
		
		// TODO
		public Vector3 GetPosition() { return default; }
		
		// TODO
		public void SetPosition(Vector3 pos) { }
		
		// TODO
		public void SetAnchorPosition(Vector2 pos) { }
		
		// TODO
		public void SetActive(bool isActive) { }
		
		// TODO
		public void Move(float x, float y) { }
		
		// TODO
		public void Selected(int sealId) { }
		
		// TODO
		public void Unselect() { }
		
		// TODO
		public void SetInfoText(SealInfo sealInfo, bool isShowLeft = false) { }
	}
}