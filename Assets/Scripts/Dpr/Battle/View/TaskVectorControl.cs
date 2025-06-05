using DG.Tweening;
using System;
using UnityEngine;

namespace Dpr.Battle.View
{
	public sealed class TaskVectorControl : TaskValueControl<Vector3>
	{
		protected override bool IsFinishCondition { get => _lifeTime <= _frame; }
		
		public TaskVectorControl(Vector3 from, Vector3 to, Ease easingType, int lifeTime, Action<Vector3> onUpdate) : base(from, to, onUpdate)
		{
			_lifeTime = lifeTime;
			_easingType = easingType;
			_elapsedTime = 0.0f;
		}
		
		// TODO
		protected override void OnUpdate(int frame, float raito) { }
	}
}