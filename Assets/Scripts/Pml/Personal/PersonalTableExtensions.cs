﻿using XLSXContent;

namespace Pml.Personal
{
    public static class PersonalTableExtensions
    {
        public static byte pains_hp(this PersonalTable.SheetPersonal self)
        {
            return (byte)(self.exp_value & 0b11);
        }

        public static byte pains_atk(this PersonalTable.SheetPersonal self)
        {
            return (byte)((self.exp_value >> 2) & 0b11);
        }

        public static byte pains_def(this PersonalTable.SheetPersonal self)
        {
            return (byte)((self.exp_value >> 4) & 0b11);
        }

        public static byte pains_agi(this PersonalTable.SheetPersonal self)
        {
            return (byte)((self.exp_value >> 6) & 0b11);
        }

        public static byte pains_spatk(this PersonalTable.SheetPersonal self)
        {
            return (byte)((self.exp_value >> 8) & 0b11);
        }

        public static byte pains_spdef(this PersonalTable.SheetPersonal self)
        {
            return (byte)((self.exp_value >> 10) & 0b11);
        }

        public static bool IsValidData(this PersonalTable.SheetPersonal data)
        {
            return data.valid_flag;
        }

        public static MonsNo GetMonsNo(this PersonalTable.SheetPersonal data)
        {
            return (MonsNo)data.monsno;
        }

        public static uint GetParam(this PersonalTable.SheetPersonal data, ParamID paramId)
        {
            switch (paramId)
            {
                case ParamID.BASIC_HP:
                    return data.basic_hp;

                case ParamID.BASIC_ATK:
                    return data.basic_atk;

                case ParamID.BASIC_DEF:
                    return data.basic_def;

                case ParamID.BASIC_AGI:
                    return data.basic_agi;

                case ParamID.BASIC_SPATK:
                    return data.basic_spatk;

                case ParamID.BASIC_SPDEF:
                    return data.basic_spdef;

                case ParamID.TYPE1:
                    return data.type1;

                case ParamID.TYPE2:
                    return data.type2;

                case ParamID.GET_RATE:
                    return data.get_rate;

                case ParamID.GIVE_EXP:
                    return data.give_exp;

                case ParamID.PAINS_HP:
                    return data.pains_hp();

                case ParamID.PAINS_ATK:
                    return data.pains_atk();

                case ParamID.PAINS_DEF:
                    return data.pains_def();

                case ParamID.PAINS_AGI:
                    return data.pains_agi();

                case ParamID.PAINS_SPATK:
                    return data.pains_spatk();

                case ParamID.PAINS_SPDEF:
                    return data.pains_spdef();

                case ParamID.ITEM1:
                    return data.item1;

                case ParamID.ITEM2:
                    return data.item2;

                case ParamID.ITEM3:
                    return data.item3;

                case ParamID.SEX:
                    return data.sex;

                case ParamID.EGG_BIRTH:
                    return data.egg_birth;

                case ParamID.INITIAL_FRIENDSHIP:
                    return data.initial_friendship;

                case ParamID.GROW:
                    return data.grow;

                case ParamID.EGG_GROUP1:
                    return data.egg_group1;

                case ParamID.EGG_GROUP2:
                    return data.egg_group2;

                case ParamID.TOKUSEI1:
                    return data.tokusei1;

                case ParamID.TOKUSEI2:
                    return data.tokusei2;

                case ParamID.TOKUSEI3:
                    return data.tokusei3;

                case ParamID.FORM_INDEX:
                    return data.form_index;

                case ParamID.FORM_MAX:
                    return data.form_max;

                case ParamID.COLOR:
                    return data.color;

                case ParamID.RANK:
                    return data.rank;

                case ParamID.HEIGHT:
                    return data.height;

                case ParamID.WEIGHT:
                    return data.weight;

                case ParamID.MACHINE1:
                    return data.machine1;

                case ParamID.MACHINE2:
                    return data.machine2;

                case ParamID.MACHINE3:
                    return data.machine3;

                case ParamID.MACHINE4:
                    return data.machine4;

                case ParamID.WAZA_OSHIE_KYUKYOKU:
                    return data.hiden_machine;

                case ParamID.GRA_NO:
                    return data.gra_no;

                case ParamID.EGG_MONS_NO:
                    return data.egg_monsno;

                case ParamID.EGG_FORM_NO:
                    return data.egg_formno;

                case ParamID.EGG_FORM_NO_KAWARAZUNOISHI:
                    return data.egg_formno_kawarazunoishi;

                case ParamID.EGG_FORM_INHERIT_KAWARAZUNOISHI:
                    return data.egg_form_inherit_kawarazunoishi ? 1u : 0u;

                case ParamID.CHIHOU_ZUKAN_NO:
                    return data.chihou_zukan_no;

                case ParamID.NO_JUMP:
                case ParamID.WAZA_RECORD1:
                case ParamID.WAZA_RECORD2:
                case ParamID.WAZA_RECORD3:
                case ParamID.WAZA_RECORD4:
                case ParamID.ZENRYOKU_WAZA_ITEM:
                case ParamID.ZENRYOKU_WAZA_BEFORE:
                case ParamID.ZENRYOKU_WAZA_AFTER:
                case ParamID.G_DISABLE:
                case ParamID.RAIDBOSS_HP_COEF_GRADE1:
                case ParamID.RAIDBOSS_HP_COEF_GRADE2:
                case ParamID.RAIDBOSS_HP_COEF_GRADE3:
                case ParamID.RAIDBOSS_HP_COEF_GRADE4:
                case ParamID.RAIDBOSS_HP_COEF_GRADE5:
                case ParamID.RAIDBOSS_GWAZA_FREQUENCY_G1:
                case ParamID.RAIDBOSS_GWAZA_FREQUENCY_G2:
                case ParamID.RAIDBOSS_GWAZA_FREQUENCY_G3:
                case ParamID.RAIDBOSS_GWAZA_FREQUENCY_G4:
                case ParamID.RAIDBOSS_GWAZA_FREQUENCY_G5:
                case ParamID.RAIDBOSS_ACTION_NUM_G1:
                case ParamID.RAIDBOSS_ACTION_NUM_G2:
                case ParamID.RAIDBOSS_ACTION_NUM_G3:
                case ParamID.RAIDBOSS_ACTION_NUM_G4:
                case ParamID.RAIDBOSS_ACTION_NUM_G5:
                case ParamID.RAIDBOSS_GWALL_MAX_G1:
                case ParamID.RAIDBOSS_GWALL_MAX_G2:
                case ParamID.RAIDBOSS_GWALL_MAX_G3:
                case ParamID.RAIDBOSS_GWALL_MAX_G4:
                case ParamID.RAIDBOSS_GWALL_MAX_G5:
                case ParamID.RAIDBOSS_GWALL_INIT_G1:
                case ParamID.RAIDBOSS_GWALL_INIT_G2:
                case ParamID.RAIDBOSS_GWALL_INIT_G3:
                case ParamID.RAIDBOSS_GWALL_INIT_G4:
                case ParamID.RAIDBOSS_GWALL_INIT_G5:
                case ParamID.RAIDBOSS_ANGRY_COND_G1_1:
                case ParamID.RAIDBOSS_ANGRY_COND_G1_2:
                case ParamID.RAIDBOSS_ANGRY_COND_G2_1:
                case ParamID.RAIDBOSS_ANGRY_COND_G2_2:
                case ParamID.RAIDBOSS_ANGRY_COND_G3_1:
                case ParamID.RAIDBOSS_ANGRY_COND_G3_2:
                case ParamID.RAIDBOSS_ANGRY_COND_G4_1:
                case ParamID.RAIDBOSS_ANGRY_COND_G4_2:
                case ParamID.RAIDBOSS_ANGRY_COND_G5_1:
                case ParamID.RAIDBOSS_ANGRY_COND_G5_2:
                case ParamID.RAIDBOSS_ANGRY_WAZA_TIMING_G1_1:
                case ParamID.RAIDBOSS_ANGRY_WAZA_TIMING_G1_2:
                case ParamID.RAIDBOSS_ANGRY_WAZA_TIMING_G2_1:
                case ParamID.RAIDBOSS_ANGRY_WAZA_TIMING_G2_2:
                case ParamID.RAIDBOSS_ANGRY_WAZA_TIMING_G3_1:
                case ParamID.RAIDBOSS_ANGRY_WAZA_TIMING_G3_2:
                case ParamID.RAIDBOSS_ANGRY_WAZA_TIMING_G4_1:
                case ParamID.RAIDBOSS_ANGRY_WAZA_TIMING_G4_2:
                case ParamID.RAIDBOSS_ANGRY_WAZA_TIMING_G5_1:
                case ParamID.RAIDBOSS_ANGRY_WAZA_TIMING_G5_2:
                case ParamID.RAIDBOSS_ANGRY_WAZA_NO_G1_1:
                case ParamID.RAIDBOSS_ANGRY_WAZA_NO_G1_2:
                case ParamID.RAIDBOSS_ANGRY_WAZA_NO_G2_1:
                case ParamID.RAIDBOSS_ANGRY_WAZA_NO_G2_2:
                case ParamID.RAIDBOSS_ANGRY_WAZA_NO_G3_1:
                case ParamID.RAIDBOSS_ANGRY_WAZA_NO_G3_2:
                case ParamID.RAIDBOSS_ANGRY_WAZA_NO_G4_1:
                case ParamID.RAIDBOSS_ANGRY_WAZA_NO_G4_2:
                case ParamID.RAIDBOSS_ANGRY_WAZA_NO_G5_1:
                case ParamID.RAIDBOSS_ANGRY_WAZA_NO_G5_2:
                    return 0;

                default:
                    GFL.ASSERT(false);
                    return 0;
            }
        }

        public static SexType GetSexType(this PersonalTable.SheetPersonal data)
        {
            switch ((SexVector)data.sex)
            {
                case SexVector.ONLY_MALE:
                case SexVector.ONLY_FEMALE:
                case SexVector.UNKNOWN:
                    return SexType.FIX;

                default:
                    return SexType.RANDOM;
            }
        }

        public static bool CheckWazaMachine(this PersonalTable.SheetPersonal data, int _machineNo)
        {
            int no = _machineNo - 1;

            if (no < 0)
                return false;

            return (data.GetParam((ParamID)((uint)ParamID.MACHINE1 + (no / 32))) & (1 << (no % 32))) != 0;
        }

        public static bool CheckWazaRecord(this PersonalTable.SheetPersonal data, int recordNo)
        {
            int no = recordNo;

            if (no < 0)
                no = recordNo + 31;

            return (data.GetParam((ParamID)((uint)ParamID.WAZA_RECORD1 + (no / 32))) & (1 << (no % 32))) != 0;
        }

        public static bool CheckWazaOshie(this PersonalTable.SheetPersonal data, int oshieNo)
        {
            return (data.GetParam(ParamID.WAZA_OSHIE_KYUKYOKU) & (1 << (oshieNo % 32))) != 0;
        }

        public static TokuseiPattern GetTokuseiPattern(this PersonalTable.SheetPersonal data)
        {
            var tokusei1 = data.tokusei1;
            var tokusei2 = data.tokusei2;
            var tokusei3 = data.tokusei3;

            if (tokusei1 == tokusei2 && tokusei1 == tokusei3)
                return TokuseiPattern.AAA;
            else if (tokusei1 == tokusei2 && tokusei1 != tokusei3)
                return TokuseiPattern.AAB;

            GFL.ASSERT(tokusei1 != tokusei3);
            GFL.ASSERT(tokusei2 != tokusei3);

            return TokuseiPattern.ABC;
        }
    }
}