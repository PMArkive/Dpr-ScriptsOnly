using DG.Tweening;
using Dpr.SequenceEditor;
using UnityEngine;

namespace Dpr.Battle.View
{
	public sealed class TaskCameraMove : Task
	{
		private SequenceCameraObject _iPtrCamerasystem;
		private Vector3 _startPos;
		private Vector3 _endPos;
		private Vector3 _startTrg;
		private Vector3 _endTrg;
		private Vector3 _startPosOfs;
		private Vector3 _endPosOfs;
		private Vector3 _startTrgOfs;
		private Vector3 _endTrgOfs;
		private float _startFov;
		private float _endFov;
		private UpdateMode _mode;
		private Vector3 _pos;
		private Vector3 _trg;
		private Vector3 _posOfs;
		private Vector3 _trgOfs;
		
		protected override bool IsFinishCondition { get => _lifeTime <= _frame; }
		
		public TaskCameraMove(SequenceCameraObject pBtlvCameraSystem, Vector3 endPos, Ease easingType, int lifeTime)
		{
			_iPtrCamerasystem = pBtlvCameraSystem;
			_startPos = pBtlvCameraSystem.GetPosition();
			_endPos = endPos;
			_lifeTime = lifeTime;
			_easingType = easingType;
			_endTrg = Vector3.zero;
			_startTrg = Vector3.zero;
			_startFov = 0.0f;
			_endFov = 0.0f;
			_mode = UpdateMode.MoveOnly;
		}
		
		public TaskCameraMove(SequenceCameraObject pBtlvCameraSystem, Vector3 endPos, Vector3 endTrg, float endFov, Ease easingType, int frame)
		{
			_iPtrCamerasystem = pBtlvCameraSystem;
			_endPos = endPos;
			_startPos = pBtlvCameraSystem.GetPosition();
			_startTrg = pBtlvCameraSystem.GetTarget();
			_endTrg = endTrg;
			_endFov = endFov;
			_startFov = pBtlvCameraSystem.Fov;
			_lifeTime = frame;
			_easingType = easingType;
			_mode = UpdateMode.All;
		}
		
		public TaskCameraMove(SequenceCameraObject pBtlvCameraSystem, Vector3 endPos, Vector3 endTrg, Vector3 endPosOfs, Vector3 endTrgOfs, float endFov, Ease easingType, int frame)
		{
            _iPtrCamerasystem = pBtlvCameraSystem;
            _endPos = endPos;
            _startPos = pBtlvCameraSystem.GetPosition();
            _endTrg = endTrg;
            _startTrg = pBtlvCameraSystem.GetTarget();
			_endPosOfs = endPosOfs;
			_startPosOfs = pBtlvCameraSystem.GetPositionOffset();
			_startTrgOfs = pBtlvCameraSystem.GetTargetOffset();
			_endTrgOfs = endTrgOfs;
            _mode = UpdateMode.All;
            _endFov = endFov;
            _startFov = pBtlvCameraSystem.Fov;
            _lifeTime = frame;
            _easingType = easingType;
        }
		
		protected override void OnDispose()
		{
			Mem.Del(ref _iPtrCamerasystem);
		}
		
		// TODO
		protected override void OnUpdate(int frame, float raito) { }

		private enum UpdateMode : int
		{
			MoveOnly = 0,
			All = 1,
		}
	}
}