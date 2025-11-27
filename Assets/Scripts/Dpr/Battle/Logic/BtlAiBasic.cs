using Pml;
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
				var mikata = Call(CMD_IF_MIKATA_ATTACK, Array.Empty<long>());
				if (mikata != HAVE_NO)
					return;
            }

			if (Basic_ConaHoushi() != HAVE_YES &&
                Basic_Itazuragokoro() != HAVE_YES &&
                Basic_Sensei() != HAVE_YES &&
                Basic_Hayatenotubasa() != HAVE_YES &&
                Basic_DaimaxNG() != HAVE_YES)
			{
				var waza = CurrentWazaNo();

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
            if ((TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { (long)AIStatusFlag.CHECK_DEFENCE }) == TokuseiNo.BOUZIN)
            {
                var tokusei = (TokuseiNo)Call(CMD_CHECK_TOKUSEI, new long[] { (long)AIStatusFlag.CHECK_ATTACK });

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
            if ((PokeType)Call(CMD_CHECK_TYPE, new long[] { (long)AIStatusFlag.CHECK_DEFENCE_TYPE1 }) == PokeType.KUSA ||
                (PokeType)Call(CMD_CHECK_TYPE, new long[] { (long)AIStatusFlag.CHECK_DEFENCE_TYPE2 }) == PokeType.KUSA)
            {
                ScoreCtrl(-10);
                return HAVE_YES;
            }

			return HAVE_NO;
        }
		
		// TODO
		private int Basic_Itazuragokoro() { return default; }
		
		// TODO
		private int Basic_Sensei() { return default; }
		
		// TODO
		private int Basic_Hayatenotubasa() { return default; }
		
		// TODO
		private int Basic_DaimaxNG() { return default; }
		
		// TODO
		private int Calc_BasicDamage() { return default; }
		
		// TODO
		private int BasicDmg_00_1() { return default; }
		
		// TODO
		private int BasicDmg_00_2() { return default; }
		
		// TODO
		private int BasicDmg_00_3() { return default; }
		
		// TODO
		private int BasicDmg_00_4() { return default; }
		
		// TODO
		private int BasicDmg_00_5() { return default; }
		
		// TODO
		private int BasicDmg_00_7() { return default; }
		
		// TODO
		private void Calc_BasicAll() { }
		
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