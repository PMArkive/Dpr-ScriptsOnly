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

    // TODO
    private static void PokerusUpdate(int diffday) { }

    // TODO
    private static void ResetScriptFlag() { }

    // TODO
    public static void SysWorkUpdatePokeLevelNo() { }

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