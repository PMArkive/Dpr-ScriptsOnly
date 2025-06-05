using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.GMS
{
	public class UINetworkIcon : MonoBehaviour
	{
		private DOTweenAnimation[] matchingIconTweens;
		private DOTweenAnimation[] attentionIconTweens;
		private GameObject matchingIconObj;
		private GameObject attentionIconObj;
		private Image matchingIconImage;
		private Image attentionIconImage;
		private RectTransform matchingIconRect;
		private RectTransform attentionIconRect;
		
		// TODO
		public void Initialize() { }
		
		public Vector3 MatchingIconPos { get => matchingIconRect.position; }
		
		// TODO
		public void ShowMatchingIcon() { }
		
		// TODO
		public void HideMatchingIcon() { }
		
		// TODO
		public void ShowAttentionIcon() { }
		
		// TODO
		public void HideAttentionIcon() { }
	}
}