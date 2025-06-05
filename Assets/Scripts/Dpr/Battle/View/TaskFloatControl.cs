using DG.Tweening;
using System;

namespace Dpr.Battle.View
{
	public sealed class TaskFloatControl : TaskValueControl<float>
	{
		protected override bool IsFinishCondition { get => _lifeTime <= _frame; }
		
		public TaskFloatControl(int lifeTime, Ease easingType, Action<float> onUpdate) : base(0.0f, 1.0f, onUpdate)
		{
			_lifeTime = lifeTime;
			_easingType = easingType;
		}
		
		public TaskFloatControl(float from, float to, int lifeTime, Ease easingType, Action<float> onUpdate) : base(from, to, onUpdate)
		{
            _lifeTime = lifeTime;
            _easingType = easingType;
        }

        // TODO
        protected override void OnUpdate(int frame, float raito) { }
	}
}