using UnityEngine;

namespace Dpr.Contest
{
	public class BarLine : MonoBehaviour
	{
		private const float OVER_LIFE_TIME = 2.0f;

		private RectTransform rect;
		private Vector3 iconPos;
		private float arriveSec;
		private float lifeTime;
		private float resetTime;
		private float moveSpeed;
		
		// TODO
		public void Create(float arriveSec, float moveSpeed, float resetTime) { }
		
		// TODO
		public void ResetParam(float arriveSec, float resetTime) { }
		
		// TODO
		public void OnUpdate(float elapsedTime) { }
		
		// TODO
		private void UpdatePosition(float lifeTime) { }
		
		// TODO
		private void SetActive(bool active) { }
	}
}