using Dpr.Battle.Logic.Handler;
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

				// Not Horn Drill nor Fissure
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

			// Not a powder move
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
		
		// TODO
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
					BaciAI_Seq_001(); break;

				case 7:
					BaciAI_Seq_007(); break;

				case 8:
					BaciAI_Seq_008(); break;

				case 10:
				case 50:
					BaciAI_Seq_010(); break;

				case 11:
				case 51:
					BaciAI_Seq_011(); break;

					// TODO: more
            }
        }
		
		// TODO
		private int Bouon_Check() { return default; }
		
		// TODO
		private int Boudan_Check() { return default; }
		
		// TODO
		private void BaciAI_Seq_001() { }
		
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
		
		// TODO
		private void BaciAI_Seq_226() { }
		
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
		
		// TODO
		private void BaciAI_Seq_259() { }
		
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
		
		// TODO
		private void BaciAI_Seq_301() { }
		
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