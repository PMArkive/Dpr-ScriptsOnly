using Dpr.SequenceEditor;
using UnityEngine;

namespace Dpr.Battle.View
{
	public sealed class TaskShakeObject : Task
	{
		private float _startRate;
		private float _endRate;
		private float _startDec;
		private float _endDec;
		private SEQ_DEF_AXIS _axis;
		private VectorSetFunc _setFunc;
		private VectorGetFunc _vectorGetFunc;
		private RotateGetFunc _rotateGetFunc;
		
		protected override bool IsFinishCondition { get => _lifeTime <= _frame; }
		
		public TaskShakeObject(VectorSetFunc setFunc, VectorGetFunc getFunc, RotateGetFunc rotGetFunc, float startRate, float endRate, float startDec, float endDec, int lifeTime, SEQ_DEF_AXIS axis)
		{
			_setFunc = setFunc;
			_vectorGetFunc = getFunc;
			_rotateGetFunc = rotGetFunc;
			_startRate = startRate * 0.01f;
			_startDec = startDec * 360.0f;
			_endRate = endRate * 0.01f;
            _lifeTime = lifeTime;
			_axis = axis;
			_endDec = endDec * 360.0f;
		}
		
		protected override void OnDispose()
		{
			Mem.Del(ref _setFunc);
			Mem.Del(ref _vectorGetFunc);
			Mem.Del(ref _rotateGetFunc);
		}
		
		// TODO
		protected override void OnUpdate(int frame, float raito) { }

		public delegate void VectorSetFunc(Vector3 value);
		public delegate Vector3 VectorGetFunc();
		public delegate Vector3 RotateGetFunc();
	}
}