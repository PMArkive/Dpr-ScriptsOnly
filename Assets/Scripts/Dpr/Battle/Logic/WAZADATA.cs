using Pml.WazaData;
using Pml;

namespace Dpr.Battle.Logic
{
    public static class WAZADATA
    {
        // TODO
        public static WazaTarget GetWazaTarget(WazaNo id) { return WazaTarget.TARGET_OTHER_SELECT; }

        // TODO
        public static uint GetHPRecoverRatio(WazaNo id) { return 0; }

        // TODO
        public static byte GetHPReactionRatio(WazaNo id) { return 0; }

        // TODO
        public static byte GetDamageReactionRatio(WazaNo id) { return 0; }

        // TODO
        public static uint GetDamageRecoverRatio(WazaNo id) { return 0; }

        // TODO
        public static uint GetShrinkPer(WazaNo id) { return 0; }

        // TODO
        public static WazaSick GetSick(WazaNo id) { return WazaSick.WAZASICK_NONE; }

        // TODO
        public static int GetSickPer(WazaNo id) { return 0; }

        // TODO
        public static byte GetType(WazaNo id) { return 0; }

        // TODO
        public static WazaCategory GetCategory(WazaNo id) { return WazaCategory.SIMPLE_DAMAGE; }

        // TODO
        public static WazaDamageType GetDamageType(WazaNo id) { return WazaDamageType.NONE; }

        // TODO
        public static SickContParam GetSickCont(WazaNo id) { return default; }

        // TODO
        public static WazaRankEffect GetRankEffect(WazaNo id, uint idx, out int volume)
        {
            volume = 0;
            return WazaRankEffect.NONE;
        }

        // TODO
        public static byte GetRankEffectCount(WazaNo id) { return 0; }

        // TODO
        public static int GetRankEffectPer(WazaNo id, uint idx) { return 0; }

        // TODO
        public static uint GetPower(WazaNo id) { return 0; }

        // TODO
        public static ushort GetHitPer(WazaNo id) { return 0; }

        public static uint GetHitCountMax(WazaNo id)
        {
            return WazaDataSystem.GetHitCountMax(id);
        }

        public static uint GetHitCountMin(WazaNo id)
        {
            return WazaDataSystem.GetHitCountMin(id);
        }

        // TODO
        public static int GetAISeqNo(WazaNo id) { return 0; }

        // TODO
        public static bool GetFlag(WazaNo id, WazaFlag flag) { return false; }

        // TODO
        public static bool IsValid(WazaNo id) { return false; }

        // TODO
        public static bool IsAlwaysHit(WazaNo id) { return false; }

        // TODO
        public static bool IsMustCritical(WazaNo id) { return false; }

        // TODO
        public static byte GetCriticalRank(WazaNo id) { return 0; }

        // TODO
        public static uint GetMaxPP(WazaNo id, uint ppup_cnt) { return 0; }

        // TODO
        public static BtlWeather GetWeather(WazaNo id) { return BtlWeather.BTL_WEATHER_NONE; }

        // TODO
        public static int GetPriority(WazaNo id) { return 0; }

        // TODO
        public static bool IsDamage(WazaNo id) { return false; }

        // TODO
        public static byte GetGPower(WazaNo wazano) { return 0; }
    }
}