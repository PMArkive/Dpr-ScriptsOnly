using System;

namespace Dpr.Battle.View
{
	public class TaskValueControl<TValue> : Task
	{
		protected TValue _from;
		protected TValue _to;
		protected Action<TValue> _onUpdate;
		
		public TaskValueControl(TValue from, TValue to, Action<TValue> onUpdate)
		{
			_onUpdate = onUpdate;
			_from = from;
			_to = to;
		}
		
		protected override void OnDispose()
		{
			Mem.Del(ref _onUpdate);
		}
	}
}