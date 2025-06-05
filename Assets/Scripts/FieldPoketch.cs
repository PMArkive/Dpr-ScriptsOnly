using Dpr.EvScript;
using Dpr.UI;
using Pml.PokePara;
using Pml;
using System;
using System.Collections.Generic;
using UnityEngine;
using DPData;

public static class FieldPoketch
{
    private static Dictionary<HidenWazaType, (EvWork.SYSFLAG_INDEX flag, ItemNo itemNo)> HidenWazaParams = new Dictionary<HidenWazaType, (EvWork.SYSFLAG_INDEX flag, ItemNo itemNo)>()
    {
        { HidenWazaType.Iwakudaki,  (EvWork.SYSFLAG_INDEX.BADGE_ID_C03, ItemNo.HIDENMASIN06) },
        { HidenWazaType.Iaigiri,    (EvWork.SYSFLAG_INDEX.BADGE_ID_C04, ItemNo.HIDENMASIN01) },
        { HidenWazaType.Sorawotobu, (EvWork.SYSFLAG_INDEX.BADGE_ID_C07, ItemNo.HIDENMASIN02) },
        { HidenWazaType.Kiribarai,  (EvWork.SYSFLAG_INDEX.BADGE_ID_C06, ItemNo.HIDENMASIN05) },
        { HidenWazaType.Naminori,   (EvWork.SYSFLAG_INDEX.BADGE_ID_C05, ItemNo.HIDENMASIN03) },
        { HidenWazaType.Kairiki,    (EvWork.SYSFLAG_INDEX.BADGE_ID_C02, ItemNo.HIDENMASIN04) },
        { HidenWazaType.Rockclimb,  (EvWork.SYSFLAG_INDEX.BADGE_ID_C09, ItemNo.HIDENMASIN08) },
        { HidenWazaType.Takinobori, (EvWork.SYSFLAG_INDEX.BADGE_ID_C08, ItemNo.HIDENMASIN07) },
    };

    // TODO
    public static void RegisterEvent() { }

    // TODO
    public static void UnregisterEvent() { }

    // TODO
    public static PoketchWindow CreatePoketchWindow() { return null; }

    // TODO
    public static void CreanPoketchWindow() { }

    // TODO
    public static void OnPushedHideButton() { }

    // TODO
    public static void HidePoketch(bool doCallback = false) { }

    // TODO
    public static void OnPushedAppearButton() { }

    // TODO
    public static bool IsRejectPoketch() { return false; }

    // TODO
    public static bool IsCloseOncePoketch() { return false; }

    // TODO
    public static void RestorePoketchWindow() { }

    // TODO
    private static void OpenPoketchWindow() { }

    // TODO
    public static bool IsControlPoketch() { return false; }

    // TODO
    public static void CountPoketchPedometer(int num) { }

    public static void SetAvailablePoketchApp(POKETCH_APPID appId)
    {
        if (PlayerWork.PoketchData.app_flag == null)
            return;

        if (PlayerWork.PoketchData.app_flag.Length == 0)
            return;

        PlayerWork.PoketchData.app_flag[(int)appId] = true;
    }

    // TODO
    public static bool IsAvailablePoketchApp(POKETCH_APPID appId) { return false; }

    // TODO
    public static void AddPokemonHistory(PokemonParam pokeParam) { }

    // TODO
    public static void AddPokemonHistory(int monsno, int form) { }

    // TODO
    public static DowsingResult Dowsing(Vector2 sonarCenterPos) { return null; }

    // TODO
    public static Vector2Int DowsingScreenToGrid(in Vector2 position, in Vector2Int gridOrigin) { return Vector2Int.zero; }

    // TODO
    public static Vector2 GridToDowsingScreen(in Vector2Int grid, in Vector2Int gridOrigin) { return Vector2.zero; }

    // TODO
    private static int HitSonar(in Vector2Int itemPos, in Vector2Int sonarCenterGrid, in Vector2Int gridLT, in Vector2Int gridRB) { return 0; }

    // TODO
    public static bool IsGetHidenWaza(HidenWazaType hidenWazaType) { return false; }

    // TODO
    public static bool IsGetHidenWazaMachine(HidenWazaType hidenWazaType) { return false; }

    // TODO
    public static UIManager.FieldUseResult AvailableHidenWaza(HidenWazaType hidenWazaType) { return UIManager.FieldUseResult.Available; }

    // TODO
    private static bool AvailableHidenWazaCore(HidenWazaType hidenWazaType) { return false; }

    // TODO
    public static void UseHidenWaza(HidenWazaType hidenWazaType) { }

    // TODO
    public static bool CanUseHidenWaza(HidenWazaType hidenWazaType) { return false; }

    // TODO
    private static bool AvailableIwakudakiObject(FieldObjectEntity obj) { return false; }

    // TODO
    private static bool AvailableIaigiriObject(FieldObjectEntity obj) { return false; }

    // TODO
    private static bool AvailableRockclimbObject(FieldObjectEntity obj) { return false; }

    // TODO
    private static bool AvailableKairikiObject(FieldObjectEntity obj) { return false; }

    // TODO
    private static FieldObjectEntity SearchCanHidenContactObject(Func<FieldObjectEntity, bool> CheckFunc, out int outIndex)
    {
        outIndex = 0;
        return null;
    }

    // TODO
    private static bool CanHidenContact(Func<FieldObjectEntity, bool> CheckFunc) { return false; }

    // TODO
    private static void ContactHidenObject(int index, FieldObjectEntity entity, string label) { }

    // TODO
    private static void JumpHidenEvent(string label) { }

    public class DowsingResult
    {
	    public List<Vector2> ItemPoints = new List<Vector2>();
        public bool ExistItem;
    }

    public enum HidenWazaType : int
    {
        Iwakudaki = 0,
        Iaigiri = 1,
        Sorawotobu = 2,
        Kiribarai = 3,
        Naminori = 4,
        Kairiki = 5,
        Rockclimb = 6,
        Takinobori = 7,
    }
}