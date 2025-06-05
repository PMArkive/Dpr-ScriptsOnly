namespace Dpr.Battle.Logic.Handler
{
	public static class Pos
	{
		private const int WORKIDX_USER_POKEID = 6;

		private static readonly GET_FUNC_TABLE_ELEM[] GET_FUNC_TABLE = new GET_FUNC_TABLE_ELEM[]
		{
			new GET_FUNC_TABLE_ELEM(BtlPosEffect.BTL_POSEFF_NEGAIGOTO,     ADD_Negaigoto),
			new GET_FUNC_TABLE_ELEM(BtlPosEffect.BTL_POSEFF_MIKADUKINOMAI, ADD_MikadukiNoMai),
			new GET_FUNC_TABLE_ELEM(BtlPosEffect.BTL_POSEFF_IYASINONEGAI,  ADD_IyasiNoNegai),
			new GET_FUNC_TABLE_ELEM(BtlPosEffect.BTL_POSEFF_DELAY_ATTACK,  ADD_DelayAttack),
			new GET_FUNC_TABLE_ELEM(BtlPosEffect.BTL_POSEFF_BATONTOUCH,    ADD_BatonTouch),
		};

		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Negaigoto = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.TURNCHECK_BEGIN, handler_pos_Negaigoto),
		};

		private const int WORKIDX_SKIP_SPFAIL_CHECK = 0;
		private const int WORKIDX_FIRST_TURN_FLAG = 1;
		private const int WORKIDX_TURN = 2;

		private static readonly EventFactor.EventHandlerTable[] HandlerTable_MikadukiNoMai = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN,  handler_pos_MikadukiNoMai),
            new EventFactor.EventHandlerTable(EventID.AFTER_MOVE, handler_pos_MikadukiNoMai),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_IyasiNoNegai = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN,  handler_pos_IyasiNoNegai),
            new EventFactor.EventHandlerTable(EventID.AFTER_MOVE, handler_pos_IyasiNoNegai),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_DelayAttack = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_BEGIN, handler_pos_DelayAttack),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_BatonTouch = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN_BATONTOUCH, handler_pos_BatonTouch),
        };

        // TODO
        public static EventFactor getEventFactor(EventSystem pEventSystem, BtlPosEffect effect, BtlPokePos pokePos) { return default; }
		
		// TODO
		public static bool isRegistable(EventSystem pEventSystem, BtlPosEffect effect, BtlPokePos pokePos) { return default; }
		
		// TODO
		public static HandlerGetFunc getHandlerGetFunc(BtlPosEffect effect) { return default; }
		
		// TODO
		public static void Add(EventSystem pEventSystem, BtlPosEffect effect, BtlPokePos pos, byte pokeID, int[] param, byte param_cnt) { }
		
		// TODO
		public static bool Remove(EventSystem pEventSystem, BtlPosEffect eff, BtlPokePos pos) { return default; }
		
		// TODO
		public static bool IsRegistered(EventSystem pEventSystem, BtlPosEffect eff, BtlPokePos pos) { return default; }
		
		// TODO
		public static void common_removePosEffect(in EventFactor.EventHandlerArgs args, BtlPokePos myPos) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Negaigoto() { return default; }
		
		// TODO
		public static void handler_pos_Negaigoto(in EventFactor.EventHandlerArgs args, byte pokePos) { }
		
		// TODO
		public static void negaigoto_recoverHP(in EventFactor.EventHandlerArgs args, BtlPokePos btlPokePos) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MikadukiNoMai() { return default; }
		
		// TODO
		public static void handler_pos_MikadukiNoMai(in EventFactor.EventHandlerArgs args, byte pokePos) { }
		
		// TODO
		public static bool mikadukiNoMai_check(BTL_POKEPARAM bpp) { return default; }
		
		// TODO
		public static void mikadukiNoMai_recover(in EventFactor.EventHandlerArgs args, byte pokeID, BTL_POKEPARAM bpp, BtlPokePos btlPokePos) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_IyasiNoNegai() { return default; }
		
		// TODO
		public static void handler_pos_IyasiNoNegai(in EventFactor.EventHandlerArgs args, byte pokePos) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_DelayAttack() { return default; }
		
		// TODO
		public static void handler_pos_DelayAttack(in EventFactor.EventHandlerArgs args, byte pokePos) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_BatonTouch() { return default; }
		
		// TODO
		public static void handler_pos_BatonTouch(in EventFactor.EventHandlerArgs args, byte pokePos) { }

		public delegate EventFactor.EventHandlerTable[] HandlerGetFunc();

		private struct GET_FUNC_TABLE_ELEM
		{
			public BtlPosEffect eff;
			public HandlerGetFunc func;
			
			public GET_FUNC_TABLE_ELEM(BtlPosEffect eff, HandlerGetFunc func)
			{
				this.eff = eff;
				this.func = func;
			}
		}
	}
}