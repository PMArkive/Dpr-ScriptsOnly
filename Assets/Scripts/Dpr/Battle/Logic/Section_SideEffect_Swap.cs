namespace Dpr.Battle.Logic
{
	public sealed class Section_SideEffect_Swap : Section
	{
		public Section_SideEffect_Swap(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result result, in Description description) { }

		public delegate bool SidefEffectSwapCheck(BtlSideEffect effect);

		public class Description
		{
			public BtlSide side1;
			public BtlSide side2;
			public SidefEffectSwapCheck checkFunc;
			
			public Description()
			{
				checkFunc = null;
				side1 = BtlSide.BTL_SIDE_NUM;
				side2 = BtlSide.BTL_SIDE_NUM;
			}
		}

		public class Result
		{
			public bool isChanged;
		}
	}
}