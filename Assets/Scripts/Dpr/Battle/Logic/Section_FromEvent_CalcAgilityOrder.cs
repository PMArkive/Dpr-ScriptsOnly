namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_CalcAgilityOrder : Section
	{
		public Section_FromEvent_CalcAgilityOrder(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }
		
		// TODO
		private ushort calcAgility(BTL_POKEPARAM poke, bool isTrickRoomApply) { return default; }

		public class Description
		{
			public BTL_POKEPARAM target;
			public bool isTrickRoomApply;
			
			public Description()
			{
				target = null;
				isTrickRoomApply = false;
			}
		}

		public class Result
		{
			public byte order;
		}
	}
}