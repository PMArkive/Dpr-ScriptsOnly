using Pml.WazaData;
using SmartPoint.AssetAssistant.UnityExtensions;

namespace Dpr.Battle.Logic.Handler
{
	public static class Side
	{
        // TODO: cctor

        private const int WORKIDX_SICKCONT_HIGH = 6;
		private const int WORKIDX_SICKCONT_LOW = 5;

		private static readonly GET_FUNC_TABLE_ELEM[] GET_FUNC_TABLE = new GET_FUNC_TABLE_ELEM[]
		{
			new GET_FUNC_TABLE_ELEM(BtlSideEffect.BTL_SIDEEFF_REFLECTOR,          ADD_SIDE_Reflector),
			new GET_FUNC_TABLE_ELEM(BtlSideEffect.BTL_SIDEEFF_HIKARINOKABE,       ADD_SIDE_Hikarinokabe),
			new GET_FUNC_TABLE_ELEM(BtlSideEffect.BTL_SIDEEFF_SINPINOMAMORI,      ADD_SIDE_Sinpinomamori),
			new GET_FUNC_TABLE_ELEM(BtlSideEffect.BTL_SIDEEFF_SIROIKIRI,          ADD_SIDE_SiroiKiri),
			new GET_FUNC_TABLE_ELEM(BtlSideEffect.BTL_SIDEEFF_OIKAZE,             ADD_SIDE_Oikaze),
			new GET_FUNC_TABLE_ELEM(BtlSideEffect.BTL_SIDEEFF_OMAJINAI,           ADD_SIDE_Omajinai),
			new GET_FUNC_TABLE_ELEM(BtlSideEffect.BTL_SIDEEFF_MAKIBISI,           ADD_SIDE_Makibisi),
			new GET_FUNC_TABLE_ELEM(BtlSideEffect.BTL_SIDEEFF_DOKUBISI,           ADD_SIDE_Dokubisi),
			new GET_FUNC_TABLE_ELEM(BtlSideEffect.BTL_SIDEEFF_STEALTHROCK,        ADD_SIDE_StealthRock),
			new GET_FUNC_TABLE_ELEM(BtlSideEffect.BTL_SIDEEFF_STEALTHROCK_HAGANE, ADD_SIDE_StealthRock_Hagane),
			new GET_FUNC_TABLE_ELEM(BtlSideEffect.BTL_SIDEEFF_WIDEGUARD,          ADD_SIDE_WideGuard),
			new GET_FUNC_TABLE_ELEM(BtlSideEffect.BTL_SIDEEFF_FASTGUARD,          ADD_SIDE_FastGuard),
			new GET_FUNC_TABLE_ELEM(BtlSideEffect.BTL_SIDEEFF_RAINBOW,            ADD_SIDE_Rainbow),
			new GET_FUNC_TABLE_ELEM(BtlSideEffect.BTL_SIDEEFF_BURNING,            ADD_SIDE_Burning),
			new GET_FUNC_TABLE_ELEM(BtlSideEffect.BTL_SIDEEFF_MOOR,               ADD_SIDE_Moor),
			new GET_FUNC_TABLE_ELEM(BtlSideEffect.BTL_SIDEEFF_NEBANEBANET,        ADD_SIDE_NebaNebaNet),
			new GET_FUNC_TABLE_ELEM(BtlSideEffect.BTL_SIDEEFF_TATAMIGAESHI,       ADD_SIDE_TatamiGaeshi),
			new GET_FUNC_TABLE_ELEM(BtlSideEffect.BTL_SIDEEFF_TRICKGUARD,         ADD_SIDE_TrickGuard),
			new GET_FUNC_TABLE_ELEM(BtlSideEffect.BTL_SIDEEFF_AURORAVEIL,         ADD_SIDE_AuroraVeil),
			new GET_FUNC_TABLE_ELEM(BtlSideEffect.BTL_SIDEEFF_SPOTLIGHT,          ADD_SIDE_SpotLight),
			new GET_FUNC_TABLE_ELEM(BtlSideEffect.BTL_SIDEEFF_GSHOCK_HONOO,       ADD_SIDE_GShock_Honoo),
			new GET_FUNC_TABLE_ELEM(BtlSideEffect.BTL_SIDEEFF_GSHOCK_IWA,         ADD_SIDE_GShock_Iwa),
		};

		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Reflector = new EventFactor.EventHandlerTable[]
        {
			new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_side_Reflector),
		};
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Hikarinokabe = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_side_HikariNoKabe),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_AuroraVeil = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_side_AuroraVeil),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Sinpinomamori = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ADDSICK_CHECKFAIL, handler_side_SinpiNoMamori_CheckFail),
            new EventFactor.EventHandlerTable(EventID.ADDSICK_FAILED,    handler_side_SinpiNoMamori_FixFail),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SiroiKiri = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.RANKEFF_LAST_CHECK, handler_side_SiroiKiri_CheckFail),
            new EventFactor.EventHandlerTable(EventID.RANKEFF_FAILED,     handler_side_SiroiKiri_FixFail),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Oikaze = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CALC_AGILITY, handler_side_Oikaze),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Omajinai = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CRITICAL_CHECK, handler_side_Omajinai),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_StealthRock = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_side_StealthRock),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_StealthRock_Hagane = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_side_StealthRock_Hagane),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_WideGuard = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_SIDEEFF_GUARD, handler_side_WideGuard),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_FastGuard = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_SIDEEFF_GUARD, handler_side_FastGuard),
            new EventFactor.EventHandlerTable(EventID.FREEFALL_START_GUARD,         handler_side_FastGuard),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC_G,              handler_side_FastGuard_Dmg),
            new EventFactor.EventHandlerTable(EventID.AFTER_CRITICAL,               handler_side_FastGuard_MsgAfterCritical),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_TatamiGaeshi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_MAMORU, handler_side_TatamiGaeshi),
            new EventFactor.EventHandlerTable(EventID.FREEFALL_START_GUARD,  handler_side_TatamiGaeshi),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC_G,       handler_side_TatamiGaeshi_DmgG),
            new EventFactor.EventHandlerTable(EventID.AFTER_CRITICAL,        handler_side_Tatamigaeshi_MsgAfterCritical),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_TrickGuard = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_SIDEEFF_GUARD, handler_side_TrickGuard),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Makibisi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_side_Makibisi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Dokubisi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_side_Dokubisi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_NebaNebaNet = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_side_NebaNebaNet),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SpotLight = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.TEMPT_TARGET, handler_SpotLight_TemptTarget),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Rainbow = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ADD_SICK,        handler_Rainbow),
            new EventFactor.EventHandlerTable(EventID.ADD_RANK_TARGET, handler_Rainbow),
            new EventFactor.EventHandlerTable(EventID.WAZA_SHRINK_PER, handler_Rainbow_Shrink),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Burning = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_BEGIN, handler_side_Burning),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Moor = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CALC_AGILITY, handler_side_Moor),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_GShock_Honoo = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_BEGIN, handler_side_GShock_Honoo),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_GShock_Iwa = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_BEGIN, handler_side_GShock_Iwa),
        };

        // TODO
        public static EventFactor GetEventFactor(EventSystem pEventSystem, BtlSide side, BtlSideEffect sideEffect) { return default; }
		
		// TODO
		public static HandlerGetFunc getHandlerGetFunc(BtlSideEffect sideEffect) { return default; }
		
		// TODO
		public static void Add(EventSystem pEventSystem, BtlSide side, BtlSideEffect sideEffect, in BTL_SICKCONT contParam) { }
		
		// TODO
		public static bool Remove(EventSystem pEventSystem, BtlSide side, BtlSideEffect sideEffect) { return default; }
		
		// TODO
		public static bool Sleep(EventSystem pEventSystem, BtlSide side, BtlSideEffect sideEffect) { return default; }
		
		// TODO
		public static bool Weak(EventSystem pEventSystem, BtlSide side, BtlSideEffect sideEffect) { return default; }
		
		// TODO
		public static bool IsExist(EventSystem pEventSystem, BtlSide side, BtlSideEffect effect) { return default; }
		
		// TODO
		public static void GetSickCont(in EventFactor.EventHandlerArgs args, out BTL_SICKCONT sickcont)
		{
			sickcont = default;
		}
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SIDE_Reflector() { return default; }
		
		// TODO
		public static void handler_side_Reflector(in EventFactor.EventHandlerArgs args, byte mySide) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SIDE_Hikarinokabe() { return default; }
		
		// TODO
		public static void handler_side_HikariNoKabe(in EventFactor.EventHandlerArgs args, byte mySide) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SIDE_AuroraVeil() { return default; }
		
		// TODO
		public static void handler_side_AuroraVeil(in EventFactor.EventHandlerArgs args, byte mySide) { }
		
		// TODO
		public static void common_wallEffect(in EventFactor.EventHandlerArgs args, byte mySide, WazaDamageType dmgType) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SIDE_Sinpinomamori() { return default; }
		
		// TODO
		public static void handler_side_SinpiNoMamori_CheckFail(in EventFactor.EventHandlerArgs args, byte mySide) { }
		
		// TODO
		public static void handler_side_SinpiNoMamori_FixFail(in EventFactor.EventHandlerArgs args, byte mySide) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SIDE_SiroiKiri() { return default; }
		
		// TODO
		public static void handler_side_SiroiKiri_CheckFail(in EventFactor.EventHandlerArgs args, byte mySide) { }
		
		// TODO
		public static void handler_side_SiroiKiri_FixFail(in EventFactor.EventHandlerArgs args, byte mySide) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SIDE_Oikaze() { return default; }
		
		// TODO
		public static void handler_side_Oikaze(in EventFactor.EventHandlerArgs args, byte mySide) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SIDE_Omajinai() { return default; }
		
		// TODO
		public static void handler_side_Omajinai(in EventFactor.EventHandlerArgs args, byte mySide) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SIDE_StealthRock() { return default; }
		
		// TODO
		public static void handler_side_StealthRock(in EventFactor.EventHandlerArgs args, byte mySide) { }
		
		// TODO
		public static ushort stealthRock_CalcDamage(BTL_POKEPARAM target, byte damageType) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SIDE_StealthRock_Hagane() { return default; }
		
		// TODO
		public static void handler_side_StealthRock_Hagane(in EventFactor.EventHandlerArgs args, byte mySide) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SIDE_WideGuard() { return default; }
		
		// TODO
		public static void handler_side_WideGuard(in EventFactor.EventHandlerArgs args, byte mySide) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SIDE_FastGuard() { return default; }
		
		// TODO
		public static void handler_side_FastGuard(in EventFactor.EventHandlerArgs args, byte mySide) { }
		
		// TODO
		public static void handler_side_FastGuard_Dmg(in EventFactor.EventHandlerArgs args, byte mySide) { }
		
		// TODO
		public static void handler_side_FastGuard_MsgAfterCritical(in EventFactor.EventHandlerArgs args, byte mySide) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SIDE_TatamiGaeshi() { return default; }
		
		// TODO
		public static void handler_side_TatamiGaeshi(in EventFactor.EventHandlerArgs args, byte mySide) { }
		
		// TODO
		public static void handler_side_TatamiGaeshi_DmgG(in EventFactor.EventHandlerArgs args, byte mySide) { }
		
		// TODO
		public static void handler_side_Tatamigaeshi_MsgAfterCritical(in EventFactor.EventHandlerArgs args, byte mySide) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SIDE_TrickGuard() { return default; }
		
		// TODO
		public static void handler_side_TrickGuard(in EventFactor.EventHandlerArgs args, byte mySide) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SIDE_Makibisi() { return default; }
		
		// TODO
		public static void handler_side_Makibisi(in EventFactor.EventHandlerArgs args, byte mySide) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SIDE_Dokubisi() { return default; }
		
		// TODO
		public static void handler_side_Dokubisi(in EventFactor.EventHandlerArgs args, byte mySide) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SIDE_NebaNebaNet() { return default; }
		
		// TODO
		public static void handler_side_NebaNebaNet(in EventFactor.EventHandlerArgs args, byte mySide) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SIDE_SpotLight() { return default; }
		
		// TODO
		public static void handler_SpotLight_TemptTarget(in EventFactor.EventHandlerArgs args, byte mySide) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SIDE_Rainbow() { return default; }
		
		// TODO
		public static void handler_Rainbow(in EventFactor.EventHandlerArgs args, byte mySide) { }
		
		// TODO
		public static void handler_Rainbow_Shrink(in EventFactor.EventHandlerArgs args, byte mySide) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SIDE_Burning() { return default; }
		
		// TODO
		public static void handler_side_Burning(in EventFactor.EventHandlerArgs args, byte mySide) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SIDE_Moor() { return default; }
		
		// TODO
		public static void handler_side_Moor(in EventFactor.EventHandlerArgs args, byte mySide) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SIDE_GShock_Honoo() { return default; }
		
		// TODO
		public static void handler_side_GShock_Honoo(in EventFactor.EventHandlerArgs args, byte mySide) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SIDE_GShock_Iwa() { return default; }
		
		// TODO
		public static void handler_side_GShock_Iwa(in EventFactor.EventHandlerArgs args, byte mySide) { }

		public delegate EventFactor.EventHandlerTable[] HandlerGetFunc();

		private struct GET_FUNC_TABLE_ELEM
		{
			public BtlSideEffect eff;
			public HandlerGetFunc func;
			
			public GET_FUNC_TABLE_ELEM(BtlSideEffect eff, HandlerGetFunc func)
			{
				this.eff = eff;
				this.func = func;
			}
		}
	}
}