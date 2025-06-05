using Pml;
using Pml.Battle;

namespace Dpr.Battle.Logic
{
	public sealed class Section_Simulation_TypeAffinity : Section
	{
		public Section_Simulation_TypeAffinity(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }
		
		// TODO
		private TypeAffinity.AffinityID checkTypeAffinity(BTL_POKEPARAM attacker, BTL_POKEPARAM defender, WazaParam wazaParam, bool checkOnlyAttacker) { return default; }

		public class Description
		{
			public byte atkPokeID;
			public byte defPokeID;
			public WazaNo waza;
			public bool onlyAttacker;
			
			public Description()
			{
				atkPokeID = PokeID.INVALID;
				defPokeID = PokeID.INVALID;
				waza = WazaNo.NULL;
				onlyAttacker = false;
			}
		}

		public class Result
		{
			public TypeAffinity.AffinityID affinity;
		}
	}
}