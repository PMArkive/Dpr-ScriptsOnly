using Pml.PokePara;

public static class AzukariyaWork
{
    public const int POKE_MAX = 2;
    private const int LoveLv_Good = 70;
    private const int LoveLv_Normal = 50;
    private const int LoveLv_Bad = 20;
    private const int LoveLv_Worst = 0;
    private const int LoveLv_Good_Ex = 88;
    private const int LoveLv_Normal_Ex = 80;
    private const int LoveLv_Bad_Ex = 40;
    private static readonly int[,] EggPercentRate =
    {
        { LoveLv_Good, LoveLv_Good_Ex },
        { LoveLv_Normal, LoveLv_Normal_Ex },
        { LoveLv_Bad, LoveLv_Bad_Ex },
        { LoveLv_Worst, LoveLv_Worst },
    };
    private const int EggCheckInterval = 180;

    // TODO
    public static void StoreFromTemoti(int temotiIndex) { }

    // TODO
    public static void RestoreToTemoti(int index) { }

    // TODO
    public static void StoreFromBox(int tray, int pos) { }

    // TODO
    public static void RestoreToBox(int index, int tray, int pos) { }

    // TODO
    public static void RestoreToBox(int index) { }

    // TODO
    private static void RestoreCommon(int index) { }

    // TODO
    public static bool IsExistEgg() { return false; }

    // TODO
    public static void GetEggToTemoti() { }

    // TODO
    public static void GetEggToTemotiReplace(int temotiIndex) { }

    // TODO
    public static void GetEggToBox() { }

    // TODO
    public static void AddEggStep(int step) { }

    // TODO
    public static void CheckLayEgg() { }

    // TODO
    public static int CalcLoveLevel() { return 0; }

    // TODO
    public static void SetExistEgg() { }

    // TODO
    public static void DiscardEgg() { }

    // TODO
    public static PokemonParam GenerateAndGetEgg() { return null; }

    // TODO
    public static void Clear() { }

    // TODO
    public static void Set(int index, PokemonParam pp) { }

    // TODO
    public static PokemonParam Get(int index) { return null; }

    // TODO
    public static void SetEmpty(int index) { }

    // TODO
    public static int GetUnusedIndex() { return 0; }

    // TODO
    public static int GetStoredCount() { return 0; }

    // TODO
    public static bool IsUsed(int index) { return false; }

    // TODO
    public static void Move(int sourceIndex, int targetIndex) { }

    // TODO
    public static void InitOldmanEvent() { }

    // TODO
    public static void MoveOldmanEvent() { }

    // TODO
    public static bool IsExistOldmanZone() { return false; }

    // TODO
    public static bool IsLoadedOldman() { return false; }

    // TODO
    public static FieldObjectEntity GetOldman() { return null; }
}