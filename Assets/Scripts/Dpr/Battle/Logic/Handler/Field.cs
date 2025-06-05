namespace Dpr.Battle.Logic.Handler
{
	public static class Field
	{
		private static readonly GET_FUNC_TABLE_ELEM[] getHandlerGetFuncTable = new GET_FUNC_TABLE_ELEM[]
		{
			new GET_FUNC_TABLE_ELEM(EffectType.EFF_WEATHER,        ADD_Fld_Weather),
			new GET_FUNC_TABLE_ELEM(EffectType.EFF_TRICKROOM,      ADD_Fld_TrickRoom),
			new GET_FUNC_TABLE_ELEM(EffectType.EFF_JURYOKU,        ADD_Fld_Juryoku),
			new GET_FUNC_TABLE_ELEM(EffectType.EFF_FUIN,           ADD_Fld_Fuin),
			new GET_FUNC_TABLE_ELEM(EffectType.EFF_WONDERROOM,     ADD_Fld_WonderRoom),
			new GET_FUNC_TABLE_ELEM(EffectType.EFF_MAGICROOM,      ADD_Fld_MagicRoom),
			new GET_FUNC_TABLE_ELEM(EffectType.EFF_FAIRY_LOCK,     ADD_Fld_FairyLock),
			new GET_FUNC_TABLE_ELEM(EffectType.EFF_PLASMASHOWER,   ADD_Fld_PlasmaShower),
			new GET_FUNC_TABLE_ELEM(EffectType.EFF_GROUND,         ADD_Fld_Ground),
			new GET_FUNC_TABLE_ELEM(EffectType.EFF_KAGAKUHENKAGAS, ADD_Fld_KagakuhenkaGas),
		};

		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Ooame = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_2ND, handler_ooame_CheckExe),
		};
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Oohideri = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_2ND, handler_oohideri_CheckExe),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Rankiryuu = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_AFFINITY,               handler_rankiryuu_CheckAff),
            new EventFactor.EventHandlerTable(EventID.CHECK_AFFINITY_ONLY_ATTACKER, handler_rankiryuu_CheckAff),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC_END,            handler_rankiryuu_AfterDamage),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Dammy = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.INVALID, handler_fld_dummy),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Fld_TrickRoom = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CALC_AGILITY, handler_fld_TrickRoom),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Fld_Juryoku = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_HIT_RATIO,               handler_fld_Jyuryoku_AdjustDmg),
            new EventFactor.EventHandlerTable(EventID.CHECK_AFFINITY,               handler_fld_Jyuryoku_CheckAff),
            new EventFactor.EventHandlerTable(EventID.CHECK_AFFINITY_ONLY_ATTACKER, handler_fld_Jyuryoku_CheckAff),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Fld_Sawagu = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_fld_Weather),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Fld_WonderRoom = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DEFENDER_GUARD_PREV, handler_fld_WonderRoom),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Fld_Fuin = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.INVALID, handler_fld_dummy),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Fld_MagicRoom = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.INVALID, handler_fld_dummy),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Fld_FairyLock = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.INVALID, handler_fld_dummy),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Fld_PlasmaShower = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_PARAM_2ND, handler_plasma_shower),
            new EventFactor.EventHandlerTable(EventID.CHANGE_G_WAZA,  handler_plasmaShower_ChangeGWaza),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Fld_KagakuhenkaGas = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.INVALID, handler_fld_dummy),
        };
        private static readonly EventFactor.EventHandlerTable[] GrassHandlerTable = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER,      handler_grass_power),
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_BEGIN, handler_grass_turncheck),
        };
        private static readonly EventFactor.EventHandlerTable[] MistHandlerTable = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER,        handler_mist_power),
            new EventFactor.EventHandlerTable(EventID.ADDSICK_CHECKFAIL, handler_mist_checkFail),
            new EventFactor.EventHandlerTable(EventID.ADDSICK_FAILED,    handler_mist_sickFailed),
        };
        private static readonly EventFactor.EventHandlerTable[] ElecHandlerTable = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER,        handler_elec_power),
            new EventFactor.EventHandlerTable(EventID.ADDSICK_CHECKFAIL, handler_elec_checkFail),
            new EventFactor.EventHandlerTable(EventID.ADDSICK_FAILED,    handler_elec_sickFailed),
        };
        private static readonly EventFactor.EventHandlerTable[] PhychoHandlerTable = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER,           handler_phycho_power),
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_FIELD, handler_phycho_noEffectCheck),
        };
        private static readonly EventFactor.EventHandlerTable[] DammyHandlerTable = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.INVALID, handler_fld_dummy),
        };

        // TODO
        public static HandlerGetFunc getHandlerGetFunc(EffectType effect) { return default; }
		
		// TODO
		public static bool Add(EventSystem pEventSystem, EffectType effect, byte subParam) { return default; }
		
		// TODO
		public static void Remove(EventSystem pEventSystem, EffectType effect) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Fld_Weather(byte sub_param) { return default; }
		
		// TODO
		public static void handler_fld_Weather(in EventFactor.EventHandlerArgs args, byte subParam) { }
		
		// TODO
		public static void handler_ooame_CheckExe(in EventFactor.EventHandlerArgs args, byte subParam) { }
		
		// TODO
		public static void handler_oohideri_CheckExe(in EventFactor.EventHandlerArgs args, byte subParam) { }
		
		// TODO
		public static void handler_rankiryuu_CheckAff(in EventFactor.EventHandlerArgs args, byte subParam) { }
		
		// TODO
		public static void handler_rankiryuu_AfterDamage(in EventFactor.EventHandlerArgs args, byte subParam) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Fld_TrickRoom(byte sub_param) { return default; }
		
		// TODO
		public static void handler_fld_TrickRoom(in EventFactor.EventHandlerArgs args, byte subParam) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Fld_Juryoku(byte sub_param) { return default; }
		
		// TODO
		public static void handler_fld_Jyuryoku_AdjustDmg(in EventFactor.EventHandlerArgs args, byte subParam) { }
		
		// TODO
		public static void handler_fld_Jyuryoku_CheckAff(in EventFactor.EventHandlerArgs args, byte subParam) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Fld_Sawagu(byte sub_param) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Fld_WonderRoom(byte sub_param) { return default; }
		
		// TODO
		public static void handler_fld_WonderRoom(in EventFactor.EventHandlerArgs args, byte subParam) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Fld_Fuin(byte sub_param) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Fld_MagicRoom(byte sub_param) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Fld_FairyLock(byte sub_param) { return default; }
		
		// TODO
		public static void handler_fld_dummy(in EventFactor.EventHandlerArgs args, byte subParam) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Fld_PlasmaShower(byte sub_param) { return default; }
		
		// TODO
		public static void handler_plasma_shower(in EventFactor.EventHandlerArgs args, byte subParam) { }
		
		// TODO
		public static void handler_plasmaShower_ChangeGWaza(in EventFactor.EventHandlerArgs args, byte subParam) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Fld_KagakuhenkaGas(byte sub_param) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Fld_Ground(byte sub_param) { return default; }
		
		// TODO
		public static bool common_isGroundEffective(in EventFactor.EventHandlerArgs args, byte pokeID) { return default; }
		
		// TODO
		public static void handler_grass_power(in EventFactor.EventHandlerArgs args, byte subParam) { }
		
		// TODO
		public static void handler_grass_turncheck(in EventFactor.EventHandlerArgs args, byte subParam) { }
		
		// TODO
		public static void handler_mist_power(in EventFactor.EventHandlerArgs args, byte subParam) { }
		
		// TODO
		public static void handler_mist_checkFail(in EventFactor.EventHandlerArgs args, byte subParam) { }
		
		// TODO
		public static void handler_mist_sickFailed(in EventFactor.EventHandlerArgs args, byte subParam) { }
		
		// TODO
		public static void handler_elec_power(in EventFactor.EventHandlerArgs args, byte subParam) { }
		
		// TODO
		public static void handler_elec_checkFail(in EventFactor.EventHandlerArgs args, byte subParam) { }
		
		// TODO
		public static void handler_elec_sickFailed(in EventFactor.EventHandlerArgs args, byte subParam) { }
		
		// TODO
		public static void common_field_sickGuardSucceed(in EventFactor.EventHandlerArgs args, ContFlag pokeContFlag, ushort strID) { }
		
		// TODO
		public static void handler_phycho_power(in EventFactor.EventHandlerArgs args, byte subParam) { }
		
		// TODO
		public static void handler_phycho_noEffectCheck(in EventFactor.EventHandlerArgs args, byte subParam) { }

		public delegate EventFactor.EventHandlerTable[] HandlerGetFunc(byte subParam);

		private struct GET_FUNC_TABLE_ELEM
		{
			public EffectType effect;
			public HandlerGetFunc func;
			
			public GET_FUNC_TABLE_ELEM(EffectType effect, HandlerGetFunc func)
			{
				this.effect = effect;
				this.func = func;
			}
		}
	}
}