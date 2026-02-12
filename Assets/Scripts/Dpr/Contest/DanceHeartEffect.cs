using DG.Tweening;
using Effect;
using System;
using UnityEngine;

namespace Dpr.Contest
{
	public class DanceHeartEffect : MonoBehaviour
	{
		private EffectManager fxManagerPtr;
		private EffectData heartFxData;
		private EffectInstance fxInst;
		private Ease easeTypeID = Ease.InCubic;
		private Transform effectTransform;
		private Transform fxInstTransform;
		private Transform fxManagerTransform;
		private Vector3 startPoint;
		private Vector3 pointA;
		private Vector3 pointB;
		private Vector3 goalPoint;
		private float timer;
		private float duration;
		private Action onComplete;
		private bool active;
		private bool isPlayerHeart;
		
		public bool IsActive { get => active; }
		
		// TODO
		public void Initialize() { }
		
		public void SetNormalHeartFxData(EffectData fxData)
		{
			this[0] = fxData;
		}
		
		public void SetLargeHeartFxData(EffectData fxData)
		{
			this[0] = fxData;
		}
		
		// TODO
		public void OnFinalize() { }
		
		public void Create()
		{
			var uVar1 = Contest_DanceHeartEffect.CheckHeartFxInst();
			if (this.fxInst == null) {
			  if (this.onComplete != null) {
			    this.onComplete.Invoke();
			  }
			}
			else {
			  var uVar2 = Component.gameObject;
			  var uVar3 = uVar2.activeSelf;
			  if ((uVar3 & 1) == 0) {
			    ExtensionMethods.SetActive(1);
			  }
			  if (this.fxInst != null) {
			    uVar2 = UnityEngine_Component__get_gameObject
			                      (this.fxInst.Length,0);
			    uVar3 = uVar2.activeSelf;
			    if ((uVar3 & 1) == 0) {
			      uVar2.SetActive(1);
			    }
			  }
			  if (!uVar1) {
			    this.fxInst.Play(0);
			  }
			}
		}
		
		// TODO
		private bool CheckHeartFxInst() { return default; }
		
		public void OnUpdate(float deltaTime)
		{
			if (this.isPlayerHeart) {
			  Contest_DanceHeartEffect.OnPlayerHeartUpdate();
			}
			Contest_DanceHeartEffect.OnNPCHeartUpdate();
		}
		
		// TODO
		public void PerformEmitPlayerHeart(float duration, Ease easeType, Action onComplete, Vector3[] points) { }
		
		// TODO
		private void OnPlayerHeartUpdate(float deltaTime) { }
		
		// TODO
		private void UpdatePosition() { }
		
		// TODO
		public void PerformEmitNPCHeart(float duration, Ease easeType, Action onComplete, Vector3 from, Vector3 to) { }
		
		// TODO
		private void OnNPCHeartUpdate(float deltaTime) { }
		
		// TODO
		private void FinishFx() { }
		
		// TODO
		public void Stop() { }
		
		private void SetGoActive(bool active)
		{
			if (this.fxInst != null) {
			  var uVar2 = UnityEngine_Component__get_gameObject
			                    (this.fxInst.Length,0);
			  var uVar1 = uVar2.activeSelf;
			  if (((uVar1 ^ active) & 1) != 0) {
			    uVar2.SetActive(active & 1);
			  }
			}
		}
	}
}