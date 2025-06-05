using System;
using UnityEngine;

namespace Dpr.DigFossil
{
	public interface IDigFade
	{
		void FadeStart(DigFade.Type type, Color startColor, Color endColor, float duration, Action onEndCallback);

		void Close();
	}
}