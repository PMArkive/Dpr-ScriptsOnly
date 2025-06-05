using Pml;
using Pml.Battle;

namespace Dpr.Battle.Logic
{
	public sealed class Section_CalcDamage : Section
	{
		public Section_CalcDamage(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private bool checkCritical(BTL_POKEPARAM attacker, BTL_POKEPARAM defender, WazaNo waza, ref bool bFriendshipAct) { return default; }
		
		// TODO
		public bool getCalcDamage(BTL_POKEPARAM attacker, BTL_POKEPARAM defender, WazaParam wazaParam, TypeAffinity.AffinityID typeAff, int targetDmgRatio, bool isCritical, bool isMigawariExist, out ushort damage)
		{
			damage = default;
			return default;
		}
		
		// TODO
		private uint roundDamage(BTL_POKEPARAM defender, uint damage) { return default; }
		
		// TODO
		private uint roundDamage_byMigawari(BTL_POKEPARAM defender, uint damage) { return default; }

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public PokeSet targets;
			public WazaParam wazaParam;
			public DmgAffRec affRec;
			public int damageRatio;
			public AffCounter affCounter;
		}

		public class Result
		{
			public DamageCalcResult calcResult = new DamageCalcResult();
		}
	}
}