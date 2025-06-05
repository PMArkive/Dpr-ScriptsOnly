using DPData;
using GameData;
using Pml;
using System;
using XLSXContent;

public class KinomiWork
{
    private static DateTime? LastUpdateTime;

    // TODO
    public static KinomiPlaceData.SheetSheet1 GetPlaceData(int placeIndex) { return null; }

    public static KinomiPlaceData.SheetSheet1[] GetPlaceDataByAreaId(AreaID areaId)
    {
        return Array.FindAll(DataManager.KinomiPlaceData.Sheet1, data => data.AreaID == areaId);
    }

    // TODO
    public static int GetPlaceDataCount() { return 0; }

    // TODO
    public static KinomiData.SheetData GetKinomiData(int tagNo) { return null; }

    // TODO
    public static int GetKinomiDataCount() { return 0; }

    // TODO
    public static KinomiData.SheetData FindKinomiDataByItemNo(ItemNo itemNo) { return null; }

    // TODO
    public static KinomiGrow GetGrowByRawIndex(int growIndex) { return default(KinomiGrow); }

    // TODO
    public static void SetGrowByRawIndex(int growIndex, KinomiGrow grow) { }

    // TODO
    public static KinomiGrow GetGrow(int placeIndex) { return default(KinomiGrow); }

    // TODO
    public static void SetGrow(int placeIndex, KinomiGrow grow) { }

    // TODO
    public static KinomiData.SheetData GetKinomiDataByPlaceIndex(int placeIndex) { return null; }

    // TODO
    public static void UpdateGrowTime() { }

    // TODO
    public static void UpdateGrowTime(int minute) { }

    // TODO
    public static void PlantKinomi(int placeIndex, ItemNo itemNo) { }

    // TODO
    public static void HarvestKinomi(int placeIndex) { }

    // TODO
    public static void GiveWater(int placeIndex) { }

    // TODO
    public static void SetDefault() { }

    // TODO
    public static GrowPhase CalcGrowPhase(KinomiGrow kinomiGrow) { return GrowPhase.Empty; }

    // TODO
    public static bool CalcGrowCompleted(KinomiGrow kinomiGrow) { return false; }

    // TODO
    public static int CalcGrowCompletedTime(KinomiData.SheetData kinomiData) { return 0; }

    // TODO
    public static int GrowIndexToPlaceIndex(int growIndex) { return 0; }

    // TODO
    public static int PlaceIndexToGrowIndex(int placeIndex) { return 0; }

    // TODO
    public static bool IsKinomiContact() { return false; }

    // TODO
    public static FieldKinomiGrowEntity IsKinomiContactEntity() { return null; }

    // TODO
    public static FieldKinomiGrowEntity IsWaterContactEntity() { return null; }

    // TODO
    public static FieldKinomiGrowEntity IsKinomiContactEntityCommon(GrowPhase phase) { return null; }

    public enum GrowPhase : int
    {
        Empty = 0,
        Seed = 1,
        Sprout = 2,
        Trunk = 3,
        Flower = 4,
        Fruit = 5,
        Invalid = 6,
    }
}