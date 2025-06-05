using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.DigFossil
{
	public class DigFade : MonoBehaviour, IDigFade
	{
		[SerializeField]
		private RawImage overUIImage;
		[SerializeField]
		private RawImage overEffectImage;
		private Color endColor = Color.black;
		private Action onEndCallback;
		private RawImage currentImage;
		
		// TODO
		private void Start() { }
		
		// TODO
		public void FadeStart(Type type, Color startColor, Color endColor, float duration, Action onEndCallback) { }
		
		// TODO
		public void Close() { }
		
		// TODO
		private IEnumerator Idle(float duration) { return default; }

		public enum Type : int
		{
			OverUI = 0,
			OverEffect = 1,
		}
	}
}