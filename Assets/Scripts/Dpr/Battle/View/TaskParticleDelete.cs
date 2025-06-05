using Dpr.Battle.View.Objects;
using Dpr.SequenceEditor;
using System;

namespace Dpr.Battle.View
{
	public sealed class TaskParticleDelete : Task
	{
		private BtlvEffectInstance _effectInstance;
		private Action _onFinishAction;
		private SEQ_DEF_PARTICLE_DELETE _deleteType;
		
		protected override bool IsFinishCondition { get => _lifeTime <= _frame; }
		
		public TaskParticleDelete(BtlvEffectInstance instance, SEQ_DEF_PARTICLE_DELETE deleteType, Action finishAction, int lifeTime, int frame = 0)
		{
			_effectInstance = instance;
			_onFinishAction = finishAction;
			_deleteType = deleteType;
			_lifeTime = lifeTime;
			_frame = frame;
		}
		
		protected override void OnDispose()
		{
			Mem.DelIDisposable(ref _effectInstance);
			Mem.Del(ref _onFinishAction);
		}
		
		protected override void OnFinishTask()
		{
			_effectInstance.Kill(_deleteType == SEQ_DEF_PARTICLE_DELETE.SEQ_DEF_PARTICLE_DELETE_KILL);
			_onFinishAction?.Invoke();
		}
	}
}