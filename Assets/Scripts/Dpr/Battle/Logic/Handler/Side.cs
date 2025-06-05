using Pml.WazaData;

namespace Dpr.Battle.Logic.Handler
{
	public static class Side
	{
        // TODO: cctor

        private const int WORKIDX_SICKCONT_HIGH = 6;
		private const int WORKIDX_SICKCONT_LOW = 5;

		private static readonly GET_FUNC_TABLE_ELEM[] GET_FUNC_TABLE;

		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Reflector;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Hikarinokabe;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_AuroraVeil;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Sinpinomamori;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_SiroiKiri;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Oikaze;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Omajinai;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_StealthRock;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_StealthRock_Hagane;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_WideGuard;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_FastGuard;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_TatamiGaeshi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_TrickGuard;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Makibisi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Dokubisi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_NebaNebaNet;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_SpotLight;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Rainbow;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Burning;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Moor;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_GShock_Honoo;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_GShock_Iwa;
		
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