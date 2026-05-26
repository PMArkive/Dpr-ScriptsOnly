using System.Collections;
using UnityEngine;

namespace Dpr.Field.Walking
{
	public class SanpoWait : ActionModel
	{
		public override IEnumerator DoAction(AIModel m)
		{
			var model = m as AIFureaiModel;

			model.charaModel.walkData.nowSpeed = 0.0f;

			var corSystem = model.sanpoModel.actionModel.corSystem;
            var rot = model.transform.eulerAngles;
            var add = Random.Range(40, 90);
            var duration = Random.Range(1.0f, 3.0f);

            // Result ignored
            _ = model.walkData;

            var radAngle = (rot.y + add) * Mathf.Deg2Rad;

            var sub = new LookAtPosition(new Vector3(Mathf.Sin(radAngle), 0.0f, Mathf.Cos(radAngle)), 5.0f, duration)
                .DoAction(model);

            yield return corSystem.AddSub().Play(sub);

            rot = model.transform.eulerAngles;
            add = Random.Range(40, 90);
            duration = Random.Range(1.0f, 3.0f);

            // Result ignored
            _ = model.walkData;

            radAngle = (rot.y + add) * Mathf.Deg2Rad;

            sub = new LookAtPosition(new Vector3(Mathf.Sin(radAngle), 0.0f, Mathf.Cos(radAngle)), 5.0f, duration)
                .DoAction(model);

            yield return corSystem.AddSub().Play(sub);
        }
    }
}