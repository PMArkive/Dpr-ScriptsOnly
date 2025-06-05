using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_Cheer : Section
	{
		private static readonly decideRankUpEffectTableElem[] decideRankUpEffectTable = new decideRankUpEffectTableElem[]
		{
			new decideRankUpEffectTableElem(WazaRankEffect.ATTACK,         2),
			new decideRankUpEffectTableElem(WazaRankEffect.DEFENCE,        2),
			new decideRankUpEffectTableElem(WazaRankEffect.SP_ATTACK,      2),
			new decideRankUpEffectTableElem(WazaRankEffect.SP_DEFENCE,     2),
			new decideRankUpEffectTableElem(WazaRankEffect.AGILITY,        2),
			new decideRankUpEffectTableElem(WazaRankEffect.AVOID,          1),
			new decideRankUpEffectTableElem(WazaRankEffect.CRITICAL_RATIO, 1),
		};
		
		public Section_Cheer(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description desc) { }
		
		// TODO
		private CheerEffect decideCheerEffect() { return default; }
		
		// TODO
		private void getSelectableCheerEffects(CheerEffect[] pEffectArray, out byte pEffectCount)
		{
			pEffectCount = default;
		}
		
		// TODO
		private bool canSelectCheerEffect(CheerEffect effect) { return default; }
		
		// TODO
		private void applyCheerEffect(BTL_CLIENT_ID cheerClientID, uint actionSerialNo, CheerEffect effect) { }
		
		// TODO
		private bool cheerEffect_RecoverHP(BTL_CLIENT_ID cheerClientID) { return default; }
		
		// TODO
		private bool cheerEffect_CureSick(BTL_CLIENT_ID cheerClientID) { return default; }
		
		// TODO
		private bool cheerEffect_RankUp(BTL_CLIENT_ID cheerClientID, uint actionSerialNo) { return default; }
		
		// TODO
		private void decideRankUpEffect(out WazaRankEffect effect, out byte volume)
		{
			effect = default;
			volume = default;
		}
		
		// TODO
		private bool applyRankUpEffect(BTL_POKEPARAM target, WazaRankEffect effect, byte volume, uint actionSerialNo) { return default; }
		
		// TODO
		private bool cheerEffect_Reflector(BTL_CLIENT_ID cheerClientID) { return default; }
		
		// TODO
		private bool cheerEffect_Hikarinokabe(BTL_CLIENT_ID cheerClientID) { return default; }
		
		// TODO
		private bool cheerEffect_BreakGWall() { return default; }
		
		// TODO
		private bool isCheerTarget(BTL_POKEPARAM poke, BTL_CLIENT_ID cheerClientID) { return default; }

		public class Description
		{
			public BTL_CLIENT_ID cheerClientID;
			public uint actionSerialNo;
			
			public Description()
			{
				cheerClientID = BTL_CLIENT_ID.BTL_CLIENT_NULL;
				actionSerialNo = 0;
			}
		}

		public class Result { }

		private struct decideRankUpEffectTableElem
		{
			public WazaRankEffect effect;
			public byte volume;
			
			public decideRankUpEffectTableElem(WazaRankEffect effect, byte volume)
			{
				this.effect = effect;
				this.volume = volume;
			}
		}
	}
}