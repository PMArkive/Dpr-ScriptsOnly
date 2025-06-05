using Audio;
using Dpr.Battle.View.Objects;

namespace Dpr.Battle.View
{
	public sealed class TaskSoundDelete : Task
	{
		private AudioInstance _audioInstance;
		private BtlvSound _sound;
		
		protected override bool IsFinishCondition { get => _lifeTime < _frame; }
		
		public TaskSoundDelete(BtlvSound instance, int lifeTime, int frame = 0)
		{
			_sound = instance;
			_lifeTime = lifeTime;
			_frame = frame;
		}
		
		protected override void OnDispose()
		{
			Mem.Del(ref _audioInstance);
		}
		
		protected override void OnFinishTask()
		{
			_audioInstance?.Stop();
		}
	}
}