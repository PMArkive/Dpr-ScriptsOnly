using DG.Tweening;
using Dpr.SequenceEditor;
using System;
using UnityEngine;

namespace Dpr.Battle.View
{
	public sealed class TaskCameraRotatePos : Task
	{
		private SequenceCameraObject _iPtrBtlvCameraSystem;
		private Vector3 _pos;
		private float _trgY;
		private float _len;
		private float _startRot;
		private float _endRot;
		
		protected override bool IsFinishCondition { get => _lifeTime <= _frame; }
		
		public TaskCameraRotatePos(SequenceCameraObject pBtlvCameraSystem, Vector3 pos, Vector3 trg, float rotRad, int lifeTime, Ease easingType)
		{
			_iPtrBtlvCameraSystem = pBtlvCameraSystem;
			_pos = pos;
			_lifeTime = lifeTime;
			_easingType = easingType;

			var delta = Mathe.Offset(trg, pos);
			_startRot = -Mathe.Atan2(delta.x, delta.z);
            _endRot = rotRad + _startRot;
			_trgY = trg.y;
			_len = Mathe.Length(delta.x, delta.z);
		}
		
		protected override void OnDispose()
		{
			Mem.Del(ref _iPtrBtlvCameraSystem);
		}
		
		// TODO
		protected override void OnUpdate(int frame, float raito) { }
	}
}