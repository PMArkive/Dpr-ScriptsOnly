using System.Collections;
using UnityEngine;

namespace Dpr.Field.Walking
{
	public class KyoroKyoro : ActionModel
	{
		public override IEnumerator DoAction(AIModel model)
		{
			// 0
			var corSys = model.walkData.actionModel.corSystem;

			yield return corSys.AddSub().Play(new SpeedDownStop().DoAction(model));

			// 1
			float speed = Random.Range(3, 5);
			float angle = model.transform.eulerAngles.y;
			int Num = Random.Range(1, 5);

			while (Num >= 1 && !model.charaModel.isDestroyed)
			{
                Num--;
                angle += Random.Range(0, 30);
                var add = Random.Range(30, 60);

                // Result ignored
                _ = model.walkData;

                var radAngle = (angle + add) * Mathf.Deg2Rad;

                var left = new LookAtPosition(new Vector3(Mathf.Sin(radAngle), 0.0f, Mathf.Cos(radAngle)), speed, Random.Range(0.5f, 0.8f))
                    .DoAction(model);

                // Result ignored
                _ = model.walkData;

                var right = new LookAtPosition(new Vector3(Mathf.Sin(radAngle), 0.0f, Mathf.Cos(radAngle)), speed, Random.Range(0.5f, 0.8f))
                    .DoAction(model);

                yield return corSys.AddSub().Play(left);

                // 2
                yield return new MyWaitForSeconds(Random.Range(0.6f, 1.2f));

                // 3
                yield return corSys.AddSub().Play(right);

                // 4
                yield return new MyWaitForSeconds(0.5f);

                // 5
                right = null;
            }

            yield return new MyWaitForSeconds(0.5f);

            // 6
            model.AI.ChangeState(typeof(ReturnState));
        }
	}
}