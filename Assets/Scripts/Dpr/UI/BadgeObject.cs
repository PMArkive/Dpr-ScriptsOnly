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
		
		public bool IsVisible { get; private set; }
		public bool IsAutoRotate { get; private set; }
		
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
		
		public void SetActive(bool isActive)
		{
			this.Length.SetActive(isActive & 1);
		}
		
		// TODO
		public void Polish() { }
		
		// TODO
		public void Hit() { }
		
		public Vector3 GetPosition()
		{
			Transform.get_position(this[0]);
		}
		
		public void SetPosition(Vector3 pos)
		{
			Transform.position = this[0];
		}
		
		public Quaternion GetRotation()
		{
			Transform.get_rotation(this[0]);
		}
		
		public void SetRotation(Quaternion quaternion)
		{
			Transform.rotation = this[0];
		}
		
		// TODO
		public void RotateY(float value) { }
		
		// TODO
		public void StartAutoRotate(float duration) { }
		
		// TODO
		public void StopAutoRotate() { }
		
		public void PlayConditionEffect()
		{
			if (this.conditionEffect != null) {
			}
			UpdateCondition(1);
		}
		
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