namespace Dpr.Battle.Logic.Handler
{
	public static class DefaultPowerUp
	{
		private static readonly GET_FUNC_TABLE_ELEM[] GET_FUNC_TABLE = new GET_FUNC_TABLE_ELEM[]
		{
			new GET_FUNC_TABLE_ELEM(DefaultPowerUpReason.DEFAULT_POWERUP_REASON_NUSI,        ADD_Nusi),
			new GET_FUNC_TABLE_ELEM(DefaultPowerUpReason.DEFAULT_POWERUP_REASON_ULTRA_BEAST, ADD_Nusi),
			new GET_FUNC_TABLE_ELEM(DefaultPowerUpReason.DEFAULT_POWERUP_REASON_BOSS,        ADD_Nusi),
		};

		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Nusi = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.MEMBER_IN_DEFAULT_POWERUP, handler_Nusi_MemberIn),
		};
		
		// TODO
		public static HandlerGetFunc getHandlerGetFunc(DefaultPowerUpReason powerUpReason) { return default; }
		
		// TODO
		public static void removeFactorForce(EventSystem pEventSystem, byte pokeId, DefaultPowerUpReason powerUpReason) { }
		
		// TODO
		public static bool Add(EventSystem pEventSystem, BTL_POKEPARAM poke) { return default; }
		
		// TODO
		public static void Remove(EventSystem pEventSystem, BTL_POKEPARAM poke) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Nusi() { return default; }
		
		// TODO
		public static void handler_Nusi_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }

		public delegate EventFactor.EventHandlerTable[] HandlerGetFunc();

		private struct GET_FUNC_TABLE_ELEM
		{
			public DefaultPowerUpReason powerUpReason;
			public HandlerGetFunc func;
			
			public GET_FUNC_TABLE_ELEM(DefaultPowerUpReason powerUpReason, HandlerGetFunc func)
			{
				this.powerUpReason = powerUpReason;
				this.func = func;
			}
		}
	}
}