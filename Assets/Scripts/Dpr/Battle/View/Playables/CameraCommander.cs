using Dpr.Battle.View.Objects;
using Dpr.SequenceEditor;
using UnityEngine;

namespace Dpr.Battle.View.Playables
{
	[RequireComponent(typeof(Camera))]
	public sealed class CameraCommander : BtlvBehaviour
	{
		[SerializeField]
		private Camera _camera;
		[SerializeField]
		private BOCamera _targetCamera;
		private CameraData _cameraData;
		private Transform _aimTarget;
		
		public BOCamera TargetCamera { get => _targetCamera; }
		public Camera Camera { get => this.GetComponentThis(ref _camera); }
		private bool IsStop { get; set; }
		public Transform AimTarget { get => _aimTarget; }
		
		// TODO
		private void OnDestroy() { }
		
		// TODO
		private void OnEnable() { }
		
		// TODO
		public void Initialize(ISequenceViewSystem viewSystem, CameraData cameraData, Transform aimTarget) { }
	}
}