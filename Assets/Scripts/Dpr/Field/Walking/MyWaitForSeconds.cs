using SmartPoint.AssetAssistant;
using UnityEngine;

namespace Dpr.Field.Walking
{
	public class MyWaitForSeconds : CustomYieldInstruction
	{
		public bool IsCompleted;
		private float elapsedTime;
		private float targetTime;
		
		public override bool keepWaiting
		{
			get
			{
				elapsedTime += Sequencer.elapsedTime;
				IsCompleted = elapsedTime >= targetTime;
				return !IsCompleted;
			}
		}
		
		public MyWaitForSeconds(float targetTime)
		{
			this.targetTime = targetTime;
		}
	}
}