namespace Dpr.Battle.Logic
{
	public sealed class Section_FieldEffect_Add : Section
	{
		private static readonly getDefaultSuccessMessage_GroundTableElem[] STR_TABLE = new getDefaultSuccessMessage_GroundTableElem[]
		{
			new getDefaultSuccessMessage_GroundTableElem(BtlGround.BTL_GROUND_GRASS,  BTL_STRID_STD.GrassGround_Start, BTL_STRID_STD.GrassGround_OnBattleStart),
			new getDefaultSuccessMessage_GroundTableElem(BtlGround.BTL_GROUND_MIST,   BTL_STRID_STD.MistGround_Start,  BTL_STRID_STD.MistGround_OnBattleStart),
			new getDefaultSuccessMessage_GroundTableElem(BtlGround.BTL_GROUND_ELEKI,  BTL_STRID_STD.ElecField_Start,   BTL_STRID_STD.ElecField_OnBattleStart),
			new getDefaultSuccessMessage_GroundTableElem(BtlGround.BTL_GROUND_PHYCHO, BTL_STRID_STD.PhychoField_Start, BTL_STRID_STD.PhychoField_OnBattleStart),
		};
		
		public Section_FieldEffect_Add(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result result, in Description description) { }
		
		// TODO
		public bool changeGround(byte pokeID, byte ground, in BTL_SICKCONT contParam, ChangeGroundCause cause) { return default; }
		
		// TODO
		public void getDefaultSuccessMessage_Ground(StrParam pStrParam, byte ground, ChangeGroundCause cause) { }
		
		// TODO
		private bool addFieldEffect(EffectType effect, in BTL_SICKCONT contParam, bool isAddDependTry) { return default; }
		
		// TODO
		private void afterFieldEffectAdd(byte pokeID, EffectType effect) { }
		
		// TODO
		private void afterFieldEffectAdd_KagakuhenkaGas(byte pokeID) { }
		
		// TODO
		private bool getFrontPokes(PokeSet targets) { return default; }
		
		// TODO
		private void sortByAgility(PokeSet targets) { }
		
		// TODO
		private void juryokuCheck(byte pokeID) { }

		public class Description
		{
			public byte pokeID;
			public EffectType effect;
			public BtlGround ground;
			public ChangeGroundCause ground_cause;
			public BTL_SICKCONT cont;
			public ushort successEffectNo;
			public StrParam successMessage;
			public bool isAddDependPoke;
			public bool isDisplayTokuseiWindow;
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				effect = EffectType.EFF_NULL;
				ground = BtlGround.BTL_GROUND_NONE;
				ground_cause = ChangeGroundCause.OTHERS;
				cont = default;
				successEffectNo = (ushort)BtlEff.BTLEFF_MAX;
				successMessage = new StrParam();
				isAddDependPoke = false;
				isDisplayTokuseiWindow = false;
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}

		private struct getDefaultSuccessMessage_GroundTableElem
		{
			public BtlGround ground;
			public int strID_others;
			public int strID_onBattleStart;
			
			public getDefaultSuccessMessage_GroundTableElem(BtlGround ground, int strID_others, int strID_onBattleStart)
			{
				this.ground = ground;
				this.strID_others = strID_others;
				this.strID_onBattleStart = strID_onBattleStart;
			}
		}
	}
}