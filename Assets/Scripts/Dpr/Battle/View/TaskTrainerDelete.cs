using Dpr.Battle.Logic;
using Dpr.SequenceEditor;

namespace Dpr.Battle.View
{
	public sealed class TaskTrainerDelete : Task
	{
		private ISequenceViewSystem _iPtrBtlvSystem;
		private BtlvPos _vPos;
		private Sequence _seq;
		
		public TaskTrainerDelete(ISequenceViewSystem pBtlvSystem, BtlvPos vPos)
		{
			_iPtrBtlvSystem = pBtlvSystem;
			_vPos = vPos;
			_seq = Sequence.START_DELETE;
		}
		
		// TODO
		public override void Update(float deltaTime, float currentSequenceTime, int step) { }

		private enum Sequence : int
		{
			START_DELETE = 0,
			WAIT_DELETE = 1,
			FINISH = 2,
		}
	}
}