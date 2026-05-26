using SmartPoint.AssetAssistant;
using System.Collections;
using UnityEngine;

namespace Dpr.Field.Walking
{
	public class LookAtPosition : ActionModel
	{
		private Vector3 offset;
		private float speed;
		private float duration;
		
		public LookAtPosition(Vector3 offset, float speed, float duration)
		{
			this.offset = offset;
			this.speed = speed;
			this.duration = duration;
		}
		
		public override IEnumerator DoAction(AIModel model)
		{
			var time = 0.0f;

            yield return model.Loop(() => time < duration, () =>
            {
                var deltaTime = Sequencer.elapsedTime;
                model.walkData.LookAtTarget(model.transform.position + offset, deltaTime, speed);
                time += deltaTime;
            });
        }
	}
}