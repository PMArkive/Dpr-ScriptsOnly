using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public static class sick
	{
		private static readonly getCureStrIDTable_t[] getCureStrIDTable = new getCureStrIDTable_t[]
		{
			new getCureStrIDTable_t(WazaSick.WAZASICK_DOKU,         BTL_STRID_SET.DokuCure,        BTL_STRID_SET.UseItem_CureDoku),
			new getCureStrIDTable_t(WazaSick.WAZASICK_YAKEDO,       BTL_STRID_SET.YakedoCure,      BTL_STRID_SET.UseItem_CureYakedo),
			new getCureStrIDTable_t(WazaSick.WAZASICK_NEMURI,       BTL_STRID_SET.NemuriWake,      BTL_STRID_SET.UseItem_CureNemuri),
			new getCureStrIDTable_t(WazaSick.WAZASICK_KOORI,        BTL_STRID_SET.KoriMelt,        BTL_STRID_SET.UseItem_CureKoori),
			new getCureStrIDTable_t(WazaSick.WAZASICK_MAHI,         BTL_STRID_SET.MahiCure,        BTL_STRID_SET.UseItem_CureMahi),
			new getCureStrIDTable_t(WazaSick.WAZASICK_ENCORE,       BTL_STRID_SET.EncoreCure,      -1),
			new getCureStrIDTable_t(WazaSick.WAZASICK_KANASIBARI,   BTL_STRID_SET.KanasibariCure,  -1),
			new getCureStrIDTable_t(WazaSick.WAZASICK_SASIOSAE,     BTL_STRID_SET.SasiosaeCure,    -1),
			new getCureStrIDTable_t(WazaSick.WAZASICK_BIND,         BTL_STRID_SET.BindCure,        BTL_STRID_SET.BindCure),
			new getCureStrIDTable_t(WazaSick.WAZASICK_YADORIGI,     BTL_STRID_SET.BindCure,        BTL_STRID_SET.BindCure),
			new getCureStrIDTable_t(WazaSick.WAZASICK_TELEKINESIS,  BTL_STRID_SET.Telekinesis_End, -1),
			new getCureStrIDTable_t(WazaSick.WAZASICK_TYOUHATSU,    BTL_STRID_SET.ChouhatuCure,    -1),
			new getCureStrIDTable_t(WazaSick.WAZASICK_FLYING,       BTL_STRID_SET.DenjiFuyuCure,   -1),
			new getCureStrIDTable_t(WazaSick.WAZASICK_KAIHUKUHUUJI, BTL_STRID_SET.KaifukuFujiCure, -1),
			new getCureStrIDTable_t(WazaSick.WAZASICK_ICHAMON,      BTL_STRID_SET.IchamonCure,     -1),
			new getCureStrIDTable_t(WazaSick.WAZASICK_KONRAN,       BTL_STRID_SET.KonranCure,      BTL_STRID_SET.UseItem_CureKonran),
			new getCureStrIDTable_t(WazaSick.WAZASICK_MEROMERO,     BTL_STRID_SET.MeromeroCure,    BTL_STRID_SET.UseItem_CureMero),
		};
		
		// TODO
		public static int getCureStrID(WazaSick sick, bool fUseItem) { return default; }
		
		// TODO
		public static int getDefaultSickStrID(WazaSick sickID, in BTL_SICKCONT cont) { return default; }
		
		// TODO
		public static int getWazaSickDamageStrID(WazaSick sick) { return default; }

		private class getCureStrIDTable_t
		{
			public WazaSick sick;
			public short strID_notItem;
			public short strID_useItem;
			
			public getCureStrIDTable_t(WazaSick sick, short strID_notItem, short strID_useItem)
			{
				this.sick = sick;
				this.strID_notItem = strID_notItem;
				this.strID_useItem = strID_useItem;
			}
		}
	}
}