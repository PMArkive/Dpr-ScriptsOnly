using DPData;
using Effect;
using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.UI
{
	public class BadgeObject
	{
		private int id;
		private GameObject gameObject;
		private Transform nodeTransform;
		private BadgeCondition currentBadgeCondition;
		private EffectInstance conditionEffect;
		private int polishedCount;
		private int needCleanupCount;
		private byte cleanupValue;
		
		public bool IsVisible { get; set; }
		public bool IsAutoRotate { get; set; }
		
		public BadgeObject(int id, GameObject gameObject, Transform transform)
		{
			this.id = id;
			this.gameObject = gameObject;
			this.nodeTransform = transform;

			IsVisible = BadgeWork.IsGet(id);
			if (IsVisible)
				UpdateCondition(true);

			gameObject.SetActive(IsVisible);
		}
		
		// TODO
		public void Dispose() { }
		
		// TODO
		public Transform GetTransform() { return default; }
		
		// TODO
		public void SetActive(bool isActive) { }
		
		// TODO
		public void Polish() { }
		
		// TODO
		public void Hit() { }
		
		// TODO
		public Vector3 GetPosition() { return default; }
		
		// TODO
		public void SetPosition(Vector3 pos) { }
		
		// TODO
		public Quaternion GetRotation() { return default; }
		
		// TODO
		public void SetRotation(Quaternion quaternion) { }
		
		// TODO
		public void RotateY(float value) { }
		
		// TODO
		public void StartAutoRotate(float duration) { }
		
		// TODO
		public void StopAutoRotate() { }
		
		// TODO
		public void PlayConditionEffect() { }
		
		// TODO
		public void StopConditionEffect() { }
		
		// TODO
		private void UpdateCondition(bool isForce = false)
		{
			// TODO
			void Loaded(EffectInstance effectInstance) { }
        }
		
		// TODO
		private void PlayEffect(int effectID, Transform parent, [Optional] Action<EffectInstance> onLoaded) { }
	}
}