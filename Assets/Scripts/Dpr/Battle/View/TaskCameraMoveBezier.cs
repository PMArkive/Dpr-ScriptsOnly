using DG.Tweening;
using Dpr.SequenceEditor;
using UnityEngine;

namespace Dpr.Battle.View
{
	public sealed class TaskCameraMoveBezier : Task
	{
		private SequenceCameraObject _camera;
		private bool _isReletive;
		private Vector3[] _points;
		private bool[] _vectorElems;
		private Vector3 _originPos;
		
		protected override bool IsFinishCondition { get => _lifeTime <= _frame; }
		
		public TaskCameraMoveBezier(SequenceCameraObject pBtlvCameraSystem, bool isRelative, Vector3[] points, bool[] vectorElems, int lifeTime, Ease easingType)
		{
			_camera = pBtlvCameraSystem;
			_isReletive = isRelative;
			_points = points;
			_vectorElems = vectorElems;
			_lifeTime = lifeTime;
			_easingType = easingType;
			_originPos = pBtlvCameraSystem.GetPosition();
		}
		
		protected override void OnDispose()
		{
			Mem.Del(ref _camera);
		}
		
		// TODO
		protected override void OnUpdate(int frame, float raito) { }
	}
}