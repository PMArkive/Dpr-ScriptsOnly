using System.Collections;

namespace Dpr.Field.Walking
{
	public class SanpoPairHoe : ActionModel
	{
		public SanpoPairHoe()
        {
            // Empty, declared explicitly
        }

        public override IEnumerator DoAction(AIModel model)
        {
            yield return model.walkData.actionModel.corSystem.AddSub()
                .Play(new SanpoPairActionCommon(FieldPokemonEntity.Animation.Roar01, FieldPokemonEntity.Animation.Roar01).DoAction(model));
        }
	}
}