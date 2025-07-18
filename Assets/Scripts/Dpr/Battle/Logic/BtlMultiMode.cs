﻿namespace Dpr.Battle.Logic
{
    public enum BtlMultiMode : byte
    {
        BTL_MULTIMODE_NONE = 0,
        BTL_MULTIMODE_PP_PP = 1,
        BTL_MULTIMODE_PP_AA = 2,
        BTL_MULTIMODE_PA_AA = 3,
        BTL_MULTIMODE_P_AA = 4,
        BTL_MULTIMODE_PA_A = 5,
        BTL_MULTIMODE_PA_A2 = 6,
        BTL_MULTIMODE_RAID_PPPP_A = 0,
        BTL_MULTIMODE_RAID_PPP_A = 1,
        BTL_MULTIMODE_RAID_PP_A = 2,
        BTL_MULTIMODE_RAID_P_A = 3,
        BTL_MULTIMODE_RAID_PA_A = 4,
        BTL_MULTIMODE_RAID_PAAA_A = 5,
        BTL_MULTIMODE_RAID_PPAA_A = 6,
        BTL_MULTIMODE_RAID_PPPA_A = 7,
    }
}