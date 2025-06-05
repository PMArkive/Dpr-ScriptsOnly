using DG.Tweening;
using System;
using UnityEngine;

namespace Dpr.Contest
{
	[Serializable]
	public class HeartBeziePath
	{
		public float duration;
		public Ease easeType;
		public Vector3 point1;
		public Vector3 point2;
	}
}