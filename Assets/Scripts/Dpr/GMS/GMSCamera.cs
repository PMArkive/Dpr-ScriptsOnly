using DG.Tweening;
using System;
using System.Runtime.InteropServices;
using UnityEngine;
using XLSXContent;

namespace Dpr.GMS
{
	public class GMSCamera : MonoBehaviour
	{
		private readonly Vector3 LOOK_AT_UP = new Vector3(0.0f, 1.0f, 0.0f);

		[SerializeField]
		private Camera mainCamera;
		private Action onStopMove;
		private EnvironmentController envControllerPtr;
		private GMSMasterData.SheetDistanceConfig[] distanceConfig;
		private GMSMasterData.SheetCameraConfig cameraConfig;
		private Tween distanceTween;
		private Tween rotTween;
		private Transform cameraTransform;
		private Quaternion initCameraRot;
		private Quaternion cameraRot;
		private Quaternion nextCameraRot;
		private Quaternion currentCameraRot;
		private Vector3 initCameraNormal;
		private Vector3 cameraPosNormal;
		private Vector3 addAngleAxis;
		private CameraMode currentMode;
		private float nowDistance;
		private float distanceRange;
		private float rotTweenRatio;
		private float addAngle;
		private float speedUpCoefficient;
		private int distanceLevel;
		private int distanceLevelNum;
		private int currentMovedIndex = -1;
		private bool bIsInputMoving;
		private bool bIsOverMaxSpeed;
		private bool bLockOperation;
		private bool isRunningDistanceTween;
		private bool isRunningRotTween;
		
		// TODO
		public void Initialize(Action onStopMove) { }
		
		// TODO
		public void SetCameraConfig(GMSMasterData gmsMasterData) { }
		
		// TODO
		public void Setup(RenderTexture renderTexture, float speedUpCoefficient, EnvironmentController envController) { }
		
		// TODO
		public void OnFinalize() { }
		
		// TODO
		private void KillDistanceTween() { }
		
		// TODO
		private void KillRotTween() { }
		
		// TODO
		public void ChangeCameraMode(CameraMode mode) { }
		
		public bool IsMoving { get => RunningDistanceTween || RunningRotTween || bIsInputMoving || HasInputMoveSpeed; }
		public bool HasInputMoveSpeed { get => addAngle > 0.0f; }
		public bool RunningDistanceTween { get => distanceTween != null; }
		public bool RunningRotTween { get => rotTween != null; }
		public Vector3 CameraPosition { get => cameraTransform.localPosition; }
		public bool IsHighZoom { get => distanceLevelNum - 1 <= distanceLevel; }
		public int DistanceLevelNum { get => distanceLevelNum; }
		public bool CanInput { get => currentMode == CameraMode.TracePoint; }
		
		// TODO
		public void LockMove() { }
		
		// TODO
		public void UnlockMove() { }
		
		// TODO
		private void ResetMovedIndex() { }
		
		// TODO
		public void PerformNearDistance([Optional] Action onComplete) { }
		
		// TODO
		public void PerformFarDistance([Optional] Action onComplete) { }
		
		// TODO
		public void ForceSetDistance(int level, [Optional] Action onComplete) { }
		
		// TODO
		public void ResetDistance([Optional] Action onComplete, bool isImmediately = false, bool playSe = true) { }
		
		// TODO
		private float GetGoalDistanceValue() { return default; }
		
		// TODO
		private void DoDistanceTween(float goalValue, float duration, Ease easeType, [Optional] [DefaultParameterValue(0.0f)] float delay, [Optional] Action onCompleteTween) { }
		
		// TODO
		public void ResetCameraPos() { }
		
		// TODO
		public bool CanSnapPoint(in Vector3 goalPoint) { return default; }
		
		// TODO
		public void PerformRotate(int movePoint, in Vector3 goalPoint, bool checkForcesRange, [Optional] Action onComplete) { }
		
		// TODO
		public void SnapPoint(int movePoint, in Vector3 goalPoint, [Optional] Action onComplete) { }
		
		// TODO
		private float CalcRotateTweenDuration(in Vector3 srcVec, in Vector3 destPoint) { return default; }
		
		// TODO
		private void DoRotateTween(Vector3 cameraPosNormal, Vector3 goalPointNormal, float tweenDuration, Ease easeType, [Optional] [DefaultParameterValue(0.0f)] float delay, [Optional] Action onCompleteTween) { }
		
		// TODO
		private void SetNowCameraTransformParams() { }
		
		// TODO
		public void MoveCameraPosition(in Vector3 moveVec, float deltaTime, bool isSpeedUp) { }
		
		// TODO
		public void StopMoveCameraPosition() { }
		
		// TODO
		public void StopImmediateMoveCameraPosition() { }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		public void OnLateUpdate(float deltaTime) { }
		
		// TODO
		private void UpdateRot() { }
		
		// TODO
		private void UpdateMove(float deltaTime) { }
		
		// TODO
		private void DecSpeed(float deltaTime) { }
		
		// TODO
		private float CalcMoveSpeedDemical() { return default; }
		
		// TODO
		private float CalcDistanceRatio() { return default; }
		
		// TODO
		private void UpdatePosition() { }
		
		// TODO
		private Quaternion CalcCameraRot() { return default; }
		
		// TODO
		public void CheckTweenRunning() { }
	}
}