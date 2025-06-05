namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_Damage : Section
	{
		public Section_FromEvent_Damage(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }
		
		// TODO
		private bool isDamageEnable(BTL_POKEPARAM poke, uint damage, DamageCause damageCause) { return default; }
		
		// TODO
		private void viewEffect(ushort effectNo, BtlPokePos effectPos_from, BtlPokePos effectPos_to) { }
		
		// TODO
		private void addDamage(BTL_POKEPARAM poke, uint damage, DamageCause damageCause, byte damageCausePokeID, in StrParam message, bool doDeadProcess) { }

		public enum EffectPlayMode : byte
		{
			DISABLE = 0,
			ENABLE = 1,
			FORCE = 2,
		}

		public class Description
		{
			public byte pokeID;
			public byte targetPokeID;
			public ushort damage;
			public DamageCause damageCause;
			public byte damageCausePokeID;
			public bool canHidePokeAvoid;
			public bool disableDeadProcess;
			public bool isDisplayTokuseiWindow;
			public EffectPlayMode exEffectPlayMode;
			public ushort exEffectNo;
			public BtlPokePos exEffectPos_from;
			public BtlPokePos exEffectPos_to;
			public StrParam successMessage = new StrParam();
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				targetPokeID = PokeID.INVALID;
				damage = 0;
				damageCause = DamageCause.OTHER;
				damageCausePokeID = PokeID.INVALID;
				canHidePokeAvoid = false;
				disableDeadProcess = false;
				isDisplayTokuseiWindow = false;
				exEffectPlayMode = EffectPlayMode.DISABLE;
				exEffectNo = 0;
				exEffectPos_from = BtlPokePos.POS_NULL;
				exEffectPos_to = BtlPokePos.POS_NULL;
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}
	}
}