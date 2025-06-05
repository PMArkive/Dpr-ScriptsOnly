using System;
using System.Runtime.InteropServices;

namespace Dpr.Battle.View
{
	public abstract class BattleViewPlayable<T> : BtlvEntityBehaviour
	{
		protected StateType _stateType;
		protected Action _onComplete;
		
		public virtual bool IsPlaying { get; }

		public abstract void Play([Optional] Action onComplete);

		public abstract void Stop();

		protected enum StateType : int
		{
			None = 0,
			Play = 1,
			Stop = 2,
			Finish = 3,
		}
	}
}