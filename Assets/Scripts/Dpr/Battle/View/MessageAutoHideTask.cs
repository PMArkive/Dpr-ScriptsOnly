using Dpr.SequenceEditor;

namespace Dpr.Battle.View
{
	public sealed class MessageAutoHideTask : Task
	{
		private ISequenceViewSystem _iPtrBtlvSystem;
		
		protected override bool IsFinishCondition { get => _lifeTime <= _frame; }
		
		public MessageAutoHideTask(ISequenceViewSystem pBtlvSystem)
		{
			_iPtrBtlvSystem = pBtlvSystem;
			_lifeTime = 10;
		}
		
		protected override void OnDispose()
		{
			Mem.Del(ref _iPtrBtlvSystem);
		}
		
		protected override void OnFinishTask()
		{
			// Empty
		}
	}
}