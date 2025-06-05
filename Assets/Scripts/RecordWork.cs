using DPData;

public static class RecordWork
{
    private const int MAX = 999999;

    // TODO
    public static void Create() { }

    // TODO
    public static void CreateAddData() { }

    // TODO
    public static void PatchLanguage() { }

    // TODO
    public static void Add(RECORD_ID index, uint add = 1) { }

    // TODO
    public static void Add(int index, uint add = 1) { }

    // TODO
    public static void Sub(RECORD_ID index, uint add = 1) { }

    // TODO
    public static void Sub(int index, uint add = 1) { }

    // TODO
    public static void Set(RECORD_ID index, uint value) { }

    // TODO
    public static void Set(int index, uint value) { }

    // TODO
    public static uint Get(RECORD_ID index) { return 0; }

    // TODO
    public static uint Get(int index) { return 0; }

    // TODO
    public static uint MaxValue(RECORD_ID index, out int recordindex)
    {
        recordindex = 0;
        return 0;
    }

    // TODO
    public static uint MaxValue(int index, out int recordindex)
    {
        recordindex = 0;
        return 0;
    }

    // TODO
    public static int CheckHeadData(ref RECORD_HEAD recodeHeadData) { return 0; }

    // TODO
    public static int CheckHeadAndGroupData(ref RECORD_HEAD recodeHeadData, ref RANDOM_SEED seed) { return 0; }

    // TODO
    public static int GetNullGroup() { return 0; }

    // TODO
    private static void SetHeadRecord(int index, ref RECORD_HEAD recodeHeadData) { }

    // TODO
    private static int GetOldRecordIndex() { return 0; }

    // TODO
    public static int SetOtherRecord(RANDOM_SEED seed, ref RECORD record, ref RECORD_HEAD recodeHeadData) { return 0; }

    // TODO
    public static void AddDataMineNull() { }

    // TODO
    public static string GetUserName(RANDOMGROUP index) { return ""; }

    // TODO
    public static uint GetUniqueID(RANDOMGROUP index) { return 0; }

    // TODO
    public static int GetLanguage(RANDOMGROUP index) { return 0; }

    // TODO
    public static byte GetSex(RANDOMGROUP index) { return 0; }

    // TODO
    public static int GetBodyType(RANDOMGROUP index) { return 0; }

    // TODO
    public static byte GetRankingActive(RANDOMGROUP index, int uiIndex) { return 0; }

    // TODO
    public static void SetRankingDisable(RANDOMGROUP index, int uiIndex) { }

    // TODO
    private static void LimitCheck(ref uint data, uint limit) { }

    // TODO
    public static void IllegalDataCheck() { }

    // TODO
    public static void ResetBtlAve() { }
}