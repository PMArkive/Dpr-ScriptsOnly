using Dpr.EvScript;

public static class FlagWork
{
    public static bool GetFlag(int flagNo)
    {
        return PlayerWork.GetBool((EvWork.FLAG_INDEX)flagNo);
    }

    public static bool GetFlag(EvWork.FLAG_INDEX flagNo)
    {
        return PlayerWork.GetBool(flagNo);
    }

    public static void SetFlag(int flagNo, bool value)
    {
        PlayerWork.SetBool((EvWork.FLAG_INDEX)flagNo, value);
    }

    public static void SetFlag(EvWork.FLAG_INDEX flagNo, bool value)
    {
        PlayerWork.SetBool(flagNo, value);
    }

    public static void ResetFlag(int flagNo)
    {
        PlayerWork.SetBool((EvWork.FLAG_INDEX)flagNo, false);
    }

    public static void ResetFlag(EvWork.FLAG_INDEX flagNo)
    {
        PlayerWork.SetBool(flagNo, false);
    }

    public static bool GetVanishFlag(int flagNo)
    {
        if (flagNo + (int)EvWork.INDEX_NUM.FV_FLAG_START < (int)EvWork.INDEX_NUM.FV_END)
            return PlayerWork.GetBool((EvWork.FLAG_INDEX)(flagNo + (int)EvWork.INDEX_NUM.FV_FLAG_START));

        return false;
    }

    public static void SetVanishFlag(int flagNo, bool value)
    {
        if (flagNo + (int)EvWork.INDEX_NUM.FV_FLAG_START < (int)EvWork.INDEX_NUM.FV_END)
            PlayerWork.SetBool((EvWork.FLAG_INDEX)(flagNo + (int)EvWork.INDEX_NUM.FV_FLAG_START), value);
    }

    public static void ResetVanishFlag(int flagNo)
    {
        if (flagNo + (int)EvWork.INDEX_NUM.FV_FLAG_START < (int)EvWork.INDEX_NUM.FV_END)
            PlayerWork.SetBool((EvWork.FLAG_INDEX)(flagNo + (int)EvWork.INDEX_NUM.FV_FLAG_START), false);
    }

    public static bool GetSysFlag(EvWork.SYSFLAG_INDEX flagNo)
    {
        return PlayerWork.GetSytemFlag(flagNo);
    }

    public static void SetSysFlag(EvWork.SYSFLAG_INDEX flagNo, bool value)
    {
        PlayerWork.SetSytemFlag(flagNo, value);
    }

    public static void ResetSysFlag(EvWork.SYSFLAG_INDEX flagNo)
    {
        PlayerWork.SetSytemFlag(flagNo, false);
    }

    public static int GetWork(int workNo)
    {
        return PlayerWork.GetInt((EvWork.WORK_INDEX)workNo);
    }

    public static int GetWork(EvWork.WORK_INDEX workNo)
    {
        return PlayerWork.GetInt(workNo);
    }

    public static void SetWork(int workNo, int value)
    {
        PlayerWork.SetInt((EvWork.WORK_INDEX)workNo, value);
    }

    public static void SetWork(EvWork.WORK_INDEX workNo, int value)
    {
        PlayerWork.SetInt(workNo, value);
    }

    public static void ResetWork(int workNo)
    {
        PlayerWork.SetInt((EvWork.WORK_INDEX)workNo, 0);
    }

    public static float GetFloatWork(int workNo)
    {
        return PlayerWork.GetInt((EvWork.WORK_INDEX)workNo);
    }

    public static float GetFloatWork(EvWork.WORK_INDEX workNo)
    {
        return PlayerWork.GetInt(workNo);
    }

    public static void SetFloatWork(int workNo, float value)
    {
        PlayerWork.SetInt((EvWork.WORK_INDEX)workNo, (int)value);
    }

    public static void SetFloatWork(EvWork.WORK_INDEX workNo, float value)
    {
        PlayerWork.SetInt(workNo, (int)value);
    }

    public static int BadgeCount()
    {
        return (PlayerWork.GetSytemFlag(EvWork.SYSFLAG_INDEX.BADGE_ID_C02) ? 1 : 0) +
            (PlayerWork.GetSytemFlag(EvWork.SYSFLAG_INDEX.BADGE_ID_C03) ? 1 : 0) +
            (PlayerWork.GetSytemFlag(EvWork.SYSFLAG_INDEX.BADGE_ID_C04) ? 1 : 0) +
            (PlayerWork.GetSytemFlag(EvWork.SYSFLAG_INDEX.BADGE_ID_C05) ? 1 : 0) +
            (PlayerWork.GetSytemFlag(EvWork.SYSFLAG_INDEX.BADGE_ID_C06) ? 1 : 0) +
            (PlayerWork.GetSytemFlag(EvWork.SYSFLAG_INDEX.BADGE_ID_C07) ? 1 : 0) +
            (PlayerWork.GetSytemFlag(EvWork.SYSFLAG_INDEX.BADGE_ID_C08) ? 1 : 0) +
            (PlayerWork.GetSytemFlag(EvWork.SYSFLAG_INDEX.BADGE_ID_C09) ? 1 : 0);
    }
}