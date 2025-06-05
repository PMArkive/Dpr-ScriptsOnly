using System;
using UnityEngine;

namespace Dpr.Battle
{
	public class WaitForFunc : CustomYieldInstruction
	{
		private Func<bool> _onComplete;
		
		public override bool keepWaiting { get => _onComplete.Invoke(); }
		
		public WaitForFunc(Func<bool> onComplete)
		{
			_onComplete = onComplete;
		}
	}
}