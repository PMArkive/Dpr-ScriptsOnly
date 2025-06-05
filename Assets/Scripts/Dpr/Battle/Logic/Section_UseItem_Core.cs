using Pml;
using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_UseItem_Core : Section
	{
		private const int RANGE_FULL = 0;
		private const int RANGE_VIEW = 1;
		private const int RANGE_FRONT = 2;

		private const int AREA_FRONT = 0;
		private const int AREA_BACK = 1;
		private const int AREA_RESERVE = 2;

		private ItemEffectInfo[] s_itemEffectTableInstance;
		
		// TODO
		private ItemEffectInfo[] s_itemEffectTable { get; }
		
		public Section_UseItem_Core(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private bool canUseEscapeItem() { return default; }
		
		// TODO
		private BTL_POKEPARAM getTaragetInfo(out byte pTargetArea, out BtlPokePos pTargetPos, byte targetPokeID)
		{
			pTargetArea = default;
			pTargetPos = default;
			return default;
		}
		
		// TODO
		private void useBall(BTL_POKEPARAM userPoke, ushort itemID, out bool pIsUsed, out bool pIsCaptured, POKE_CAPTURED_CONTEXT pCaptureContext)
		{
			pIsUsed = default;
			pIsCaptured = default;
		}
		
		// TODO
		private BTL_POKEPARAM decideBallTarget(out BtlPokePos pTargetPos, BTL_POKEPARAM userPoke)
		{
			pTargetPos = default;
			return default;
		}
		
		// TODO
		private int decideCaptureValueCoef(BTL_POKEPARAM pUserPoke, BTL_POKEPARAM pTargetPoke) { return default; }
		
		// TODO
		private void useBallForbidden(ushort itemID, BtlPokePos targetPos, BallThrowForbiddenCause cause) { }
		
		// TODO
		private bool canUseItem(ushort itemID, byte targetArea, BtlPokePos targetPos) { return default; }
		
		// TODO
		private bool ItemEff_SleepRcv(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam) { return default; }
		
		// TODO
		private bool ItemEff_PoisonRcv(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam) { return default; }
		
		// TODO
		private bool ItemEff_YakedoRcv(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam) { return default; }
		
		// TODO
		private bool ItemEff_KooriRcv(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam) { return default; }
		
		// TODO
		private bool ItemEff_MahiRcv(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam) { return default; }
		
		// TODO
		private bool ItemEff_KonranRcv(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam) { return default; }
		
		// TODO
		private bool ItemEff_MeromeroRcv(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam) { return default; }
		
		// TODO
		private bool ItemEff_Mental_Cure(BTL_POKEPARAM bpp, ushort itemID, int itemParam, WazaSick sickID) { return default; }
		
		// TODO
		private bool ItemEff_Common_Cure(BTL_POKEPARAM bpp, ushort itemID, int itemParam, WazaSick sickID) { return default; }
		
		// TODO
		private void makeCmd_CureSick(BTL_POKEPARAM bpp, WazaSick sickID, bool bStdMsg) { }
		
		// TODO
		private bool ItemEff_EffectGuard(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam) { return default; }
		
		// TODO
		private bool ItemEff_Relive(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam) { return default; }
		
		// TODO
		private bool ItemEff_AttackRank(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam) { return default; }
		
		// TODO
		private bool ItemEff_DefenceRank(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam) { return default; }
		
		// TODO
		private bool ItemEff_SPAttackRank(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam) { return default; }
		
		// TODO
		private bool ItemEff_SPDefenceRank(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam) { return default; }
		
		// TODO
		private bool ItemEff_AgilityRank(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam) { return default; }
		
		// TODO
		private bool ItemEff_HitRank(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam) { return default; }
		
		// TODO
		private bool ItemEff_Common_Rank(BTL_POKEPARAM bpp, ushort itemID, int itemParam, BTL_POKEPARAM.ValueID rankType) { return default; }
		
		// TODO
		private void makeCmd_RankEffect(BTL_POKEPARAM bpp, WazaRankEffect rankType, int volume) { }
		
		// TODO
		private bool ItemEff_CriticalUp(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam) { return default; }
		
		// TODO
		private bool ItemEff_PP_Rcv(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam) { return default; }
		
		// TODO
		private bool ItemEff_AllPP_Rcv(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam) { return default; }
		
		// TODO
		private bool makeCmd_RecoverAllPP(BTL_POKEPARAM bpp, byte recoverLimit, bool bStdMsg) { return default; }
		
		// TODO
		private bool ItemEff_HP_Rcv(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam) { return default; }
		
		// TODO
		private void makeCmd_RecoverHP(BTL_POKEPARAM bpp, uint recoverHP, bool bStdMsg) { }

		public class Description
		{
			public BTL_POKEPARAM poke;
			public ushort itemID;
			public byte actParam;
			public byte targetID;
			public POKE_CAPTURED_CONTEXT capContext;
			
			public Description()
			{
				poke = null;
				capContext = null;
				itemID = (ushort)ItemNo.DUMMY_DATA;
				actParam = 0;
				targetID = PokeID.INVALID;
			}
		}

		public class Result
		{
			public TrainerItemResult useResult;
			public bool isConsumed;
			public bool isUsedBall;
		}

		private delegate bool ItemEffectFuncPtr(BTL_POKEPARAM target, ushort itemID, int itemParam, byte actParam);

		private class ItemEffectInfo
		{
			public Pml.Item.ItemData.PrmID effect;
			public byte range;
			public ItemEffectFuncPtr func;
			
			public ItemEffectInfo(Pml.Item.ItemData.PrmID effect, byte range, ItemEffectFuncPtr func)
			{
				this.func = func;
				this.effect = effect;
				this.range = range;
			}
		}
	}
}