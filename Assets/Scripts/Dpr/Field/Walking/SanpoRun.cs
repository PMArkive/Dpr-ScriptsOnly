using System.Collections;
using UnityEngine;

namespace Dpr.Field.Walking
{
	public class SanpoRun : ActionModel
	{
		public SanpoRun()
        {
            // Empty, declared explicitly
        }

        // TODO
        public override IEnumerator DoAction(AIModel m) { return default; }
		
		private float GetNormalizeTime(float elapsedTime, float duration)
		{
			if (duration == 0.0f)
				return 1.0f;
			else
				return Mathf.Clamp(elapsedTime / duration, 0.0f, 1.0f);
		}
	}
}