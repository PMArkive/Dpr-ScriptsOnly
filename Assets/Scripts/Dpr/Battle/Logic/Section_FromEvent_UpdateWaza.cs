using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_UpdateWaza : Section
	{
		public Section_FromEvent_UpdateWaza(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }

		public class Description
		{
			public byte pokeID;
			public byte wazaIdx;
			public WazaNo waza;
			public byte ppMax;
			public bool isPermanent;
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				wazaIdx = 0;
				waza = WazaNo.NULL;
				ppMax = 0;
				isPermanent = false;
			}
		}

		public class Result { }
	}
}