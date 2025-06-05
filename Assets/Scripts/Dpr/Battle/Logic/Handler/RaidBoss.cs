namespace Dpr.Battle.Logic.Handler
{
    public static class RaidBoss
    {
        public const int WIDX0 = 0;
        public const int WIDX1 = 1;
        public const int WIDX2 = 2;
        public const int WIDX3 = 3;
        public const int NUM_WIDX = 4;

        private static readonly GET_FUNC_TABLE_ELEM[] GET_FUNC_TABLE = new GET_FUNC_TABLE_ELEM[]
        {
            new GET_FUNC_TABLE_ELEM(RaidBossHandlerType.RREINFORCE, ADD_Reinforce),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Reinforce = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_START, handler_Reinforce_Start),
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_END, handler_Reinforce_End),
        };

        public static HandlerGetFunc getHandlerGetFunc(RaidBossHandlerType handlerType)
        {
            for (int i=0; i<GET_FUNC_TABLE.Length; i++)
            {
                if (GET_FUNC_TABLE[i].type == handlerType)
                    return GET_FUNC_TABLE[i].func;
            }

            return null;
        }

        // TODO
        public static EventFactor Add(EventSystem eventSystem, BTL_POKEPARAM poke, RaidBossHandlerType handlerType) { return null; }

        // TODO
        public static bool canAdd(EventSystem eventSystem, BTL_POKEPARAM poke, RaidBossHandlerType handlerType) { return false; }

        // TODO
        public static void Remove(EventSystem pEventSystem, BTL_POKEPARAM poke, RaidBossHandlerType handlerType) { }

        public static EventFactor.EventHandlerTable[] ADD_Reinforce()
        {
            return HandlerTable_Reinforce;
        }

        // TODO
        public static void handler_Reinforce_Start(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_Reinforce_End(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public delegate EventFactor.EventHandlerTable[] HandlerGetFunc();

        private struct GET_FUNC_TABLE_ELEM
        {
            public RaidBossHandlerType type;
            public HandlerGetFunc func;

            public GET_FUNC_TABLE_ELEM(RaidBossHandlerType type, HandlerGetFunc func)
            {
                this.type = type;
                this.func = func;
            }
        }
    }
}