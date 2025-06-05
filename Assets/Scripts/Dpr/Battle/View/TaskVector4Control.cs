using DG.Tweening;
using System;
using UnityEngine;

namespace Dpr.Battle.View
{
	public sealed class TaskVector4Control : TaskValueControl<Vector4>
	{
		protected override bool IsFinishCondition { get => _lifeTime <= _frame; }
		
		public TaskVector4Control(Vector4 from, Vector4 to, Ease easingType, int lifeTime, Action<Vector4> onUpdate) : base(from, to, onUpdate)
		{
			_lifeTime = lifeTime;
			_easingType = easingType;
		}
		
		protected override void OnUpdate(int frame, float raito)
		{
			_onUpdate?.Invoke(new Vector4(DOVirtual.EasedValue(_from.x, _to.x, raito, _easingType),
                DOVirtual.EasedValue(_from.y, _to.y, raito, _easingType),
                DOVirtual.EasedValue(_from.z, _to.z, raito, _easingType),
				DOVirtual.EasedValue(_from.w, _to.w, raito, _easingType)));
		}
	}
}