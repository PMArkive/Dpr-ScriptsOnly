public static class BtlTowerWork
{
    private static int _contRound;

    // TODO
    public static void Create() { }

    // TODO
    public static void SetBP(int value) { }

    public static int GetBP()
    {
        return (int)PlayerWork.btlTowerSave.btl_point;
    }

    public static int GetRank(int mode)
    {
        return (int)PlayerWork.btlTowerSave.class_data[mode].rank;
    }

    // TODO
    public static void SetRank(int mode, byte value) { }

    // TODO
    public static uint DayFixRand(uint seed) { return 0; }

    // TODO
    public static void DayUpdate() { }

    // TODO
    public static void DebugLot(uint btlclass) { }

    // TODO
    public static void Start() { }

    // TODO
    public static void Restart(int btlclass) { }

    // TODO
    public static void Clear() { }

    // TODO
    public static void UpdateRenshou(int mode, uint wins) { }

    // TODO
    public static void AddLose(int mode) { }

    // TODO
    public static void ResetRenshou(int mode) { }

    public static uint GetRankDownLose(int mode)
    {
        return PlayerWork.btlTowerSave.class_data[mode].rank_down_lose;
    }

    // TODO
    public static void ReseRankDownLose(int mode) { }

    // TODO
    public static void SetMode(int mode) { }

    public static int GetMode()
    {
        return PlayerWork.btlTowerSave.play_mode;
    }

    public static int GetOldMode()
    {
        return PlayerWork.btlTowerSave.old_playmode;
    }

    public static int GetRound(int mode)
    {
        return PlayerWork.btlTowerSave.class_data[mode].tower_round;
    }

    // TODO
    public static void SetRound(int mode, int value) { }

    // TODO
    public static void RoundAdd(int mode) { }

    // TODO
    public static bool GameClear(int mode) { return false; }

    public static uint GetRenshou(int mode)
    {
        return PlayerWork.btlTowerSave.class_data[mode].renshou_cnt;
    }

    public static uint GetOldRenshou(int mode)
    {
        return PlayerWork.btlTowerSave.class_data[mode].old_renshou_cnt;
    }

    public static uint GetLastRenshou(int mode)
    {
        if (GetRenshou(mode) != 0)
            return GetRenshou(mode);
        else
            return GetOldRenshou(mode);
    }

    // TODO
    public static void LotTrainer(int mode) { }

    // TODO
    public static void UpdatePlayScore() { }

    // TODO
    public static void ChangeModeEnum(int mode, out TowerLotRule rule, out TowerLotCls cls)
    {
        rule = TowerLotRule.Invalid;
        cls = TowerLotCls.Invalid;
    }

    public static void GetNowModeEnum(out TowerLotRule rule, out TowerLotCls cls)
    {
        rule = TowerLotRule.Invalid;
        cls = TowerLotCls.Invalid;

        switch (PlayerWork.btlTowerSave.play_mode)
        {
            case 0:
                rule = TowerLotRule.Single;
                cls = TowerLotCls.Normal;
                break;

            case 1:
                rule = TowerLotRule.Double;
                cls = TowerLotCls.Normal;
                break;

            case 2:
                rule = TowerLotRule.Single;
                cls = TowerLotCls.Master;
                break;

            case 3:
                rule = TowerLotRule.Double;
                cls = TowerLotCls.Master;
                break;
        }
    }

    public static ulong GetTrainerRand(int round)
    {
        return PlayerWork.btlTowerSave.class_data[GetMode()].trainer_random[round];
    }

    public static void AddChallengeCount()
    {
        var data = PlayerWork.btlTowerSave;

        if (data.play_mode == 2 || data.play_mode == 3)
            data.challenge_cnt = data.challenge_cnt < 999999 ? data.challenge_cnt + 1 : data.challenge_cnt;

        PlayerWork.btlTowerSave = data;
    }

    // TODO
    public static void ResetBtlAve() { }

    // TODO
    public static void ContinueRound() { }
}