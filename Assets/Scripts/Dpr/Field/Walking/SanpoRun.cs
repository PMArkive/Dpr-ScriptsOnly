using SmartPoint.AssetAssistant;
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

        public override IEnumerator DoAction(AIModel m)
		{
			var model = m as AIFureaiModel;
			var elapsedTime = 0.0f;
			var RotY = Vector3.up * Random.Range(30, 60);

			if (Random.Range(0, 2) == 0)
				RotY = -RotY;

			var RunTime = Random.Range(0.5f, 1.5f);

			while (elapsedTime < RunTime)
			{
				if (m.charaModel.isDestroyed)
					break;

				var deltaTime = Sequencer.elapsedTime;

				m.walkData.isNeedRun = true;
				model.walkData.Move(deltaTime, 10.0f, 1.8f, 0.0f);

				elapsedTime += deltaTime;

				var angle = model.walkData.GetAngle(model.sanpoModel.InitPos);
				model.transform.eulerAngles += (RotY + (angle * Vector3.up * model.sanpoModel.CollidedRotValue)) * deltaTime;

				yield return new WaitForEndOfFrame();
            }

			yield return null;
		}
		
		private float GetNormalizeTime(float elapsedTime, float duration)
		{
			if (duration == 0.0f)
				return 1.0f;
			else
				return Mathf.Clamp(elapsedTime / duration, 0.0f, 1.0f);
		}
	}
}