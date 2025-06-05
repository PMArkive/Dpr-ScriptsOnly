using Dpr.EvScript;

public static class FieldBattleSearcher
{
    private const int RANGE_X = 5;
    private const int RANGE_UY = 5;
    private const int RANGE_DY = -5;
    private const int CAMERA_2D_MIN_X = 100;
    private const int CAMERA_2D_MIN_Y = 100;
    private const int CAMERA_2D_MAX_X = 1180;
    private const int CAMERA_2D_MAX_Y = 620;
    private static float eventTime;

    // TODO
    public static int TrainerSearch() { return 0; }

    private static void SearchEventEnd(float time)
    {
        eventTime += time;

        if (eventTime < 0.3f)
            return;

        FlagWork.SetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_AUTOSAVE_STOP, false);
        FlagWork.SetSysFlag(EvWork.SYSFLAG_INDEX.SYS_INPUT_OFF, false);

        PlayerWork.isPlayerInputActive = true;

        FieldCanvas.DeleteBalloon(null);
        EvDataManager.Instanse.SetBtlSearchEndEvent(null);
        FlagWork.SetSysFlag(EvWork.SYSFLAG_INDEX.FLAG_STOP_EYE_ENCOUNT, false);
    }

    // TODO
    public static void WalkClearFlag() { }
}