using Dpr.EvScript;
using Pml;

public static class DailyEventWork
{
    public static int PenaltyMin = 1440;

    // TODO
    private static Status UpdateDateCheck(out int diffdays)
    {
        diffdays = 0;
        return Status.NO_DAILY;
    }

    // TODO
    public static bool UpdateEvent() { return false; }

    private static void PokerusUpdate(int diffday)
    {
        if (PlayerWork.playerParty.CheckPokerusExist())
            PlayerWork.playerParty.DecreasePokerusDayCount(diffday);
    }

    private static void ResetScriptFlag()
    {
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_SEED_PRESENT, false);
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_T05PC0101_ITEM_GET, false);
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_URANIWA_ENCOUNT, false);
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_C06R0201_SEED_PRESENT, false);
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_C08R0201_RIBBON_GET, false);
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_T07R0101_ESTHTIQUE, false);
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_C08R0201_WEEK_TALK, false);
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_C08R0201_FIRST_DAY, false);
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_D02_FUUSEN, false);
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_KUJI_DAY, false);
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_T03R0101_SEED_PRESENT, false);
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_L02R0101_INIT, false);
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_C07R0801_DRESSING, false);
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_C09R0201_NANKAI, false);
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_R221R0201_ITEM_GET, false);
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_C01R0201_BATTLE_END, false);
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_D25R0106_SPPOKE_END, false);
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_T04R0301_NEWS_END, false);
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_C11_RIVAL_BTL, false);

        FlagWork.SetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_USE_TODAY_IWAKUDAKI, false);
        FlagWork.SetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_USE_TODAY_IAIGIRI, false);
        FlagWork.SetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_USE_TODAY_SORAWOTOBU, false);
        FlagWork.SetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_USE_TODAY_KIRIBARAI, false);
        FlagWork.SetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_USE_TODAY_NAMINORI, false);
        FlagWork.SetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_USE_TODAY_KAIRIKI, false);
        FlagWork.SetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_USE_TODAY_ROKKUKURAIMU, false);
        FlagWork.SetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_USE_TODAY_TAKINOBORI, false);

        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_C01R0203_PRODUCER, false);
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_C02_GYM_RETRUN_MATCH, false);
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_C03_GYM_RETRUN_MATCH, false);
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_C04_GYM_RETRUN_MATCH, false);
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_C05_GYM_RETRUN_MATCH, false);
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_C06_GYM_RETRUN_MATCH, false);
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_C07_GYM_RETRUN_MATCH, false);
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_C08_GYM_RETRUN_MATCH, false);
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_C09_GYM_RETRUN_MATCH, false);
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_T04R0301_NEWS_ONEDAY, false);
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_T02_SUP_RETRUN_MATCH, false);
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_POKE_TUREARUI_PEMALTY, false);
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_4_POKE_TUREARUI_ITEM, false);
        FlagWork.SetFlag(EvWork.FLAG_INDEX.TMFLG_R213_POOL, false);
    }

    public static void SysWorkUpdatePokeLevelNo()
    {
        FlagWork.SetWork(EvWork.WORK_INDEX.SYS_WORK_POKE_LEVEL_NO, RandomGroupWork.RandomRange(2, PmlConstants.MAX_POKE_LEVEL));
    }

    // TODO
    private static void UpdateSafari() { }

    // TODO
    private static void UpdatePenalty() { }

    // TODO
    public static bool PenaltyCheck() { return false; }

    private enum Status : int
    {
        NO_DAILY = 0,
        DAIRY = 1,
        PENALTY = 2,
    }
}