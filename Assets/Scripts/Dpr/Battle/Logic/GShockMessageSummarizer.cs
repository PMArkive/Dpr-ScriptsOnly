using Pml.PokePara;
using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public static class GShockMessageSummarizer
	{
		private static readonly RankEffectDesc[] RANK_EFFECT_DESC = new RankEffectDesc[]
		{
			new RankEffectDesc(GShock.Effect.RANKUP_ATK,      WazaRankEffect.ATTACK,         1, (ushort)BtlEff.BTLEFF_STATUS_UP,   BTL_STRID_SET.Rankup_ATK,   BTL_STRID_STD.GShockWave_RankUp_ATK),
			new RankEffectDesc(GShock.Effect.RANKUP_DEF,      WazaRankEffect.DEFENCE,        1, (ushort)BtlEff.BTLEFF_STATUS_UP,   BTL_STRID_SET.Rankup_ATK,   BTL_STRID_STD.GShockWave_RankUp_ATK),
			new RankEffectDesc(GShock.Effect.RANKUP_SPATK,    WazaRankEffect.SP_ATTACK,      1, (ushort)BtlEff.BTLEFF_STATUS_UP,   BTL_STRID_SET.Rankup_ATK,   BTL_STRID_STD.GShockWave_RankUp_ATK),
			new RankEffectDesc(GShock.Effect.RANKUP_SPDEF,    WazaRankEffect.SP_DEFENCE,     1, (ushort)BtlEff.BTLEFF_STATUS_UP,   BTL_STRID_SET.Rankup_ATK,   BTL_STRID_STD.GShockWave_RankUp_ATK),
			new RankEffectDesc(GShock.Effect.RANKUP_AGI,      WazaRankEffect.AGILITY,        1, (ushort)BtlEff.BTLEFF_STATUS_UP,   BTL_STRID_SET.Rankup_ATK,   BTL_STRID_STD.GShockWave_RankUp_ATK),
			new RankEffectDesc(GShock.Effect.RANKUP_CRITICAL, WazaRankEffect.CRITICAL_RATIO, 1, (ushort)BtlEff.BTLEFF_STATUS_UP,   BTL_STRID_SET.KiaiDame,     BTL_STRID_STD.GShockWave_RankUp_CRITICAL),
			new RankEffectDesc(GShock.Effect.RANKDOWN_ATK,    WazaRankEffect.ATTACK,         1, (ushort)BtlEff.BTLEFF_STATUS_DOWN, BTL_STRID_SET.Rankdown_ATK, BTL_STRID_STD.GShockWave_RankDown_ATK),
			new RankEffectDesc(GShock.Effect.RANKDOWN_DEF,    WazaRankEffect.DEFENCE,        1, (ushort)BtlEff.BTLEFF_STATUS_DOWN, BTL_STRID_SET.Rankdown_ATK, BTL_STRID_STD.GShockWave_RankDown_ATK),
			new RankEffectDesc(GShock.Effect.RANKDOWN_SPATK,  WazaRankEffect.SP_ATTACK,      1, (ushort)BtlEff.BTLEFF_STATUS_DOWN, BTL_STRID_SET.Rankdown_ATK, BTL_STRID_STD.GShockWave_RankDown_ATK),
			new RankEffectDesc(GShock.Effect.RANKDOWN_SPDEF,  WazaRankEffect.SP_DEFENCE,     1, (ushort)BtlEff.BTLEFF_STATUS_DOWN, BTL_STRID_SET.Rankdown_ATK, BTL_STRID_STD.GShockWave_RankDown_ATK),
			new RankEffectDesc(GShock.Effect.RANKDOWN_AGI,    WazaRankEffect.AGILITY,        1, (ushort)BtlEff.BTLEFF_STATUS_DOWN, BTL_STRID_SET.Rankdown_ATK, BTL_STRID_STD.GShockWave_RankDown_ATK),
            new RankEffectDesc(GShock.Effect.RANKDOWN_AGI2,   WazaRankEffect.AGILITY,        2, (ushort)BtlEff.BTLEFF_STATUS_DOWN, BTL_STRID_SET.Rankdown_ATK, BTL_STRID_STD.GShockWave_RankDown_ATK),
            new RankEffectDesc(GShock.Effect.RANKDOWN_AVOID,  WazaRankEffect.AVOID,          1, (ushort)BtlEff.BTLEFF_STATUS_DOWN, BTL_STRID_SET.Rankdown_ATK, BTL_STRID_STD.GShockWave_RankDown_ATK),
        };
		private static readonly SickDesc[] SICK_DESC = new SickDesc[]
		{
			new SickDesc((ushort)BtlEff.BTLEFF_MAHI,     BTL_STRID_SET.MahiGet,     BTL_STRID_STD.GShockWave_Mahi),
			new SickDesc((ushort)BtlEff.BTLEFF_NEMURI,   BTL_STRID_SET.NemuriGet,   BTL_STRID_STD.GShockWave_Nemuri),
			new SickDesc((ushort)BtlEff.BTLEFF_KOORI,    BTL_STRID_SET.KoriGet,     BTL_STRID_STD.GShockWave_Koori),
			new SickDesc((ushort)BtlEff.BTLEFF_YAKEDO,   BTL_STRID_SET.YakedoGet,   BTL_STRID_STD.GShockWave_Yakedo),
			new SickDesc((ushort)BtlEff.BTLEFF_DOKU,     BTL_STRID_SET.DokuGet,     BTL_STRID_STD.GShockWave_Doku),
			new SickDesc((ushort)BtlEff.BTLEFF_KONRAN,   BTL_STRID_SET.KonranGet,   BTL_STRID_STD.GShockWave_Konran),
			new SickDesc((ushort)BtlEff.BTLEFF_MEROMERO, BTL_STRID_SET.MeromeroGet, BTL_STRID_STD.GShockWave_MeroMero),
		};
		private static CureSickDesc[] CURESICK_DESC = new CureSickDesc[]
		{
			new CureSickDesc() { sick = Sick.MAHI,   message_unit = BTL_STRID_SET.MahiCure },
			new CureSickDesc() { sick = Sick.NEMURI, message_unit = BTL_STRID_SET.NemuriWake },
			new CureSickDesc() { sick = Sick.KOORI,  message_unit = BTL_STRID_SET.KoriMelt },
			new CureSickDesc() { sick = Sick.YAKEDO, message_unit = BTL_STRID_SET.YakedoCure },
			new CureSickDesc() { sick = Sick.DOKU,   message_unit = BTL_STRID_SET.DokuCure },
		};
		private static readonly OthersDesc[] OTHERS_DESC = new OthersDesc[]
		{
			new OthersDesc() { gShockEffect = GShock.Effect.TOOSENBOU,    message_unit = BTL_STRID_SET.CantEscWaza,          message_summarized = BTL_STRID_STD.GShockWave_CantEsc },
			new OthersDesc() { gShockEffect = GShock.Effect.AKUBI,        message_unit = BTL_STRID_SET.Akubi,                message_summarized = BTL_STRID_STD.GShockWave_Sick },
			new OthersDesc() { gShockEffect = GShock.Effect.ICHAMON,      message_unit = BTL_STRID_SET.Ichamon,              message_summarized = BTL_STRID_STD.GShockWave_Ichamon },
			new OthersDesc() { gShockEffect = GShock.Effect.SUNAZIGOKU,   message_unit = BTL_STRID_SET.Sunajigoku_Start,     message_summarized = BTL_STRID_STD.GShockWave_Sunajigoku },
			new OthersDesc() { gShockEffect = GShock.Effect.HONOONOUZU,   message_unit = BTL_STRID_SET.HonoNoUzu_Start,      message_summarized = BTL_STRID_STD.GShockWave_HonoNoUzu },
			new OthersDesc() { gShockEffect = GShock.Effect.RECOVER_HP,   message_unit = BTL_STRID_SET.HP_Recover,           message_summarized = BTL_STRID_STD.GShockWave_HP_Recover },
			new OthersDesc() { gShockEffect = GShock.Effect.DECREMENT_PP, message_unit = BTL_STRID_SET.GShockWave_PP_Reduce, message_summarized = BTL_STRID_STD.GShockWave_PP_Reduce },
		};
		
		// TODO
		private static bool rank_GetDesc(ref RankEffectDesc pParam, GShock.Effect gShockEffect) { return default; }
		
		// TODO
		private static void rank_SetupMessage_Unit(StrParam pStrParam, GShock.Effect gShockEffect, byte pokeID, int volume) { }
		
		// TODO
		private static void rank_GetMessageParam(StrParam pStrParam, GShock.Effect gShockEffect) { }
		
		// TODO
		private static void rank_SetupMessage(out byte pDefaultEffectCount, out byte pUniqueEffectPokeID, in GShockEffectParam gShockEffectParam)
		{
			pDefaultEffectCount = default;
			pUniqueEffectPokeID = default;
		}
		
		// TODO
		private static void rank_SetupMessage(StrParam pStrParam, in GShockEffectParam gShockEffectParam) { }
		
		// TODO
		private static bool sick_GetDesc(out SickDesc pParam, ushort effectNo)
		{
			pParam = default;
			return false;
		}
		
		// TODO
		private static void sick_SetupMessage_Unit(StrParam pStrParam, ushort effectNo, ushort pokeID) { }
		
		// TODO
		private static void sick_SetupMessage_Plural(StrParam pStrParam, ushort effectNo) { }
		
		// TODO
		private static void sick_GetMessageParam(out byte pTargetCount, out byte pEffectNoCount, out byte pUniqueEffectPokeID, out ushort pUniqueEffectNo, in GShockEffectParam gShockEffectParam)
		{
			pTargetCount = default;
			pEffectNoCount = default;
			pUniqueEffectPokeID = default;
			pUniqueEffectNo = default;
		}
		
		// TODO
		private static void sick_SetupMessage(StrParam pStrParam, in GShockEffectParam gShockEffectParam) { }
		
		// TODO
		private static bool cureSick_GetDesc(CureSickDesc pParam, Sick sick) { return default; }
		
		// TODO
		private static void cureSick_SetupMessage_Unit(StrParam pStrParam, Sick sick, ushort pokeID) { }
		
		// TODO
		private static void cureSick_GetMessageParam(out byte pTargetCount, out byte pUniqueEffectPokeID, out Sick pUniqueCuredSick, in GShockEffectParam gShockEffectParam)
		{
			pTargetCount = default;
			pUniqueEffectPokeID = default;
			pUniqueCuredSick = default;
        }
		
		// TODO
		private static void cureSick_SetupMessage(StrParam pStrParam, in GShockEffectParam gShockEffectParam) { }
		
		// TODO
		private static bool others_GetDesc(OthersDesc pParam, GShock.Effect gShockEffect) { return default; }
		
		// TODO
		private static void others_SetupMessage_Unit(StrParam pStrParam, GShock.Effect gShockEffect, byte pokeID) { }
		
		// TODO
		private static void others_SetupMessage_Plural(StrParam pStrParam, GShock.Effect gShockEffect) { }
		
		// TODO
		private static void others_GetMessageParam(out byte pTargetCount, out byte pUniqueEffectPokeID, in GShockEffectParam gShockEffectParam)
		{
			pTargetCount = default;
			pUniqueEffectPokeID = default;
		}
		
		// TODO
		private static void others_SetupMessage(StrParam pStrParam, in GShockEffectParam gShockEffectParam) { }
		
		// TODO
		public static void SetupMessage(StrParam pStrParam, GShockEffectParam param) { }

		private struct RankEffectDesc
		{
			public GShock.Effect gShockEffect;
			public WazaRankEffect rankEffect;
			public int rankVolume;
			public ushort defaultEffectNo;
			public ushort message_unit;
			public ushort message_summarized;
			
			public RankEffectDesc(GShock.Effect gShockEffect, WazaRankEffect rankEffect, int rankVolume, ushort defaultEffectNo, ushort message_unit, ushort message_summarized)
			{
				this.gShockEffect = gShockEffect;
				this.rankEffect = rankEffect;
				this.rankVolume = rankVolume;
				this.defaultEffectNo = defaultEffectNo;
				this.message_unit = message_unit;
				this.message_summarized = message_summarized;
			}
		}

		private class SickDesc
		{
			public ushort effectNo;
			public ushort message_unit;
			public ushort message_summarized;
			
			public SickDesc(ushort effectNo, ushort message_unit, ushort message_summarized)
			{
				this.effectNo = effectNo;
				this.message_unit = message_unit;
				this.message_summarized = message_summarized;
			}
		}

		private class CureSickDesc
		{
			public Sick sick;
			public ushort message_unit;
		}

		private class OthersDesc
		{
			public GShock.Effect gShockEffect;
			public ushort message_unit;
			public ushort message_summarized;
		}
	}
}