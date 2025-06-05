using Pml.Battle;

namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaDamageReaction : Section
	{
		public Section_WazaDamageReaction(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description desc) { }

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public BTL_POKEPARAM defender;
			public WazaParam wazaParam;
			public TypeAffinity.AffinityID affinity = TypeAffinity.AffinityID.TYPEAFF_1;
			public uint damage;
			public bool critical_flag;
			public bool fMigawari;
		}

		public class Result { }
	}
}