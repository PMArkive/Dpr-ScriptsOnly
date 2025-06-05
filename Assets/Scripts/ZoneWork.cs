using Pml.Personal;

public class ZoneWork
{
    public static bool GetEnableTeleportFlag(ZoneID zoneid)
    {
        var mapInfo = GameManager.mapInfo[(int)zoneid];
        return mapInfo.Fly && mapInfo.MapType == MapType.MAPTYPE_TOWN;
    }

    public static bool GetEnableFlyFlag(ZoneID zoneid)
    {
        var mapInfo = GameManager.mapInfo[(int)zoneid];
        return mapInfo.Fly;
    }

    public static bool IsSinouField(ZoneID zoneid)
    {
        var mapInfo = GameManager.mapInfo[(int)zoneid];
        return false;
    }

    public static bool IsPokecen(ZoneID zone_id)
    {
        return IsPokecen1F(zone_id) || IsPokecen2F(zone_id) || IsPokecenB1(zone_id);
    }

    public static bool IsPokecen1F(ZoneID zone_id)
    {
        switch (zone_id)
        {
            case ZoneID.C01PC0101:
            case ZoneID.C02PC0101:
            case ZoneID.C03PC0101:
            case ZoneID.C04PC0101:
            case ZoneID.C05PC0101:
            case ZoneID.C06PC0101:
            case ZoneID.C07PC0101:
            case ZoneID.C08PC0101:
            case ZoneID.C09PC0101:
            case ZoneID.C10PC0101:
            case ZoneID.C10R0101:
            case ZoneID.C11PC0101:
            case ZoneID.T01R0201:
            case ZoneID.T02PC0101:
            case ZoneID.T03PC0101:
            case ZoneID.T04PC0101:
            case ZoneID.T05PC0101:
            case ZoneID.T06PC0101:
            case ZoneID.T07PC0101:
                return true;

            default:
                return false;
        }
    }

    public static bool IsPokecen2F(ZoneID zone_id)
    {
        switch (zone_id)
        {
            case ZoneID.C01PC0102:
            case ZoneID.C02PC0102:
            case ZoneID.C03PC0102:
            case ZoneID.C04PC0102:
            case ZoneID.C05PC0102:
            case ZoneID.C06PC0102:
            case ZoneID.C07PC0102:
            case ZoneID.C08PC0102:
            case ZoneID.C09PC0102:
            case ZoneID.C10PC0102:
            case ZoneID.C11PC0102:
            case ZoneID.T02PC0102:
            case ZoneID.T03PC0102:
            case ZoneID.T04PC0102:
            case ZoneID.T05PC0102:
            case ZoneID.T06PC0102:
            case ZoneID.T07PC0102:
                return true;

            default:
                return false;
        }
    }

    public static bool IsPokecenB1(ZoneID zone_id)
    {
        switch (zone_id)
        {
            case ZoneID.C01PC0103:
            case ZoneID.C02PC0103:
            case ZoneID.C03PC0103:
            case ZoneID.C04PC0103:
            case ZoneID.C05PC0103:
            case ZoneID.C06PC0103:
            case ZoneID.C07PC0103:
            case ZoneID.C08PC0103:
            case ZoneID.C09PC0103:
            case ZoneID.C10PC0103:
            case ZoneID.C11PC0103:
            case ZoneID.T02PC0103:
            case ZoneID.T03PC0103:
            case ZoneID.T04PC0103:
            case ZoneID.T05PC0103:
            case ZoneID.T06PC0103:
            case ZoneID.T07PC0103:
                return true;

            default:
                return false;
        }
    }

    public static bool IsDungeon(ZoneID zoneid)
    {
        switch (zoneid)
        {
            case ZoneID.D05R0104:
            case ZoneID.D05R0105:
            case ZoneID.D05R0114:
            case ZoneID.D05R0115:
            case ZoneID.D05R0116:
            case ZoneID.D05R0117:
                return true;

            default:
                return GameManager.mapInfo[(int)zoneid].MapType == MapType.MAPTYPE_CAVE;
        }
    }

    public static bool IsRoom(ZoneID zoneid)
    {
        var mapInfo = GameManager.mapInfo[(int)zoneid];
        return mapInfo.MapType == MapType.MAPTYPE_ROOM || mapInfo.MapType == MapType.MAPTYPE_POKECEN;
    }

    public static bool IsOutDoor(ZoneID zoneid)
    {
        var mapInfo = GameManager.mapInfo[(int)zoneid];
        return mapInfo.MapType == MapType.MAPTYPE_TOWN || mapInfo.MapType == MapType.MAPTYPE_ROAD;
    }

    public static bool IsCommPlayableZone(ZoneID zone_id)
    {
        return IsCommPlayableZone(zone_id);
    }

    public static bool IsUnionRoom(ZoneID zone_id)
    {
        switch (zone_id)
        {
            case ZoneID.UNION01:
            case ZoneID.UNION02:
            case ZoneID.UNION03:
                return true;

            default:
                return false;
        }
    }

    public static bool IsUnderGround(ZoneID zone_id)
    {
        if (PlayerWork.zoneID == ZoneID.UNKNOWN)
            return false;

        return GameManager.mapInfo[(int)PlayerWork.zoneID].MapType == MapType.MAPTYPE_UNDERGROUND;
    }

    public static bool IsUnderGroundRoad(ZoneID zone_id)
    {
        switch (zone_id)
        {
            case ZoneID.UGA01:
            case ZoneID.UGA02:
            case ZoneID.UGA03:
            case ZoneID.UGA04:
            case ZoneID.UGA05:
            case ZoneID.UGA06:
            case ZoneID.UGA07:
            case ZoneID.UGA08:
            case ZoneID.UGA09:
            case ZoneID.UGA10:
            case ZoneID.UGB01:
            case ZoneID.UGB02:
            case ZoneID.UGB03:
            case ZoneID.UGB04:
            case ZoneID.UGB05:
            case ZoneID.UGB06:
            case ZoneID.UGB07:
            case ZoneID.UGC01:
            case ZoneID.UGD01:
            case ZoneID.UGD02:
            case ZoneID.UGD03:
            case ZoneID.UGD04:
            case ZoneID.UGD05:
            case ZoneID.UGE01:
            case ZoneID.UGE02:
            case ZoneID.UGE03:
            case ZoneID.UGE04:
            case ZoneID.UGE05:
            case ZoneID.UGF01:
            case ZoneID.UGF02:
            case ZoneID.UGF03:
            case ZoneID.UGF04:
            case ZoneID.UGF05:
            case ZoneID.UGF06:
            case ZoneID.UGF07:
                return true;

            default:
                return false;
        }
    }

    public static bool IsSpFishingZone(ZoneID zone_id)
    {
        return zone_id == ZoneID.D05R0113;
    }

    public static bool IsHillBackZone(ZoneID zone_id)
    {
        return zone_id == ZoneID.D23R0101;
    }

    public static bool IsNaturalPark(ZoneID zone_id)
    {
        return zone_id == ZoneID.D11R0101;
    }

    public static bool IsUseTenkainofueZone(ZoneID zone_id)
    {
#if PEARL
        return zone_id == ZoneID.D05R0115;
#else
        return zone_id == ZoneID.D05R0114;
#endif
    }

    public static bool IsSafariZone(ZoneID zone_id)
    {
        switch (zone_id)
        {
            case ZoneID.D06R0201:
            case ZoneID.D06R0202:
            case ZoneID.D06R0203:
            case ZoneID.D06R0204:
            case ZoneID.D06R0205:
            case ZoneID.D06R0206:
                return true;

            default:
                return false;
        }
    }

    public static int SafariZonePosID(ZoneID zone_id)
    {
        switch (zone_id)
        {
            case ZoneID.D06R0201: return 0;
            case ZoneID.D06R0202: return 1;
            case ZoneID.D06R0203: return 2;
            case ZoneID.D06R0204: return 3;
            case ZoneID.D06R0205: return 4;
            case ZoneID.D06R0206: return 5;
            default: return 0;
        }
    }

    public static bool IsSecretBase(ZoneID zone_id)
    {
        switch (zone_id)
        {
            case ZoneID.UGAASECRETBASE01:
            case ZoneID.UGAASECRETBASE02:
            case ZoneID.UGAASECRETBASE03:
            case ZoneID.UGABSECRETBASE01:
            case ZoneID.UGABSECRETBASE02:
            case ZoneID.UGABSECRETBASE03:
            case ZoneID.UGBASECRETBASE01:
            case ZoneID.UGBASECRETBASE02:
            case ZoneID.UGBASECRETBASE03:
            case ZoneID.UGCASECRETBASE01:
            case ZoneID.UGCASECRETBASE02:
            case ZoneID.UGCASECRETBASE03:
            case ZoneID.UGDASECRETBASE01:
            case ZoneID.UGDASECRETBASE02:
            case ZoneID.UGDASECRETBASE03:
            case ZoneID.UGEASECRETBASE01:
            case ZoneID.UGEASECRETBASE02:
            case ZoneID.UGEASECRETBASE03:
            case ZoneID.UGFASECRETBASE01:
            case ZoneID.UGFASECRETBASE02:
            case ZoneID.UGFASECRETBASE03:
                return true;

            default:
                return false;
        }
    }

    public static bool BicBgmStopZone(ZoneID zone_id)
    {
        switch (zone_id)
        {
            case ZoneID.D01R0101:
            case ZoneID.D01R0102:
            case ZoneID.D05R0101:
            case ZoneID.D05R0102:
            case ZoneID.D05R0103:
            case ZoneID.D05R0106:
            case ZoneID.D05R0107:
            case ZoneID.D05R0108:
            case ZoneID.D05R0109:
            case ZoneID.D05R0110:
            case ZoneID.D05R0111:
            case ZoneID.D05R0112:
            case ZoneID.D05R0113:
                return true;

            default:
                return false;
        }
    }

    public static ZoneID TairyouHassei_ZoneID()
    {
        return TairyouHassei_Zone_Data(RandomGroupWork.GetDailyRandom() % 28);
        
    }

    private static ZoneID TairyouHassei_Zone_Data(int index)
    {
        switch (index)
        {
            case 0: return ZoneID.R201;
            case 1: return ZoneID.R202;
            case 2: return ZoneID.R203;
            case 3: return ZoneID.R206;
            case 4: return ZoneID.R207;
            case 5: return ZoneID.R208;
            case 6: return ZoneID.R209;
            case 7: return ZoneID.R213;
            case 8: return ZoneID.R214;
            case 9: return ZoneID.R215;
            case 10: return ZoneID.R216;
            case 11: return ZoneID.R217;
            case 12: return ZoneID.R218;
            case 13: return ZoneID.R221;
            case 14: return ZoneID.R222;
            case 15: return ZoneID.R224;
            case 16: return ZoneID.R225;
            case 17: return ZoneID.W226;
            case 18: return ZoneID.R227;
            case 19: return ZoneID.R228;
            case 20: return ZoneID.R229;
            case 21: return ZoneID.W230;
            case 22: return ZoneID.D27R0102;
            case 23: return ZoneID.D28R0102;
            case 24: return ZoneID.D29R0102;
            case 25: return ZoneID.D02;
            case 26: return ZoneID.D03R0101;
            case 27: return ZoneID.D04;
            default: return ZoneID.UNKNOWN;
        }
    }

    public static MonsLv[] TairyouHassei_MonsLv(ZoneID zonid)
    {
        return GameManager.GetFieldEncountData(zonid).tairyo;
    }

    public static bool IsModoriNoDoukutsu(ZoneID zone_id)
    {
        switch (zone_id)
        {
            case ZoneID.D17R0102:
            case ZoneID.D17R0103:
            case ZoneID.D17R0104:
            case ZoneID.D17R0105:
            case ZoneID.D17R0106:
            case ZoneID.D17R0107:
            case ZoneID.D17R0108:
            case ZoneID.D17R0109:
            case ZoneID.D17R0110:
            case ZoneID.D17R0111:
            case ZoneID.D17R0112:
            case ZoneID.D17R0113:
            case ZoneID.D17R0114:
            case ZoneID.D17R0115:
            case ZoneID.D17R0116:
            case ZoneID.D17R0117:
            case ZoneID.D17R0118:
            case ZoneID.D17R0119:
            case ZoneID.D17R0120:
            case ZoneID.D17R0121:
            case ZoneID.D17R0122:
                return true;

            default:
                return false;
        }
    }

    // TODO
    public static EvolveCond GetShinkaPlaceID(ZoneID zone_id) { return 0; }

    public static bool NoFishingZone(ZoneID zone_id)
    {
        return zone_id == ZoneID.D10R0101;
    }
}