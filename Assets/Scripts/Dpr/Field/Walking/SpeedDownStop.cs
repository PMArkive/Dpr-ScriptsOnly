using SmartPoint.AssetAssistant;
using System.Collections;
using UnityEngine;

namespace Dpr.Field.Walking
{
	public class SpeedDownStop : ActionModel
	{
		public override IEnumerator DoAction(AIModel model)
		{
			var moveVec = model.walkData.prevMoveVec;
			var t = 0.0f;

			yield return model.Loop(() => t < 1.0f, () =>
			{
				model.walkData.entity.moveVector = Vector3.Lerp(moveVec, Vector3.zero, t);
				t += Sequencer.elapsedTime;
			});
		}
	}
}