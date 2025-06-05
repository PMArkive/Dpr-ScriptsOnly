namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_AddViewEffect : Section
	{
		public Section_FromEvent_AddViewEffect(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result result, in Description description) { }
		
		// TODO
		private void addVewEffect(ushort effectNo, BtlPokePos effectPos_from, BtlPokePos effectPos_to, bool isQueueReserved, uint reservedQueuePos) { }

		public class Description
		{
			public ushort effectNo;
			public BtlPokePos pos_from;
			public BtlPokePos pos_to;
			public ushort reservedQueuePos;
			public bool isQueueReserved;
			public bool isMessageWindowVanish;
			public StrParam afterMessage = new StrParam();
			
			public Description()
			{
				effectNo = 0;
				pos_from = BtlPokePos.POS_NULL;
				pos_to = BtlPokePos.POS_NULL;
				reservedQueuePos = 0;
				isQueueReserved = false;
				isMessageWindowVanish = false;
			}
		}

		public class Result { }
	}
}