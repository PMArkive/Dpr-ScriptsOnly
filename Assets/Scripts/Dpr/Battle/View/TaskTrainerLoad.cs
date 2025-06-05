using Dpr.Battle.Logic;
using Dpr.SequenceEditor;

namespace Dpr.Battle.View
{
	public sealed class TaskTrainerLoad : Task
	{
		private ISequenceViewSystem _iPtrBtlvSystem;
		private BtlvPos _vPos;
		private string _name;
		private Sequence _seq;
		
		public TaskTrainerLoad(ISequenceViewSystem pBtlvSystem, BtlvPos vPos, string name)
		{
			_iPtrBtlvSystem = pBtlvSystem;
			_name = name;
			_vPos = vPos;
			_seq = Sequence.START_LOAD;
		}
		
		protected override void OnDispose()
		{
			Mem.Del(ref _iPtrBtlvSystem);
		}
		
		// TODO
		public override void Update(float deltaTime, float currentSequenceTime, int step) { }

		private enum Sequence : int
		{
			START_LOAD = 0,
			WAIT_LOAD = 1,
			FINISH = 2,
		}
	}
}