using System;

namespace DPData
{
    [Serializable]
    public struct PLAYER_SAVE_DATA
    {
        public bool gear_type;
        public bool shoes_flag;
        public uint form;
        public byte bic_color;
        public WorpPoint worpPoint;
        public float walkcount;
        public int natuki_walkcnt;
        public LOCATION_WORK TownMapLocation;
        public bool isTokushuLocation;
        public LOCATION_WORK TokushuLocation;

        // TODO: Some of the values here are getting assigned weirdly, but I think this is right
        public PLAYER_SAVE_DATA(int a)
        {
            worpPoint.teleport.zoneID = (int)ZoneID.T01R0201;
            walkcount = 0.0f;

            TokushuLocation.zoneID = 0;
            TokushuLocation.posX = 0.0f;
            TokushuLocation.posY = 0.0f;
            TokushuLocation.posZ = 0.0f;

            worpPoint.zenmetu.zoneID = 0; // Couldn't find this one?
            worpPoint.zenmetu.posX = 6.0f;
            worpPoint.zenmetu.posY = 0.0f;
            worpPoint.zenmetu.posZ = 8.0f;
            worpPoint.zenmetu.dir = 3;

            TownMapLocation.posX = -116.0f;
            TownMapLocation.posY = 1.0f;
            TownMapLocation.posZ = 886.0f;
            TownMapLocation.dir = 0;

            gear_type = false;
            shoes_flag = false;
            form = 0;

            worpPoint.teleport.posX = 0.0f;
            worpPoint.teleport.posY = 0.0f;
            worpPoint.teleport.posZ = 0.0f;
            worpPoint.teleport.dir = 0;

            worpPoint.ananuke.zoneID = 0;
            worpPoint.ananuke.posX = 0.0f;
            worpPoint.ananuke.posY = 0.0f;
            worpPoint.ananuke.posZ = 0.0f;
            worpPoint.ananuke.dir = 0;

            isTokushuLocation = false;
            natuki_walkcnt = 0;
            TownMapLocation.zoneID = (int)ZoneID.T01;
            TokushuLocation.dir = 0;
            bic_color = 0;
        }
    }
}