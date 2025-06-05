namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_FieldEffect_Remove : Section
	{
		public Section_FromEvent_FieldEffect_Remove(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }
		
		// TODO
		private bool removeFieldEffect(EffectType effect, BTL_POKEPARAM pDependPoke) { return default; }

		public class Description
		{
			public EffectType effect;
			public BTL_POKEPARAM pDependPoke;
			
			public Description()
			{
				pDependPoke = null;
				effect = EffectType.EFF_NULL;
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}
	}
}