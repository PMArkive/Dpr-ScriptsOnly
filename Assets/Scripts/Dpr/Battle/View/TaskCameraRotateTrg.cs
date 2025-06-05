using DG.Tweening;
using Dpr.SequenceEditor;
using System;
using UnityEngine;

namespace Dpr.Battle.View
{
	public sealed class TaskCameraRotateTrg : Task
	{
		private SequenceCameraObject _iPtrBtlvCameraSystem;
		private Vector3 _trg;
		private float _posY;
		private float _len;
		private float _startRot;
		private float _endRot;
		
		protected override bool IsFinishCondition { get => _lifeTime <= _frame; }
		
		public TaskCameraRotateTrg(SequenceCameraObject pBtlvCameraSystem, Vector3 pos, Vector3 trg, float rotRad, int lifeTime, Ease easingType)
		{
			_iPtrBtlvCameraSystem = pBtlvCameraSystem;
			_trg = trg;
			_lifeTime = lifeTime;
			_easingType = easingType;

			var delta = Mathe.Offset(pos, trg);
			_startRot = -Mathe.Atan2Deg(delta.x, delta.z);
			_endRot = _startRot - rotRad;
			_posY = pos.y;
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