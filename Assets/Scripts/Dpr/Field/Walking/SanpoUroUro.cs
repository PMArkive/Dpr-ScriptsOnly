using SmartPoint.AssetAssistant;
using System.Collections;
using UnityEngine;

namespace Dpr.Field.Walking
{
	public class SanpoUroUro : ActionModel
	{
		public SanpoUroUro()
        {
            // Empty, declared explicitly
        }

        public override IEnumerator DoAction(AIModel m)
        {
            var elapsedTime = 0.0f;
            var RotY = Vector3.up * Random.Range(0, 90);

            if (Random.Range(0, 2) == 0)
                RotY = -RotY;

            var duration = Random.Range(2.0f, 3.0f);

            yield return m.Loop(() => elapsedTime < duration, () =>
            {
                var deltaTime = Sequencer.elapsedTime;

                m.walkData.isNeedRun = false;
                m.walkData.Move(deltaTime, 10.0f);

                elapsedTime += deltaTime;

                if (m.GetType() == typeof(AIFureaiModel))
                {
                    var model = m as AIFureaiModel;
                    var angle = model.walkData.GetAngle(model.sanpoModel.InitPos + model.sanpoModel.RandomOffsetPos);

                    m.transform.eulerAngles += (RotY + (angle * Vector3.up * model.sanpoModel.CollidedRotValue)) * deltaTime;
                }
            });
        }
	}
}