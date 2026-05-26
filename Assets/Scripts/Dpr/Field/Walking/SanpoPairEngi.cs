using System.Collections;

namespace Dpr.Field.Walking
{
	public class SanpoPairEngi : ActionModel
	{
		public SanpoPairEngi()
		{
			// Empty, declared explicitly
		}
		
		public override IEnumerator DoAction(AIModel model)
		{
			var fureaiModel = model as AIFureaiModel;
			var masterAnim = fureaiModel.sanpoModel.PairModel.masterPoke.GetAnimRandom();
			var slaveAnim = fureaiModel.sanpoModel.PairModel.slavePoke.GetAnimRandom();
			
			yield return model.corSys.AddSub()
                .Play(new SanpoPairActionCommon(masterAnim, slaveAnim, true).DoAction(model));
        }
	}
}