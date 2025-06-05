using Pml.PokePara;
using Pml;
using DPData;

public class EncountDataWork
{
    // TODO
    public static void Create() { }

    // TODO
    public static bool EncDataSave_CanUseSpray() { return false; }

    // TODO
    public static int GetMovePokeIndex(MonsNo monsno) { return 0; }

    // TODO
    public static void SetMovePokeData(PokemonParam param, bool init = false) { }

    // TODO
    public static bool GetMovePokeData(MonsNo monsno, ref MV_POKE_DATA outData) { return false; }

    // TODO
    public static bool GetMovePokeData(int index, ref MV_POKE_DATA outData) { return false; }

    // TODO
    public static void SetMovePokeData_ZoneID(MonsNo monsno, ZoneID zonid) { }

    // TODO
    public static void SetMovePokeData_ZoneID(int index, ZoneID zonid) { }

    // TODO
    public static void SetMovePokeData_Status(MonsNo monsno, GetPokeStatus status) { }

    // TODO
    public static bool IsMovePokeData_ReActive(int index) { return false; }

    // TODO
    public static void SetMovePokeData_Status(int index, GetPokeStatus status) { }

    // TODO
    public static void MovePoke_RandomZone(MonsNo monsno) { }

    // TODO
    public static void MovePoke_RandomZone() { }

    // TODO
    public static void MovePoke_RandomZone(int index) { }

    // TODO
    public static void MovePoke_PlayerEqualZoneNextZone(ZoneID zoneid) { }

    // TODO
    public static void MovePoke_NextZone() { }

    // TODO
    public static ZoneID GetMovePoke_ZoneID(int index) { return ZoneID.UNKNOWN; }

    // TODO
    public static void FukkatuMvPoke() { }

    // TODO
    public static void SetTairyouHassei(bool flag) { }

    // TODO
    public static bool IsTairyouHassei() { return false; }

    // TODO
    public static int GetUrayamaIndex(int index) { return 0; }

    // TODO
    public static void ChangeUrayamaIndex(int diff) { }

    // TODO
    public static void SetUrayamaIndex(uint num) { }

    // TODO
    public static void JumpMovePokeAffterBattle(ZoneID playerZone) { }

    public enum GetPokeStatus : int
    {
        NoActive = 0,
        Active = 1,
        Kill = 2,
        Get = 3,
    }
}