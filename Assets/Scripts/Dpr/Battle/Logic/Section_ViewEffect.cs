namespace Dpr.Battle.Logic
{
	public sealed class Section_ViewEffect : Section
	{
		private const int EFF_SIMPLE = 0;
		private const int EFF_POS = 1;
		private const int EFF_VECTOR = 2;
		
		public Section_ViewEffect(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }

		public class Description
		{
			public ushort effectNo;
			public BtlPokePos pos_from;
			public BtlPokePos pos_to;
			public bool fQueResereved;
			public uint reservedPos;
		}

		public class Result { }
	}
}