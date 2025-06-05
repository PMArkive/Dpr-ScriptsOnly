using Dpr.Trainer;

public static class TrainerWork
{
    // TODO
    public static void Reset() { }

    public static void SetWinFlag(TrainerID id)
    {
        SetWinFlag((int)id);
    }

    public static void SetWinFlag(int index)
    {
        PlayerWork.tr_battleData[index].IsWin = true;
    }

    public static void ResetWinFlag(TrainerID id)
    {
        ResetWinFlag((int)id);
    }

    public static void ResetWinFlag(int index)
    {
        PlayerWork.tr_battleData[index].IsWin = false;
    }

    // TODO
    public static bool GetWinFlag(TrainerID id) { return true; }

    // TODO
    public static bool GetWinFlag(int index) { return true; }

    public static void SetBattleSaercher(TrainerID id)
    {
        SetBattleSaercher((int)id);
    }

    public static void SetBattleSaercher(int index)
    {
        PlayerWork.tr_battleData[index].IsBattleSearcher = true;
    }

    public static void ReSetBattleSaercher(TrainerID id)
    {
        ReSetBattleSaercher((int)id);
    }

    public static void ReSetBattleSaercher(int index)
    {
        PlayerWork.tr_battleData[index].IsBattleSearcher = false;
    }

    // TODO
    public static void AllResetBattleSaercher() { }

    // TODO
    public static bool GetBattleSearcher(TrainerID id) { return true; }

    // TODO
    public static bool GetBattleSearcher(int index) { return true; }

    // TODO
    public static TrainerID RematchTrainerID(TrainerID id) { return TrainerID.NONE; }

    // TODO
    public static TrainerID GetTrainerID(string name) { return TrainerID.NONE; }

    // TODO
    public static bool IsTokushuEncount(TrainerType trainer) { return true; }

    // TODO
    public static bool IsTagTranier(TrainerID trainer, out TrainerID tag)
    {
        tag = TrainerID.NONE;
        return true;
    }

    // TODO
    public static TrainerID GetTagTrainer(int index) { return TrainerID.NONE; }
}