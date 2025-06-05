using System;

public static class GimmickWork
{
    private static readonly AreaID[] GearAreaIdTable = new AreaID[3]
    {
        AreaID.C08GYM0101, AreaID.C08GYM0102, AreaID.C08GYM0103
    };

    public static int GetGearRotate(AreaID areaId)
    {
        return PlayerWork.GimmickGearRotate[AreaIdToGearAreaIndex(areaId)];
    }

    public static void SetGearRotate(AreaID areaId, int deg)
    {
        PlayerWork.GimmickGearRotate[AreaIdToGearAreaIndex(areaId)] = deg;
    }

    public static int AreaIdToGearAreaIndex(AreaID areaId)
    {
        return Array.FindIndex(GearAreaIdTable, id => areaId == id);
    }

    public static int GetGearAreaCount()
    {
        return GearAreaIdTable.Length;
    }

    public static void ClearGearRotate()
    {
        PlayerWork.GimmickGearRotate = new int[GetGearAreaCount()];
    }
}