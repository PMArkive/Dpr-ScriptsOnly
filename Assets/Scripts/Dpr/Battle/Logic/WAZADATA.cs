using Pml.WazaData;
using Pml;

namespace Dpr.Battle.Logic
{
    public static class WAZADATA
    {
        public static WazaTarget GetWazaTarget(WazaNo id)
        {
        	WazaDataSystem.GetTarget(id);
        }

        public static uint GetHPRecoverRatio(WazaNo id)
        {
        	WazaDataSystem.GetHPRecoverRatio(id);
        }

        public static byte GetHPReactionRatio(WazaNo id)
        {
        	WazaDataSystem.GetHPReactionRatio(id);
        }

        public static byte GetDamageReactionRatio(WazaNo id)
        {
        	WazaDataSystem.GetDamageReactionRatio(id);
        }

        public static uint GetDamageRecoverRatio(WazaNo id)
        {
        	WazaDataSystem.GetDamageRecoverRatio(id);
        }

        public static uint GetShrinkPer(WazaNo id)
        {
        	WazaDataSystem.GetShrinkPer(id);
        }

        public static WazaSick GetSick(WazaNo id)
        {
        	WazaDataSystem.GetSick(id);
        }

        public static int GetSickPer(WazaNo id)
        {
        	WazaDataSystem.GetSickPer(id);
        }

        public static byte GetType(WazaNo id)
        {
        	WazaDataSystem.GetType(id);
        }

        public static WazaCategory GetCategory(WazaNo id)
        {
        	WazaDataSystem.GetCategory(id);
        }

        public static WazaDamageType GetDamageType(WazaNo id)
        {
        	WazaDataSystem.GetDamageType(id);
        }

        public static SickContParam GetSickCont(WazaNo id)
        {
        	var uVar1 = WazaDataSystem.GetSickCont(id);
        	return uVar1;
        }

        public static WazaRankEffect GetRankEffect(WazaNo id, uint idx, out int volume)
        {
        	WazaDataSystem.GetRankEffect();
        }

        public static byte GetRankEffectCount(WazaNo id)
        {
        	WazaDataSystem.GetRankEffectCount(id);
        }

        public static int GetRankEffectPer(WazaNo id, uint idx)
        {
        	WazaDataSystem.GetRankEffectPer(id,idx);
        }

        public static uint GetPower(WazaNo id)
        {
        	WazaDataSystem.GetPower(id);
        }

        public static ushort GetHitPer(WazaNo id)
        {
        	WazaDataSystem.GetHitPer(id);
        }

        public static uint GetHitCountMax(WazaNo id)
        {
            return WazaDataSystem.GetHitCountMax(id);
        }

        public static uint GetHitCountMin(WazaNo id)
        {
            return WazaDataSystem.GetHitCountMin(id);
        }

        public static int GetAISeqNo(WazaNo id)
        {
        	WazaDataSystem.GetAISeqNo(id);
        }

        public static bool GetFlag(WazaNo id, WazaFlag flag)
        {
        	WazaDataSystem.GetFlag(id,flag);
        }

        public static bool IsValid(WazaNo id)
        {
        	WazaDataSystem.IsValid(id);
        }

        public static bool IsAlwaysHit(WazaNo id)
        {
        	WazaDataSystem.IsAlwaysHit(id);
        }

        public static bool IsMustCritical(WazaNo id)
        {
        	WazaDataSystem.IsMustCritical(id);
        }

        public static byte GetCriticalRank(WazaNo id)
        {
        	WazaDataSystem.GetCriticalRank(id);
        }

        public static uint GetMaxPP(WazaNo id, uint ppup_cnt)
        {
        	WazaDataSystem.GetMaxPP(id,ppup_cnt);
        }

        public static BtlWeather GetWeather(WazaNo id)
        {
        	WazaDataSystem.GetWeather(id);
        }

        public static int GetPriority(WazaNo id)
        {
        	WazaDataSystem.GetPriority(id);
        }

        public static bool IsDamage(WazaNo id)
        {
        	WazaDataSystem.IsDamage(id);
        }

        public static byte GetGPower(WazaNo wazano)
        {
        	WazaDataSystem.GetGPower(wazano);
        }
    }
}