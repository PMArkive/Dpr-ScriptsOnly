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
		
		public void Dispose()
		{
            OnDispose();
            Clear();
        }
		
		protected virtual void OnDispose()
		{
			// Empty
		}
		
		public void Clear(Task iPtrDummyTask)
		{
			Clear();
			_iPtrPrev = iPtrDummyTask;
			_iPtrNext = iPtrDummyTask;
			_priority = 0;
		}
		
		public void Delete()
		{
			_iPtrPrev._iPtrNext = _iPtrNext;
			_iPtrNext._iPtrPrev = _iPtrPrev;

			Dispose();
		}
		
		protected virtual void Clear()
		{
            _priority = 0;
            _iPtrPrev = null;
            _iPtrNext = null;
            _isSelfDelete = false;
            _frame = 0;
            _lifeTime = 0;
            _isStart = false;
			_onFinished = null;
            _onStart = null;
            Parent = null;

            _startTime = 0.0f;
            _endTime = 0.0f;
            _elapsedTime = 0.0f;
        }
		
		// TODO
		public virtual void Update(float deltaTime, float currentSequenceTime, int step) { }
		
		protected virtual void FinishTask()
		{
			OnFinishTask();
			_isSelfDelete = true;
			_onFinished?.Invoke();
		}
		
		public Task SetOnStart(Action onStart)
		{
			_onStart = onStart;
			return this;
		}
		
		public Task SetOnFinished(Action onFinished)
		{
			_onFinished = onFinished;
			return this;
		}
		
		public Task SetStartTime(float startTime)
		{
			_startTime = startTime;
			return this;
		}
		
		public Task SetEndTime(float endTime)
		{
			_endTime = endTime;
			_duration = endTime - _startTime;
			return this;
		}
		
		public Task SetDuration(float duration)
		{
			_duration = duration;
			return this;
		}
		
		public Task SetAdvanceMode(AdvanceMode mode)
		{
			_advanceMode = mode;
			return this;
		}
		
		protected virtual void OnUpdate(int frame, float raito)
		{
			// Empty
		}
		
		protected virtual void OnFinishTask()
        {
            // Empty
        }

        public enum AdvanceMode : int
		{
			Step = 0,
			Time = 1,
		}
	}
}