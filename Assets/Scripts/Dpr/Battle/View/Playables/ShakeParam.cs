using System;
using UnityEngine;

namespace Dpr.Battle.View.Playables
{
	[Serializable]
	public struct ShakeParam
	{
		[Tooltip("揺れ幅")]
		public Vector3 Strength;
		[Tooltip("振動の強さ")]
		public int Vibrato;
		[Tooltip("")]
		public float Randomness;
		[Tooltip("スムーズフェードするか")]
		public bool FadeOut;
		
		public static ShakeParam Factory(bool isShakeParam = false)
		{
			return new ShakeParam
			{
				Strength = isShakeParam ? new Vector3(0.0f, 0.0f, 0.0f) : new Vector3(0.05f, 0.05f, 0.05f),
				Randomness = isShakeParam ? 0.0f : 90.0f,
				Vibrato = isShakeParam ? 0 : 10,
				FadeOut = false,
			};
		}
	}
}