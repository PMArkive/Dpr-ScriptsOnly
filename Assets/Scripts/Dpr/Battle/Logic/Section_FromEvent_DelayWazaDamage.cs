using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_DelayWazaDamage : Section
	{
		public Section_FromEvent_DelayWazaDamage(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }
		
		// TODO
		private bool checkWazaInvalid(DmgAffRec pAffinityRecorder, BTL_POKEPARAM pAttacker, WazaParam pWazaParam, ActionDesc actionDesc, PokeSet pTaragets) { return default; }
		
		// TODO
		private void damageWaza(BTL_POKEPARAM attacker, WazaParam wazaParam, DmgAffRec affinityRecorder, PokeSet targets, ActionDesc actionDesc) { }

		public class Description
		{
			public byte attackerPokeID;
			public byte targetPokeID;
			public BtlPokePos attackerPos;
			public WazaNo wazaID;
			
			public Description()
			{
				attackerPokeID = PokeID.INVALID;
				targetPokeID = PokeID.INVALID;
				attackerPos = BtlPokePos.POS_NULL;
				wazaID = WazaNo.NULL;
			}
		}

		public class Result
		{
			public bool isSucceeded;
		}
	}
}