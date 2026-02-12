using Dpr.Battle.Logic;
using Dpr.Battle.View.Systems;
using Dpr.SequenceEditor;
using System;
using System.Runtime.InteropServices;
using UnityEngine;
using XLSXContent;

namespace Dpr.Battle.View.Playables
{
	[RequireComponent(typeof(Animation))]
	public class CameraFilePlayable : BattleViewPlayable<CameraFilePlayable>
	{
		[Header("[CameraData(待機カメラの場合は無視されます)]")]
		[SerializeField]
		private CameraData _cameraData = CameraData.Factory();
		[Header("[Animation Params]")]
		[SerializeField]
		private Animation _animation;
		[SerializeField]
		private AnimationClip _animationClip;
		[Header("[Shake Params]")]
		[SerializeField]
		private Transform _shakeNode;
		[SerializeField]
		private ShakeParam _shakeParam = ShakeParam.Factory();
		[SerializeField]
		private CameraCommander _waitCameraCommander;
		[SerializeField]
		private Transform _aimTarget;
		private float _speed;
		private PlayMode _mode;
		private Vector3 _initialScale;
		private Vector3 _offset;
		private bool _isFlip;
		private ISequenceViewSystem _viewSystem;
		private BattleWaitCameraData.SheetWaitCameraData _waitCameraData;
		
		public override bool IsPlaying { get => Animation.isPlaying; }
		public Animation Animation { get => this.GetComponentThis(ref _animation); }
		public CameraCommander Commander { get => _waitCameraCommander; }
		
		// TODO
		private void OnDestroy() { }
		
		// TODO
		public void Initialize(ISequenceViewSystem viewSystem) { }
		
		// TODO
		public void Initialize(BattleViewSystem viewSystem, BattleWaitCameraData.SheetWaitCameraData data) { }
		
		// TODO
		public void UnInitialize() { }
		
		// TODO
		protected override void OnLateUpdate(float deltaTime) { }
		
		// TODO
		private void OnLateUpdateSequenceEditor(float deltaTime) { }
		
		// TODO
		private void OnLateUpdateWaitCamera(float deltaTime) { }
		
		// TODO
		public override void Play([Optional] Action onComplete) { }
		
		private void OnStart()
		{
			this[0] = 1;
			if ((int)this._mode != 0) {
			}
			Playables_CameraFilePlayable.OnStartWaitCamera();
		}
		
		private void OnStartWaitCamera()
		{
			var uVar1 = ExtensionMethods__GetComponentThis<Transform>
			                  (this,ref this._animation);
			var uVar2 = ExtensionMethods__GetComponentThis<Transform>
			                  (this,ref this._animation);
			uVar2 = uVar2.clip;
			uVar2 = uVar2.name;
			uVar1 = uVar1.get_Item(uVar2);
			AnimationState.set_speed(this._waitCameraData[0],uVar1);
		}
		
		// TODO
		private void OnComplete() { }
		
		// TODO
		public override void Stop() { }
		
		// TODO
		public void SetSpeed(float speed) { }
		
		// TODO
		public void SetCameraAnimationFlip(bool isFlip) { }
		
		// TODO
		public void SetCameraAnimationRotateYDeg(float rot) { }
		
		// TODO
		public void SetReserveFollowTrainer(BtlvPos vPos, Joint pJoint, Vector3 posOfs, bool isLoseCam) { }
		
		// TODO
		public void SetCameraAnimationOffset(Vector3 offset) { }
		
		// TODO
		public void SetCameraAnimationScale(Vector3 scale) { }

		public enum PlayMode : int
		{
			WaitCamera = 0,
			SequenceEditor = 1,
		}
	}
}