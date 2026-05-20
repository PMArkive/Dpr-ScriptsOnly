using System.Collections;

namespace Dpr.Field.Walking
{
	public class SanpoPairDotuki : ActionModel
	{
		public SanpoPairDotuki()
		{
			// Empty, declared explicitly
		}
		
		public override IEnumerator DoAction(AIModel model)
		{
			yield return model.walkData.actionModel.corSystem.AddSub()
				.Play(new SanpoPairActionCommon(FieldPokemonEntity.Animation.Buturi01, FieldPokemonEntity.Animation.Buturi01).DoAction(model));
		}
	}
}