using Pml;
using Pml.WazaData;
using System;

namespace Dpr.Battle.Logic
{
	public class BtlAiBasic : BtlAIBaseScript
	{
		protected override void main()
		{
			var seqNo = Call(CMD_CHECK_WORKWAZA_SEQNO, Array.Empty<long>());

			// Ignored
			_ = string.Format("■PAWN basicAI start ...wazaNo = {0}[{1}],　seqNo = {2}, score={3}\n", CurrentWazaNo(), (int)CurrentWazaNo(), seqNo, p_Score);

			main_proc();

			// Ignored
			_ = string.Format("■PAWN baseAI score = {0}\n", p_Score);
		}
		
		private void main_proc()
		{
			var rule = Call(CMD_CHECK_BTL_RULE, Array.Empty<long>());

			if (rule == BTL_RULE_DOUBLE)
			{
				if (Call(CMD_IF_MIKATA_ATTACK, Array.Empty<long>()) != HAVE_NO)
					return;
            }

			if (Basic_ConaHoushi() != HAVE_YES &&
                Basic_Itazuragokoro() != HAVE_YES &&
                Basic_Sensei() != HAVE_YES &&
                Basic_Hayatenotubasa() != HAVE_YES &&
                Basic_DaimaxNG() != HAVE_YES)
			{
				var waza = CurrentWazaNo();

				// Move is not Horn Drill nor Fissure
				if (waza != WazaNo.TUNODORIRU && waza != WazaNo.ZIWARE)
				{
					var dmg = Call(CMD_CHECK_DAMAGE_WAZA, new long[] { (long)CurrentWazaNo() });
					if (dmg == 0)
					{
						Calc_BasicAll();
						return;
					}
				}

                if (Calc_BasicDamage() == HAVE_YES)
                    Calc_BasicAll();
			}
		}
		
		private int Basic_ConaHoushi()
		{
			var waza = CurrentWazaNo();

			// Move is not a powder move
			if (waza != WazaNo.DOKUNOKONA &&
				waza != WazaNo.SIBIREGONA &&
				waza != WazaNo.NEMURIGONA &&
				waza != WazaNo.KINOKONOHOUSI &&
				waza != WazaNo.IKARINOKONA &&
				waza != WazaNo.HUNZIN)
				return HAVE_NO;

			// Defensive ability is Overcoat
            if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE }) == TokuseiNo.BOUZIN)
            {
                var tokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });

				// Offensive ability is not Mold Breaker, Turboblaze, nor Teravolt
				if (tokusei != TokuseiNo.KATAYABURI &&
                    tokusei != TokuseiNo.TAABOBUREIZU &&
                    tokusei != TokuseiNo.TERABORUTEEZI)
				{
                    ScoreCtrl(-10);
                    return HAVE_YES;
                }
            }

			// Defensive type is Grass
            if ((PokeType)Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 }) == PokeType.KUSA ||
                (PokeType)Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 }) == PokeType.KUSA)
            {
                ScoreCtrl(-10);
                return HAVE_YES;
            }

			return HAVE_NO;
        }
		
		private int Basic_Itazuragokoro()
		{
			var tokuseiAtk = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var tokuseiDef = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });
            var moveCategory = (WazaDamageType)Call(CMD_CHECK_WAZA_KIND, Array.Empty<long>());

            // Offensive ability is not Prankster
            if (tokuseiAtk != TokuseiNo.ITAZURAGOKORO)
				return HAVE_NO;

			// Physical or Special move
			if (moveCategory == WazaDamageType.PHYSIC ||
				moveCategory == WazaDamageType.SPECIAL)
				return HAVE_NO;

			// Specific targetting
            var wazaTarget = (WazaTarget)Call(CMD_GET_WAZA_TARGET, Array.Empty<long>());
			if (wazaTarget != WazaTarget.TARGET_OTHER_SELECT &&
                wazaTarget != WazaTarget.TARGET_ENEMY_SELECT &&
                wazaTarget != WazaTarget.TARGET_OTHER_ALL &&
                wazaTarget != WazaTarget.TARGET_ENEMY_ALL &&
                wazaTarget != WazaTarget.TARGET_ALL &&
                wazaTarget != WazaTarget.TARGET_ENEMY_RANDOM)
				return HAVE_NO;

            // Defensive type is Dark
            if ((PokeType)Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 }) == PokeType.AKU ||
                (PokeType)Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 }) == PokeType.AKU)
            {
                ScoreCtrl(-10);
                return HAVE_YES;
            }

			// Psychic Terrain is active and Defensive Pokémon is grounded
            if (Call(CMD_IF_EXIST_GROUND, new long[] { BTL_GROUND_PHYCHO }) != HAVE_NO &&
                (PokeType)Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 }) != PokeType.HIKOU &&
                (PokeType)Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 }) != PokeType.HIKOU &&
                tokuseiDef != TokuseiNo.HUYUU)
			{
                ScoreCtrl(-10);
                return HAVE_YES;
            }

            // Defensive ability is Queenly Majesty or Dazzling
            if (tokuseiDef == TokuseiNo.ZYOOUNOIGEN ||
				tokuseiDef == TokuseiNo.BIBIDDOBODHI)
			{
                ScoreCtrl(-10);
                return HAVE_YES;
            }

            return HAVE_NO;
        }
		
		private int Basic_Sensei()
		{
            var tokuseiDef = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });
            var seqNo = Call(CMD_CHECK_WORKWAZA_SEQNO, Array.Empty<long>());

            // Affected Trainer AI Move Logic IDs
            // 103 - General Increased Priority
            // 158 - Fake Out
            // 223 - Feint
            // 248 - Sucker Punch
            // 360 - Water Shuriken
            // 364 - Baby-Doll Eyes
            // 377 - Powder
            // 382 - First Impression
            // 388 - Spotlight
            if (seqNo != 103 &&
				seqNo != 158 &&
                seqNo != 223 &&
                seqNo != 248 &&
                seqNo != 360 &&
                seqNo != 364 &&
				seqNo != 377 &&
                seqNo != 382 &&
                seqNo != 388)
                return HAVE_NO;

            // Psychic Terrain is active and Defensive Pokémon is grounded
            if (Call(CMD_IF_EXIST_GROUND, new long[] { BTL_GROUND_PHYCHO }) != HAVE_NO &&
                (PokeType)Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 }) != PokeType.HIKOU &&
                (PokeType)Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 }) != PokeType.HIKOU &&
                tokuseiDef != TokuseiNo.HUYUU)
            {
                ScoreCtrl(-10);
                return HAVE_YES;
            }

            // Defensive ability is Queenly Majesty or Dazzling
            if (tokuseiDef == TokuseiNo.ZYOOUNOIGEN ||
                tokuseiDef == TokuseiNo.BIBIDDOBODHI)
            {
                ScoreCtrl(-10);
                return HAVE_YES;
            }

            return HAVE_NO;
        }
		
		private int Basic_Hayatenotubasa()
        {
            var tokuseiAtk = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var tokuseiDef = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // Offensive ability is not Gale Wings
            if (tokuseiAtk != TokuseiNo.HAYATENOTUBASA)
                return HAVE_NO;

			// Offensive Pokémon's HP is not 100%
            if (Call(CMD_IF_HP_EQUAL, new long[] { CHECK_ATTACK, 100 }) == 0)
                return HAVE_NO;

			// Move is not Flying type
			if ((PokeType)Call(CMD_CHECK_WORKWAZA_TYPE, Array.Empty<long>()) != PokeType.HIKOU)
				return HAVE_NO;

            // Specific targetting
            var wazaTarget = (WazaTarget)Call(CMD_GET_WAZA_TARGET, Array.Empty<long>());
            if (wazaTarget != WazaTarget.TARGET_OTHER_SELECT &&
                wazaTarget != WazaTarget.TARGET_ENEMY_SELECT &&
                wazaTarget != WazaTarget.TARGET_OTHER_ALL &&
                wazaTarget != WazaTarget.TARGET_ENEMY_ALL &&
                wazaTarget != WazaTarget.TARGET_ALL &&
                wazaTarget != WazaTarget.TARGET_ENEMY_RANDOM)
                return HAVE_NO;

            // Psychic Terrain is active and Defensive Pokémon is grounded
            if (Call(CMD_IF_EXIST_GROUND, new long[] { BTL_GROUND_PHYCHO }) != HAVE_NO &&
                (PokeType)Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 }) != PokeType.HIKOU &&
                (PokeType)Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 }) != PokeType.HIKOU &&
                tokuseiDef != TokuseiNo.HUYUU)
            {
                ScoreCtrl(-10);
                return HAVE_YES;
            }

            // Defensive ability is Queenly Majesty or Dazzling
            if (tokuseiDef == TokuseiNo.ZYOOUNOIGEN ||
                tokuseiDef == TokuseiNo.BIBIDDOBODHI)
            {
                ScoreCtrl(-10);
                return HAVE_YES;
            }

            return HAVE_NO;
        }
		
		private int Basic_DaimaxNG()
		{
            // Defensive Pokémon is not Dynamaxed
            if (Call(CMD_IF_G, new long[] { CHECK_DEFENCE }) == 0)
                return HAVE_NO;

			switch (CurrentWazaNo())
			{
				// Move is:
				// Guillotine,  Whirlwind,  Horn Drill,  Roar,
				// Disable,     Low Kick,   Fissure,     Mimic,
				// Mirror Move, Encore,     Torment,     Skill Swap,
				// Imprison,    Grudge,     Snatch,      Sheer Cold,
				// Grass Knot,  Heavy Slam, Ally Switch, Sky Drop,
				// Heat Crash,  Instruct
				case WazaNo.HASAMIGIROTIN:
				case WazaNo.HUKITOBASI:
				case WazaNo.TUNODORIRU:
				case WazaNo.HOERU:
				case WazaNo.KANASIBARI:
				case WazaNo.KETAGURI:
				case WazaNo.ZIWARE:
				case WazaNo.MONOMANE:
				case WazaNo.OUMUGAESI:
                case WazaNo.ANKOORU:
                case WazaNo.ITYAMON:
                case WazaNo.SUKIRUSUWAPPU:
                case WazaNo.HUUIN:
                case WazaNo.ONNEN:
                case WazaNo.YOKODORI:
                case WazaNo.ZETTAIREIDO:
                case WazaNo.KUSAMUSUBI:
                case WazaNo.HEBIIBONBAA:
                case WazaNo.SAIDOTHENZI:
                case WazaNo.HURIIFOORU:
                case WazaNo.HIITOSUTANPU:
                case WazaNo.SAIHAI:
                    ScoreCtrl(-10);
                    return HAVE_YES;

				default:
					return HAVE_NO;
            }
        }
		
		private int Calc_BasicDamage()
        {
            var tokuseiAtk = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var tokuseiDef = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

			// Move Affinity is "No Effect"
            if (Call(CMD_CHECK_WAZA_AISYOU, new long[] { CHECK_ATTACK, CHECK_DEFENCE, (long)CurrentWazaNo(), AISYOU_0BAI }) != HAVE_NO)
			{
                // Move Type is Ground, Defensive Ability is Levitate
                // and Offensive ability is Mold Breaker, Turboblaze, or Teravolt
                if ((PokeType)Call(CMD_CHECK_TYPE, new long[] { CHECK_WAZA }) == PokeType.JIMEN &&
                    tokuseiDef == TokuseiNo.HUYUU &&
					(tokuseiAtk == TokuseiNo.KATAYABURI ||
                    tokuseiAtk == TokuseiNo.TAABOBUREIZU ||
                    tokuseiAtk == TokuseiNo.TERABORUTEEZI))
                    return HAVE_YES;

                var seqNo = Call(CMD_CHECK_WORKWAZA_SEQNO, Array.Empty<long>());

                // Affected Trainer AI Move Logic IDs
                // 135 - Hidden Power
                // 173 - Nature Power
                // 222 - Natural Gift
                if (seqNo != 135 &&
                    seqNo != 173 &&
                    seqNo != 222)
                {
                    ScoreCtrl(-10);
                    return HAVE_NO;
                }
				else
				{
					return HAVE_YES;
				}
            }

            // Offensive ability is Mold Breaker, Turboblaze, or Teravolt
            if (tokuseiAtk == TokuseiNo.KATAYABURI ||
                tokuseiAtk == TokuseiNo.TAABOBUREIZU ||
                tokuseiAtk == TokuseiNo.TERABORUTEEZI)
                return HAVE_YES;

			// Ignored
			_ = string.Format("とくせい = {0}\n", tokuseiDef);

			switch (tokuseiDef)
			{
                // Volt Absorb, Lightning Rod, Motor Drive
                case TokuseiNo.TIKUDEN:
				case TokuseiNo.HIRAISIN:
				case TokuseiNo.DENKIENZIN:
					return (BasicDmg_00_1() == HAVE_NO) ? HAVE_YES : HAVE_NO;

                // Water Absorb, Dry Skin, Storm Drain
                case TokuseiNo.TYOSUI:
                case TokuseiNo.KANSOUHADA:
                case TokuseiNo.YOBIMIZU:
                    return (BasicDmg_00_2() == HAVE_NO) ? HAVE_YES : HAVE_NO;

                // Flash Fire
                case TokuseiNo.MORAIBI:
                    return (BasicDmg_00_3() == HAVE_NO) ? HAVE_YES : HAVE_NO;

                // Wonder Guard
                case TokuseiNo.HUSIGINAMAMORI:
                    return (BasicDmg_00_4() == HAVE_NO) ? HAVE_YES : HAVE_NO;

                // Levitate
                case TokuseiNo.HUYUU:
                    return (BasicDmg_00_5() == HAVE_NO) ? HAVE_YES : HAVE_NO;

                // Sap Sipper
                case TokuseiNo.SOUSYOKU:
                    return (BasicDmg_00_7() == HAVE_NO) ? HAVE_YES : HAVE_NO;

                default:
					return HAVE_YES;
            }
        }

        private int BasicDmg_00_1()
		{
			// Move Type is Electric
			if ((PokeType)Call(CMD_CHECK_TYPE, new long[] { CHECK_WAZA }) == PokeType.DENKI)
            {
                ScoreCtrl(-12);
                return HAVE_YES;
            }

			return HAVE_NO;
		}
		
		private int BasicDmg_00_2()
		{
            // Move Type is Water
            if ((PokeType)Call(CMD_CHECK_TYPE, new long[] { CHECK_WAZA }) == PokeType.MIZU)
            {
                ScoreCtrl(-12);
                return HAVE_YES;
            }

            return HAVE_NO;
        }
		
		private int BasicDmg_00_3()
		{
            // Move Type is Fire
            if ((PokeType)Call(CMD_CHECK_TYPE, new long[] { CHECK_WAZA }) == PokeType.HONOO)
            {
                ScoreCtrl(-12);
                return HAVE_YES;
            }

            return HAVE_NO;
        }
		
		private int BasicDmg_00_4()
        {
            // Move Affinity is not "Super Effective" nor better
            if (Call(CMD_CHECK_WAZA_AISYOU, new long[] { CHECK_ATTACK, CHECK_DEFENCE, (long)CurrentWazaNo(), AISYOU_2BAI }) == HAVE_NO &&
                Call(CMD_CHECK_WAZA_AISYOU, new long[] { CHECK_ATTACK, CHECK_DEFENCE, (long)CurrentWazaNo(), AISYOU_4BAI }) == HAVE_NO)
            {
                ScoreCtrl(-10);
                return HAVE_YES;
            }

            return HAVE_NO;
        }
		
		private int BasicDmg_00_5()
		{
            // Move Type is Ground and there is no Gravity active
            if ((PokeType)Call(CMD_CHECK_TYPE, new long[] { CHECK_WAZA }) == PokeType.JIMEN &&
                Call(CMD_FLDEFF_CHECK, new long[] { EFF_JURYOKU }) == HAVE_NO)
            {
                ScoreCtrl(-10);
                return HAVE_YES;
            }

            return HAVE_NO;
        }
		
		private int BasicDmg_00_7()
		{
            // Move Type is Grass
            if ((PokeType)Call(CMD_CHECK_TYPE, new long[] { CHECK_WAZA }) == PokeType.KUSA)
            {
                ScoreCtrl(-12);
                return HAVE_YES;
            }

            return HAVE_NO;
        }
		
		private void Calc_BasicAll()
		{
			if (Bouon_Check() == HAVE_YES || Boudan_Check() == HAVE_YES)
				return;

            var seqNo = Call(CMD_CHECK_WORKWAZA_SEQNO, Array.Empty<long>());

            // Ignored
            _ = string.Format("シーケンス = {0} のチェックをします\n", seqNo);

			switch (seqNo)
			{
				case 1:
				case 187:
					BaciAI_Seq_001(); break;

				case 7:
					BaciAI_Seq_007(); break;

				case 8:
					BaciAI_Seq_008(); break;

				case 10:
				case 50:
				case 277:
				case 308:
				case 312:
				case 316:
				case 322:
				case 327:
					BaciAI_Seq_010(); break;

				case 11:
				case 51:
                case 156:
                case 328:
                    BaciAI_Seq_011(); break;

				case 12:
				case 52:
				case 284:
					BaciAI_Seq_012(); break;

				case 13:
				case 53:
				case 290:
				case 321:
				case 365:
					BaciAI_Seq_013(); break;

				case 14:
				case 54:
					BaciAI_Seq_014(); break;

				case 15:
				case 55:
					BaciAI_Seq_015(); break;

				case 16:
				case 56:
				case 108:
					BaciAI_Seq_016(); break;

				case 18:
				case 58:
                case 343:
                case 346:
                case 356:
                case 364:
                case 411:
                    BaciAI_Seq_018(); break;

				case 19:
				case 59:
                    BaciAI_Seq_019(); break;

				case 20:
				case 60:
                    BaciAI_Seq_020(); break;

				case 21:
				case 61:
				case 357:
                    BaciAI_Seq_021(); break;

				case 22:
				case 62:
                    BaciAI_Seq_022(); break;

				case 23:
				case 63:
                    BaciAI_Seq_023(); break;

				case 24:
				case 64:
                    BaciAI_Seq_024(); break;

				case 25:
                case 143:
                    BaciAI_Seq_025(); break;

                case 28:
                    BaciAI_Seq_028(); break;

                case 32:
                case 381:
                    BaciAI_Seq_032(); break;

                case 33:
                case 66:
                    BaciAI_Seq_033(); break;

                case 35:
                    BaciAI_Seq_035(); break;

                case 37:
                    BaciAI_Seq_037(); break;

                case 38:
                    BaciAI_Seq_038(); break;

                case 46:
                    BaciAI_Seq_046(); break;

                case 47:
                    BaciAI_Seq_047(); break;

                case 49:
                case 118:
                case 166:
                case 199:
                    BaciAI_Seq_049(); break;

                case 65:
                    BaciAI_Seq_065(); break;

                case 67:
                    BaciAI_Seq_067(); break;

                case 79:
                    BaciAI_Seq_079(); break;

                case 84:
                    BaciAI_Seq_084(); break;

                case 86:
                    BaciAI_Seq_086(); break;

                case 90:
                    BaciAI_Seq_090(); break;

                case 92:
                case 97:
                    BaciAI_Seq_092(); break;

                case 94:
                    BaciAI_Seq_094(); break;

                case 102:
                    BaciAI_Seq_102(); break;

                case 106:
                    BaciAI_Seq_106(); break;

                case 107:
                    BaciAI_Seq_107(); break;

                case 109:
                    BaciAI_Seq_109(); break;

                case 112:
                    BaciAI_Seq_112(); break;

                case 113:
                    BaciAI_Seq_113(); break;

                case 114:
                    BaciAI_Seq_114(); break;

                case 115:
                    BaciAI_Seq_115(); break;

                case 120:
                    BaciAI_Seq_120(); break;

                case 124:
                    BaciAI_Seq_124(); break;

                case 127:
                    BaciAI_Seq_127(); break;

                case 132:
                case 133:
                case 134:
                case 157:
                    BaciAI_Seq_132(); break;

                case 136:
                    BaciAI_Seq_136(); break;

                case 137:
                    BaciAI_Seq_137(); break;

                case 142:
                    BaciAI_Seq_142(); break;

                case 148:
                    BaciAI_Seq_148(); break;

                case 158:
                case 376:
                case 382:
                    BaciAI_Seq_158(); break;

                case 160:
                    BaciAI_Seq_160(); break;

                case 161:
                case 162:
                    BaciAI_Seq_161(); break;

                case 164:
                    BaciAI_Seq_164(); break;

                case 165:
                    BaciAI_Seq_165(); break;

                case 167:
                    BaciAI_Seq_167(); break;

                case 168:
                    BaciAI_Seq_168(); break;

                case 172:
                    BaciAI_Seq_172(); break;

                case 175:
                    BaciAI_Seq_175(); break;

                case 176:
                    BaciAI_Seq_176(); break;

                case 177:
                    BaciAI_Seq_177(); break;

                case 178:
                    BaciAI_Seq_178(); break;

                case 179:
                    BaciAI_Seq_179(); break;

                case 181:
                    BaciAI_Seq_181(); break;

                case 184:
                    BaciAI_Seq_184(); break;

                case 188:
                    BaciAI_Seq_188(); break;

                case 191:
                    BaciAI_Seq_191(); break;

                case 192:
                    BaciAI_Seq_192(); break;

                case 193:
                    BaciAI_Seq_193(); break;

                case 205:
                    BaciAI_Seq_205(); break;

                case 206:
                    BaciAI_Seq_206(); break;

                case 208:
                    BaciAI_Seq_208(); break;

                case 211:
                    BaciAI_Seq_211(); break;

                case 212:
                    BaciAI_Seq_212(); break;

                case 215:
                    BaciAI_Seq_215(); break;

                case 216:
                    BaciAI_Seq_216(); break;

                case 220:
                    BaciAI_Seq_220(); break;

                case 222:
                    BaciAI_Seq_222(); break;

                case 225:
                    BaciAI_Seq_225(); break;

				case 226:
                    BaciAI_Seq_226(); break;

				case 227:
                    BaciAI_Seq_227(); break;

				case 232:
                    BaciAI_Seq_232(); break;

				case 233:
                    BaciAI_Seq_233(); break;

				case 234:
                    BaciAI_Seq_234(); break;

				case 236:
                    BaciAI_Seq_236(); break;

				case 238:
                    BaciAI_Seq_238(); break;

				case 239:
                    BaciAI_Seq_239(); break;

				case 241:
                    BaciAI_Seq_241(); break;

				case 242:
                    BaciAI_Seq_242(); break;

				case 243:
                    BaciAI_Seq_243(); break;

				case 244:
                    BaciAI_Seq_244(); break;

				case 246:
                    BaciAI_Seq_246(); break;

				case 247:
                    BaciAI_Seq_247(); break;

				case 249:
                    BaciAI_Seq_249(); break;

				case 251:
                    BaciAI_Seq_251(); break;

				case 252:
                    BaciAI_Seq_252(); break;

				case 258:
                    BaciAI_Seq_258(); break;

				case 259:
                    BaciAI_Seq_259(); break;

				case 265:
                    BaciAI_Seq_265(); break;

				case 266:
                    BaciAI_Seq_266(); break;

				case 270:
                    BaciAI_Seq_270(); break;

				case 278:
                    BaciAI_Seq_278(); break;

				case 281:
                    BaciAI_Seq_281(); break;

				case 285:
                    BaciAI_Seq_285(); break;

				case 286:
                    BaciAI_Seq_286(); break;

				case 292:
                    BaciAI_Seq_292(); break;

				case 294:
                    BaciAI_Seq_294(); break;

				case 298:
                    BaciAI_Seq_298(); break;

				case 299:
                    BaciAI_Seq_299(); break;

				case 300:
                    BaciAI_Seq_300(); break;

				case 301:
                    BaciAI_Seq_301(); break;

				case 307:
                    BaciAI_Seq_307(); break;

				case 309:
				case 386:
                    BaciAI_Seq_309(); break;

				case 311:
                    BaciAI_Seq_311(); break;

				case 315:
                    BaciAI_Seq_315(); break;

				case 318:
                    BaciAI_Seq_318(); break;

				case 320:
                    BaciAI_Seq_320(); break;

				case 323:
                    BaciAI_Seq_323(); break;

				case 338:
                    BaciAI_Seq_338(); break;

				case 339:
                    BaciAI_Seq_339(); break;

				case 340:
                    BaciAI_Seq_340(); break;

				case 342:
                    BaciAI_Seq_342(); break;

				case 349:
                    BaciAI_Seq_349(); break;

				case 350:
                    BaciAI_Seq_350(); break;

				case 351:
                    BaciAI_Seq_351(); break;

				case 352:
                    BaciAI_Seq_352(); break;

				case 354:
                    BaciAI_Seq_354(); break;

				case 362:
                    BaciAI_Seq_362(); break;

				case 363:
                    BaciAI_Seq_363(); break;

				case 366:
                    BaciAI_Seq_366(); break;

				case 368:
                    BaciAI_Seq_368(); break;

				case 370:
                    BaciAI_Seq_370(); break;

				case 375:
                    BaciAI_Seq_375(); break;

				case 387:
                    BaciAI_Seq_387(); break;

				case 388:
                    BaciAI_Seq_388(); break;

				case 389:
                    BaciAI_Seq_389(); break;

				case 391:
                    BaciAI_Seq_391(); break;

				case 394:
                    BaciAI_Seq_394(); break;

				case 397:
                    BaciAI_Seq_397(); break;

				case 399:
                    BaciAI_Seq_399(); break;

				case 406:
                    BaciAI_Seq_406(); break;

				case 419:
                    BaciAI_Seq_419(); break;

				case 420:
                    BaciAI_Seq_423(); break;

				case 425:
                    BaciAI_Seq_425(); break;

				case 426:
                    BaciAI_Seq_426(); break;

				case 428:
                    BaciAI_Seq_428(); break;

				case 429:
                    BaciAI_Seq_429(); break;

				case 431:
                    BaciAI_Seq_431(); break;

				case 432:
                    BaciAI_Seq_432(); break;

				case 434:
                    BaciAI_Seq_434(); break;
            }
        }
		
		private int Bouon_Check()
        {
            // Defensive ability is Soundproof
            if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE }) == TokuseiNo.BOUON)
            {
                var tokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });

                // Offensive ability is not Mold Breaker, Turboblaze, nor Teravolt
                if (tokusei != TokuseiNo.KATAYABURI &&
                    tokusei != TokuseiNo.TAABOBUREIZU &&
                    tokusei != TokuseiNo.TERABORUTEEZI)
                {
                    switch (CurrentWazaNo())
                    {
                        // Move is:
                        // Growl,       Roar,        Sing,            Supersonic,
                        // Screech,     Snore,       Perish Song,     Uproar,
                        // Hyper Voice, Metal Sound, Grass Whistle,   Bug Buzz,
                        // Chatter,     Round,       Echoed Voice,    Relic Song,
                        // Snarl,       Noble Roar,  Disarming Voice, Parting Shot,
                        // Boomburst,   Confide,     Sparkling Aria,  Clanging Scales,
                        // Overdrive
                        case WazaNo.NAKIGOE:
                        case WazaNo.HOERU:
                        case WazaNo.UTAU:
                        case WazaNo.TYOUONPA:
                        case WazaNo.IYANAOTO:
                        case WazaNo.IBIKI:
                        case WazaNo.HOROBINOUTA:
                        case WazaNo.SAWAGU:
                        case WazaNo.HAIPAABOISU:
                        case WazaNo.KINZOKUON:
                        case WazaNo.KUSABUE:
                        case WazaNo.MUSINOSAZAMEKI:
                        case WazaNo.OSYABERI:
                        case WazaNo.RINSYOU:
                        case WazaNo.EKOOBOISU:
                        case WazaNo.INISIENOUTA:
                        case WazaNo.BAAKUAUTO:
                        case WazaNo.OTAKEBI:
                        case WazaNo.TYAAMUBOISU:
                        case WazaNo.SUTEZERIHU:
                        case WazaNo.BAKUONPA:
                        case WazaNo.NAISYOBANASI:
                        case WazaNo.UTAKATANOARIA:
                        case WazaNo.SUKEIRUNOIZU:
                        case WazaNo.OOBAADORAIBU:
                            ScoreCtrl(-10);
                            return HAVE_YES;

                        default:
                            return HAVE_NO;
                    }
                }
            }

            return HAVE_NO;
        }
		
		private int Boudan_Check()
		{
            // Defensive ability is Bulletproof
            if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE }) == TokuseiNo.BOUDAN)
            {
                var tokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });

                // Offensive ability is not Mold Breaker, Turboblaze, nor Teravolt
                if (tokusei != TokuseiNo.KATAYABURI &&
                    tokusei != TokuseiNo.TAABOBUREIZU &&
                    tokusei != TokuseiNo.TERABORUTEEZI)
                {
                    switch (CurrentWazaNo())
                    {
                        // Move is:
                        // Egg Bomb,     Barrage,     Sludge Bomb,  Octazooka,
                        // Zap Cannon,   Shadow Ball, Mist Ball,    Ice Ball,
                        // Weather Ball, Bullet Seed, Gyro Ball,    Aura Sphere,
                        // Seed Bomb,    Focus Blast, Energy Ball,  Mud Bomb,
                        // Rock Wrecker, Magnet Bomb, Electro Ball, Acid Spray,
                        // Searing Shot
                        case WazaNo.TAMAGOBAKUDAN:
                        case WazaNo.TAMANAGE:
                        case WazaNo.HEDOROBAKUDAN:
                        case WazaNo.OKUTANHOU:
                        case WazaNo.DENZIHOU:
                        case WazaNo.SYADOOBOORU:
                        case WazaNo.MISUTOBOORU:
                        case WazaNo.AISUBOORU:
                        case WazaNo.WHEZAABOORU:
                        case WazaNo.TANEMASINGAN:
                        case WazaNo.ZYAIROBOORU:
                        case WazaNo.HADOUDAN:
                        case WazaNo.TANEBAKUDAN:
                        case WazaNo.KIAIDAMA:
                        case WazaNo.ENAZIIBOORU:
                        case WazaNo.DOROBAKUDAN:
                        case WazaNo.GANSEKIHOU:
                        case WazaNo.MAGUNETTOBOMU:
                        case WazaNo.EREKIBOORU:
                        case WazaNo.ASIDDOBOMU:
                        case WazaNo.KAENDAN:
                            ScoreCtrl(-10);
                            return HAVE_YES;

                        default:
                            return HAVE_NO;
                    }
                }
            }

            return HAVE_NO;
        }

        // 1   - Induces Sleep
		// 187 - Induces Drowsy
        private void BaciAI_Seq_001()
		{
			// Defensive Pokémon has a status effect
			if (Call(CMD_IF_POKESICK, new long[] { CHECK_DEFENCE }) != HAVE_NO)
			{
                ScoreCtrl(-10);
				return;
            }

            // Defensive side has Safeguard active
            if (Call(CMD_IF_SIDEEFF, new long[] { CHECK_DEFENCE, BTL_SIDEEFF_SINPINOMAMORI }) != HAVE_NO)
            {
                ScoreCtrl(-10);
                return;
            }

			var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });

            // Offensive ability is not Infiltrator and Defensive Pokémon has a Substitute up
            if (atkTokusei != TokuseiNo.SURINUKE && Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != HAVE_NO)
            {
                ScoreCtrl(-10);
                return;
            }

            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });
            var defType1 = (PokeType)Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 });
            var defType2 = (PokeType)Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 });

            // Electric Terrain is active and Defensive Pokémon is grounded
            if (defTokusei != TokuseiNo.HUYUU &&
				defType1 != PokeType.HIKOU &&
				defType2 != PokeType.HIKOU &&
                Call(CMD_IF_EXIST_GROUND, new long[] { BTL_GROUND_ELEKI }) != HAVE_NO)
            {
                ScoreCtrl(-10);
                return;
            }

            // Misty Terrain is active and Defensive Pokémon is grounded
            if (defTokusei != TokuseiNo.HUYUU &&
                defType1 != PokeType.HIKOU &&
                defType2 != PokeType.HIKOU &&
				Call(CMD_IF_EXIST_GROUND, new long[] { BTL_GROUND_MIST }) != HAVE_NO)
            {
                ScoreCtrl(-10);
                return;
            }

            var rule = (BtlRule)Call(CMD_CHECK_BTL_RULE, Array.Empty<long>());

			// Offensive ability is Mold Breaker, Turboblaze, or Teravolt
			if (atkTokusei == TokuseiNo.KATAYABURI ||
				atkTokusei == TokuseiNo.TAABOBUREIZU ||
				atkTokusei == TokuseiNo.TERABORUTEEZI)
				return;

            // Defensive ability is Insomnia, Vital Spirit, Magic Bounce
            if (defTokusei == TokuseiNo.HUMIN ||
                defTokusei == TokuseiNo.YARUKI ||
                defTokusei == TokuseiNo.MAZIKKUMIRAA)
            {
                ScoreCtrl(-10);
                return;
            }

            // Defensive type is Grass
            if (defType1 == PokeType.KUSA ||
                defType2 == PokeType.KUSA)
            {
                // Defensive ability is Flower Veil
                if (defTokusei == TokuseiNo.HURAWAABEERU)
				{
                    ScoreCtrl(-10);
                    return;
                }

                // Double Battle, and ally's ability is Flower Veil
                if (rule == BtlRule.BTL_RULE_DOUBLE &&
                    (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE_FRIEND }) == TokuseiNo.HURAWAABEERU)
                {
                    ScoreCtrl(-10);
                    return;
                }
            }
            // Defensive ability is Shields Down
            else if (defTokusei == TokuseiNo.RIMITTOSIIRUDO)
            {
				// Defensive Pokémon's HP is over 51%
				if (Call(CMD_IF_HP_OVER, new long[] { CHECK_DEFENCE, 51 }) != HAVE_NO)
				{
                    ScoreCtrl(-10);
                    return;
                }
            }
            else
			{
                // Defensive ability is Sweet Veil
                if (defTokusei == TokuseiNo.SUIITOBEERU)
                {
                    ScoreCtrl(-10);
                    return;
                }

                // Double Battle, and ally's ability is Sweet Veil
                if (rule == BtlRule.BTL_RULE_DOUBLE &&
                    (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE_FRIEND }) == TokuseiNo.SUIITOBEERU)
                {
                    ScoreCtrl(-10);
                    return;
                }
            }
        }
		
		// TODO
		private void BaciAI_Seq_007() { }
		
		// TODO
		private void BaciAI_Seq_008() { }
		
		// TODO
		private void BaciAI_Seq_010() { }
		
		// TODO
		private void BaciAI_Seq_011() { }
		
		// TODO
		private void BaciAI_Seq_012() { }
		
		// TODO
		private void BaciAI_Seq_013() { }
		
		// TODO
		private void BaciAI_Seq_014() { }
		
		// TODO
		private void BaciAI_Seq_015() { }
		
		// TODO
		private void BaciAI_Seq_016() { }
		
		// TODO
		private void BaciAI_Seq_018() { }
		
		// TODO
		private void BaciAI_Seq_019() { }
		
		// TODO
		private void BaciAI_Seq_020() { }
		
		// TODO
		private void BaciAI_Seq_021() { }
		
		// TODO
		private void BaciAI_Seq_022() { }
		
		// TODO
		private void BaciAI_Seq_023() { }
		
		// TODO
		private void BaciAI_Seq_024() { }
		
		// TODO
		private void BaciAI_Seq_025() { }
		
		// TODO
		private void BaciAI_Seq_028() { }
		
		// TODO
		private void BaciAI_Seq_037() { }
		
		// TODO
		private void BaciAI_Seq_032() { }
		
		// TODO
		private void BaciAI_Seq_033() { }
		
		// TODO
		private void BaciAI_Seq_035() { }
		
		// TODO
		private void BaciAI_Seq_038() { }
		
		// TODO
		private void BaciAI_Seq_046() { }
		
		// TODO
		private void BaciAI_Seq_047() { }
		
		// TODO
		private void BaciAI_Seq_049() { }
		
		// TODO
		private void BaciAI_Seq_065() { }
		
		// TODO
		private void BaciAI_Seq_067() { }
		
		// TODO
		private void BaciAI_Seq_079() { }
		
		// TODO
		private void BaciAI_Seq_084() { }
		
		// TODO
		private void BaciAI_Seq_086() { }
		
		// TODO
		private void BaciAI_Seq_090() { }
		
		// TODO
		private void BaciAI_Seq_092() { }
		
		// TODO
		private void BaciAI_Seq_094() { }
		
		// TODO
		private void BaciAI_Seq_102() { }
		
		// TODO
		private void BaciAI_Seq_106() { }
		
		// TODO
		private void BaciAI_Seq_107() { }
		
		// TODO
		private void BaciAI_Seq_109() { }
		
		// TODO
		private void BaciAI_Seq_112() { }
		
		// TODO
		private void BaciAI_Seq_113() { }
		
		// TODO
		private void BaciAI_Seq_114() { }
		
		// TODO
		private void BaciAI_Seq_115() { }
		
		// TODO
		private void BaciAI_Seq_120() { }
		
		// TODO
		private void BaciAI_Seq_124() { }
		
		// TODO
		private void BaciAI_Seq_127() { }
		
		// TODO
		private void BaciAI_Seq_132() { }
		
		// TODO
		private void BaciAI_Seq_136() { }
		
		// TODO
		private void BaciAI_Seq_137() { }
		
		// TODO
		private void BaciAI_Seq_142() { }
		
		// TODO
		private void BaciAI_Seq_148() { }
		
		// TODO
		private void BaciAI_Seq_158() { }
		
		// TODO
		private void BaciAI_Seq_160() { }
		
		// TODO
		private void BaciAI_Seq_161() { }
		
		// TODO
		private void BaciAI_Seq_164() { }
		
		// TODO
		private void BaciAI_Seq_165() { }
		
		// TODO
		private void BaciAI_Seq_167() { }
		
		// TODO
		private void BaciAI_Seq_168() { }
		
		// TODO
		private void BaciAI_Seq_172() { }
		
		// TODO
		private void BaciAI_Seq_175() { }
		
		// TODO
		private void BaciAI_Seq_176() { }
		
		// TODO
		private void BaciAI_Seq_177() { }
		
		// TODO
		private void BaciAI_Seq_178() { }
		
		// TODO
		private void BaciAI_Seq_179() { }
		
		// TODO
		private void BaciAI_Seq_181() { }
		
		// TODO
		private void BaciAI_Seq_184() { }
		
		// TODO
		private void BaciAI_Seq_188() { }
		
		// TODO
		private void BaciAI_Seq_191() { }
		
		// TODO
		private void BaciAI_Seq_192() { }
		
		// TODO
		private void BaciAI_Seq_193() { }
		
		// TODO
		private void BaciAI_Seq_205() { }
		
		// TODO
		private void BaciAI_Seq_206() { }
		
		// TODO
		private void BaciAI_Seq_208() { }
		
		// TODO
		private void BaciAI_Seq_211() { }
		
		// TODO
		private void BaciAI_Seq_212() { }
		
		// TODO
		private void BaciAI_Seq_215() { }
		
		// TODO
		private void BaciAI_Seq_216() { }
		
		// TODO
		private void BaciAI_Seq_220() { }
		
		// TODO
		private void BaciAI_Seq_222() { }
		
		// TODO
		private void BaciAI_Seq_225() { }
		
		private void BaciAI_Seq_226()
		{
			// Empty
		}
		
		// TODO
		private void BaciAI_Seq_227() { }
		
		// TODO
		private void BaciAI_Seq_232() { }
		
		// TODO
		private void BaciAI_Seq_233() { }
		
		// TODO
		private void BaciAI_Seq_234() { }
		
		// TODO
		private void BaciAI_Seq_236() { }
		
		// TODO
		private void BaciAI_Seq_238() { }
		
		// TODO
		private void BaciAI_Seq_239() { }
		
		// TODO
		private void BaciAI_Seq_240() { }
		
		// TODO
		private void BaciAI_Seq_241() { }
		
		// TODO
		private void BaciAI_Seq_242() { }
		
		// TODO
		private void BaciAI_Seq_243() { }
		
		// TODO
		private void BaciAI_Seq_244() { }
		
		// TODO
		private void BaciAI_Seq_246() { }
		
		// TODO
		private void BaciAI_Seq_247() { }
		
		// TODO
		private void BaciAI_Seq_249() { }
		
		// TODO
		private void BaciAI_Seq_251() { }
		
		// TODO
		private void BaciAI_Seq_252() { }
		
		// TODO
		private void BaciAI_Seq_258() { }
		
		private void BaciAI_Seq_259()
		{
			// Empty
		}
		
		// TODO
		private void BaciAI_Seq_265() { }
		
		// TODO
		private void BaciAI_Seq_266() { }
		
		// TODO
		private void BaciAI_Seq_270() { }
		
		// TODO
		private void BaciAI_Seq_278() { }
		
		// TODO
		private void BaciAI_Seq_281() { }
		
		// TODO
		private void BaciAI_Seq_285() { }
		
		// TODO
		private void BaciAI_Seq_286() { }
		
		// TODO
		private void BaciAI_Seq_292() { }
		
		// TODO
		private void BaciAI_Seq_294() { }
		
		// TODO
		private void BaciAI_Seq_298() { }
		
		// TODO
		private void BaciAI_Seq_299() { }
		
		// TODO
		private void BaciAI_Seq_300() { }
		
		private void BaciAI_Seq_301()
		{
			// Empty
		}
		
		// TODO
		private void BaciAI_Seq_307() { }
		
		// TODO
		private void BaciAI_Seq_309() { }
		
		// TODO
		private void BaciAI_Seq_311() { }
		
		// TODO
		private void BaciAI_Seq_315() { }
		
		// TODO
		private void BaciAI_Seq_318() { }
		
		// TODO
		private void BaciAI_Seq_320() { }
		
		// TODO
		private void BaciAI_Seq_323() { }
		
		// TODO
		private void BaciAI_Seq_338() { }
		
		// TODO
		private void BaciAI_Seq_339() { }
		
		// TODO
		private void BaciAI_Seq_340() { }
		
		// TODO
		private void BaciAI_Seq_342() { }
		
		// TODO
		private void BaciAI_Seq_375() { }
		
		// TODO
		private void BaciAI_Seq_349() { }
		
		// TODO
		private void BaciAI_Seq_350() { }
		
		// TODO
		private void BaciAI_Seq_351() { }
		
		// TODO
		private void BaciAI_Seq_352() { }
		
		// TODO
		private void BaciAI_Seq_354() { }
		
		// TODO
		private void BaciAI_Seq_362() { }
		
		// TODO
		private void BaciAI_Seq_363() { }
		
		// TODO
		private void BaciAI_Seq_366() { }
		
		// TODO
		private void BaciAI_Seq_368() { }
		
		// TODO
		private void BaciAI_Seq_370() { }
		
		// TODO
		private void BaciAI_Seq_387() { }
		
		// TODO
		private void BaciAI_Seq_388() { }
		
		// TODO
		private void BaciAI_Seq_389() { }
		
		// TODO
		private void BaciAI_Seq_391() { }
		
		// TODO
		private void BaciAI_Seq_394() { }
		
		// TODO
		private void BaciAI_Seq_397() { }
		
		// TODO
		private void BaciAI_Seq_399() { }
		
		// TODO
		private void BaciAI_Seq_406() { }
		
		// TODO
		private void BaciAI_Seq_419() { }
		
		// TODO
		private void BaciAI_Seq_423() { }
		
		// TODO
		private void BaciAI_Seq_425() { }
		
		// TODO
		private void BaciAI_Seq_426() { }
		
		// TODO
		private void BaciAI_Seq_428() { }
		
		// TODO
		private void BaciAI_Seq_429() { }
		
		// TODO
		private void BaciAI_Seq_431() { }
		
		// TODO
		private void BaciAI_Seq_432() { }
		
		// TODO
		private void BaciAI_Seq_434() { }
	}
}