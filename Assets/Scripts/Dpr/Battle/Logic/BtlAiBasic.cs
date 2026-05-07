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
            // Double Battle and user is targetting an ally
            if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_DOUBLE &&
                Call(CMD_IF_MIKATA_ATTACK, Array.Empty<long>()) != 0)
                return;

            // Powder move damage prevented
            if (Basic_ConaHoushi() == 1)
                return;

            // Prankster effect prevented
            if (Basic_Itazuragokoro() == 1)
                return;

            // Priority move damage prevented
            if (Basic_Sensei() == 1)
                return;

            // Gale Wings damage prevented
            if (Basic_Hayatenotubasa() == 1)
                return;

            // Moves nullified by Dynamax damage/effect prevented
            if (Basic_DaimaxNG() == 1)
                return;

            var waza = CurrentWazaNo();

            // Move is not Horn Drill nor Fissure and deals 0 damage
            if (waza != WazaNo.TUNODORIRU && waza != WazaNo.ZIWARE &&
                Call(CMD_CHECK_DAMAGE_WAZA, new long[] { (ushort)CurrentWazaNo() }) == 0)
            {
                Calc_BasicAll();
            }
            // Move is calculated to deal damage
            else if (Calc_BasicDamage() == 1)
            {
                Calc_BasicAll();
            }
        }

        // Powder move logic
        // 0 = Damage dealt
        // 1 = Damage prevented
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
                return 0;

            // Target's ability is Overcoat
            if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE }) == TokuseiNo.BOUZIN)
            {
                var tokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });

                // User's ability is not Mold Breaker, Turboblaze, nor Teravolt
                if (tokusei != TokuseiNo.KATAYABURI &&
                    tokusei != TokuseiNo.TAABOBUREIZU &&
                    tokusei != TokuseiNo.TERABORUTEEZI)
                {
                    ScoreCtrl(-10);
                    return 1;
                }
            }

            // Target's type is Grass
            if (Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 }) == POKETYPE_KUSA ||
                Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 }) == POKETYPE_KUSA)
            {
                ScoreCtrl(-10);
                return 1;
            }

            return 0;
        }

        // Prankster logic
        // 0 = Effect dealt
        // 1 = Effect prevented
        private int Basic_Itazuragokoro()
        {
            var tokuseiAtk = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var tokuseiDef = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });
            var moveCategory = (WazaDamageType)Call(CMD_CHECK_WAZA_KIND, Array.Empty<long>());

            // User's ability is not Prankster
            if (tokuseiAtk != TokuseiNo.ITAZURAGOKORO)
                return 0;

            // Physical or Special move
            if (moveCategory == WazaDamageType.PHYSIC ||
                moveCategory == WazaDamageType.SPECIAL)
                return 0;

            // Specific targetting
            var wazaTarget = (WazaTarget)Call(CMD_GET_WAZA_TARGET, Array.Empty<long>());
            if (wazaTarget != WazaTarget.TARGET_OTHER_SELECT &&
                wazaTarget != WazaTarget.TARGET_ENEMY_SELECT &&
                wazaTarget != WazaTarget.TARGET_OTHER_ALL &&
                wazaTarget != WazaTarget.TARGET_ENEMY_ALL &&
                wazaTarget != WazaTarget.TARGET_ALL &&
                wazaTarget != WazaTarget.TARGET_ENEMY_RANDOM)
                return 0;

            // Target's type is Dark
            if (Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 }) == POKETYPE_AKU ||
                Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 }) == POKETYPE_AKU)
            {
                ScoreCtrl(-10);
                return 1;
            }

            // Psychic Terrain is active and target is grounded
            if (Call(CMD_IF_EXIST_GROUND, new long[] { BTL_GROUND_PHYCHO }) != 0 &&
                Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 }) != POKETYPE_HIKOU &&
                Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 }) != POKETYPE_HIKOU &&
                tokuseiDef != TokuseiNo.HUYUU)
            {
                ScoreCtrl(-10);
                return 1;
            }

            // Target's ability is Queenly Majesty or Dazzling
            if (tokuseiDef == TokuseiNo.ZYOOUNOIGEN ||
                tokuseiDef == TokuseiNo.BIBIDDOBODHI)
            {
                ScoreCtrl(-10);
                return 1;
            }

            return 0;
        }

        // Priority move logic
        // 0 = Damage dealt
        // 1 = Damage prevented
        private int Basic_Sensei()
        {
            var tokuseiDef = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });
            var seqNo = Call(CMD_CHECK_WORKWAZA_SEQNO, Array.Empty<long>());

            // Affected Trainer AI Move Logic IDs
            // 103 - Increased Priority
            // 158 - Fake Out
            // 223 - Feint
            // 248 - Sucker Punch
            // 360 - Water Shuriken
            // 364 - Baby-Doll Eyes
            // 377 - Powder
            // 382 - First Impression
            // 388 - Induces Spotlight
            if (seqNo != 103 &&
                seqNo != 158 &&
                seqNo != 223 &&
                seqNo != 248 &&
                seqNo != 360 &&
                seqNo != 364 &&
                seqNo != 377 &&
                seqNo != 382 &&
                seqNo != 388)
                return 0;

            // Psychic Terrain is active and target is grounded
            if (Call(CMD_IF_EXIST_GROUND, new long[] { BTL_GROUND_PHYCHO }) != 0 &&
                Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 }) != POKETYPE_HIKOU &&
                Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 }) != POKETYPE_HIKOU &&
                tokuseiDef != TokuseiNo.HUYUU)
            {
                ScoreCtrl(-10);
                return 1;
            }

            // Target's ability is Queenly Majesty or Dazzling
            if (tokuseiDef == TokuseiNo.ZYOOUNOIGEN ||
                tokuseiDef == TokuseiNo.BIBIDDOBODHI)
            {
                ScoreCtrl(-10);
                return 1;
            }

            return 0;
        }

        // Gale Wings logic
        // 0 = Damage dealt
        // 1 = Damage prevented
        private int Basic_Hayatenotubasa()
        {
            var tokuseiAtk = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var tokuseiDef = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // User's ability is not Gale Wings
            if (tokuseiAtk != TokuseiNo.HAYATENOTUBASA)
                return 0;

            // User's HP is not 100%
            if (Call(CMD_IF_HP_EQUAL, new long[] { CHECK_ATTACK, 100 }) == 0)
                return 0;

            // Move is not Flying type
            if ((PokeType)Call(CMD_CHECK_WORKWAZA_TYPE, Array.Empty<long>()) != PokeType.HIKOU)
                return 0;

            // Specific targetting
            var wazaTarget = (WazaTarget)Call(CMD_GET_WAZA_TARGET, Array.Empty<long>());
            if (wazaTarget != WazaTarget.TARGET_OTHER_SELECT &&
                wazaTarget != WazaTarget.TARGET_ENEMY_SELECT &&
                wazaTarget != WazaTarget.TARGET_OTHER_ALL &&
                wazaTarget != WazaTarget.TARGET_ENEMY_ALL &&
                wazaTarget != WazaTarget.TARGET_ALL &&
                wazaTarget != WazaTarget.TARGET_ENEMY_RANDOM)
                return 0;

            // Psychic Terrain is active and target is grounded
            if (Call(CMD_IF_EXIST_GROUND, new long[] { BTL_GROUND_PHYCHO }) != 0 &&
                Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 }) != POKETYPE_HIKOU &&
                Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 }) != POKETYPE_HIKOU &&
                tokuseiDef != TokuseiNo.HUYUU)
            {
                ScoreCtrl(-10);
                return 1;
            }

            // Target's ability is Queenly Majesty or Dazzling
            if (tokuseiDef == TokuseiNo.ZYOOUNOIGEN ||
                tokuseiDef == TokuseiNo.BIBIDDOBODHI)
            {
                ScoreCtrl(-10);
                return 1;
            }

            return 0;
        }

        // Moves nullified by Dynamax logic
        // 0 = Damage/effect dealt
        // 1 = Damage/effect prevented
        private int Basic_DaimaxNG()
        {
            // Target is not Dynamaxed
            if (Call(CMD_IF_G, new long[] { CHECK_DEFENCE }) == 0)
                return 0;

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
                    return 1;

                default:
                    return 0;
            }
        }
        
        // Damaging move logic
        // 0 = Damage prevented
        // 1 = Damage dealt
        private int Calc_BasicDamage()
        {
            var tokuseiAtk = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var tokuseiDef = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // Move affinity is "No Effect"
            if (Call(CMD_CHECK_WAZA_AISYOU, new long[] { CHECK_ATTACK, CHECK_DEFENCE, (long)CurrentWazaNo(), AISYOU_0BAI }) != 0)
            {
                // Move type is Ground, target's ability is Levitate
                // and user's ability is Mold Breaker, Turboblaze, or Teravolt
                if (Call(CMD_CHECK_TYPE, new long[] { CHECK_WAZA }) == POKETYPE_JIMEN &&
                    tokuseiDef == TokuseiNo.HUYUU &&
                    (tokuseiAtk == TokuseiNo.KATAYABURI ||
                     tokuseiAtk == TokuseiNo.TAABOBUREIZU ||
                     tokuseiAtk == TokuseiNo.TERABORUTEEZI))
                    return 1;

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
                    return 0;
                }
                else
                {
                    return 1;
                }
            }

            // User's ability is Mold Breaker, Turboblaze, or Teravolt
            if (tokuseiAtk == TokuseiNo.KATAYABURI ||
                tokuseiAtk == TokuseiNo.TAABOBUREIZU ||
                tokuseiAtk == TokuseiNo.TERABORUTEEZI)
                return 1;

            // Ignored
            _ = string.Format("とくせい = {0}\n", tokuseiDef);

            // Target's ability is...
            switch (tokuseiDef)
            {
                // Volt Absorb, Lightning Rod, Motor Drive
                case TokuseiNo.TIKUDEN:
                case TokuseiNo.HIRAISIN:
                case TokuseiNo.DENKIENZIN:
                    return (BasicDmg_00_1() == 0) ? 1 : 0;

                // Water Absorb, Dry Skin, Storm Drain
                case TokuseiNo.TYOSUI:
                case TokuseiNo.KANSOUHADA:
                case TokuseiNo.YOBIMIZU:
                    return (BasicDmg_00_2() == 0) ? 1 : 0;

                // Flash Fire
                case TokuseiNo.MORAIBI:
                    return (BasicDmg_00_3() == 0) ? 1 : 0;

                // Wonder Guard
                case TokuseiNo.HUSIGINAMAMORI:
                    return (BasicDmg_00_4() == 0) ? 1 : 0;

                // Levitate
                case TokuseiNo.HUYUU:
                    return (BasicDmg_00_5() == 0) ? 1 : 0;

                // Sap Sipper
                case TokuseiNo.SOUSYOKU:
                    return (BasicDmg_00_7() == 0) ? 1 : 0;

                default:
                    return 1;
            }
        }

        // Electric-immune ability logic
        // 0 = Damage dealt
        // 1 = Damage prevented
        private int BasicDmg_00_1()
        {
            // Move type is Electric
            if (Call(CMD_CHECK_TYPE, new long[] { CHECK_WAZA }) == POKETYPE_DENKI)
            {
                ScoreCtrl(-12);
                return 1;
            }

            return 0;
        }

        // Water-immune ability logic
        // 0 = Damage dealt
        // 1 = Damage prevented
        private int BasicDmg_00_2()
        {
            // Move type is Water
            if (Call(CMD_CHECK_TYPE, new long[] { CHECK_WAZA }) == POKETYPE_MIZU)
            {
                ScoreCtrl(-12);
                return 1;
            }

            return 0;
        }

        // Fire-immune ability logic
        // 0 = Damage dealt
        // 1 = Damage prevented
        private int BasicDmg_00_3()
        {
            // Move type is Fire
            if (Call(CMD_CHECK_TYPE, new long[] { CHECK_WAZA }) == POKETYPE_HONOO)
            {
                ScoreCtrl(-12);
                return 1;
            }

            return 0;
        }

        // Wonder Guard logic
        // 0 = Damage dealt
        // 1 = Damage prevented
        private int BasicDmg_00_4()
        {
            // Move affinity is not "Super Effective" at x2 nor x4
            if (Call(CMD_CHECK_WAZA_AISYOU, new long[] { CHECK_ATTACK, CHECK_DEFENCE, (long)CurrentWazaNo(), AISYOU_2BAI }) == 0 &&
                Call(CMD_CHECK_WAZA_AISYOU, new long[] { CHECK_ATTACK, CHECK_DEFENCE, (long)CurrentWazaNo(), AISYOU_4BAI }) == 0)
            {
                ScoreCtrl(-10);
                return 1;
            }

            return 0;
        }

        // Ground-immune ability logic
        // 0 = Damage dealt
        // 1 = Damage prevented
        private int BasicDmg_00_5()
        {
            // Move type is Ground and Gravity is not active
            if (Call(CMD_CHECK_TYPE, new long[] { CHECK_WAZA }) == POKETYPE_JIMEN &&
                Call(CMD_FLDEFF_CHECK, new long[] { EFF_JURYOKU }) == 0)
            {
                ScoreCtrl(-10);
                return 1;
            }

            return 0;
        }

        // Grass-immune ability logic
        // 0 = Damage dealt
        // 1 = Damage prevented
        private int BasicDmg_00_7()
        {
            // Move type is Grass
            if (Call(CMD_CHECK_TYPE, new long[] { CHECK_WAZA }) == POKETYPE_KUSA)
            {
                ScoreCtrl(-12);
                return 1;
            }

            return 0;
        }
        
        private void Calc_BasicAll()
        {
            // Soundproof prevents damage
            if (Bouon_Check() == 1)
                return;

            // Bulletproof prevents damage
            if (Boudan_Check() == 1)
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

                case 240: // Assumed, since this method is empty it probably got optimized out
                    BaciAI_Seq_240(); break;

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

                case 420: // BUG: This should be 423
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

        // Soundproof logic
        // 0 = Damage dealt
        // 1 = Damage prevented
        private int Bouon_Check()
        {
            // Target's ability is Soundproof
            if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE }) == TokuseiNo.BOUON)
            {
                var tokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });

                // User's ability is not Mold Breaker, Turboblaze, nor Teravolt
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
                            return 1;

                        default:
                            return 0;
                    }
                }
            }

            return 0;
        }

        // Bulletproof logic
        // 0 = Damage dealt
        // 1 = Damage prevented
        private int Boudan_Check()
        {
            // Target's ability is Bulletproof
            if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE }) == TokuseiNo.BOUDAN)
            {
                var tokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });

                // User's ability is not Mold Breaker, Turboblaze, nor Teravolt
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
                            return 1;

                        default:
                            return 0;
                    }
                }
            }

            return 0;
        }

        // 1   - Induces Sleep
        // 187 - Induces Drowsy
        private void BaciAI_Seq_001()
        {
            // Target has a status effect
            if (Call(CMD_IF_POKESICK, new long[] { CHECK_DEFENCE }) != 0)
            {
                ScoreCtrl(-10);
                return;
            }

            // Target's side has Safeguard active
            if (Call(CMD_IF_SIDEEFF, new long[] { CHECK_DEFENCE, BTL_SIDEEFF_SINPINOMAMORI }) != 0)
            {
                ScoreCtrl(-10);
                return;
            }

            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });

            // User's ability is not Infiltrator and target has a substitute
            if (atkTokusei != TokuseiNo.SURINUKE && Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0)
            {
                ScoreCtrl(-10);
                return;
            }

            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });
            var defType1 = Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 });
            var defType2 = Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 });

            // Electric Terrain is active and target is grounded
            if (defTokusei != TokuseiNo.HUYUU &&
                defType1 != POKETYPE_HIKOU &&
                defType2 != POKETYPE_HIKOU &&
                Call(CMD_IF_EXIST_GROUND, new long[] { BTL_GROUND_ELEKI }) != 0)
            {
                ScoreCtrl(-10);
                return;
            }

            // Misty Terrain is active and target is grounded
            if (defTokusei != TokuseiNo.HUYUU &&
                defType1 != POKETYPE_HIKOU &&
                defType2 != POKETYPE_HIKOU &&
                Call(CMD_IF_EXIST_GROUND, new long[] { BTL_GROUND_MIST }) != 0)
            {
                ScoreCtrl(-10);
                return;
            }

            var rule = Call(CMD_CHECK_BTL_RULE, Array.Empty<long>());

            // User's ability is Mold Breaker, Turboblaze, or Teravolt
            if (atkTokusei == TokuseiNo.KATAYABURI ||
                atkTokusei == TokuseiNo.TAABOBUREIZU ||
                atkTokusei == TokuseiNo.TERABORUTEEZI)
                return;

            // Target's ability is Insomnia, Vital Spirit, or Magic Bounce
            if (defTokusei == TokuseiNo.HUMIN ||
                defTokusei == TokuseiNo.YARUKI ||
                defTokusei == TokuseiNo.MAZIKKUMIRAA)
            {
                ScoreCtrl(-10);
                return;
            }

            // Target's type is Grass
            if (defType1 == POKETYPE_KUSA ||
                defType2 == POKETYPE_KUSA)
            {
                // Target's ability is Flower Veil
                if (defTokusei == TokuseiNo.HURAWAABEERU)
                {
                    ScoreCtrl(-10);
                    return;
                }

                // Double Battle, and target's ally's ability is Flower Veil
                if (rule == BTL_RULE_DOUBLE &&
                    (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE_FRIEND }) == TokuseiNo.HURAWAABEERU)
                {
                    ScoreCtrl(-10);
                    return;
                }
            }
            // Target's ability is Shields Down
            else if (defTokusei == TokuseiNo.RIMITTOSIIRUDO)
            {
                // Target's HP is over 51%
                if (Call(CMD_IF_HP_OVER, new long[] { CHECK_DEFENCE, 51 }) != 0)
                {
                    ScoreCtrl(-10);
                    return;
                }
            }
            else
            {
                // Target's ability is Sweet Veil
                if (defTokusei == TokuseiNo.SUIITOBEERU)
                {
                    ScoreCtrl(-10);
                    return;
                }

                // Double Battle, and target's ally's ability is Sweet Veil
                if (rule == BTL_RULE_DOUBLE &&
                    (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE_FRIEND }) == TokuseiNo.SUIITOBEERU)
                {
                    ScoreCtrl(-10);
                    return;
                }
            }
        }

        // 7 - Explosion
        private void BaciAI_Seq_007()
        {
            // Move affinity is "No Effect"
            if (Call(CMD_CHECK_WAZA_AISYOU, new long[] { CHECK_ATTACK, CHECK_DEFENCE, (ushort)CurrentWazaNo(), AISYOU_0BAI }) != 0)
            {
                ScoreCtrl(-10);
                return;
            }

            // User's ability is not Mold Breaker and target's ability is Damp
            if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK }) != TokuseiNo.KATAYABURI &&
                (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE }) == TokuseiNo.SIMERIKE)
            {
                ScoreCtrl(-10);
                return;
            }

            // Single battle and both sides have no other Pokémon left in their parties
            if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_SINGLE &&
                Call(CMD_CHECK_BENCH_COUNT, new long[] { CHECK_ATTACK }) == 0 &&
                Call(CMD_CHECK_BENCH_COUNT, new long[] { CHECK_DEFENCE }) == 0)
            {
                ScoreCtrl(-1);
                return;
            }
        }
        
        // 8 - Dream Eater
        private void BaciAI_Seq_008()
        {
            // Target is not asleep
            if (Call(CMD_IFN_WAZASICK, new long[] { CHECK_DEFENCE, WAZASICK_NEMURI }) != 0)
            {
                ScoreCtrl(-10);
                return;
            }

            // Target's ability is Magic Guard
            if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE }) == TokuseiNo.KATAYABURI)
            {
                ScoreCtrl(-10);
                return;
            }
        }

        // 10  - +1 Attack Stage
        // 50  - +2 Attack Stages
        // 277 - +1 Attack Stage and +1 Accuracy Stage
        // 308 - Shell Smash
        // 312 - Shift Gear
        // 316 - Growth
        // 322 - Coil
        // 327 - Work Up
        private void BaciAI_Seq_010()
        {
            // User's ability is Contrary
            if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK }) == TokuseiNo.AMANOZYAKU)
            {
                ScoreCtrl(-12);
                return;
            }

            // User's Attack is at +6 stages
            if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_ATTACK, PARA_POW, 12 }) != 0)
            {
                ScoreCtrl(-10);
                return;
            }
        }

        // 11  - +1 Defense Stage
        // 51  - +2 Defense Stages
        // 156 - Defense Curl
        // 328 - +3 Defense Stages
        private void BaciAI_Seq_011()
        {
            // User's ability is Contrary
            if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK }) == TokuseiNo.AMANOZYAKU)
            {
                ScoreCtrl(-12);
                return;
            }

            // User's Defense is at +6 stages
            if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_ATTACK, PARA_DEF, 12 }) != 0)
            {
                ScoreCtrl(-10);
                return;
            }
        }

        // 12  - +1 Speed Stage
        // 52  - +2 Speed Stages
        // 284 - Autotomize
        private void BaciAI_Seq_012()
        {
            // User's ability is Contrary
            if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK }) == TokuseiNo.AMANOZYAKU)
            {
                ScoreCtrl(-12);
                return;
            }

            // User's Speed is at +6 stages
            if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_ATTACK, PARA_AGI, 12 }) != 0)
            {
                ScoreCtrl(-10);
                return;
            }

            // Trick Room is active
            if (Call(CMD_FLDEFF_CHECK, new long[] { EFF_TRICKROOM }) != 0)
            {
                ScoreCtrl(-5);
                return;
            }
        }

        // 13  - +1 Special Attack Stage
        // 53  - +2 Special Attack Stages
        // 290 - Quiver Dance
        // 321 - +3 Special Attack Stages
        // 365 - Geomancy
        private void BaciAI_Seq_013()
        {
            // User's ability is Contrary
            if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK }) == TokuseiNo.AMANOZYAKU)
            {
                ScoreCtrl(-12);
                return;
            }

            // User's Special Attack is at +6 stages
            if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_ATTACK, PARA_SPEPOW, 12 }) != 0)
            {
                ScoreCtrl(-10);
                return;
            }
        }

        // 14 - +1 Special Defense Stage
        // 54 - +2 Special Defense Stages
        private void BaciAI_Seq_014()
        {
            // User's ability is Contrary
            if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK }) == TokuseiNo.AMANOZYAKU)
            {
                ScoreCtrl(-12);
                return;
            }

            // User's Special Defense is at +6 stages
            if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_ATTACK, PARA_SPEDEF, 12 }) != 0)
            {
                ScoreCtrl(-10);
                return;
            }
        }

        // 15 - +1 Accuracy Stage
        // 55 - +2 Accuracy Stages
        private void BaciAI_Seq_015()
        {
            // User's ability is Contrary
            if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK }) == TokuseiNo.AMANOZYAKU)
            {
                ScoreCtrl(-12);
                return;
            }

            // Target's ability is No Guard
            if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE }) == TokuseiNo.NOOGAADO)
            {
                ScoreCtrl(-10);
                return;
            }

            // User's ability is No Guard
            if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK }) == TokuseiNo.NOOGAADO)
            {
                ScoreCtrl(-10);
                return;
            }

            // User's Accuracy is at +6 stages
            if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_ATTACK, PARA_HIT, 12 }) != 0)
            {
                ScoreCtrl(-10);
                return;
            }
        }

        // 16  - +1 Evasiveness Stage
        // 56  - +2 Evasiveness Stages
        // 108 - Minimize
        private void BaciAI_Seq_016()
        {
            // User's ability is Contrary
            if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK }) == TokuseiNo.AMANOZYAKU)
            {
                ScoreCtrl(-12);
                return;
            }

            // Target's ability is No Guard
            if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE }) == TokuseiNo.NOOGAADO)
            {
                ScoreCtrl(-10);
                return;
            }

            // User's ability is No Guard
            if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK }) == TokuseiNo.NOOGAADO)
            {
                ScoreCtrl(-10);
                return;
            }

            // User's Evasiveness is at +6 stages
            if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_ATTACK, PARA_AVOID, 12 }) != 0)
            {
                ScoreCtrl(-10);
                return;
            }
        }

        // 18  - -1 Attack Stage
        // 58  - -2 Attack Stages
        // 343 - Noble Roar
        // 346 - Parting Shot
        // 356 - Play Nice
        // 364 - Baby-Doll Eyes
        // 411 - Tearful Look
        private void BaciAI_Seq_018()
        {
            // Target's Attack is at -6 stages
            if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_DEFENCE, PARA_POW, 0 }) != 0)
            {
                ScoreCtrl(-10);
            }

            // Target's ability is Competitive or Defiant
            switch ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE }))
            {
                case TokuseiNo.MAKENKI:
                case TokuseiNo.KATIKI:
                    ScoreCtrl(-12);
                    break;
            }

            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });

            // User's ability is not Infiltrator
            if (atkTokusei != TokuseiNo.SURINUKE)
            {
                // Target has a substitute
                if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0)
                {
                    ScoreCtrl(-10);
                    return;
                }

                // Target's side has Mist active
                if (Call(CMD_IF_SIDEEFF, new long[] { CHECK_DEFENCE, BTL_SIDEEFF_SIROIKIRI }) != 0)
                {
                    ScoreCtrl(-10);
                }

                // User's ability is Mold Breaker, Turboblaze, or Teravolt
                if (atkTokusei == TokuseiNo.KATAYABURI ||
                    atkTokusei == TokuseiNo.TAABOBUREIZU ||
                    atkTokusei == TokuseiNo.TERABORUTEEZI)
                {
                    return;
                }
            }

            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // Target's ability is Clear Body, Hyper Cutter, or White Smoke
            if (defTokusei == TokuseiNo.KURIABODHI ||
                defTokusei == TokuseiNo.KAIRIKIBASAMI ||
                defTokusei == TokuseiNo.SIROIKEMURI)
            {
                ScoreCtrl(-10);
            }
            // Target's ability is Contrary or Magic Bounce
            else if (defTokusei == TokuseiNo.AMANOZYAKU ||
                     defTokusei == TokuseiNo.MAZIKKUMIRAA)
            {
                ScoreCtrl(-12);
            }
            else
            {
                // Target's type is Grass
                if (Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 }) == POKETYPE_KUSA ||
                    Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 }) == POKETYPE_KUSA)
                {
                    // Target's ability is Flower Veil
                    if (defTokusei == TokuseiNo.HURAWAABEERU)
                    {
                        ScoreCtrl(-10);
                        return;
                    }
                }
            }

            // Double Battle, and target's ally's ability is Flower Veil
            if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_DOUBLE &&
                (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE_FRIEND }) == TokuseiNo.HURAWAABEERU)
            {
                ScoreCtrl(-10);
                return;
            }
        }

        // 19 - -1 Defense Stage
        // 59 - -2 Defense Stages
        private void BaciAI_Seq_019()
        {
            // BUG: Checks for user instead of target
            // User's Defense is at -6 stages
            if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_ATTACK, PARA_DEF, 0 }) != 0)
            {
                ScoreCtrl(-10);
            }

            // Target's ability is Competitive or Defiant
            switch ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE }))
            {
                case TokuseiNo.MAKENKI:
                case TokuseiNo.KATIKI:
                    ScoreCtrl(-12);
                    break;
            }

            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });

            // User's ability is not Infiltrator
            if (atkTokusei != TokuseiNo.SURINUKE)
            {
                // Target has a substitute
                if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0)
                {
                    ScoreCtrl(-10);
                    return;
                }

                // Target's side has Mist active
                if (Call(CMD_IF_SIDEEFF, new long[] { CHECK_DEFENCE, BTL_SIDEEFF_SIROIKIRI }) != 0)
                {
                    ScoreCtrl(-10);
                }

                // User's ability is Mold Breaker, Turboblaze, or Teravolt
                if (atkTokusei == TokuseiNo.KATAYABURI ||
                    atkTokusei == TokuseiNo.TAABOBUREIZU ||
                    atkTokusei == TokuseiNo.TERABORUTEEZI)
                {
                    return;
                }
            }

            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // Target's ability is Clear Body, White Smoke, or Big Pecks
            if (defTokusei == TokuseiNo.KURIABODHI ||
                defTokusei == TokuseiNo.SIROIKEMURI ||
                defTokusei == TokuseiNo.HATOMUNE)
            {
                ScoreCtrl(-10);
            }
            // Target's ability is Contrary or Magic Bounce
            else if (defTokusei == TokuseiNo.AMANOZYAKU ||
                     defTokusei == TokuseiNo.MAZIKKUMIRAA)
            {
                ScoreCtrl(-12);
            }
            else
            {
                // Target's type is Grass
                if (Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 }) == POKETYPE_KUSA ||
                    Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 }) == POKETYPE_KUSA)
                {
                    // Target's ability is Flower Veil
                    if (defTokusei == TokuseiNo.HURAWAABEERU)
                    {
                        ScoreCtrl(-10);
                        return;
                    }
                }
            }

            // Double Battle, and target's ally's ability is Flower Veil
            if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_DOUBLE &&
                (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE_FRIEND }) == TokuseiNo.HURAWAABEERU)
            {
                ScoreCtrl(-10);
                return;
            }
        }

        // 20 - -1 Speed Stage
        // 60 - -2 Speed Stages
        private void BaciAI_Seq_020()
        {
            // BUG: Checks for user instead of target
            // User's Speed is at -6 stages
            if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_ATTACK, PARA_AGI, 0 }) != 0)
            {
                ScoreCtrl(-10);
            }

            // Target's ability is Competitive or Defiant
            switch ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE }))
            {
                case TokuseiNo.MAKENKI:
                case TokuseiNo.KATIKI:
                    ScoreCtrl(-8);
                    break;
            }

            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });

            // User's ability is not Infiltrator
            if (atkTokusei != TokuseiNo.SURINUKE)
            {
                // Target has a substitute
                if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0)
                {
                    ScoreCtrl(-10);
                    return;
                }

                // Target's side has Mist active
                if (Call(CMD_IF_SIDEEFF, new long[] { CHECK_DEFENCE, BTL_SIDEEFF_SIROIKIRI }) != 0)
                {
                    ScoreCtrl(-10);
                }

                // User's ability is Mold Breaker, Turboblaze, or Teravolt
                if (atkTokusei == TokuseiNo.KATAYABURI ||
                    atkTokusei == TokuseiNo.TAABOBUREIZU ||
                    atkTokusei == TokuseiNo.TERABORUTEEZI)
                {
                    return;
                }
            }

            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // Target's ability is Clear Body or White Smoke
            if (defTokusei == TokuseiNo.KURIABODHI ||
                defTokusei == TokuseiNo.SIROIKEMURI)
            {
                ScoreCtrl(-10);
                return;
            }
            // Target's ability is Contrary or Magic Bounce
            else if (defTokusei == TokuseiNo.AMANOZYAKU ||
                     defTokusei == TokuseiNo.MAZIKKUMIRAA)
            {
                ScoreCtrl(-12);
                return;
            }
            else
            {
                // Target's type is Grass
                if (Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 }) == POKETYPE_KUSA ||
                    Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 }) == POKETYPE_KUSA)
                {
                    // Target's ability is Flower Veil
                    if (defTokusei == TokuseiNo.HURAWAABEERU)
                    {
                        ScoreCtrl(-10);
                        return;
                    }
                    // Double Battle, and target's ally's ability is Flower Veil
                    else if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_DOUBLE &&
                             (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE_FRIEND }) == TokuseiNo.HURAWAABEERU)
                    {
                        ScoreCtrl(-10);
                        return;
                    }
                }
            }
        }

        // 21  - -1 Special Attack Stage
        // 61  - -2 Special Attack Stages
        // 357 - Confide
        private void BaciAI_Seq_021()
        {
            // BUG: Checks for user instead of target
            // User's Special Attack is at -6 stages
            if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_ATTACK, PARA_SPEPOW, 0 }) != 0)
            {
                ScoreCtrl(-10);
            }

            // Target's ability is Competitive or Defiant
            switch ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE }))
            {
                case TokuseiNo.MAKENKI:
                case TokuseiNo.KATIKI:
                    ScoreCtrl(-8);
                    break;
            }

            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });

            // User's ability is not Infiltrator
            if (atkTokusei != TokuseiNo.SURINUKE)
            {
                // Target has a substitute
                if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0)
                {
                    ScoreCtrl(-10);
                    return;
                }

                // Target's side has Mist active
                if (Call(CMD_IF_SIDEEFF, new long[] { CHECK_DEFENCE, BTL_SIDEEFF_SIROIKIRI }) != 0)
                {
                    ScoreCtrl(-10);
                }

                // User's ability is Mold Breaker, Turboblaze, or Teravolt
                if (atkTokusei == TokuseiNo.KATAYABURI ||
                    atkTokusei == TokuseiNo.TAABOBUREIZU ||
                    atkTokusei == TokuseiNo.TERABORUTEEZI)
                {
                    return;
                }
            }

            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // Target's ability is Oblivious, Clear Body, or White Smoke
            if (defTokusei == TokuseiNo.DONKAN ||
                defTokusei == TokuseiNo.KURIABODHI ||
                defTokusei == TokuseiNo.SIROIKEMURI)
            {
                ScoreCtrl(-10);
                return;
            }
            // Target's ability is Contrary or Magic Bounce
            else if (defTokusei == TokuseiNo.AMANOZYAKU ||
                     defTokusei == TokuseiNo.MAZIKKUMIRAA)
            {
                ScoreCtrl(-12);
                return;
            }
            else
            {
                // Target's type is Grass
                if (Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 }) == POKETYPE_KUSA ||
                    Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 }) == POKETYPE_KUSA)
                {
                    // Target's ability is Flower Veil
                    if (defTokusei == TokuseiNo.HURAWAABEERU)
                    {
                        ScoreCtrl(-10);
                        return;
                    }
                    // Double Battle, and target's ally's ability is Flower Veil
                    else if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_DOUBLE &&
                             (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE_FRIEND }) == TokuseiNo.HURAWAABEERU)
                    {
                        ScoreCtrl(-10);
                        return;
                    }
                }
            }
        }

        // 22 - -1 Special Defense Stage
        // 62 - -2 Special Defense Stages
        private void BaciAI_Seq_022()
        {
            // BUG: Checks for user instead of target
            // User's Special Defense is at -6 stages
            if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_ATTACK, PARA_SPEDEF, 0 }) != 0)
            {
                ScoreCtrl(-10);
            }

            // Target's ability is Competitive or Defiant
            switch ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE }))
            {
                case TokuseiNo.MAKENKI:
                case TokuseiNo.KATIKI:
                    ScoreCtrl(-8);
                    break;
            }

            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });

            // User's ability is not Infiltrator
            if (atkTokusei != TokuseiNo.SURINUKE)
            {
                // Target has a substitute
                if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0)
                {
                    ScoreCtrl(-10);
                    return;
                }

                // Target's side has Mist active
                if (Call(CMD_IF_SIDEEFF, new long[] { CHECK_DEFENCE, BTL_SIDEEFF_SIROIKIRI }) != 0)
                {
                    ScoreCtrl(-10);
                }

                // User's ability is Mold Breaker, Turboblaze, or Teravolt
                if (atkTokusei == TokuseiNo.KATAYABURI ||
                    atkTokusei == TokuseiNo.TAABOBUREIZU ||
                    atkTokusei == TokuseiNo.TERABORUTEEZI)
                {
                    return;
                }
            }

            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // Target's ability is Clear Body or White Smoke
            if (defTokusei == TokuseiNo.KURIABODHI ||
                defTokusei == TokuseiNo.SIROIKEMURI)
            {
                ScoreCtrl(-10);
                return;
            }
            // Target's ability is Contrary or Magic Bounce
            else if (defTokusei == TokuseiNo.AMANOZYAKU ||
                     defTokusei == TokuseiNo.MAZIKKUMIRAA)
            {
                ScoreCtrl(-12);
                return;
            }
            else
            {
                // Target's type is Grass
                if (Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 }) == POKETYPE_KUSA ||
                    Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 }) == POKETYPE_KUSA)
                {
                    // Target's ability is Flower Veil
                    if (defTokusei == TokuseiNo.HURAWAABEERU)
                    {
                        ScoreCtrl(-10);
                        return;
                    }
                    // Double Battle, and target's ally's ability is Flower Veil
                    else if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_DOUBLE &&
                             (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE_FRIEND }) == TokuseiNo.HURAWAABEERU)
                    {
                        ScoreCtrl(-10);
                        return;
                    }
                }
            }
        }

        // 23 - -1 Accuracy Stage
        // 63 - -2 Accuracy Stages
        private void BaciAI_Seq_023()
        {
            // BUG: Checks for user instead of target
            // User's Accuracy is at -6 stages
            if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_ATTACK, PARA_HIT, 0 }) != 0)
            {
                ScoreCtrl(-10);
            }

            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });

            // Target's ability is No Guard
            if (defTokusei == TokuseiNo.NOOGAADO)
            {
                ScoreCtrl(-10);
            }
            // Target's ability is Competitive or Defiant
            else if (defTokusei == TokuseiNo.MAKENKI ||
                     defTokusei == TokuseiNo.KATIKI)
            {
                ScoreCtrl(-8);
            }
            // User's ability is No Guard
            else if (atkTokusei == TokuseiNo.NOOGAADO)
            {
                ScoreCtrl(-10);
            }

            // User's ability is not Infiltrator
            if (atkTokusei != TokuseiNo.SURINUKE)
            {
                // Target has a substitute
                if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0)
                {
                    ScoreCtrl(-10);
                    return;
                }

                // Target's side has Mist active
                if (Call(CMD_IF_SIDEEFF, new long[] { CHECK_DEFENCE, BTL_SIDEEFF_SIROIKIRI }) != 0)
                {
                    ScoreCtrl(-10);
                }

                // User's ability is Mold Breaker, Turboblaze, or Teravolt
                if (atkTokusei == TokuseiNo.KATAYABURI ||
                    atkTokusei == TokuseiNo.TAABOBUREIZU ||
                    atkTokusei == TokuseiNo.TERABORUTEEZI)
                {
                    return;
                }
            }

            // Target's ability is Clear Body, Keen Eye, or White Smoke
            if (defTokusei == TokuseiNo.KURIABODHI ||
                defTokusei == TokuseiNo.SURUDOIME ||
                defTokusei == TokuseiNo.SIROIKEMURI)
            {
                ScoreCtrl(-10);
                return;
            }
            // Target's ability is Contrary or Magic Bounce
            else if (defTokusei == TokuseiNo.AMANOZYAKU ||
                     defTokusei == TokuseiNo.MAZIKKUMIRAA)
            {
                ScoreCtrl(-12);
                return;
            }
            else
            {
                // Target's type is Grass
                if (Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 }) == POKETYPE_KUSA ||
                    Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 }) == POKETYPE_KUSA)
                {
                    // Target's ability is Flower Veil
                    if (defTokusei == TokuseiNo.HURAWAABEERU)
                    {
                        ScoreCtrl(-10);
                        return;
                    }
                    // Double Battle, and target's ally's ability is Flower Veil
                    else if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_DOUBLE &&
                             (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE_FRIEND }) == TokuseiNo.HURAWAABEERU)
                    {
                        ScoreCtrl(-10);
                        return;
                    }
                }
            }
        }

        // 24 - -1 Evasiveness Stage
        // 64 - -2 Evasiveness Stages
        private void BaciAI_Seq_024()
        {
            // Target's Evasiveness is at -6 stages
            if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_DEFENCE, PARA_AVOID, 0 }) != 0)
            {
                ScoreCtrl(-10);
            }

            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });

            // Target's ability is No Guard
            if (defTokusei == TokuseiNo.NOOGAADO)
            {
                ScoreCtrl(-10);
            }
            // Target's ability is Competitive or Defiant
            else if (defTokusei == TokuseiNo.MAKENKI ||
                     defTokusei == TokuseiNo.KATIKI)
            {
                ScoreCtrl(-8);
            }
            // User's ability is No Guard
            else if (atkTokusei == TokuseiNo.NOOGAADO)
            {
                ScoreCtrl(-10);
            }

            // User's ability is not Infiltrator
            if (atkTokusei != TokuseiNo.SURINUKE)
            {
                // Target has a substitute
                if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0)
                {
                    ScoreCtrl(-10);
                    return;
                }

                // Target's side has Mist active
                if (Call(CMD_IF_SIDEEFF, new long[] { CHECK_DEFENCE, BTL_SIDEEFF_SIROIKIRI }) != 0)
                {
                    ScoreCtrl(-10);
                }

                // User's ability is Mold Breaker, Turboblaze, or Teravolt
                if (atkTokusei == TokuseiNo.KATAYABURI ||
                    atkTokusei == TokuseiNo.TAABOBUREIZU ||
                    atkTokusei == TokuseiNo.TERABORUTEEZI)
                {
                    return;
                }
            }

            // Target's ability is Clear Body or White Smoke
            if (defTokusei == TokuseiNo.KURIABODHI ||
                defTokusei == TokuseiNo.SIROIKEMURI)
            {
                ScoreCtrl(-10);
                return;
            }
            // Target's ability is Contrary or Magic Bounce
            else if (defTokusei == TokuseiNo.AMANOZYAKU ||
                     defTokusei == TokuseiNo.MAZIKKUMIRAA)
            {
                ScoreCtrl(-12);
                return;
            }
            else
            {
                // Target's type is Grass
                if (Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 }) == POKETYPE_KUSA ||
                    Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 }) == POKETYPE_KUSA)
                {
                    // Target's ability is Flower Veil
                    if (defTokusei == TokuseiNo.HURAWAABEERU)
                    {
                        ScoreCtrl(-10);
                        return;
                    }
                    // Double Battle, and target's ally's ability is Flower Veil
                    else if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_DOUBLE &&
                             (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE_FRIEND }) == TokuseiNo.HURAWAABEERU)
                    {
                        ScoreCtrl(-10);
                        return;
                    }
                }
            }
        }

        // 25  - Haze
        // 143 - Psych Up
        private void BaciAI_Seq_025()
        {
            // Any of user's stats are at +1 stage or more, or
            // Any of target's stats are at -1 stage or less
            if (Call(CMD_IF_PARA_OVER, new long[] { CHECK_ATTACK, PARA_POW, 6 }) != 0 ||
                Call(CMD_IF_PARA_OVER, new long[] { CHECK_ATTACK, PARA_DEF, 6 }) != 0 ||
                Call(CMD_IF_PARA_OVER, new long[] { CHECK_ATTACK, PARA_SPEPOW, 6 }) != 0 ||
                Call(CMD_IF_PARA_OVER, new long[] { CHECK_ATTACK, PARA_SPEDEF, 6 }) != 0 ||
                Call(CMD_IF_PARA_OVER, new long[] { CHECK_ATTACK, PARA_AGI, 6 }) != 0 ||
                Call(CMD_IF_PARA_OVER, new long[] { CHECK_ATTACK, PARA_HIT, 6 }) != 0 ||
                Call(CMD_IF_PARA_OVER, new long[] { CHECK_ATTACK, PARA_AVOID, 6 }) != 0 ||
                Call(CMD_IF_PARA_UNDER, new long[] { CHECK_DEFENCE, PARA_POW, 6 }) != 0 ||
                Call(CMD_IF_PARA_UNDER, new long[] { CHECK_DEFENCE, PARA_DEF, 6 }) != 0 ||
                Call(CMD_IF_PARA_UNDER, new long[] { CHECK_DEFENCE, PARA_SPEPOW, 6 }) != 0 ||
                Call(CMD_IF_PARA_UNDER, new long[] { CHECK_DEFENCE, PARA_SPEDEF, 6 }) != 0 ||
                Call(CMD_IF_PARA_UNDER, new long[] { CHECK_DEFENCE, PARA_AGI, 6 }) != 0 ||
                Call(CMD_IF_PARA_UNDER, new long[] { CHECK_DEFENCE, PARA_HIT, 6 }) != 0 ||
                Call(CMD_IF_PARA_UNDER, new long[] { CHECK_DEFENCE, PARA_AVOID, 6 }) != 0)
            {
                ScoreCtrl(-6);
            }
        }

        // 28 - Force Switch Out
        private void BaciAI_Seq_028()
        {
            // Target's side has no other Pokémon left in their party
            if (Call(CMD_CHECK_BENCH_COUNT, new long[] { CHECK_DEFENCE }) == 0)
            {
                ScoreCtrl(-10);
            }

            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });

            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt
            // and target's ability is Suction Cups or Magic Bounce
            if (atkTokusei != TokuseiNo.KATAYABURI &&
                atkTokusei != TokuseiNo.TAABOBUREIZU &&
                atkTokusei != TokuseiNo.TERABORUTEEZI &&
                (defTokusei == TokuseiNo.KYUUBAN ||
                 defTokusei == TokuseiNo.MAZIKKUMIRAA))
            {
                ScoreCtrl(-10);
            }
        }

        // 37 - Rest
        private void BaciAI_Seq_037()
        {
            // User is afflicted by Heal Block
            if (Call(CMD_IF_WAZASICK, new long[] { CHECK_ATTACK, WAZASICK_KAIHUKUHUUJI }) != 0)
            {
                ScoreCtrl(-10);
                return;
            }

            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var atkType1 = Call(CMD_CHECK_TYPE, new long[] { CHECK_ATTACK_TYPE1 });
            var atkType2 = Call(CMD_CHECK_TYPE, new long[] { CHECK_ATTACK_TYPE2 });

            // Electric Terrain is active and user is grounded
            if (Call(CMD_IF_EXIST_GROUND, new long[] { BTL_GROUND_ELEKI }) != 0 &&
                atkTokusei != TokuseiNo.HUYUU &&
                atkType1 != POKETYPE_HIKOU &&
                atkType2 != POKETYPE_HIKOU)
            {
                ScoreCtrl(-10);
                return;
            }

            // Misty Terrain is active and user is grounded
            if (Call(CMD_IF_EXIST_GROUND, new long[] { BTL_GROUND_MIST }) != 0 &&
                atkTokusei != TokuseiNo.HUYUU &&
                atkType1 != POKETYPE_HIKOU &&
                atkType2 != POKETYPE_HIKOU)
            {
                ScoreCtrl(-10);
                return;
            }

            BaciAI_Seq_032();
        }

        // 32  - Self-Healing
        // 381 - Shore Up
        private void BaciAI_Seq_032()
        {
            // User's HP is 100%
            if (Call(CMD_IF_HP_EQUAL, new long[] { CHECK_ATTACK, 100 }) != 0)
            {
                ScoreCtrl(-8);
                return;
            }
        }

        // 33 - Induces Bad Poison
        // 66 - Induces Poison
        private void BaciAI_Seq_033()
        {
            var defType1 = Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 });
            var defType2 = Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var weather = Call(CMD_CHECK_WEATHER, Array.Empty<long>());

            // Target's ability is Poison Heal
            if (defTokusei == TokuseiNo.POIZUNHIIRU)
            {
                ScoreCtrl(-12);
                return;
            }

            // User's ability is not Infiltrator and target has a substitute
            if (atkTokusei != TokuseiNo.SURINUKE &&
                Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0)
            {
                ScoreCtrl(-10);
                return;
            }

            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt
            if (atkTokusei != TokuseiNo.KATAYABURI &&
                atkTokusei != TokuseiNo.TAABOBUREIZU &&
                atkTokusei != TokuseiNo.TERABORUTEEZI)
            {
                // Target's ability is Shields Down
                if (defTokusei == TokuseiNo.RIMITTOSIIRUDO)
                {
                    // Target's HP is over 51%
                    if (Call(CMD_IF_HP_OVER, new long[] { CHECK_DEFENCE, 51 }) != 0)
                    {
                        ScoreCtrl(-10);
                        return;
                    }
                }
                // Target's ability is Magic Bounce
                else if (defTokusei == TokuseiNo.MAZIKKUMIRAA)
                {
                    ScoreCtrl(-12);
                    return;
                }
                // Target's ability is Immunity
                else if (defTokusei == TokuseiNo.MENEKI)
                {
                    ScoreCtrl(-10);
                    return;
                }
                // Target's ability is Leaf Guard and weather is Harsh Sunlight
                else if (defTokusei == TokuseiNo.RIIHUGAADO && weather == WEATHER_HARE)
                {
                    ScoreCtrl(-10);
                    return;
                }

                // Target's type is Grass
                if (Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 }) == POKETYPE_KUSA ||
                    Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 }) == POKETYPE_KUSA)
                {
                    // Target's ability is Flower Veil
                    if (defTokusei == TokuseiNo.HURAWAABEERU)
                    {
                        ScoreCtrl(-10);
                        return;
                    }
                    // Double Battle, and target's ally's ability is Flower Veil
                    else if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_DOUBLE &&
                             (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE_FRIEND }) == TokuseiNo.HURAWAABEERU)
                    {
                        ScoreCtrl(-10);
                        return;
                    }
                }
            }

            // Target's type is Poison or Steel
            if (defType1 == POKETYPE_DOKU || defType1 == POKETYPE_HAGANE ||
                defType2 == POKETYPE_DOKU || defType2 == POKETYPE_HAGANE)
            {
                ScoreCtrl(-10);
                return;
            }

            // Target's ability is Magic Guard
            if (defTokusei == TokuseiNo.MAZIKKUGAADO)
            {
                ScoreCtrl(-10);
                return;
            }

            // Target has a status effect
            if (Call(CMD_IF_POKESICK, new long[] { CHECK_DEFENCE }) != 0)
            {
                ScoreCtrl(-10);
                return;
            }

            // Misty Terrain is active and target is grounded
            if (Call(CMD_IF_EXIST_GROUND, new long[] { BTL_GROUND_MIST }) != 0 &&
                defTokusei != TokuseiNo.HUYUU &&
                defType1 != POKETYPE_HIKOU &&
                defType2 != POKETYPE_HIKOU)
            {
                ScoreCtrl(-10);
                return;
            }

            // Target's side has Safeguard active
            if (Call(CMD_IF_SIDEEFF, new long[] { CHECK_DEFENCE, BTL_SIDEEFF_SINPINOMAMORI }) != 0)
            {
                ScoreCtrl(-10);
                return;
            }
        }
        
        // 35 - Light Screen
        private void BaciAI_Seq_035()
        {
            // User's side has Light Screen active
            if (Call(CMD_IF_SIDEEFF, new long[] { CHECK_ATTACK, BTL_SIDEEFF_HIKARINOKABE }) != 0)
            {
                ScoreCtrl(-10);
                return;
            }
        }

        // 38 - One-Hit KO
        private void BaciAI_Seq_038()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });

            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt
            if (atkTokusei != TokuseiNo.KATAYABURI &&
                atkTokusei != TokuseiNo.TAABOBUREIZU &&
                atkTokusei != TokuseiNo.TERABORUTEEZI)
            {
                // Target's ability is Sturdy
                if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE }) == TokuseiNo.GANZYOU)
                {
                    ScoreCtrl(-10);
                }
            }

            // Target's level is higher than user
            if (Call(CMD_IF_LEVEL, new long[] { IF_FIRST_DEFENCE }) != 0)
            {
                ScoreCtrl(-10);
            }
        }
        
        // 46 - Mist
        private void BaciAI_Seq_046()
        {
            // User's side has Mist active
            if (Call(CMD_IF_SIDEEFF, new long[] { CHECK_ATTACK, BTL_SIDEEFF_SIROIKIRI }) != 0)
            {
                ScoreCtrl(-10);
                return;
            }
        }

        // 47 - Focus Energy
        private void BaciAI_Seq_047()
        {
            // User's side has Focus Energy active
            if (Call(CMD_IF_CONTFLG, new long[] { CHECK_ATTACK, CONTFLG_KIAIDAME }) != 0)
            {
                ScoreCtrl(-10);
                return;
            }
        }

        // 49  - Induces Confusion
        // 118 - Swagger
        // 166 - Flatter
        // 199 - Teeter Dance
        private void BaciAI_Seq_049()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // Target's side has Safeguard active
            if (Call(CMD_IF_SIDEEFF, new long[] { CHECK_DEFENCE, BTL_SIDEEFF_SINPINOMAMORI }) != 0)
            {
                ScoreCtrl(-10);
            }
            // Target is confused
            else if (Call(CMD_IF_WAZASICK, new long[] { CHECK_DEFENCE, WAZASICK_KONRAN }) != 0)
            {
                ScoreCtrl(-8);
            }

            // Target has a substitute
            if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0)
            {
                // User's ability is not Infiltrator
                if (atkTokusei != TokuseiNo.SURINUKE)
                {
                    ScoreCtrl(-10);
                    return;
                }
            }
            else
            {
                // User's ability is not Mold Breaker, Turboblaze, nor Teravolt
                if (atkTokusei != TokuseiNo.KATAYABURI &&
                    atkTokusei != TokuseiNo.TAABOBUREIZU &&
                    atkTokusei != TokuseiNo.TERABORUTEEZI)
                {
                    // Target's ability is Magic Bounce
                    if (defTokusei == TokuseiNo.MAZIKKUMIRAA)
                    {
                        ScoreCtrl(-12);
                    }
                    // Target's ability is Own Tempo
                    else if (defTokusei == TokuseiNo.MAIPEESU)
                    {
                        ScoreCtrl(-10);
                    }
                }
            }
        }

        // 65 - Reflect
        private void BaciAI_Seq_065()
        {
            // User's side has Reflect active
            if (Call(CMD_IF_SIDEEFF, new long[] { CHECK_ATTACK, BTL_SIDEEFF_REFLECTOR }) != 0)
            {
                ScoreCtrl(-10);
                return;
            }
        }
        
        // 67 - Induces Paralysis
        private void BaciAI_Seq_067()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });
            var waza = CurrentWazaNo();
            var defType1 = Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 });
            var defType2 = Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 });
            var weather = Call(CMD_CHECK_WEATHER, Array.Empty<long>());

            // Target's side has Safeguard active
            if (Call(CMD_IF_SIDEEFF, new long[] { CHECK_DEFENCE, BTL_SIDEEFF_SINPINOMAMORI }) != 0)
            {
                ScoreCtrl(-10);
            }
            // Target has a status effect
            else if (Call(CMD_IF_POKESICK, new long[] { CHECK_DEFENCE }) != 0)
            {
                ScoreCtrl(-10);
            }
            // Target's type is Electric
            else if (defType1 == POKETYPE_DENKI ||
                     defType2 == POKETYPE_DENKI)
            {
                ScoreCtrl(-10);
            }
            // Move affinity is "No Effect"
            else if (Call(CMD_CHECK_WAZA_AISYOU, new long[] { CHECK_ATTACK, CHECK_DEFENCE, (ushort)CurrentWazaNo(), AISYOU_0BAI }) != 0)
            {
                ScoreCtrl(-10);
            }
            // Move is Thunder Wave and target's type is Ground
            else if (waza == WazaNo.DENZIHA &&
                     (defType1 == POKETYPE_JIMEN ||
                      defType2 == POKETYPE_JIMEN))
            {
                ScoreCtrl(-10);
            }

            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt
            if (atkTokusei != TokuseiNo.KATAYABURI &&
                atkTokusei != TokuseiNo.TAABOBUREIZU &&
                atkTokusei != TokuseiNo.TERABORUTEEZI)
            {
                // Target's ability is Limber
                if (defTokusei == TokuseiNo.ZYUUNAN)
                {
                    ScoreCtrl(-10);
                    return;
                }

                // Target's ability is Magic Bounce
                if (defTokusei == TokuseiNo.MAZIKKUMIRAA)
                {
                    ScoreCtrl(-12);
                    return;
                }

                // Move is Thunder Wave and target's ability is Volt Absorb, Lightning Rod, or Motor Drive
                if (waza == WazaNo.DENZIHA &&
                    (defTokusei == TokuseiNo.TIKUDEN ||
                     defTokusei == TokuseiNo.HIRAISIN ||
                     defTokusei == TokuseiNo.DENKIENZIN))
                {
                    ScoreCtrl(-10);
                    return;
                }

                // Target's ability is Leaf Guard and weather is Harsh Sunlight
                if (defTokusei == TokuseiNo.RIIHUGAADO && weather == WEATHER_HARE)
                {
                    ScoreCtrl(-10);
                }

                // Target's type is Grass
                if (Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 }) == POKETYPE_KUSA ||
                    Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 }) == POKETYPE_KUSA)
                {
                    // Target's ability is Flower Veil
                    if (defTokusei == TokuseiNo.HURAWAABEERU)
                    {
                        ScoreCtrl(-10);
                        return;
                    }
                    // Double Battle, and target's ally's ability is Flower Veil
                    else if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_DOUBLE &&
                             (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE_FRIEND }) == TokuseiNo.HURAWAABEERU)
                    {
                        ScoreCtrl(-10);
                        return;
                    }
                }

                // Target's ability is Shields Down
                if (defTokusei == TokuseiNo.RIMITTOSIIRUDO)
                {
                    // Target's HP is over 51%
                    if (Call(CMD_IF_HP_OVER, new long[] { CHECK_DEFENCE, 51 }) != 0)
                    {
                        ScoreCtrl(-10);
                        return;
                    }
                }
            }

            // User's ability is not Infiltrator and target has a substitute
            if (atkTokusei != TokuseiNo.SURINUKE &&
                Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0)
            {
                ScoreCtrl(-10);
                return;
            }

            // Misty Terrain is active and target is grounded
            if (defType1 != POKETYPE_HIKOU &&
                defType2 != POKETYPE_HIKOU &&
                defTokusei != TokuseiNo.HUYUU &&
                Call(CMD_IF_EXIST_GROUND, new long[] { BTL_GROUND_MIST }) != 0)
            {
                ScoreCtrl(-10);
                return;
            }
        }

        // 79 - Substitute
        private void BaciAI_Seq_079()
        {
            // User has a substitute
            if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_ATTACK }) != 0)
            {
                ScoreCtrl(-8);
            }

            // User's HP is under 26%
            if (Call(CMD_IF_HP_UNDER, new long[] { CHECK_ATTACK, 26 }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 84 - Induces Leech Seed
        private void BaciAI_Seq_084()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });
            var defType1 = Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 });
            var defType2 = Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 });

            // Target is afflicted by Leech Seed
            if (Call(CMD_IF_WAZASICK, new long[] { CHECK_DEFENCE, WAZASICK_YADORIGI }) != 0)
            {
                ScoreCtrl(-8);
            }
            // Target's type is Grass
            else if (defType1 != POKETYPE_KUSA &&
                     defType2 != POKETYPE_KUSA)
            {
                ScoreCtrl(-10);
            }
            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt
            else if (atkTokusei != TokuseiNo.KATAYABURI &&
                     atkTokusei != TokuseiNo.TAABOBUREIZU &&
                     atkTokusei != TokuseiNo.TERABORUTEEZI)
            {
                // Target's ability is Magic Guard
                if (defTokusei == TokuseiNo.MAZIKKUGAADO)
                {
                    ScoreCtrl(-10);
                }
                // Target's ability is Magic Bounce
                else if (defTokusei == TokuseiNo.MAZIKKUMIRAA)
                {
                    ScoreCtrl(-12);
                }
            }

            // User's ability is not Infiltrator and target has a substitute
            if (atkTokusei != TokuseiNo.SURINUKE &&
                Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 86 - Induces Move Disabled
        private void BaciAI_Seq_086()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // Target is afflicted by Move Disabled
            if (Call(CMD_IF_WAZASICK, new long[] { CHECK_DEFENCE, WAZASICK_KANASIBARI }) != 0)
            {
                ScoreCtrl(-10);
            }

            // User's ability is Prankster or user goes first
            if (atkTokusei == TokuseiNo.ITAZURAGOKORO ||
                Call(CMD_IF_FIRST, new long[] { IF_FIRST_ATTACK }) != 0)
            {
                // Target's previous move is not defined
                if ((WazaNo)Call(CMD_CHECK_LAST_WAZA, new long[] { CHECK_DEFENCE }) == WazaNo.NULL)
                {
                    ScoreCtrl(-10);
                    return;
                }
            }
            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt
            else if (atkTokusei != TokuseiNo.KATAYABURI &&
                     atkTokusei != TokuseiNo.TAABOBUREIZU &&
                     atkTokusei != TokuseiNo.TERABORUTEEZI)
            {
                // Target's ability is Magic Bounce
                if (defTokusei == TokuseiNo.MAZIKKUMIRAA)
                {
                    ScoreCtrl(-12);
                }
                // Target's ability is Aroma Veil
                else if (defTokusei == TokuseiNo.AROMABEERU)
                {
                    ScoreCtrl(-10);
                }

                // Double Battle, and target's ally's ability is Aroma Veil
                if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_DOUBLE &&
                    (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE_FRIEND }) == TokuseiNo.AROMABEERU)
                {
                    ScoreCtrl(-10);
                    return;
                }
            }
        }

        // 90 - Induces Encore
        private void BaciAI_Seq_090()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // Target is afflicted by Encore
            if (Call(CMD_IF_WAZASICK, new long[] { CHECK_DEFENCE, WAZASICK_ENCORE }) != 0)
            {
                ScoreCtrl(-10);
            }

            // User's ability is Prankster or user goes first
            if (atkTokusei == TokuseiNo.ITAZURAGOKORO ||
                Call(CMD_IF_FIRST, new long[] { IF_FIRST_ATTACK }) != 0)
            {
                // Target's previous move is not defined
                if ((WazaNo)Call(CMD_CHECK_LAST_WAZA, new long[] { CHECK_DEFENCE }) == WazaNo.NULL)
                {
                    ScoreCtrl(-10);
                    return;
                }
            }
            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt
            else if (atkTokusei != TokuseiNo.KATAYABURI &&
                     atkTokusei != TokuseiNo.TAABOBUREIZU &&
                     atkTokusei != TokuseiNo.TERABORUTEEZI)
            {
                // Target's ability is Magic Bounce
                if (defTokusei == TokuseiNo.MAZIKKUMIRAA)
                {
                    ScoreCtrl(-12);
                }
                // Target's ability is Aroma Veil
                else if (defTokusei == TokuseiNo.AROMABEERU)
                {
                    ScoreCtrl(-10);
                }

                // Double Battle, and target's ally's ability is Aroma Veil
                if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_DOUBLE &&
                    (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE_FRIEND }) == TokuseiNo.AROMABEERU)
                {
                    ScoreCtrl(-10);
                    return;
                }
            }
        }

        // 92 - Snore
        // 97 - Sleep Talk
        private void BaciAI_Seq_092()
        {
            // User is not asleep
            if (Call(CMD_IFN_WAZASICK, new long[] { CHECK_ATTACK, WAZASICK_NEMURI }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 94 - Lock-On
        private void BaciAI_Seq_094()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // User is not asleep
            if (Call(CMD_IF_WAZASICK, new long[] { CHECK_ATTACK, WAZASICK_MUSTHIT_TARGET }) != 0)
            {
                ScoreCtrl(-10);
            }
            // User or target's ability is No Guard
            else if (atkTokusei == TokuseiNo.NOOGAADO ||
                     defTokusei == TokuseiNo.NOOGAADO)
            {
                ScoreCtrl(-8);
            }

            // Target has a substitute and user's ability is not Infiltrator
            if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0 &&
                atkTokusei != TokuseiNo.SURINUKE)
            {
                ScoreCtrl(-10);
                return;
            }
        }

        // 102 - Cure Party Status Effects
        private void BaciAI_Seq_102()
        {
            // User does not have a status effect and
            // The rest of the Pokémon in the party of the user's side do not have a status effect
            if (Call(CMD_IFN_POKESICK, new long[] { CHECK_ATTACK }) != 0 &&
                Call(CMD_IFN_BENCH_COND, new long[] { CHECK_ATTACK }) != 0)
            {
                // Double battle and user's ally does not have a status effect
                if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_DOUBLE &&
                    Call(CMD_IF_POKESICK, new long[] { CHECK_ATTACK_FRIEND }) != 0)
                {
                    return;
                }

                ScoreCtrl(-10);
            }
        }

        // 106 - Induces Can’t Escape
        private void BaciAI_Seq_106()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // Target is afflicted by Can’t Escape
            if (Call(CMD_IF_WAZASICK, new long[] { CHECK_DEFENCE, WAZASICK_TOOSENBOU }) != 0)
            {
                ScoreCtrl(-10);
            }

            // Target's type is Ghost
            if (Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 }) == POKETYPE_GHOST ||
                Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 }) == POKETYPE_GHOST)
            {
                ScoreCtrl(-10);
            }
            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt and
            // Target's ability is Magic Bounce
            else if (atkTokusei != TokuseiNo.KATAYABURI &&
                     atkTokusei != TokuseiNo.TAABOBUREIZU &&
                     atkTokusei != TokuseiNo.TERABORUTEEZI &&
                     defTokusei == TokuseiNo.MAZIKKUMIRAA)
            {
                ScoreCtrl(-12);
                return;
            }

            // Target has a substitute and user's ability is not Infiltrator
            if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0 &&
                atkTokusei != TokuseiNo.SURINUKE)
            {
                ScoreCtrl(-10);
            }
        }

        // 107 - Induces Nightmare
        private void BaciAI_Seq_107()
        {
            // Target is afflicted by Nightmare
            if (Call(CMD_IF_WAZASICK, new long[] { CHECK_DEFENCE, WAZASICK_AKUMU }) != 0)
            {
                ScoreCtrl(-10);
            }
            // Target is not asleep
            else if (Call(CMD_IFN_WAZASICK, new long[] { CHECK_DEFENCE, WAZASICK_NEMURI }) != 0)
            {
                ScoreCtrl(-8);
            }

            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });

            // Target has a substitute and user's ability is not Infiltrator
            if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0 &&
                atkTokusei != TokuseiNo.SURINUKE)
            {
                ScoreCtrl(-10);
                return;
            }
        }
        
        // 109 - Curse
        private void BaciAI_Seq_109()
        {
            var atkType1 = Call(CMD_CHECK_TYPE, new long[] { CHECK_ATTACK_TYPE1 });
            var atkType2 = Call(CMD_CHECK_TYPE, new long[] { CHECK_ATTACK_TYPE2 });

            // User's type is Ghost
            if (atkType1 == POKETYPE_GHOST ||
                atkType2 == POKETYPE_GHOST)
            {
                // Target is afflicted by Curse
                if (Call(CMD_IF_WAZASICK, new long[] { CHECK_DEFENCE, WAZASICK_NOROI }) != 0)
                {
                    ScoreCtrl(-10);
                }
            }
            // User's ability is Contrary
            else if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK }) == TokuseiNo.AMANOZYAKU)
            {
                ScoreCtrl(-12);
            }
            // User's Attack is at +6 stages
            else if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_ATTACK, PARA_POW, 12 }) != 0)
            {
                ScoreCtrl(-10);
            }
            // User's Defense is at +6 stages
            else if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_ATTACK, PARA_DEF, 12 }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 112 - Spikes
        private void BaciAI_Seq_112()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });
            var defSideEffCount = Call(CMD_CHECK_SIDEEFF_COUNT, new long[] { CHECK_DEFENCE, BTL_SIDEEFF_MAKIBISI });
            var defBenchCount = Call(CMD_CHECK_BENCH_COUNT, new long[] { CHECK_DEFENCE });

            // Target's side has 3 stacks of Spikes
            if (defSideEffCount == 3)
            {
                ScoreCtrl(-10);
            }
            // Target's side has no other Pokémon left in their party
            else if (defBenchCount == 0)
            {
                ScoreCtrl(-10);
            }
            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt and
            // Target's ability is Magic Bounce
            else if (atkTokusei != TokuseiNo.KATAYABURI &&
                     atkTokusei != TokuseiNo.TAABOBUREIZU &&
                     atkTokusei != TokuseiNo.TERABORUTEEZI &&
                     defTokusei == TokuseiNo.MAZIKKUMIRAA)
            {
                ScoreCtrl(-12);
            }
        }

        // 113 - Induces Identified
        private void BaciAI_Seq_113()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // Target is afflicted by Identified
            if (Call(CMD_IF_WAZASICK, new long[] { CHECK_DEFENCE, WAZASICK_MIYABURU }) != 0)
            {
                ScoreCtrl(-10);
            }
            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt and
            // Target's ability is Magic Bounce
            else if (atkTokusei != TokuseiNo.KATAYABURI &&
                     atkTokusei != TokuseiNo.TAABOBUREIZU &&
                     atkTokusei != TokuseiNo.TERABORUTEEZI &&
                     defTokusei == TokuseiNo.MAZIKKUMIRAA)
            {
                ScoreCtrl(-12);
            }
        }

        // 114 - Perish Song
        private void BaciAI_Seq_114()
        {
            // Target is afflicted by Perish Song
            if (Call(CMD_IF_WAZASICK, new long[] { CHECK_DEFENCE, WAZASICK_HOROBINOUTA }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 115 - Sandstorm
        private void BaciAI_Seq_115()
        {
            var weather = Call(CMD_CHECK_WEATHER, Array.Empty<long>());

            // Weather is Sandstorm, Heavy Rain, Extremely Harsh Sunlight, or Strong Winds
            if (weather == WEATHER_SUNAARASHI ||
                weather == WEATHER_OOAME ||
                weather == WEATHER_OOHIDERI ||
                weather == WEATHER_RANKIRYUU)
            {
                ScoreCtrl(-8);
            }
        }

        // 120 - Induces Infatuation
        private void BaciAI_Seq_120()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });
            var atkSex = (Sex)Call(CMD_CHECK_POKESEX, new long[] { CHECK_ATTACK });
            var defSex = (Sex)Call(CMD_CHECK_POKESEX, new long[] { CHECK_DEFENCE });

            // Target is afflicted by Infatuation
            if (Call(CMD_IF_WAZASICK, new long[] { CHECK_DEFENCE, WAZASICK_MEROMERO }) != 0)
            {
                ScoreCtrl(-10);
            }
            // Target is afflicted by Infatuation
            else if (Call(CMD_IF_WAZASICK, new long[] { CHECK_DEFENCE, WAZASICK_MEROMERO }) != 0)
            {
                ScoreCtrl(-10);
            }
            // User is female
            else if (atkSex == Sex.FEMALE)
            {
                // Target is not male
                if (defSex != Sex.MALE)
                {
                    ScoreCtrl(-10);
                }
            }
            // User is male
            else if (atkSex == Sex.MALE)
            {
                // Target is not female
                if (defSex != Sex.FEMALE)
                {
                    ScoreCtrl(-10);
                }
            }
            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt
            else if (atkTokusei != TokuseiNo.KATAYABURI &&
                     atkTokusei != TokuseiNo.TAABOBUREIZU &&
                     atkTokusei != TokuseiNo.TERABORUTEEZI)
            {
                // Target's ability is Oblivious or Aroma Veil
                if (defTokusei == TokuseiNo.DONKAN ||
                    defTokusei == TokuseiNo.AROMABEERU)
                {
                    ScoreCtrl(-10);
                }
                // Target's ability is Magic Bounce
                else if (defTokusei == TokuseiNo.MAZIKKUMIRAA)
                {
                    ScoreCtrl(-12);
                }

                // Double Battle, and target's ally's ability is Aroma Veil
                if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_DOUBLE &&
                    (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE_FRIEND }) == TokuseiNo.AROMABEERU)
                {
                    ScoreCtrl(-10);
                }
            }
        }

        // 124 - Safeguard
        private void BaciAI_Seq_124()
        {
            // User's side has Safeguard active
            if (Call(CMD_IF_SIDEEFF, new long[] { CHECK_ATTACK, BTL_SIDEEFF_SINPINOMAMORI }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 127 - Baton Pass
        private void BaciAI_Seq_127()
        {
            // User's side has no other Pokémon left in their party
            if (Call(CMD_CHECK_BENCH_COUNT, new long[] { CHECK_ATTACK }) == 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 132 - Sun-Boosted Healing
        // 133 - ???
        // 134 - ???
        // 157 - ???
        private void BaciAI_Seq_132()
        {
            // User's HP is 100%
            if (Call(CMD_IF_HP_EQUAL, new long[] { CHECK_ATTACK, 100 }) != 0)
            {
                ScoreCtrl(-8);
            }
        }

        // 136 - Rain
        private void BaciAI_Seq_136()
        {
            var weather = Call(CMD_CHECK_WEATHER, Array.Empty<long>());

            // Weather is Rain, Heavy Rain, Extremely Harsh Sunlight, or Strong Winds
            if (weather == WEATHER_AME ||
                weather == WEATHER_OOAME ||
                weather == WEATHER_OOHIDERI ||
                weather == WEATHER_RANKIRYUU)
            {
                ScoreCtrl(-8);
            }
        }

        // 137 - Harsh Sunlight
        private void BaciAI_Seq_137()
        {
            var weather = Call(CMD_CHECK_WEATHER, Array.Empty<long>());

            // Weather is Harsh Sunlight, Heavy Rain, Extremely Harsh Sunlight, or Strong Winds
            if (weather == WEATHER_HARE ||
                weather == WEATHER_OOAME ||
                weather == WEATHER_OOHIDERI ||
                weather == WEATHER_RANKIRYUU)
            {
                ScoreCtrl(-8);
            }
        }

        // 142 - Belly Drum
        private void BaciAI_Seq_142()
        {
            // User's ability is Contrary
            if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK }) == TokuseiNo.AMANOZYAKU)
            {
                ScoreCtrl(-12);
            }
            // User's Attack is at +6 stages
            else if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_ATTACK, PARA_POW, 12 }) != 0)
            {
                ScoreCtrl(-10);
            }
            // User's HP is under 51%
            else if (Call(CMD_IF_HP_UNDER, new long[] { CHECK_ATTACK, 51 }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 148 - Future Attack
        private void BaciAI_Seq_148()
        {
            // Future Attack is already set on the target
            if (Call(CMD_IF_MIRAIYOCHI, new long[] { CHECK_DEFENCE }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 158 - Fake Out
        // 376 - Mat Block
        // 382 - First Impression
        private void BaciAI_Seq_158()
        {
            // User has already taken an action in battle
            if (Call(CMD_CHECK_NEKODAMASI, new long[] { CHECK_ATTACK }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 160 - Stockpile
        private void BaciAI_Seq_160()
        {
            // User's ability is Contrary
            if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK }) == TokuseiNo.AMANOZYAKU)
            {
                ScoreCtrl(-12);
            }
            // User has 3 stages of Stockpile
            else if (Call(CMD_CHECK_TAKUWAERU, new long[] { CHECK_ATTACK }) == 3)
            {
                ScoreCtrl(-10);
            }
        }

        // 161 - Spit Up
        // 162 - Swallow
        private void BaciAI_Seq_161()
        {
            // User has 0 stages of Stockpile
            if (Call(CMD_CHECK_TAKUWAERU, new long[] { CHECK_ATTACK }) == 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 164 - Hail
        private void BaciAI_Seq_164()
        {
            var weather = Call(CMD_CHECK_WEATHER, Array.Empty<long>());

            // Weather is Hail, Heavy Rain, Extremely Harsh Sunlight, or Strong Winds
            if (weather == WEATHER_ARARE ||
                weather == WEATHER_OOAME ||
                weather == WEATHER_OOHIDERI ||
                weather == WEATHER_RANKIRYUU)
            {
                ScoreCtrl(-8);
            }
        }

        // 165 - Induces Torment
        private void BaciAI_Seq_165()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // Target is afflicted by Torment
            if (Call(CMD_IF_WAZASICK, new long[] { CHECK_DEFENCE, WAZASICK_ICHAMON }) != 0)
            {
                ScoreCtrl(-10);
            }
            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt
            else if (atkTokusei != TokuseiNo.KATAYABURI &&
                     atkTokusei != TokuseiNo.TAABOBUREIZU &&
                     atkTokusei != TokuseiNo.TERABORUTEEZI)
            {
                // Target's ability is Aroma Veil
                if (defTokusei == TokuseiNo.AROMABEERU)
                {
                    ScoreCtrl(-10);
                }
                // Target's ability is Magic Bounce
                else if (defTokusei == TokuseiNo.MAZIKKUMIRAA)
                {
                    ScoreCtrl(-12);
                }

                // Double Battle, and target's ally's ability is Aroma Veil
                if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_DOUBLE &&
                    (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE_FRIEND }) == TokuseiNo.AROMABEERU)
                {
                    ScoreCtrl(-10);
                }
            }
        }

        // 167 - Induces Burn
        private void BaciAI_Seq_167()
        {
            var defType1 = Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 });
            var defType2 = Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var weather = Call(CMD_CHECK_WEATHER, Array.Empty<long>());

            // Target's type is Fire
            if (defType1 == POKETYPE_HONOO ||
                defType2 == POKETYPE_HONOO)
            {
                ScoreCtrl(-10);
            }
            // Target's ability is Magic Guard
            else if (defTokusei == TokuseiNo.MAZIKKUGAADO)
            {
                ScoreCtrl(-10);
            }
            // Target has a status effect
            else if (Call(CMD_IF_POKESICK, new long[] { CHECK_DEFENCE }) != 0)
            {
                ScoreCtrl(-10);
            }
            // Target's side has Safeguard active
            else if (Call(CMD_IF_SIDEEFF, new long[] { CHECK_DEFENCE, BTL_SIDEEFF_SINPINOMAMORI }) != 0)
            {
                ScoreCtrl(-10);
            }
            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt
            else if (atkTokusei != TokuseiNo.KATAYABURI &&
                     atkTokusei != TokuseiNo.TAABOBUREIZU &&
                     atkTokusei != TokuseiNo.TERABORUTEEZI)
            {
                // Target's ability is...
                switch (defTokusei)
                {
                    // Flash Fire or Magic Bounce
                    case TokuseiNo.MORAIBI:
                    case TokuseiNo.MAZIKKUMIRAA:
                        ScoreCtrl(-12);
                        break;

                    // Water Veil or Water Bubble
                    case TokuseiNo.MIZUNOBEERU:
                    case TokuseiNo.SUIHOU:
                        ScoreCtrl(-10);
                        break;

                    // Leaf Guard
                    case TokuseiNo.RIIHUGAADO:
                        // Weather is Harsh Sunlight
                        if (weather == WEATHER_HARE)
                            ScoreCtrl(-10);
                        break;

                    // Shields Down
                    case TokuseiNo.RIMITTOSIIRUDO:
                        // Target's HP is over 51%
                        if (Call(CMD_IF_HP_OVER, new long[] { CHECK_DEFENCE, 51 }) != 0)
                        {
                            ScoreCtrl(-10);
                            return;
                        }
                        break;
                }

                // Target's type is Grass
                if (Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 }) == POKETYPE_KUSA ||
                    Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 }) == POKETYPE_KUSA)
                {
                    // Target's ability is Flower Veil
                    if (defTokusei == TokuseiNo.HURAWAABEERU)
                    {
                        ScoreCtrl(-10);
                        return;
                    }
                    // Double Battle, and target's ally's ability is Flower Veil
                    else if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_DOUBLE &&
                             (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE_FRIEND }) == TokuseiNo.HURAWAABEERU)
                    {
                        ScoreCtrl(-10);
                        return;
                    }
                }
            }

            // Target has a substitute and user's ability is not Infiltrator
            if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0 &&
                atkTokusei != TokuseiNo.SURINUKE)
            {
                ScoreCtrl(-10);
            }
            // Misty Terrain is active and target is grounded
            else if (Call(CMD_IF_EXIST_GROUND, new long[] { BTL_GROUND_MIST }) != 0 &&
                defType1 != POKETYPE_HIKOU &&
                defType2 != POKETYPE_HIKOU &&
                defTokusei != TokuseiNo.HUYUU)
            {
                ScoreCtrl(-10);
            }
        }

        // 168 - Memento
        private void BaciAI_Seq_168()
        {
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });

            // User's side has no other Pokémon left in their party
            if (Call(CMD_CHECK_BENCH_COUNT, new long[] { CHECK_ATTACK }) == 0)
            {
                ScoreCtrl(-10);
            }
            // Target's Attack is at -6 stages
            else if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_DEFENCE, PARA_POW, 0 }) != 0)
            {
                ScoreCtrl(-10);
            }
            // Target's Special Attack is at -6 stages
            else if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_DEFENCE, PARA_SPEPOW, 0 }) != 0)
            {
                ScoreCtrl(-10);
            }
            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt
            else if (atkTokusei != TokuseiNo.KATAYABURI &&
                     atkTokusei != TokuseiNo.TAABOBUREIZU &&
                     atkTokusei != TokuseiNo.TERABORUTEEZI)
            {
                // Target's ability is...
                switch (defTokusei)
                {
                    // Clear Body, White Smoke, or Magic Bounce
                    case TokuseiNo.KURIABODHI:
                    case TokuseiNo.SIROIKEMURI:
                    case TokuseiNo.MAZIKKUMIRAA:
                        ScoreCtrl(-10);
                        break;

                    // Contrary
                    case TokuseiNo.AMANOZYAKU:
                        ScoreCtrl(-12);
                        break;

                    default:
                        // Target's type is Grass
                        if (Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 }) == POKETYPE_KUSA ||
                            Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 }) == POKETYPE_KUSA)
                        {
                            // Target's ability is Flower Veil
                            if (defTokusei == TokuseiNo.HURAWAABEERU)
                            {
                                ScoreCtrl(-10);
                                return;
                            }
                            // Double Battle, and target's ally's ability is Flower Veil
                            else if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_DOUBLE &&
                                     (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE_FRIEND }) == TokuseiNo.HURAWAABEERU)
                            {
                                ScoreCtrl(-10);
                            }
                        }
                        break;
                }
            }

            // Target has a substitute and user's ability is not Infiltrator
            if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0 &&
                atkTokusei != TokuseiNo.SURINUKE)
            {
                ScoreCtrl(-10);
            }
        }

        // 172 - Center of Attention
        private void BaciAI_Seq_172()
        {
            // Single Battle
            if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_SINGLE)
            {
                ScoreCtrl(-10);
            }
        }

        // 175 - Induces Taunt
        private void BaciAI_Seq_175()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // Target is afflicted by Taunt
            if (Call(CMD_IF_WAZASICK, new long[] { CHECK_DEFENCE, WAZASICK_TYOUHATSU }) != 0)
            {
                ScoreCtrl(-10);
                return;
            }
            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt
            else if (atkTokusei != TokuseiNo.KATAYABURI &&
                     atkTokusei != TokuseiNo.TAABOBUREIZU &&
                     atkTokusei != TokuseiNo.TERABORUTEEZI)
            {
                // Target's ability is...
                switch (defTokusei)
                {
                    // Oblivious or Aroma Veil
                    case TokuseiNo.DONKAN:
                    case TokuseiNo.AROMABEERU:
                        ScoreCtrl(-10);
                        break;

                    // Magic Bounce
                    case TokuseiNo.MAZIKKUMIRAA:
                        ScoreCtrl(-12);
                        break;

                    default:
                        // Double Battle, and target's ally's ability is Aroma Veil
                        if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_DOUBLE &&
                            (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE_FRIEND }) == TokuseiNo.AROMABEERU)
                        {
                            ScoreCtrl(-10);
                        }
                        break;
                }
            }
        }

        // 176 - Helping Hand
        private void BaciAI_Seq_176()
        {
            // Single Battle
            if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_SINGLE)
            {
                ScoreCtrl(-20);
            }
        }

        // 177 - Item Swap
        private void BaciAI_Seq_177()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt and
            // Target's ability is Sticky Hold
            if (atkTokusei != TokuseiNo.KATAYABURI &&
                atkTokusei != TokuseiNo.TAABOBUREIZU &&
                atkTokusei != TokuseiNo.TERABORUTEEZI &&
                defTokusei == TokuseiNo.NENTYAKU)
            {
                ScoreCtrl(-10);
            }

            // Target has a substitute and user's ability is not Infiltrator
            if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0 &&
                atkTokusei != TokuseiNo.SURINUKE)
            {
                ScoreCtrl(-10);
            }
            else
            {
                // Target's species is...
                switch ((MonsNo)Call(CMD_CHECK_MONSNO, new long[] { CHECK_DEFENCE }))
                {
                    // Giratina
                    case MonsNo.GIRATHINA:
                        // Target is holding a Griseous Orb
                        if (Call(CMD_IF_HAVE_ITEM, new long[] { CHECK_DEFENCE, (long)ItemNo.HAKKINDAMA }) != 0)
                            ScoreCtrl(-10);
                        break;

                    // Arceus
                    case MonsNo.ARUSEUSU:
                        ScoreCtrl(-10);
                        break;
                }
            }

            // Target is mega evolved
            if (Call(CMD_IF_MEGAEVOLVED, new long[] { CHECK_DEFENCE }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 178 - Copy Ability
        private void BaciAI_Seq_178()
        {
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // Target's ability is Trace or Zen Mode
            if (defTokusei == TokuseiNo.TOREESU ||
                defTokusei == TokuseiNo.DARUMAMOODO)
            {
                ScoreCtrl(-10);
            }
            else
            {
                // Target's species is...
                switch ((MonsNo)Call(CMD_CHECK_MONSNO, new long[] { CHECK_DEFENCE }))
                {
                    // Ditto,   Slaking,   Shedinja, Castform
                    // Cherrim, Regigigas, Arceus
                    case MonsNo.METAMON:
                    case MonsNo.KEKKINGU:
                    case MonsNo.NUKENIN:
                    case MonsNo.POWARUN:
                    case MonsNo.THERIMU:
                    case MonsNo.REZIGIGASU:
                    case MonsNo.ARUSEUSU:
                        ScoreCtrl(-10);
                        break;
                }
            }
        }

        // 179 - Wish
        private void BaciAI_Seq_179()
        {
            // User's last used move is Wish
            if ((WazaNo)Call(CMD_CHECK_LAST_WAZA, new long[] { CHECK_ATTACK }) == WazaNo.NEGAIGOTO)
            {
                ScoreCtrl(-10);
            }
        }

        // 181 - Ingrain
        private void BaciAI_Seq_181()
        {
            // User is ingrained
            if (Call(CMD_IF_WAZASICK, new long[] { CHECK_ATTACK, WAZASICK_NEWOHARU }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 184 - Recycle
        private void BaciAI_Seq_184()
        {
            // User does not have an item to Recycle
            if (Call(CMD_CHECK_RECYCLE_ITEM, new long[] { CHECK_ATTACK }) == 0)
            {
                ScoreCtrl(-8);
            }
        }

        // 188 - Knock Off
        private void BaciAI_Seq_188()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // Target does not have a held item
            if (Call(CMD_CHECK_SOUBI_ITEM, new long[] { CHECK_DEFENCE }) == 0)
            {
                ScoreCtrl(-10);
            }
            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt and
            // Target's ability is Sticky Hold
            else if (atkTokusei != TokuseiNo.KATAYABURI &&
                     atkTokusei != TokuseiNo.TAABOBUREIZU &&
                     atkTokusei != TokuseiNo.TERABORUTEEZI &&
                     defTokusei == TokuseiNo.NENTYAKU)
            {
                ScoreCtrl(-10);
            }

            // Target has a substitute and user's ability is not Infiltrator
            if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0 &&
                atkTokusei != TokuseiNo.SURINUKE)
            {
                ScoreCtrl(-10);
            }
        }

        // 191 - Swap Abilities
        private void BaciAI_Seq_191()
        {
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // Target's ability is Wonder Guard, Multitype, Illusion, or Stance Change
            if (defTokusei == TokuseiNo.HUSIGINAMAMORI ||
                defTokusei == TokuseiNo.MARUTITAIPU ||
                defTokusei == TokuseiNo.IRYUUZYON ||
                defTokusei == TokuseiNo.BATORUSUITTI)
            {
                ScoreCtrl(-10);
            }

            // Target's species is...
            switch ((MonsNo)Call(CMD_CHECK_MONSNO, new long[] { CHECK_DEFENCE }))
            {
                // Ditto,     Shedinja, Castform, Cherrim,
                // Regigigas, Arceus
                case MonsNo.METAMON:
                case MonsNo.NUKENIN:
                case MonsNo.POWARUN:
                case MonsNo.THERIMU:
                case MonsNo.REZIGIGASU:
                case MonsNo.ARUSEUSU:
                    ScoreCtrl(-10);
                    break;

                // Slaking
                case MonsNo.KEKKINGU:
                    ScoreCtrl(-12);
                    break;

                default:
                    // Target's ability is Truant, Slow Start, or Defeatist
                    if (defTokusei == TokuseiNo.NAMAKE ||
                        defTokusei == TokuseiNo.SUROOSUTAATO ||
                        defTokusei == TokuseiNo.YOWAKI)
                    {
                        ScoreCtrl(-12);
                    }
                    break;
            }
        }

        // 192 - Imprison
        private void BaciAI_Seq_192()
        {
            // Imprison is active
            if (Call(CMD_FLDEFF_CHECK, new long[] { EFF_FUIN }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 193 - Refresh
        private void BaciAI_Seq_193()
        {
            // User does not have a status effect
            if (Call(CMD_IFN_POKESICK, new long[] { CHECK_ATTACK }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 205 - Tickle
        private void BaciAI_Seq_205()
        {
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });

            // Target's ability is Defiant or Competitive
            if (defTokusei == TokuseiNo.MAKENKI ||
                defTokusei == TokuseiNo.KATIKI)
            {
                ScoreCtrl(-12);
            }
            // Target's Attack is at -6 stages
            else if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_DEFENCE, PARA_POW, 0 }) != 0)
            {
                ScoreCtrl(-10);
            }
            // Target's Attack is at -6 stages
            else if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_DEFENCE, PARA_DEF, 0 }) != 0)
            {
                ScoreCtrl(-10);
            }
            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt
            else if (atkTokusei != TokuseiNo.KATAYABURI &&
                     atkTokusei != TokuseiNo.TAABOBUREIZU &&
                     atkTokusei != TokuseiNo.TERABORUTEEZI)
            {
                // Target's ability is...
                switch (defTokusei)
                {
                    // Clear Body, Hyper Cutter, White Smoke, Big Pecks
                    case TokuseiNo.KURIABODHI:
                    case TokuseiNo.KAIRIKIBASAMI:
                    case TokuseiNo.SIROIKEMURI:
                    case TokuseiNo.HATOMUNE:
                        ScoreCtrl(-10);
                        break;

                    // Contrary, Magic Bounce
                    case TokuseiNo.AMANOZYAKU:
                    case TokuseiNo.MAZIKKUMIRAA:
                        ScoreCtrl(-12);
                        break;

                    default:
                        // Target's type is Grass
                        if (Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 }) == POKETYPE_KUSA ||
                            Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 }) == POKETYPE_KUSA)
                        {
                            // Target's ability is Flower Veil
                            if (defTokusei == TokuseiNo.HURAWAABEERU)
                            {
                                ScoreCtrl(-10);
                                return;
                            }
                            // Double Battle, and target's ally's ability is Flower Veil
                            else if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_DOUBLE &&
                                     (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE_FRIEND }) == TokuseiNo.HURAWAABEERU)
                            {
                                ScoreCtrl(-10);
                            }
                        }
                        break;
                }
            }

            // Target has a substitute and user's ability is not Infiltrator
            if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0 &&
                atkTokusei != TokuseiNo.SURINUKE)
            {
                ScoreCtrl(-10);
            }
        }

        // 206 - Cosmic Power
        private void BaciAI_Seq_206()
        {
            // User's ability is Contrary
            if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK }) == TokuseiNo.AMANOZYAKU)
            {
                ScoreCtrl(-12);
            }
            // User's Defense is at +6 stages
            else if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_ATTACK, PARA_DEF, 12 }) != 0)
            {
                ScoreCtrl(-10);
            }
            // User's Special Defense is at +6 stages
            else if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_ATTACK, PARA_SPEDEF, 12 }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 208 - Bulk Up
        private void BaciAI_Seq_208()
        {
            // User's ability is Contrary
            if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK }) == TokuseiNo.AMANOZYAKU)
            {
                ScoreCtrl(-12);
            }
            // User's Attack is at +6 stages
            else if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_ATTACK, PARA_POW, 12 }) != 0)
            {
                ScoreCtrl(-10);
            }
            // User's Defense is at +6 stages
            else if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_ATTACK, PARA_DEF, 12 }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 211 - Calm Mind
        private void BaciAI_Seq_211()
        {
            // User's ability is Contrary
            if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK }) == TokuseiNo.AMANOZYAKU)
            {
                ScoreCtrl(-12);
            }
            // User's Special Attack is at +6 stages
            else if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_ATTACK, PARA_SPEPOW, 12 }) != 0)
            {
                ScoreCtrl(-10);
            }
            // User's Special Defense is at +6 stages
            else if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_ATTACK, PARA_SPEDEF, 12 }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 212 - Dragon Dance
        private void BaciAI_Seq_212()
        {
            // User's ability is Contrary
            if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK }) == TokuseiNo.AMANOZYAKU)
            {
                ScoreCtrl(-12);
            }
            // User's Attack is at +6 stages
            else if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_ATTACK, PARA_POW, 12 }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 215 - Induces Gravity
        private void BaciAI_Seq_215()
        {
            // Gravity is active
            if (Call(CMD_FLDEFF_CHECK, new long[] { EFF_JURYOKU }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 216 - Induces Miracle Eye
        private void BaciAI_Seq_216()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // Target is afflicted by Identified
            if (Call(CMD_IF_WAZASICK, new long[] { CHECK_DEFENCE, WAZASICK_MIYABURU }) != 0)
            {
                ScoreCtrl(-10);
            }
            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt and
            // Target's ability is Magic Bounce
            else if (atkTokusei != TokuseiNo.KATAYABURI &&
                     atkTokusei != TokuseiNo.TAABOBUREIZU &&
                     atkTokusei != TokuseiNo.TERABORUTEEZI &&
                     defTokusei == TokuseiNo.MAZIKKUMIRAA)
            {
                ScoreCtrl(-12);
            }
        }

        // 220 - Healing Wish
        private void BaciAI_Seq_220()
        {
            // User's side has no other Pokémon left in their party
            if (Call(CMD_CHECK_BENCH_COUNT, new long[] { CHECK_ATTACK }) == 0)
            {
                ScoreCtrl(-10);
            }
            // User's side does not have Pokémon in their party with less than 100% HP
            else if (Call(CMD_IF_BENCH_HPDEC, new long[] { CHECK_ATTACK }) == 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 222 - Natural Gift
        private void BaciAI_Seq_222()
        {
            // User does not have a held item
            if (Call(CMD_CHECK_SOUBI_ITEM, new long[] { CHECK_ATTACK }) == 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 225 - Tailwind
        private void BaciAI_Seq_225()
        {
            // User's side has Tailwind active
            if (Call(CMD_IF_SIDEEFF, new long[] { CHECK_ATTACK, BTL_SIDEEFF_OIKAZE }) != 0)
            {
                ScoreCtrl(-10);
            }
            // Trick Room is active
            else if (Call(CMD_FLDEFF_CHECK, new long[] { EFF_TRICKROOM }) != 0)
            {
                ScoreCtrl(-8);
            }
        }

        // 226 - Acupressure
        private void BaciAI_Seq_226()
        {
            // Empty
        }

        // 227 - Metal Burst
        private void BaciAI_Seq_227()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // Target's ability is Stall
            if (defTokusei == TokuseiNo.ATODASI)
            {
                ScoreCtrl(-10);
            }
            // User's ability is not Stall and user goes first
            else if (atkTokusei != TokuseiNo.ATODASI &&
                     Call(CMD_IF_FIRST, new long[] { IF_FIRST_ATTACK }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 232 - Induces Embargo
        private void BaciAI_Seq_232()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // Target is afflicted by Embargo
            if (Call(CMD_IF_WAZASICK, new long[] { CHECK_DEFENCE, WAZASICK_SASIOSAE }) != 0)
            {
                ScoreCtrl(-10);
            }
            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt and
            // Target's ability is Magic Bounce
            else if (atkTokusei != TokuseiNo.KATAYABURI &&
                     atkTokusei != TokuseiNo.TAABOBUREIZU &&
                     atkTokusei != TokuseiNo.TERABORUTEEZI &&
                     defTokusei == TokuseiNo.MAZIKKUMIRAA)
            {
                ScoreCtrl(-12);
            }

            // Target has a substitute and user's ability is not Infiltrator
            if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0 &&
                atkTokusei != TokuseiNo.SURINUKE)
            {
                ScoreCtrl(-10);
            }
        }

        // 233 - Fling
        private void BaciAI_Seq_233()
        {
            var atkItemEqp = Call(CMD_CHECK_SOUBI_EQUIP, new long[] { CHECK_ATTACK });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // User's item's effect is...
            switch (atkItemEqp)
            {
                // Inflicts Flinch on target
                // King's Rock and Razor Fang
                case SOUBI_HIRUMASERU:
                    // Target goes first or target's ability is Inner Focus or Prankster
                    if (Call(CMD_IF_FIRST, new long[] { IF_FIRST_DEFENCE }) != 0 ||
                        defTokusei == TokuseiNo.SEISINRYOKU ||
                        defTokusei == TokuseiNo.ITAZURAGOKORO)
                    {
                        ScoreCtrl(-10);
                    }
                    break;

                // Inflicts Paralysis on target
                // Light Ball
                case SOUBI_PIKATYUUTOKUKOUNIBAI:
                    BaciAI_Seq_067();
                    break;

                // Inflict Poison/Bad Poison on target
                // Poison Barb and Toxic Orb
                case SOUBI_DOKUBARIUP:
                case SOUBI_TEKINIMOTASERUTOMOUDOKU:
                    BaciAI_Seq_033();
                    break;

                // Inflicts Burn on target
                // Flame Orb
                case SOUBI_TTEKINIMOTASERUTOYAKEDO:
                    BaciAI_Seq_167();
                    break;

                default:
                    if (atkItemEqp == 0)
                    {
                        ScoreCtrl(-10);
                    }
                    break;
            }
        }

        // 234 - Psycho Shift
        private void BaciAI_Seq_234()
        {
            // Target has a status effect
            if (Call(CMD_IF_POKESICK, new long[] { CHECK_DEFENCE }) != 0)
            {
                ScoreCtrl(-10);
            }
            // User does not have a status effect
            else if (Call(CMD_IFN_POKESICK, new long[] { CHECK_ATTACK }) != 0)
            {
                ScoreCtrl(-8);
            }
            // Target's side has Safeguard active
            else if (Call(CMD_IF_SIDEEFF, new long[] { CHECK_DEFENCE, BTL_SIDEEFF_SINPINOMAMORI }) != 0)
            {
                ScoreCtrl(-10);
            }
            // User is poisoned or badly poisoned
            else if (Call(CMD_IF_WAZASICK, new long[] { CHECK_ATTACK, WAZASICK_DOKU }) != 0 ||
                     Call(CMD_IF_DOKUDOKU, new long[] { CHECK_ATTACK }) != 0)
            {
                BaciAI_Seq_033();
            }
            // User is burned
            else if (Call(CMD_IF_WAZASICK, new long[] { CHECK_ATTACK, WAZASICK_YAKEDO }) != 0)
            {
                BaciAI_Seq_167();
            }
            // User is paralyzed
            else if (Call(CMD_IF_WAZASICK, new long[] { CHECK_ATTACK, WAZASICK_MAHI }) != 0)
            {
                BaciAI_Seq_067();
            }
        }

        // 236 - Heal Block
        private void BaciAI_Seq_236()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // Target is afflicted by Heal Block
            if (Call(CMD_IF_WAZASICK, new long[] { CHECK_DEFENCE, WAZASICK_KAIHUKUHUUJI }) != 0)
            {
                ScoreCtrl(-10);
            }
            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt
            else if (atkTokusei != TokuseiNo.KATAYABURI &&
                     atkTokusei != TokuseiNo.TAABOBUREIZU &&
                     atkTokusei != TokuseiNo.TERABORUTEEZI)
            {
                // Target's ability is Magic Bounce
                if (defTokusei == TokuseiNo.MAZIKKUMIRAA)
                {
                    ScoreCtrl(-12);
                }
                // Target's ability is Aroma Veil
                else if (defTokusei == TokuseiNo.AROMABEERU)
                {
                    ScoreCtrl(-10);
                }

                // Double Battle, and target's ally's ability is Aroma Veil
                if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_DOUBLE &&
                    (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE_FRIEND }) == TokuseiNo.AROMABEERU)
                {
                    ScoreCtrl(-10);
                }
            }
        }

        // 238 - Power Trick
        private void BaciAI_Seq_238()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });

            // Target has a substitute and user's ability is not Infiltrator
            if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0 &&
                atkTokusei != TokuseiNo.SURINUKE)
            {
                ScoreCtrl(-10);
            }
        }

        // 239 - Suppress Ability
        private void BaciAI_Seq_239()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });
            var defMonsno = (MonsNo)Call(CMD_CHECK_MONSNO, new long[] { CHECK_DEFENCE });

            // Target's ability is suppressed
            if (Call(CMD_IF_WAZASICK, new long[] { CHECK_DEFENCE, WAZASICK_IEKI }) != 0)
            {
                ScoreCtrl(-10);
            }
            // Target's ability is Run Away, Honey Gather, or Multitype
            else if (defTokusei == TokuseiNo.NIGEASI ||
                     defTokusei == TokuseiNo.MITUATUME ||
                     defTokusei == TokuseiNo.MARUTITAIPU)
            {
                ScoreCtrl(-10);
            }
            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt and
            // Target's ability is Magic Bounce
            else if (atkTokusei != TokuseiNo.KATAYABURI &&
                     atkTokusei != TokuseiNo.TAABOBUREIZU &&
                     atkTokusei != TokuseiNo.TERABORUTEEZI &&
                     defTokusei == TokuseiNo.MAZIKKUMIRAA)
            {
                ScoreCtrl(-12);
            }
            // Target has a substitute and user's ability is not Infiltrator
            else if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0 &&
                     atkTokusei != TokuseiNo.SURINUKE)
            {
                ScoreCtrl(-10);
            }
            else
            {
                // Target's species is...
                switch (defMonsno)
                {
                    // Arceus
                    case MonsNo.ARUSEUSU:
                        ScoreCtrl(-10);
                        break;

                    // Slaking, Regigigas
                    case MonsNo.KEKKINGU:
                    case MonsNo.REZIGIGASU:
                        ScoreCtrl(-12);
                        break;

                    default:
                        // Target's ability is Truant, Slow Start, or Defeatist
                        if (defTokusei == TokuseiNo.NAMAKE ||
                            defTokusei == TokuseiNo.SUROOSUTAATO ||
                            defTokusei == TokuseiNo.YOWAKI)
                        {
                            ScoreCtrl(-12);
                        }
                        break;
                }
            }
        }

        // 240 - Lucky Chant
        private void BaciAI_Seq_240()
        {
            // Empty
        }

        // 241 - Me First
        private void BaciAI_Seq_241()
        {
            // Target goes first and user's ability is not Prankster
            if (Call(CMD_IF_FIRST, new long[] { IF_FIRST_DEFENCE }) != 0 &&
                (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK }) != TokuseiNo.ITAZURAGOKORO)
            {
                ScoreCtrl(-10);
            }
        }

        // 242 - Copycat
        private void BaciAI_Seq_242()
        {
            // First turn of battle and user goes first
            if (Call(CMD_CHECK_TURN, Array.Empty<long>()) == 0 &&
                Call(CMD_IF_FIRST, new long[] { IF_FIRST_ATTACK }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 243 - Power Swap
        private void BaciAI_Seq_243()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });

            // Target has a substitute and user's ability is not Infiltrator
            if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0 &&
                atkTokusei != TokuseiNo.SURINUKE)
            {
                ScoreCtrl(-10);
            }
        }

        // 244 - Guard Swap
        private void BaciAI_Seq_244()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });

            // Target has a substitute and user's ability is not Infiltrator
            if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0 &&
                atkTokusei != TokuseiNo.SURINUKE)
            {
                ScoreCtrl(-10);
            }
        }

        // 246 - Last Resort
        private void BaciAI_Seq_246()
        {
            // At least one of the user's moves other than Last Resort hasn't been used
            if (Call(CMD_IF_TOTTEOKI, new long[] { CHECK_ATTACK }) == 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 247 - Worry Seed
        private void BaciAI_Seq_247()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });
            var defMonsno = (MonsNo)Call(CMD_CHECK_MONSNO, new long[] { CHECK_DEFENCE });

            // Target's ability is Insomnia
            if (defTokusei == TokuseiNo.HUMIN)
            {
                ScoreCtrl(-10);
            }
            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt and
            // Target's ability is Magic Bounce
            else if (atkTokusei != TokuseiNo.KATAYABURI &&
                     atkTokusei != TokuseiNo.TAABOBUREIZU &&
                     atkTokusei != TokuseiNo.TERABORUTEEZI &&
                     defTokusei == TokuseiNo.MAZIKKUMIRAA)
            {
                ScoreCtrl(-12);
            }
            // Target has a substitute and user's ability is not Infiltrator
            else if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0 &&
                     atkTokusei != TokuseiNo.SURINUKE)
            {
                ScoreCtrl(-10);
            }
            else
            {
                // Target's ability is Multitype or Stance Change
                if (defTokusei == TokuseiNo.MARUTITAIPU ||
                    defTokusei == TokuseiNo.BATORUSUITTI)
                {
                    ScoreCtrl(-10);
                }

                // Target's species is...
                switch (defMonsno)
                {
                    // Ditto, Arceus
                    case MonsNo.METAMON:
                    case MonsNo.ARUSEUSU:
                        ScoreCtrl(-10);
                        break;

                    // Slaking, Regigigas
                    case MonsNo.KEKKINGU:
                    case MonsNo.REZIGIGASU:
                        ScoreCtrl(-12);
                        break;

                    default:
                        // Target's ability is Truant, Slow Start, Defeatist, or Sap Sipper
                        if (defTokusei == TokuseiNo.NAMAKE ||
                            defTokusei == TokuseiNo.SUROOSUTAATO ||
                            defTokusei == TokuseiNo.YOWAKI ||
                            defTokusei == TokuseiNo.SOUSYOKU)
                        {
                            ScoreCtrl(-12);
                        }
                        break;
                }
            }
        }

        // 249 - Toxic Spikes
        private void BaciAI_Seq_249()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });
            var defSideEffCount = Call(CMD_CHECK_SIDEEFF_COUNT, new long[] { CHECK_DEFENCE, BTL_SIDEEFF_DOKUBISI });
            var defBenchCount = Call(CMD_CHECK_BENCH_COUNT, new long[] { CHECK_DEFENCE });

            // Target's side has 2 stacks of Toxic Spikes
            if (defSideEffCount == 2)
            {
                ScoreCtrl(-10);
            }
            // Target's side has no other Pokémon left in their party
            else if (defBenchCount == 0)
            {
                ScoreCtrl(-10);
            }
            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt and
            // Target's ability is Magic Bounce
            else if (atkTokusei != TokuseiNo.KATAYABURI &&
                     atkTokusei != TokuseiNo.TAABOBUREIZU &&
                     atkTokusei != TokuseiNo.TERABORUTEEZI &&
                     defTokusei == TokuseiNo.MAZIKKUMIRAA)
            {
                ScoreCtrl(-12);
            }
        }

        // 251 - Aqua Ring
        private void BaciAI_Seq_251()
        {
            // User is afflicted by Aqua Ring
            if (Call(CMD_IF_WAZASICK, new long[] { CHECK_ATTACK, WAZASICK_AQUARING }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 252 - Magnet Rise
        private void BaciAI_Seq_252()
        {
            var atkType1 = Call(CMD_CHECK_TYPE, new long[] { CHECK_ATTACK_TYPE1 });
            var atkType2 = Call(CMD_CHECK_TYPE, new long[] { CHECK_ATTACK_TYPE2 });
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });

            // User is afflicted by Magnet Rise
            if (Call(CMD_IF_WAZASICK, new long[] { CHECK_ATTACK, WAZASICK_FLYING }) != 0)
            {
                ScoreCtrl(-10);
            }
            // User is not grounded
            else if (atkType1 == POKETYPE_HIKOU ||
                     atkType2 == POKETYPE_HIKOU ||
                     atkTokusei == TokuseiNo.HUYUU)
            {
                ScoreCtrl(-10);
            }
            // Gravity is active
            else if (Call(CMD_FLDEFF_CHECK, new long[] { EFF_JURYOKU }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 258 - Defog
        private void BaciAI_Seq_258()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt and
            // Target's ability is Magic Bounce
            if (atkTokusei != TokuseiNo.KATAYABURI &&
                atkTokusei != TokuseiNo.TAABOBUREIZU &&
                atkTokusei != TokuseiNo.TERABORUTEEZI &&
                defTokusei == TokuseiNo.MAZIKKUMIRAA)
            {
                ScoreCtrl(-12);
            }
            // Neither side has Reflect active and target's Evasiveness is at -6 stages
            else if (Call(CMD_IF_SIDEEFF, new long[] { CHECK_ATTACK, BTL_SIDEEFF_REFLECTOR }) == 0 &&
                     Call(CMD_IF_SIDEEFF, new long[] { CHECK_DEFENCE, BTL_SIDEEFF_REFLECTOR }) == 0 &&
                     Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_DEFENCE, PARA_AVOID, 0 }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 259 - Trick Room
        private void BaciAI_Seq_259()
        {
            // Empty
        }

        // 265 - Captivate
        private void BaciAI_Seq_265()
        {
            var atkSex = (Sex)Call(CMD_CHECK_POKESEX, new long[] { CHECK_ATTACK });
            var defSex = (Sex)Call(CMD_CHECK_POKESEX, new long[] { CHECK_DEFENCE });

            // User is female
            if (atkSex == Sex.FEMALE)
            {
                // Target is not male
                if (defSex != Sex.MALE)
                {
                    ScoreCtrl(-10);
                    return;
                }
            }
            // User is male
            else if (atkSex == Sex.MALE)
            {
                // Target is not female
                if (defSex != Sex.FEMALE)
                {
                    ScoreCtrl(-10);
                    return;
                }
            }

            BaciAI_Seq_021();
        }

        // 266 - Stealth Rock
        private void BaciAI_Seq_266()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });
            var defBenchCount = Call(CMD_CHECK_BENCH_COUNT, new long[] { CHECK_DEFENCE });

            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt and
            // Target's ability is Magic Bounce
            if (atkTokusei != TokuseiNo.KATAYABURI &&
                atkTokusei != TokuseiNo.TAABOBUREIZU &&
                atkTokusei != TokuseiNo.TERABORUTEEZI &&
                defTokusei == TokuseiNo.MAZIKKUMIRAA)
            {
                ScoreCtrl(-12);
            }
            // Target's side has Stealth Rock active
            else if (Call(CMD_IF_SIDEEFF, new long[] { CHECK_DEFENCE, BTL_SIDEEFF_STEALTHROCK }) != 0)
            {
                ScoreCtrl(-10);
            }
            // Target's side has no other Pokémon left in their party
            else if (defBenchCount == 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 270 - Lunar Dance
        private void BaciAI_Seq_270()
        {
            // User's side has no other Pokémon left in their party
            if (Call(CMD_CHECK_BENCH_COUNT, new long[] { CHECK_DEFENCE }) == 0)
            {
                ScoreCtrl(-10);
            }
            // User's side does not have Pokémon in their party with less than 100% HP and
            // User's side does not have Pokémon in their party with a status effect and
            // User's side does not have Pokémon in their party with decreased PP on any move
            else if (Call(CMD_IF_BENCH_HPDEC, new long[] { CHECK_ATTACK }) == 0 &&
                     Call(CMD_IF_BENCH_COND, new long[] { CHECK_ATTACK }) == 0 &&
                     Call(CMD_IF_BENCH_PPDEC, new long[] { CHECK_ATTACK }) == 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 278 - Wide Guard
        private void BaciAI_Seq_278()
        {
            // Single Battle
            if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_SINGLE)
            {
                ScoreCtrl(-10);
            }
        }

        // 281 - Wonder Room
        private void BaciAI_Seq_281()
        {
            // Wonder Room is active
            if (Call(CMD_FLDEFF_CHECK, new long[] { EFF_WONDERROOM }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 285 - Induces Telekinesis
        private void BaciAI_Seq_285()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt and
            // Target's ability is Magic Bounce
            if (atkTokusei != TokuseiNo.KATAYABURI &&
                atkTokusei != TokuseiNo.TAABOBUREIZU &&
                atkTokusei != TokuseiNo.TERABORUTEEZI &&
                defTokusei == TokuseiNo.MAZIKKUMIRAA)
            {
                ScoreCtrl(-12);
            }
            else
            {
                // User is afflicted by Telekinesis
                if (Call(CMD_IF_WAZASICK, new long[] { CHECK_ATTACK, WAZASICK_TELEKINESIS }) != 0)
                {
                    ScoreCtrl(-10);
                }

                // Target has a substitute and user's ability is not Infiltrator
                if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0 &&
                    atkTokusei != TokuseiNo.SURINUKE)
                {
                    ScoreCtrl(-10);
                }
            }
        }

        // 286 - Magic Room
        private void BaciAI_Seq_286()
        {
            // Magic Room is active
            if (Call(CMD_FLDEFF_CHECK, new long[] { EFF_MAGICROOM }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 292 - Synchronoise
        private void BaciAI_Seq_292()
        {
            var atkType1 = Call(CMD_CHECK_TYPE, new long[] { CHECK_ATTACK_TYPE1 });
            var atkType2 = Call(CMD_CHECK_TYPE, new long[] { CHECK_ATTACK_TYPE2 });
            var defType1 = Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 });
            var defType2 = Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 });

            // Double Battle
            if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_DOUBLE)
            {
                var defAllyType1 = Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_FRIEND_TYPE1 });
                var defAllyType2 = Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_FRIEND_TYPE2 });

                // User and target do not have any matching types and
                // User and target's ally do not have any matching types
                if (atkType2 != defType2 && atkType2 != defType1 &&
                    atkType1 != defType2 && atkType1 != defType1 &&
                    atkType2 != defAllyType2 && atkType2 != defAllyType1 &&
                    atkType1 != defAllyType2 && atkType1 != defAllyType1)
                {
                    ScoreCtrl(-10);
                }
            }
            else
            {
                // User and target do not have any matching types
                if (atkType2 != defType2 && atkType2 != defType1 &&
                    atkType1 != defType2 && atkType1 != defType1)
                {
                    ScoreCtrl(-10);
                }
            }
        }

        // 294 - Soak
        private void BaciAI_Seq_294()
        {
            var defType1 = Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 });
            var defType2 = Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 });
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt and
            // Target's ability is Storm Drain
            if (atkTokusei != TokuseiNo.KATAYABURI &&
                atkTokusei != TokuseiNo.TAABOBUREIZU &&
                atkTokusei != TokuseiNo.TERABORUTEEZI &&
                defTokusei == TokuseiNo.YOBIMIZU)
            {
                ScoreCtrl(-12);
            }
            else
            {
                // Target is Water type
                if (defType1 == POKETYPE_MIZU ||
                    defType2 == POKETYPE_MIZU)
                {
                    ScoreCtrl(-10);
                }

                // Target has a substitute and user's ability is not Infiltrator
                if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0 &&
                    atkTokusei != TokuseiNo.SURINUKE)
                {
                    ScoreCtrl(-10);
                }
            }
        }

        // 298 - Simple Beam
        private void BaciAI_Seq_298()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt and
            // Target's ability is Magic Bounce
            if (atkTokusei != TokuseiNo.KATAYABURI &&
                atkTokusei != TokuseiNo.TAABOBUREIZU &&
                atkTokusei != TokuseiNo.TERABORUTEEZI &&
                defTokusei == TokuseiNo.MAZIKKUMIRAA)
            {
                ScoreCtrl(-10);
            }
            // Target's ability is Trace or Zen Mode
            else if (defTokusei == TokuseiNo.TOREESU ||
                     defTokusei == TokuseiNo.DARUMAMOODO)
            {
                ScoreCtrl(-10);
            }
            else
            {
                var defMonsno = (MonsNo)Call(CMD_CHECK_MONSNO, new long[] { CHECK_DEFENCE });

                // Target's species is Ditto, Shedinja, Castform, Cherrim, or Arceus
                if (defMonsno == MonsNo.METAMON ||
                    defMonsno == MonsNo.NUKENIN ||
                    defMonsno == MonsNo.POWARUN ||
                    defMonsno == MonsNo.THERIMU ||
                    defMonsno == MonsNo.ARUSEUSU)
                {
                    ScoreCtrl(-10);
                }
                // Target's ability is Simple
                else if (defTokusei == TokuseiNo.TANZYUN)
                {
                    ScoreCtrl(-10);
                }
                // Target has a substitute and user's ability is not Infiltrator
                else if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0 &&
                         atkTokusei != TokuseiNo.SURINUKE)
                {
                    ScoreCtrl(-10);
                }
                // Target's species is Slaking or Regigigas or
                // Target's ability is Truant, Slow Start, or Defeatist
                else if (defMonsno == MonsNo.KEKKINGU ||
                         defMonsno == MonsNo.REZIGIGASU ||
                         defTokusei == TokuseiNo.NAMAKE ||
                         defTokusei == TokuseiNo.SUROOSUTAATO ||
                         defTokusei == TokuseiNo.YOWAKI)
                {
                    ScoreCtrl(-12);
                }
            }
        }

        // 299 - Entrainment
        private void BaciAI_Seq_299()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // User's ability is the same as target's ability
            if (atkTokusei == defTokusei)
            {
                ScoreCtrl(-10);
            }
            else
            {
                // User's ability is not Mold Breaker, Turboblaze, nor Teravolt and
                // Target's ability is Magic Bounce
                if (atkTokusei != TokuseiNo.KATAYABURI &&
                    atkTokusei != TokuseiNo.TAABOBUREIZU &&
                    atkTokusei != TokuseiNo.TERABORUTEEZI &&
                    defTokusei == TokuseiNo.MAZIKKUMIRAA)
                {
                    ScoreCtrl(-12);
                }

                // Target has a substitute and user's ability is not Infiltrator
                if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0 &&
                    atkTokusei != TokuseiNo.SURINUKE)
                {
                    ScoreCtrl(-10);
                }
                // Target's ability is Trace or Zen Mode
                else if (defTokusei == TokuseiNo.TOREESU ||
                         defTokusei == TokuseiNo.DARUMAMOODO)
                {
                    ScoreCtrl(-10);
                }
                else
                {
                    // Target's species is...
                    switch ((MonsNo)Call(CMD_CHECK_MONSNO, new long[] { CHECK_DEFENCE }))
                    {
                        // Ditto, Shedinja, Castform, Cherrim,
                        // Arceus
                        case MonsNo.METAMON:
                        case MonsNo.NUKENIN:
                        case MonsNo.POWARUN:
                        case MonsNo.THERIMU:
                        case MonsNo.ARUSEUSU:
                            ScoreCtrl(-10);
                            break;

                        // Slaking, Regigigas
                        case MonsNo.KEKKINGU:
                        case MonsNo.REZIGIGASU:
                            ScoreCtrl(-12);
                            break;

                        default:
                            // Target's ability is Truant, Slow Start, or Defeatist
                            if (defTokusei == TokuseiNo.NAMAKE ||
                                defTokusei == TokuseiNo.SUROOSUTAATO ||
                                defTokusei == TokuseiNo.YOWAKI)
                            {
                                ScoreCtrl(-12);
                            }
                            break;
                    }
                }
            }
        }

        // 300 - After You
        private void BaciAI_Seq_300()
        {
            // Single Battle
            if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_SINGLE)
            {
                ScoreCtrl(-10);
            }
        }

        // 301 - Round
        private void BaciAI_Seq_301()
        {
            // Empty
        }

        // 307 - Ally Switch
        private void BaciAI_Seq_307()
        {
            var rule = Call(CMD_CHECK_BTL_RULE, Array.Empty<long>());

            // Single Battle
            if (rule == BTL_RULE_SINGLE)
            {
                ScoreCtrl(-10);
            }
            // Multi Battle
            else if (Call(CMD_IF_MULTI, Array.Empty<long>()) != 0)
            {
                ScoreCtrl(-10);
            }
            // Double Battle and user's ally's HP is 0%
            else if (rule == BTL_RULE_DOUBLE &&
                     Call(CMD_IF_HP_EQUAL, new long[] { CHECK_ATTACK_FRIEND, 0 }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 309 - Heal Pulse
        // 386 - Floral Healing
        private void BaciAI_Seq_309()
        {
            // Single Battle
            if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_SINGLE)
            {
                ScoreCtrl(-10);
            }
        }

        // 311 - Sky Drop
        private void BaciAI_Seq_311()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var defWeight = Call(CMD_GET_WEIGHT, new long[] { CHECK_DEFENCE });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // Target's weight is 200kg or more
            if (defWeight >= 2000)
            {
                ScoreCtrl(-10);
            }
            // Target's weight is 100kg or more and target's ability is Heavy Metal
            else if (defWeight >= 1000 &&
                     defTokusei == TokuseiNo.HEVHIMETARU)
            {
                ScoreCtrl(-10);
            }
            // Target has a substitute and user's ability is not Infiltrator
            else if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0 &&
                     atkTokusei != TokuseiNo.SURINUKE)
            {
                ScoreCtrl(-10);
            }
        }

        // 315 - Quash
        private void BaciAI_Seq_315()
        {
            // Single Battle
            if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_SINGLE)
            {
                ScoreCtrl(-10);
            }
            // User's ally's HP is 0%
            else if (Call(CMD_IF_HP_EQUAL, new long[] { CHECK_ATTACK_FRIEND, 0 }) != 0)
            {
                ScoreCtrl(-10);
            }
            else
            {
                var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });

                // Target has a substitute and user's ability is not Infiltrator
                if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0 &&
                     atkTokusei != TokuseiNo.SURINUKE)
                {
                    ScoreCtrl(-10);
                }
            }
        }

        // 318 - Copy Type
        private void BaciAI_Seq_318()
        {
            var defType1 = Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 });
            var defType2 = Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 });
            var atkType1 = Call(CMD_CHECK_TYPE, new long[] { CHECK_ATTACK_TYPE1 });
            var atkType2 = Call(CMD_CHECK_TYPE, new long[] { CHECK_ATTACK_TYPE2 });

            // User and target have the same type combination
            if ((defType1 == atkType1 && defType2 == atkType2) ||
                (defType2 == atkType1 && defType1 == atkType2))
            {
                ScoreCtrl(-10);
            }
        }

        // 320 - Final Gambit
        private void BaciAI_Seq_320()
        {
            // User's side has no other Pokémon left in their party
            if (Call(CMD_CHECK_BENCH_COUNT, new long[] { CHECK_ATTACK }) == 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 323 - Give Item
        private void BaciAI_Seq_323()
        {
            // User has no held item
            if (Call(CMD_CHECK_SOUBI_ITEM, new long[] { CHECK_ATTACK }) == 0)
            {
                ScoreCtrl(-10);
            }

            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });

            // Target has a substitute and user's ability is not Infiltrator
            if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0 &&
                atkTokusei != TokuseiNo.SURINUKE)
            {
                ScoreCtrl(-10);
            }
            else
            {
                // Target's species is...
                switch ((MonsNo)Call(CMD_CHECK_MONSNO, new long[] { CHECK_DEFENCE }))
                {
                    // Giratina
                    case MonsNo.GIRATHINA:
                        // Target is holding a Griseous Orb
                        if (Call(CMD_IF_HAVE_ITEM, new long[] { CHECK_DEFENCE, (long)ItemNo.HAKKINDAMA }) != 0)
                            ScoreCtrl(-10);
                        break;

                    // Arceus
                    case MonsNo.ARUSEUSU:
                        ScoreCtrl(-10);
                        break;
                }

                // Target is mega evolved
                if (Call(CMD_IF_MEGAEVOLVED, new long[] { CHECK_DEFENCE }) != 0)
                {
                    ScoreCtrl(-10);
                }
            }
        }

        // 338 - Belch
        private void BaciAI_Seq_338()
        {
            // User has not eaten a berry
            if (Call(CMD_IF_ATE_KINOMI, new long[] { CHECK_ATTACK }) == 0)
            {
                ScoreCtrl(-8);
            }
        }

        // 339 - Rototiller
        private void BaciAI_Seq_339()
        {
            var atkType1 = Call(CMD_CHECK_TYPE, new long[] { CHECK_ATTACK_TYPE1 });
            var atkType2 = Call(CMD_CHECK_TYPE, new long[] { CHECK_ATTACK_TYPE2 });
            var atkAllyType1 = Call(CMD_CHECK_TYPE, new long[] { CHECK_ATTACK_FRIEND_TYPE1 });
            var atkAllyType2 = Call(CMD_CHECK_TYPE, new long[] { CHECK_ATTACK_FRIEND_TYPE2 });
            var rule = Call(CMD_CHECK_BTL_RULE, Array.Empty<long>());
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var atkAllyTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK_FRIEND });

            // User's type is Grass
            if (atkType1 == POKETYPE_KUSA ||
                atkType2 == POKETYPE_KUSA)
            {
                // User's ability is Contrary
                if (atkTokusei == TokuseiNo.AMANOZYAKU)
                {
                    ScoreCtrl(-12);
                }
                // Double Battle
                else if (rule == BTL_RULE_DOUBLE)
                {
                    // User's ally's type is Grass and user's ally's ability is Contrary
                    if ((atkAllyType1 == POKETYPE_KUSA ||
                         atkAllyType2 == POKETYPE_KUSA) &&
                        atkAllyTokusei == TokuseiNo.AMANOZYAKU)
                    {
                        ScoreCtrl(-12);
                    }
                    // User is not grounded
                    else if (atkType1 == POKETYPE_HIKOU ||
                             atkType2 == POKETYPE_HIKOU ||
                             atkTokusei == TokuseiNo.HUYUU)
                    {
                        // User's ally's type is not Grass
                        if (atkAllyType1 != POKETYPE_KUSA &&
                            atkAllyType2 != POKETYPE_KUSA)
                        {
                            ScoreCtrl(-10);
                        }
                        // User's ally is not grounded
                        else if (atkAllyType1 == POKETYPE_HIKOU ||
                                 atkAllyType2 == POKETYPE_HIKOU ||
                                 atkAllyTokusei == TokuseiNo.HUYUU)
                        {
                            ScoreCtrl(-10);
                        }
                    }
                }
                // User is not grounded
                else if (atkType1 == POKETYPE_HIKOU ||
                         atkType2 == POKETYPE_HIKOU ||
                         atkTokusei == TokuseiNo.HUYUU)
                {
                    ScoreCtrl(-10);
                }
            }
            // Not Double Battle
            else if (rule != BTL_RULE_DOUBLE)
            {
                ScoreCtrl(-10);
            }
            // User's ally's type is not Grass
            else if (atkAllyType1 != POKETYPE_KUSA &&
                     atkAllyType2 != POKETYPE_KUSA)
            {
                ScoreCtrl(-10);
            }
            // User's ally's ability is Contrary
            else if (atkAllyTokusei == TokuseiNo.AMANOZYAKU)
            {
                ScoreCtrl(-12);
            }
            // User's ally is not grounded
            else if (atkAllyType1 == POKETYPE_HIKOU ||
                     atkAllyType2 == POKETYPE_HIKOU ||
                     atkAllyTokusei == TokuseiNo.HUYUU)
            {
                ScoreCtrl(-10);
            }
        }

        // 340 - Sticky Web
        private void BaciAI_Seq_340()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });
            var defBenchCount = Call(CMD_CHECK_BENCH_COUNT, new long[] { CHECK_DEFENCE });

            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt and
            // Target's ability is Magic Bounce
            if (atkTokusei != TokuseiNo.KATAYABURI &&
                atkTokusei != TokuseiNo.TAABOBUREIZU &&
                atkTokusei != TokuseiNo.TERABORUTEEZI &&
                defTokusei == TokuseiNo.MAZIKKUMIRAA)
            {
                ScoreCtrl(-12);
            }
            // Target's side has Sticky Web active
            else if (Call(CMD_IF_SIDEEFF, new long[] { CHECK_DEFENCE, BTL_SIDEEFF_NEBANEBANET }) != 0)
            {
                ScoreCtrl(-10);
            }
            // Target's side has no other Pokémon left in their party
            else if (defBenchCount == 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 342 - Trick-or-Treat
        private void BaciAI_Seq_342()
        {
            var defType1 = Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 });
            var defType2 = Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 });

            // Target is Ghost type
            if (defType1 == POKETYPE_GHOST ||
                defType2 == POKETYPE_GHOST)
            {
                ScoreCtrl(-10);
            }
            // Target has Ghost as a third type
            else if (Call(CMD_IF_TYPE_EX, new long[] { CHECK_DEFENCE, POKETYPE_GHOST }) != 0)
            {
                ScoreCtrl(-10);
            }
            else
            {
                var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });

                // Target has a substitute and user's ability is not Infiltrator
                if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0 &&
                    atkTokusei != TokuseiNo.SURINUKE)
                {
                    ScoreCtrl(-10);
                }
            }
        }

        // 375 - Forest's Curse
        private void BaciAI_Seq_375()
        {
            var defType1 = Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 });
            var defType2 = Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 });

            // Target is Grass type
            if (defType1 == POKETYPE_KUSA ||
                defType2 == POKETYPE_KUSA)
            {
                ScoreCtrl(-10);
            }
            // Target has Grass as a third type
            else if (Call(CMD_IF_TYPE_EX, new long[] { CHECK_DEFENCE, POKETYPE_KUSA }) != 0)
            {
                ScoreCtrl(-10);
            }
            else
            {
                var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });

                // Target has a substitute and user's ability is not Infiltrator
                if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0 &&
                    atkTokusei != TokuseiNo.SURINUKE)
                {
                    ScoreCtrl(-10);
                }
            }
        }

        // 349 - Crafty Shield
        private void BaciAI_Seq_349()
        {
            // Single Battle
            if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_SINGLE)
            {
                ScoreCtrl(-5);
            }
        }

        // 350 - Flower Shield
        private void BaciAI_Seq_350()
        {
            var atkType1 = Call(CMD_CHECK_TYPE, new long[] { CHECK_ATTACK_TYPE1 });
            var atkType2 = Call(CMD_CHECK_TYPE, new long[] { CHECK_ATTACK_TYPE2 });
            var atkAllyType1 = Call(CMD_CHECK_TYPE, new long[] { CHECK_ATTACK_FRIEND_TYPE1 });
            var atkAllyType2 = Call(CMD_CHECK_TYPE, new long[] { CHECK_ATTACK_FRIEND_TYPE2 });
            var rule = Call(CMD_CHECK_BTL_RULE, Array.Empty<long>());

            if (rule == BTL_RULE_SINGLE)
            {
                // User's type is not Grass
                if (atkType1 != POKETYPE_KUSA &&
                    atkType2 != POKETYPE_KUSA)
                {
                    ScoreCtrl(-10);
                }
                // User's ability is Contrary
                else if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK }) == TokuseiNo.AMANOZYAKU)
                {
                    ScoreCtrl(-12);
                }
            }
            else
            {
                // User's type is Grass and user's ability is Contrary
                if ((atkType1 == POKETYPE_KUSA ||
                     atkType2 == POKETYPE_KUSA) &&
                     (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK }) == TokuseiNo.AMANOZYAKU)
                {
                    ScoreCtrl(-12);
                }

                // User's ally's type is Grass and user's ally's ability is Contrary
                if ((atkAllyType1 == POKETYPE_KUSA ||
                     atkAllyType2 == POKETYPE_KUSA) &&
                    (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK_FRIEND }) == TokuseiNo.AMANOZYAKU)
                {
                    ScoreCtrl(-12);
                }

                // User's type is not Grass and user's ally's type is not Grass
                if (atkType1 != POKETYPE_KUSA &&
                    atkType2 != POKETYPE_KUSA &&
                    atkAllyType1 != POKETYPE_KUSA &&
                    atkAllyType2 != POKETYPE_KUSA)
                {
                    ScoreCtrl(-10);
                }
            }
        }

        // 351 - Grassy Terrain
        private void BaciAI_Seq_351()
        {
            // Grassy Terrain is active
            if (Call(CMD_IF_EXIST_GROUND, new long[] { BTL_GROUND_GRASS }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 352 - Misty Terrain
        private void BaciAI_Seq_352()
        {
            // Misty Terrain is active
            if (Call(CMD_IF_EXIST_GROUND, new long[] { BTL_GROUND_MIST }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 354 - Induces Fairy Lock
        private void BaciAI_Seq_354()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var defBenchCount = Call(CMD_CHECK_BENCH_COUNT, new long[] { CHECK_DEFENCE });

            // User's ability is Shadow Tag
            if (atkTokusei == TokuseiNo.KAGEHUMI)
            {
                ScoreCtrl(-10);
            }
            // Target's side has no other Pokémon left in their party
            else if (defBenchCount == 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 362 - Aromatic Mist
        private void BaciAI_Seq_362()
        {
            // Single Battle
            if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_SINGLE)
            {
                ScoreCtrl(-20);
            }
            // User's ally's Special Defense is at +6 stages
            else if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_ATTACK_FRIEND, PARA_SPEDEF, 12 }) != 0)
            {
                ScoreCtrl(-10);
            }
            // User's ally's ability is Contrary
            else if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK_FRIEND }) == TokuseiNo.AMANOZYAKU)
            {
                ScoreCtrl(-12);
            }
        }

        // 363 - Venom Drench
        private void BaciAI_Seq_363()
        {
            // Target is not poisoned
            if (Call(CMD_IFN_WAZASICK, new long[] { CHECK_DEFENCE, WAZASICK_DOKU }) != 0)
            {
                ScoreCtrl(-10);
            }
            // Target is not badly poisoned
            else if (Call(CMD_IFN_DOKUDOKU, new long[] { CHECK_DEFENCE }) != 0)
            {
                ScoreCtrl(-10);
            }
            else
            {
                BaciAI_Seq_018();
                BaciAI_Seq_021();
            }
        }

        // 366 - Magnetic Flux
        private void BaciAI_Seq_366()
        {
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var atkAllyTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK_FRIEND });

            // User's ability is not Plus nor Minus and
            // User's ally's ability is not Plus nor Minus
            if (atkTokusei != TokuseiNo.PURASU &&
                atkTokusei != TokuseiNo.MAINASU &&
                atkAllyTokusei != TokuseiNo.PURASU &&
                atkAllyTokusei != TokuseiNo.MAINASU)
            {
                ScoreCtrl(-10);
            }
        }

        // 368 - Electric Terrain
        private void BaciAI_Seq_368()
        {
            // Electric Terrain is active
            if (Call(CMD_IF_EXIST_GROUND, new long[] { BTL_GROUND_ELEKI }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 370 - Hold Hands
        private void BaciAI_Seq_370()
        {
            // Single Battle
            if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_SINGLE)
            {
                ScoreCtrl(-20);
            }
        }

        // 387 - Strength Sap
        private void BaciAI_Seq_387()
        {
            // Target's Attack is at +6 stages
            if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_DEFENCE, PARA_POW, 0 }) != 0)
            {
                ScoreCtrl(-10);
            }

            // Target's ability is Defiant or Competitive
            switch ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE }))
            {
                case TokuseiNo.MAKENKI:
                case TokuseiNo.KATIKI:
                    ScoreCtrl(-12);
                    break;
            }

            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });

            // Target has a substitute and user's ability is not Infiltrator
            if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0 &&
                atkTokusei != TokuseiNo.SURINUKE)
            {
                ScoreCtrl(-10);
            }
            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt
            else if (atkTokusei != TokuseiNo.KATAYABURI &&
                     atkTokusei != TokuseiNo.TAABOBUREIZU &&
                     atkTokusei != TokuseiNo.TERABORUTEEZI)
            {
                var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

                // Target's ability is...
                switch (defTokusei)
                {
                    // Clear Body, Hyper Cutter, White Smoke
                    case TokuseiNo.KURIABODHI:
                    case TokuseiNo.KAIRIKIBASAMI:
                    case TokuseiNo.SIROIKEMURI:
                        ScoreCtrl(-10);
                        break;

                    // Contrary, Magic Bounce
                    case TokuseiNo.AMANOZYAKU:
                    case TokuseiNo.MAZIKKUMIRAA:
                        ScoreCtrl(-12);
                        break;

                    default:
                        // Target's type is Grass
                        if (Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 }) == POKETYPE_KUSA ||
                            Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 }) == POKETYPE_KUSA)
                        {
                            // Target's ability is Flower Veil
                            if (defTokusei == TokuseiNo.HURAWAABEERU)
                            {
                                ScoreCtrl(-10);
                            }
                            // Double Battle, and target's ally's ability is Flower Veil
                            else if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_DOUBLE &&
                                     (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE_FRIEND }) == TokuseiNo.HURAWAABEERU)
                            {
                                ScoreCtrl(-10);
                            }
                        }
                        break;
                }
            }
        }

        // 388 - Induces Spotlight
        private void BaciAI_Seq_388()
        {
            // Single Battle
            if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_SINGLE)
            {
                ScoreCtrl(-20);
            }
        }

        // 389 - Toxic Thread
        private void BaciAI_Seq_389()
        {
            // This is the most complicated of all the methods

            var defType1 = Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 });
            var defType2 = Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var weather = Call(CMD_CHECK_WEATHER, Array.Empty<long>());

            // Target's ability is Poison Heal
            if (defTokusei == TokuseiNo.POIZUNHIIRU)
            {
                ScoreCtrl(-12);
                return;
            }
            // Target has a substitute and user's ability is not Infiltrator
            else if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0 &&
                     atkTokusei != TokuseiNo.SURINUKE)
            {
                ScoreCtrl(-10);
                return;
            }
            // Target has a status effect and
            // Trick Room is active or user goes first
            else if (Call(CMD_IF_POKESICK, new long[] { CHECK_DEFENCE }) != 0 &&
                     (Call(CMD_FLDEFF_CHECK, new long[] { EFF_TRICKROOM }) != 0 ||
                      Call(CMD_IF_FIRST, new long[] { IF_FIRST_ATTACK }) != 0))
            {
                ScoreCtrl(-10);
                return;
            }
            // Target's side has Safeguard active and
            // Trick Room is active or user goes first
            else if (Call(CMD_IF_SIDEEFF, new long[] { CHECK_DEFENCE, BTL_SIDEEFF_SINPINOMAMORI }) != 0 &&
                     (Call(CMD_FLDEFF_CHECK, new long[] { EFF_TRICKROOM }) != 0 ||
                      Call(CMD_IF_FIRST, new long[] { IF_FIRST_ATTACK }) != 0))
            {
                ScoreCtrl(-10);
                return;
            }
            // Misty Terrain is active and target is grounded and
            // Trick Room is active or user goes first
            else if ((defTokusei != TokuseiNo.HUYUU &&
                      defType1 != POKETYPE_HIKOU &&
                      defType2 != POKETYPE_HIKOU &&
                      Call(CMD_IF_EXIST_GROUND, new long[] { BTL_GROUND_MIST }) != 0) &&
                     (Call(CMD_FLDEFF_CHECK, new long[] { EFF_TRICKROOM }) != 0 ||
                      Call(CMD_IF_FIRST, new long[] { IF_FIRST_ATTACK }) != 0))
            {
                ScoreCtrl(-10);
                return;
            }

            // User's ability is not Corrosion
            if (atkTokusei != TokuseiNo.HUSYOKU)
            {
                // Target's type is Poison or Steel
                if (defType1 == POKETYPE_DOKU ||
                    defType2 == POKETYPE_DOKU ||
                    defType1 == POKETYPE_HAGANE ||
                    defType2 == POKETYPE_HAGANE)
                {
                    if (Call(CMD_FLDEFF_CHECK, new long[] { EFF_TRICKROOM }) != 0 ||
                        Call(CMD_IF_FIRST, new long[] { IF_FIRST_ATTACK }) != 0)
                    {
                        ScoreCtrl(-10);
                        return;
                    }
                }

                // User's ability is Mold Breaker, Turboblaze, or Teravolt
                if (atkTokusei == TokuseiNo.KATAYABURI ||
                    atkTokusei == TokuseiNo.TAABOBUREIZU ||
                    atkTokusei == TokuseiNo.TERABORUTEEZI)
                {
                    return;
                }
            }

            // Target's ability is Defiant, Magic Bounce, or Competitive
            if (defTokusei == TokuseiNo.MAKENKI ||
                defTokusei == TokuseiNo.MAZIKKUMIRAA ||
                defTokusei == TokuseiNo.KATIKI)
            {
                ScoreCtrl(-12);
                return;
            }

            // Target's ability is Clear Body or White Smoke
            if (defTokusei == TokuseiNo.KURIABODHI ||
                defTokusei == TokuseiNo.SIROIKEMURI)
            {
                // Target's type is Poison or Steel
                if (defType1 == POKETYPE_DOKU ||
                    defType2 == POKETYPE_DOKU ||
                    defType1 == POKETYPE_HAGANE ||
                    defType2 == POKETYPE_HAGANE)
                {
                    // Target has a status effect
                    if (Call(CMD_IF_POKESICK, new long[] { CHECK_DEFENCE }) != 0)
                    {
                        ScoreCtrl(-10);
                        return;
                    }
                }
            }

            // Trick Room is active or user goes first
            if (Call(CMD_FLDEFF_CHECK, new long[] { EFF_TRICKROOM }) != 0 ||
                Call(CMD_IF_FIRST, new long[] { IF_FIRST_ATTACK }) != 0)
            {
                // Target's ability is...
                switch (defTokusei)
                {
                    // Immunity, Magic Bounce
                    case TokuseiNo.MENEKI:
                    case TokuseiNo.MAZIKKUMIRAA:
                        ScoreCtrl(-10);
                        return;

                    // Shields Down
                    case TokuseiNo.RIMITTOSIIRUDO:
                        // Target's HP is over 51%
                        if (Call(CMD_IF_HP_OVER, new long[] { CHECK_DEFENCE, 51 }) != 0)
                        {
                            ScoreCtrl(-10);
                            return;
                        }
                        break;

                    // Leaf Guard
                    case TokuseiNo.RIIHUGAADO:
                        // Weather is Harsh Sunlight
                        if (weather == WEATHER_HARE)
                        {
                            ScoreCtrl(-10);
                            return;
                        }
                        break;
                }
            }

            // Target's type is Grass
            if (Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 }) == POKETYPE_KUSA ||
                Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 }) == POKETYPE_KUSA)
            {
                // Target's ability is Flower Veil
                if (defTokusei == TokuseiNo.HURAWAABEERU)
                {
                    ScoreCtrl(-10);
                }
                // Double Battle, and target's ally's ability is Flower Veil
                else if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_DOUBLE &&
                         (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE_FRIEND }) == TokuseiNo.HURAWAABEERU)
                {
                    ScoreCtrl(-10);
                }
            }
        }

        // 391 - Gear Up
        private void BaciAI_Seq_391()
        {
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });

            // Target's ability is not Plus nor Minus and
            // User's ability is not Plus nor Minus
            if (defTokusei != TokuseiNo.PURASU &&
                defTokusei != TokuseiNo.MAINASU &&
                atkTokusei != TokuseiNo.PURASU &&
                atkTokusei != TokuseiNo.MAINASU)
            {
                ScoreCtrl(-10);
            }
        }

        // 394 - Psychic Terrain
        private void BaciAI_Seq_394()
        {
            // Psychic Terrain is active
            if (Call(CMD_IF_EXIST_GROUND, new long[] { BTL_GROUND_PHYCHO }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 397 - Burn Up
        private void BaciAI_Seq_397()
        {
            var atkType1 = Call(CMD_CHECK_TYPE, new long[] { CHECK_ATTACK_TYPE1 });
            var atkType2 = Call(CMD_CHECK_TYPE, new long[] { CHECK_ATTACK_TYPE2 });

            // User's type is not Fire
            if (atkType1 != POKETYPE_HONOO &&
                atkType2 != POKETYPE_HONOO)
            {
                ScoreCtrl(-10);
            }
        }

        // 399 - Purify
        private void BaciAI_Seq_399()
        {
            // Target does not have a status effect
            if (Call(CMD_IFN_POKESICK, new long[] { CHECK_DEFENCE }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 406 - Aurora Veil
        private void BaciAI_Seq_406()
        {
            // User's side has Aurora Veil active
            if (Call(CMD_IF_SIDEEFF, new long[] { CHECK_ATTACK, BTL_SIDEEFF_AURORAVEIL }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 419 - 50% Recoil
        private void BaciAI_Seq_419()
        {
            // User's HP is under 51%
            if (Call(CMD_IF_HP_UNDER, new long[] { CHECK_ATTACK, 51 }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 420 - Dynamax Cannon
        private void BaciAI_Seq_423()
        {
            // User is not holding a berry
            if (Call(CMD_IF_HAVE_KINOMI, new long[] { CHECK_ATTACK }) == 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 425 - Induces Tar Shot
        private void BaciAI_Seq_425()
        {
            // Target is afflicted by Tar Shot
            if (Call(CMD_IF_WAZASICK, new long[] { CHECK_DEFENCE, WAZASICK_TAR }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 426 - Magic Powder
        private void BaciAI_Seq_426()
        {
            var defType1 = Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE1 });
            var defType2 = Call(CMD_CHECK_TYPE, new long[] { CHECK_DEFENCE_TYPE2 });
            var atkTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK });
            var defTokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_DEFENCE });

            // User's ability is not Mold Breaker, Turboblaze, nor Teravolt and
            // Target's ability is Overcoat
            if (atkTokusei != TokuseiNo.KATAYABURI &&
                atkTokusei != TokuseiNo.TAABOBUREIZU &&
                atkTokusei != TokuseiNo.TERABORUTEEZI &&
                defTokusei == TokuseiNo.BOUZIN)
            {
                ScoreCtrl(-10);
            }
            else
            {
                // Target's type is Grass or Psychic
                if (defType1 == POKETYPE_KUSA ||
                    defType2 == POKETYPE_KUSA ||
                    defType1 == POKETYPE_ESPER ||
                    defType2 == POKETYPE_ESPER)
                {
                    ScoreCtrl(-10);
                }

                // Target has a substitute and user's ability is not Infiltrator
                if (Call(CMD_IF_MIGAWARI, new long[] { CHECK_DEFENCE }) != 0 &&
                    atkTokusei != TokuseiNo.SURINUKE)
                {
                    ScoreCtrl(-10);
                }
            }
        }

        // 428 - Teatime
        private void BaciAI_Seq_428()
        {
            var rule = Call(CMD_CHECK_BTL_RULE, Array.Empty<long>());
            var atkHaveKinomi = Call(CMD_IF_HAVE_KINOMI, new long[] { CHECK_ATTACK });

            // Single Battle
            if (rule == BTL_RULE_SINGLE)
            {
                // User and target are not holding berries
                if (atkHaveKinomi == 0 &&
                    Call(CMD_IF_HAVE_KINOMI, new long[] { CHECK_DEFENCE }) == 0)
                {
                    ScoreCtrl(-10);
                }
            }
            else
            {
                // User, user's ally, target, and target's ally are not holding berries
                if (atkHaveKinomi == 0 &&
                    Call(CMD_IF_HAVE_KINOMI, new long[] { CHECK_ATTACK_FRIEND }) == 0 &&
                    Call(CMD_IF_HAVE_KINOMI, new long[] { CHECK_DEFENCE }) == 0 &&
                    Call(CMD_IF_HAVE_KINOMI, new long[] { CHECK_DEFENCE_FRIEND }) == 0)
                {
                    ScoreCtrl(-10);
                }
            }
        }

        // 429 - Induces Octolock
        private void BaciAI_Seq_429()
        {
            // Target is afflicted by Octolock
            if (Call(CMD_IF_WAZASICK, new long[] { CHECK_DEFENCE, WAZASICK_TAKOGATAME }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 431 - Court Change
        private void BaciAI_Seq_431()
        {
            // User's side has any Side Effect active and
            // target's side has any Side Effect active
            if (Call(CMD_IF_SIDEEFF, new long[] { CHECK_ATTACK, BTL_SIDEEFF_NULL }) != 0 &&
                Call(CMD_IF_SIDEEFF, new long[] { CHECK_DEFENCE, BTL_SIDEEFF_NULL }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 432 - Clangorous Soul
        private void BaciAI_Seq_432()
        {
            // User's ability is Contrary
            if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK }) == TokuseiNo.AMANOZYAKU)
            {
                ScoreCtrl(-12);
            }
            // User's Attack is at +6 stages
            else if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_ATTACK, PARA_POW, 12 }) != 0)
            {
                ScoreCtrl(-10);
            }
            // User's HP is under 26%
            else if (Call(CMD_IF_HP_UNDER, new long[] { CHECK_ATTACK, 26 }) != 0)
            {
                ScoreCtrl(-10);
            }
        }

        // 434 - Decorate
        private void BaciAI_Seq_434()
        {
            // Single Battle
            if (Call(CMD_CHECK_BTL_RULE, Array.Empty<long>()) == BTL_RULE_SINGLE)
            {
                ScoreCtrl(-20);
            }
            // User's ally's Attack and Special Attack are both at +6 stages
            else if (Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_ATTACK_FRIEND, PARA_POW, 12 }) != 0 &&
                     Call(CMD_IF_PARA_EQUAL, new long[] { CHECK_ATTACK_FRIEND, PARA_SPEPOW, 12 }) != 0)
            {
                ScoreCtrl(-10);
            }
            // User's ally's ability is Contrary
            else if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { CHECK_ATTACK_FRIEND }) == TokuseiNo.AMANOZYAKU)
            {
                ScoreCtrl(-12);
            }
        }
    }
}