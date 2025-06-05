using System;

namespace Dpr.Battle.View
{
	public sealed class TaskFinishFuncCall : Task
	{
		private Action _onFinishFunc;
		
		protected override bool IsFinishCondition { get => _lifeTime <= _frame; }
		
		public TaskFinishFuncCall(int lifeTime, Action onFinish)
		{
			_onFinishFunc = onFinish;
			_lifeTime = lifeTime;
		}
		
		protected override void OnDispose()
		{
			_onFinishFunc = null;
		}
		
		protected override void OnFinishTask()
		{
			_onFinishFunc?.Invoke();
		}
	}
}