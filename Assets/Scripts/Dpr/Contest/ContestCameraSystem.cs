using Dpr.SequenceEditor;
using UnityEngine;

namespace Dpr.Contest
{
	public class ContestCameraSystem : SequenceCameraSystem
	{
		public WaitCameraStateType WaitCameraState { get; set; }
		public bool IsPlayWaitCamera { get => WaitCameraState != WaitCameraStateType.None; }
		
		// TODO
		public Transform GetTargetTransform() { return default; }
		
		// TODO
		public ContestCameraSystem(ISequenceViewSystem cameraView, Camera mainCamera) : base(cameraView) { }
		
		// TODO
		public override void OnLateUpdate(float deltaTime) { }
		
		// TODO
		private void LateUpdateWaitCamera() { }
	}
}