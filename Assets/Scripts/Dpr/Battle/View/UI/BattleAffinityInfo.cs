using Dpr.Battle.Logic;
using Pml;
using Pml.Battle;
using System.Collections.Generic;

namespace Dpr.Battle.View.UI
{
	public class BattleAffinityInfo
	{
		private static BtlvPos[] kVposList_Single_Near = new BtlvPos[] { BtlvPos.BTL_VPOS_NEAR_1 };
		private static BtlvPos[] kVposList_Single_Far = new BtlvPos[]  { BtlvPos.BTL_VPOS_FAR_1 };
        private static BtlvPos[] kVposList_Double_Near = new BtlvPos[] { BtlvPos.BTL_VPOS_NEAR_1, BtlvPos.BTL_VPOS_NEAR_2 };
        private static BtlvPos[] kVposList_Double_Fa = new BtlvPos[]   { BtlvPos.BTL_VPOS_FAR_1,  BtlvPos.BTL_VPOS_FAR_2 };
        private static BtlvPos[] kVposList_Raid_Near = new BtlvPos[]   { BtlvPos.BTL_VPOS_NEAR_1, BtlvPos.BTL_VPOS_NEAR_2, BtlvPos.BTL_VPOS_NEAR_3, BtlvPos.BTL_VPOS_NEAR_4 };
        private static BtlvPos[] kVposList_Raid_Far = new BtlvPos[]    { BtlvPos.BTL_VPOS_FAR_1 };
        private static readonly List<TypeAffinity.AboutAffinityID> AboutAffinityPriority = new List<TypeAffinity.AboutAffinityID>()
		{
			TypeAffinity.AboutAffinityID.NONE,
			TypeAffinity.AboutAffinityID.DISADVANTAGE,
			TypeAffinity.AboutAffinityID.NORMAL,
			TypeAffinity.AboutAffinityID.ADVANTAGE,
		};
		
		// TODO
		public static List<BTL_POKEPARAM> GetBattleTargets() { return default; }
		
		// TODO
		public static bool GetAboutAffinity(BTL_POKEPARAM bpp, WazaNo wazaNo, BTL_POKEPARAM target, out TypeAffinity.AboutAffinityID destAffinity)
		{
			destAffinity = default;
			return default;
		}
		
		// TODO
		public static bool CheckWazaAffinity(BTL_POKEPARAM bpp, WazaNo wazaNo, List<BTL_POKEPARAM> targets, out TypeAffinity.AboutAffinityID destAffinity)
        {
            destAffinity = default;
            return default;
        }
	}
}