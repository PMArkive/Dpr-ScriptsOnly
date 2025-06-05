using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Contest
{
	public class UITimingGrade : MonoBehaviour
	{
		private readonly Vector3 INACTIVE_POS = new Vector3(0.0f, -1500.0f, 0.0f);
		private readonly Vector3 VECTOR_ONE = new Vector3(1.0f, 1.0f, 1.0f);

		private DOTweenAnimation[] tweenArray;
		private Image gardeImage;
		private RectTransform rect;
		private float initPosY;
		private bool isInitialize;
		private bool isActive;
		
		public bool IsActive { get => isActive; }
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void Show(Sprite spr) { }
		
		// TODO
		private void ResetParameter() { }
		
		// TODO
		public void OnComplete() { }
	}
}