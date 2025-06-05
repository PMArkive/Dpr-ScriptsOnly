using Dpr.SequenceEditor;
using System;
using UnityEngine;

namespace Dpr.Battle.View
{
	public sealed class TaskObjectCameraAutoRotate : Task
	{
		private SequenceCameraObject _iPtrBtlvCamraSystem;
		private float _len;
		private Vector3 _ofs;
		private Action<Vector3> _onPosUpdate;
		private Action<Vector3> _onRotUpdate;
		
		protected override bool IsFinishCondition { get => _lifeTime <= _frame; }
		
		public TaskObjectCameraAutoRotate(SequenceCameraObject pBtlvCameraSystem, float len, Vector3 ofs, int lifeTime, Action<Vector3> onPosUpdate, Action<Vector3> onRotUpdate)
		{
			_iPtrBtlvCamraSystem = pBtlvCameraSystem;
			_len = len;
			_ofs = ofs;
			_lifeTime = lifeTime;
			_onPosUpdate = onPosUpdate;
			_onRotUpdate = onRotUpdate;
            _lifeTime = lifeTime;
        }
		
		protected override void OnDispose()
		{
			Mem.Del(ref _onPosUpdate);
			Mem.Del(ref _onRotUpdate);
		}
		
		// TODO
		protected override void OnUpdate(int frame, float raito) { }
	}
}