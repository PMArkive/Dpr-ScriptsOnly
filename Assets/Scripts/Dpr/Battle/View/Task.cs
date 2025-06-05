using DG.Tweening;
using System;

namespace Dpr.Battle.View
{
	public class Task : IDisposable
	{
		public int _priority;
		public Task _iPtrPrev;
		public Task _iPtrNext;
		public bool _isSelfDelete;
		protected float _raito;
		protected int _frame;
		protected int _lifeTime;
		protected Ease _easingType;
		protected bool _isStart;
		protected Action _onStart;
		protected Action _onFinished;
		protected AdvanceMode _advanceMode;
		protected float _startTime;
		protected float _endTime;
		protected float _duration;
		protected float _elapsedTime;

		protected virtual bool IsFinishCondition { get; }
		public bool IsEffectEnable { get; set; }
		public TaskManager Parent { get; set; }
		public bool IsFinished { get => _isSelfDelete; }
		public float Duration { get => _endTime - _startTime; }
		
		public Task()
		{
			_priority = 0;
			_iPtrPrev = null;
			_iPtrNext = null;
			_isSelfDelete = false;
			_frame = 0;
			_lifeTime = 0;
			_isStart = false;
			_onStart = null;
			Parent = null;
			_endTime = 0.0f;
			_advanceMode = AdvanceMode.Step;
			_startTime = 0.0f;
			_elapsedTime = 0.0f;
		}
		
		// TODO
		public void Dispose() { }
		
		// TODO
		protected virtual void OnDispose() { }
		
		public void Clear(Task iPtrDummyTask)
		{
			Clear();
			_iPtrPrev = iPtrDummyTask;
			_iPtrNext = iPtrDummyTask;
			_priority = 0;
		}
		
		// TODO
		public void Delete() { }
		
		// TODO
		protected virtual void Clear() { }
		
		// TODO
		public virtual void Update(float deltaTime, float currentSequenceTime, int step) { }
		
		// TODO
		protected virtual void FinishTask() { }
		
		// TODO
		public Task SetOnStart(Action onStart) { return default; }
		
		// TODO
		public Task SetOnFinished(Action onFinished) { return default; }
		
		// TODO
		public Task SetStartTime(float startTime) { return default; }
		
		// TODO
		public Task SetEndTime(float endTime) { return default; }
		
		// TODO
		public Task SetDuration(float duration) { return default; }
		
		// TODO
		public Task SetAdvanceMode(AdvanceMode mode) { return default; }
		
		// TODO
		protected virtual void OnUpdate(int frame, float raito) { }
		
		// TODO
		protected virtual void OnFinishTask() { }

		public enum AdvanceMode : int
		{
			Step = 0,
			Time = 1,
		}
	}
}