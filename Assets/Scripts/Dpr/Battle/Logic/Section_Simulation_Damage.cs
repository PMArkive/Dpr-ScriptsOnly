using Pml;
using Pml.Battle;

namespace Dpr.Battle.Logic
{
	public sealed class Section_Simulation_Damage : Section
	{
		public Section_Simulation_Damage(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }
		
		// TODO
		private TypeAffinity.AffinityID checkTypeAffinity(byte attackerID, byte defenderID, WazaNo waza) { return default; }
		
		// TODO
		private BtlWeather getLoaclWeather(byte pokeID) { return default; }

		public class Description
		{
			public byte atkPokeID;
			public byte defPokeID;
			public WazaNo waza;
			public bool isAffinityEnable;
			public bool isRandomEnable;
			
			public Description()
			{
				atkPokeID = PokeID.INVALID;
				defPokeID = PokeID.INVALID;
				waza = WazaNo.NULL;
				isAffinityEnable = false;
				isRandomEnable = false;
			}
		}

		public class Result
		{
			public ushort damage;
		}
	}
}