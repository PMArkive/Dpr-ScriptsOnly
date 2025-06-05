using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_InsertWazaAction : Section
	{
		public Section_FromEvent_InsertWazaAction(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }
		
		// TODO
		private uint calcActionPriority(PokeAction pokeAction) { return default; }

		public class Description
		{
			public ActionDesc actionDesc = new ActionDesc();
			public byte actPokeID;
			public WazaNo actWazaNo;
			public BtlPokePos targetPos;
			
			public Description()
			{
				actPokeID = PokeID.INVALID;
				actWazaNo = WazaNo.NULL;
				targetPos = BtlPokePos.POS_NULL;
			}
		}

		public class Result
		{
			public bool isAdded;
		}
	}
}