using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class Capsule2DGridCell : MonoBehaviour
	{
		[SerializeField]
		private SealIcon sealIcon;
		[SerializeField]
		private Image cellImage;
		[SerializeField]
		private RectTransform gridRectTransform;

		private Vector3 sealPosition;
		private Color clearColor = Color.clear;
		private Color affixedSealColor = Color.clear;

		public Vector2 GridPosition { get; private set; }
		public int AffixSealId { get; private set; }
		public int SealId { get; private set; }
		public bool IsSetSeal { get; private set; }
		
		// TODO
		public void Initialize(int x, int y) { }
		
		// TODO
		public void Setup(bool isFront, Color clear, Color affixed) { }
		
		// TODO
		public RectTransform GetRectTransform() { return default; }
		
		// TODO
		public void SetAffixSeal(int affixSealId, int sealId) { }
		
		// TODO
		public void ClearAffixSeal() { }
		
		// TODO
		public void ShowAffixSeal() { }
		
		// TODO
		public void HideAffixSeal() { }
		
		// TODO
		public Vector3 GetSealPosition() { return default; }
		
		// TODO
		public Vector3 GetPosition() { return default; }
		
		// TODO
		private void SetClearColor() { }
		
		// TODO
		private void SetAffixedSealColor() { }
	}
}