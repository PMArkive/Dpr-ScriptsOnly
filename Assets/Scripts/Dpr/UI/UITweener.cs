using System;
using System.Collections;
using UnityEngine;

namespace Dpr.UI
{
	public static class UITweener
	{
		private const float ArrowTweenMoveValue = 20.0f;
		private const float ArrowTweenMoveDuration = 0.05f;
		
		// TODO
		public static void PlayArrowTween(RectTransform rectTransform, ArrowDirection direction) { }
		
		// TODO
		public static Coroutine StartRemoveNewIcon(Action onRemove)
		{
			// TODO
			IEnumerator RemoveNewCoroutine() { return default; }

            return default;
		}

		public enum ArrowDirection : int
		{
			Up = 0,
			Down = 1,
			Left = 2,
			Right = 3,
		}
	}
}