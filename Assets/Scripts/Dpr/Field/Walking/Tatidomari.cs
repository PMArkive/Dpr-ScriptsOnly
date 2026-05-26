using System.Collections;

namespace Dpr.Field.Walking
{
	public class Tatidomari : ActionModel
	{
		public override IEnumerator DoAction(AIModel model)
		{
			yield return model.walkData.actionModel.corSystem.AddSub()
				.Play(new SpeedDownStop().DoAction(model));

			yield return new MyWaitForSeconds(3.0f);

			model.AI.ChangeState(typeof(ReturnState));
		}
	}
}