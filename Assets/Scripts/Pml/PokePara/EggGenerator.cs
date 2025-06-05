using Dpr.Message;
using Pml.Item;
using Pml.Personal;

namespace Pml.PokePara
{
    public class EggGenerator
    {
        private static readonly uint[][] BABY_TABLE =
        {
            new uint[4] { (uint)MonsNo.MARIRU,    (uint)ItemNo.USIONOOKOU,     (uint)MonsNo.RURIRI,  0, },
            new uint[4] { (uint)MonsNo.SOONANSU,  (uint)ItemNo.NONKINOOKOU,    (uint)MonsNo.SOONANO, 0, },
            new uint[4] { (uint)MonsNo.BARIYAADO, (uint)ItemNo.AYASIIOKOU,     (uint)MonsNo.MANENE,  0, },
            new uint[4] { (uint)MonsNo.USOKKII,   (uint)ItemNo.GANSEKIOKOU,    (uint)MonsNo.USOHATI, 0, },
            new uint[4] { (uint)MonsNo.KABIGON,   (uint)ItemNo.MANPUKUOKOU,    (uint)MonsNo.GONBE,   0, },
            new uint[4] { (uint)MonsNo.MANTAIN,   (uint)ItemNo.SAZANAMINOOKOU, (uint)MonsNo.TAMANTA, 0, },
            new uint[4] { (uint)MonsNo.ROZERIA,   (uint)ItemNo.OHANANOOKOU,    (uint)MonsNo.SUBOMII, 0, },
            new uint[4] { (uint)MonsNo.RAKKII,    (uint)ItemNo.KOUUNNOOKOU,    (uint)MonsNo.PINPUKU, 0, },
            new uint[4] { (uint)MonsNo.TIRIIN,    (uint)ItemNo.KIYOMENOOKOU,   (uint)MonsNo.RIISYAN, 0, },
        };
        private static readonly uint[] POWER_ITEMS = new uint[6]
        {
            (uint)ItemNo.PAWAAUEITO, (uint)ItemNo.PAWAARISUTO, (uint)ItemNo.PAWAABERUTO,
            (uint)ItemNo.PAWAARENZU, (uint)ItemNo.PAWAABANDO, (uint)ItemNo.PAWAAANKURU,
        };

        public static PokemonParam CreateEgg(CoreParam poke1, CoreParam poke2, Setting setting)
        {
            return new PokemonParam(CreateEgg_CoreParam(poke1, poke2, setting));
        }

        public static CoreParam CreateEgg_CoreParam(CoreParam poke1, CoreParam poke2, Setting setting)
        {
            var poke1ValidFlag = poke1.StartFastMode();
            var poke2ValidFlag = poke2.StartFastMode();

            var parents = new Parents();
            DecideParents(parents, poke1, poke2);
            var egg_param = new EggParam();
            DecideEggParams(egg_param, parents, setting);

            poke1.EndFastMode(poke1ValidFlag);
            poke2.EndFastMode(poke2ValidFlag);

            var egg = new CoreParam(egg_param.spec);
            SetupEggParam(egg, egg_param, parents, setting);
            return egg;
        }

        private static void DecideParents(Parents parents, CoreParam poke1, CoreParam poke2)
        {
            parents.father = poke1;
            parents.mother = poke2;

            CorrectParents_SEX(parents);
            CorrectParents_METAMON(parents);
        }

        private static void CorrectParents_SEX(Parents parents)
        {
            var fatherSex = parents.father.GetSex();
            var motherSex = parents.mother.GetSex();
            if (fatherSex == Sex.FEMALE)
                ReverseParents(parents);

            fatherSex = parents.father.GetSex();
            motherSex = parents.mother.GetSex();
            if (motherSex == Sex.MALE)
                ReverseParents(parents);
        }

        private static void CorrectParents_METAMON(Parents parents)
        {
            if (parents.father.GetMonsNo() == MonsNo.METAMON && parents.mother.GetSex() == Sex.UNKNOWN)
                ReverseParents(parents);
        }

        private static void ReverseParents(Parents parents)
        {
            var oldFather = parents.father;
            parents.father = parents.mother;
            parents.mother = oldFather;
        }

        private static CoreParam GetBasePokemon_forMonsNo(Parents parents)
        {
            return parents.mother.GetMonsNo() == MonsNo.METAMON ? parents.father : parents.mother;
        }

        private static CoreParam GetBasePokemon_forForm(Parents parents)
        {
            return parents.mother.GetMonsNo() == MonsNo.METAMON ? parents.father : parents.mother;
        }

        private static void DecideEggParams(EggParam egg_param, Parents parents, Setting setting)
        {
            egg_param.spec.id = setting.IDNo;
            egg_param.spec.level = 1;

            DecideEggParam_MonsNo_BASIC(egg_param, parents);
            DecideEggParam_MonsNo_NIDORAN(egg_param, parents, setting.randFunc);
            DecideEggParam_MonsNo_BARUBIITO(egg_param, parents, setting.randFunc);
            DecideEggParam_MonsNo_FIONE(egg_param, parents);

            DecideEggParam_Form_BASIC(egg_param, parents);
            DecideEggParam_Form_KAWARAZUNOISHI(egg_param, parents);
            DecideEggParam_Form_REGION(egg_param, parents, setting);
            DecideEggParam_Form_SIRUKII(egg_param, parents, setting.randFunc);
            DecideEggParam_Form_MINOMUTTI(egg_param, parents);
            DecideEggParam_MonsNo_FormNo_BABY(egg_param, parents);

            DecideEggParam_Sex(egg_param, egg_param.spec.monsno, egg_param.spec.formno, setting.randFunc);

            DecideEggParam_Seikaku_BASIC(egg_param, parents, setting.randFunc);
            DecideEggParam_Seikaku_KAWARAZUNOISI(egg_param, parents, setting.randFunc);

            DecideEggParam_TokuseiIndex(egg_param, parents, setting.randFunc);
            DecideEggParam_BirthCount(egg_param);

            DecideDerivedTalentPower_AKAIITO(egg_param, parents);
            DecideDerivedTalentPower_ITEM(egg_param, parents, setting.randFunc);
            DecideDerivedTalentPower_RANDOM(egg_param, parents, setting.randFunc);

            DecideEggParam_TalentPower_RANDOM(egg_param, parents, setting.randFunc);
            DecideEggParam_TalentPower_DERIVE(egg_param, parents);

            DecideEggParam_PersonalRnd(egg_param, parents, setting.randFunc);
            DecideEggParam_RareRnd(egg_param, parents, setting.haveItem_HIKARUOMAMORI, setting.randFunc);

            DecideEggParam_Waza_DEFAULT(egg_param);
            DecideEggParam_Waza_PARENTS(egg_param, parents);
            DecideEggParam_Waza_EGG(egg_param, parents);
            DecideEggParam_Waza_PITYUU(egg_param, parents);

            DecideEggParam_BallID(egg_param, parents, setting.randFunc);
        }

        private static void DecideEggParam_MonsNo_BASIC(EggParam egg, Parents parents)
        {
            var baseMon = GetBasePokemon_forMonsNo(parents);
            egg.spec.monsno = GetSeedMonsNo(baseMon.GetMonsNo(), baseMon.GetFormNo());
        }

        private static void DecideEggParam_MonsNo_NIDORAN(EggParam egg, Parents parents, SavedRandomFunc randFunc)
        {
            var baseMon = GetBasePokemon_forMonsNo(parents);
            switch (baseMon.GetMonsNo())
            {
                case MonsNo.NIDORAN_F:
                case MonsNo.NIDORAN_M:
                case MonsNo.NIDORIINO:
                case MonsNo.NIDOKINGU:
                    egg.spec.monsno = randFunc.Invoke(2) == 0 ? MonsNo.NIDORAN_M : MonsNo.NIDORAN_F;
                    break;
            }
        }

        private static void DecideEggParam_MonsNo_BARUBIITO(EggParam egg, Parents parents, SavedRandomFunc randFunc)
        {
            var baseMon = GetBasePokemon_forMonsNo(parents);
            switch (baseMon.GetMonsNo())
            {
                case MonsNo.BARUBIITO:
                case MonsNo.IRUMIIZE:
                    egg.spec.monsno = randFunc.Invoke(2) == 0 ? MonsNo.BARUBIITO : MonsNo.IRUMIIZE;
                    break;
            }
        }

        private static void DecideEggParam_MonsNo_FIONE(EggParam egg, Parents parents)
        {
            var baseMon = GetBasePokemon_forMonsNo(parents);
            if (baseMon.GetMonsNo() == MonsNo.MANAFI)
                egg.spec.monsno = MonsNo.FIONE;
        }

        private static void DecideEggParam_MonsNo_FormNo_BABY(EggParam egg, Parents parents)
        {
            var fatherItem = parents.father.GetItem();
            var motherItem = parents.mother.GetItem();

            for (int i=0; i<BABY_TABLE.Length; i++)
            {
                if (BABY_TABLE[i][0] == (uint)egg.spec.monsno)
                {
                    if (BABY_TABLE[i][1] == fatherItem || BABY_TABLE[i][1] == motherItem)
                    {
                        egg.spec.monsno = (MonsNo)BABY_TABLE[i][2];
                        egg.spec.formno = (ushort)BABY_TABLE[i][3];
                    }
                }
            }
        }

        private static void DecideEggParam_Form_BASIC(EggParam egg, Parents parents)
        {
            var baseMon = GetBasePokemon_forForm(parents);
            egg.spec.formno = (ushort)PersonalSystem.GetPersonalData(baseMon.GetMonsNo(), baseMon.GetFormNo()).GetParam(ParamID.EGG_FORM_NO);
        }

        private static void DecideEggParam_Form_KAWARAZUNOISHI(EggParam egg, Parents parents)
        {
            var motherMonsno = parents.mother.GetMonsNo();
            var motherFormno = parents.mother.GetFormNo();
            var fatherMonsno = parents.father.GetMonsNo();
            var fatherFormno = parents.father.GetFormNo();

            if (motherMonsno == MonsNo.METAMON || fatherMonsno == MonsNo.METAMON)
            {
                ushort resultFormno = 0;
                if (isFormInheritEnableByKawarazuNoIshi(ref resultFormno, GetBasePokemon_forForm(parents)))
                    egg.spec.formno = resultFormno;
            }
            else
            {
                var motherEggMonsno = GetSeedMonsNo(motherMonsno, motherFormno);
                var fatherEggMonsno = GetSeedMonsNo(fatherMonsno, fatherFormno);
                if (motherEggMonsno == fatherEggMonsno)
                {
                    ushort resultFormno = 0;
                    if (isFormInheritEnableByKawarazuNoIshi(ref resultFormno, parents.mother))
                        egg.spec.formno = resultFormno;
                    else if (isFormInheritEnableByKawarazuNoIshi(ref resultFormno, parents.father))
                        egg.spec.formno = resultFormno;
                }
                else
                {
                    ushort resultFormno = 0;
                    if (isFormInheritEnableByKawarazuNoIshi(ref resultFormno, GetBasePokemon_forForm(parents)))
                        egg.spec.formno = resultFormno;
                }
            }
        }

        private static void DecideEggParam_Form_REGION(EggParam egg, Parents parents, Setting setting)
        {
            var baseMon = GetBasePokemon_forForm(parents);

            // Result ignored
            GetSeedMonsNo(baseMon.GetMonsNo(), baseMon.GetFormNo());
        }

        private static void DecideEggParam_Form_SIRUKII(EggParam egg, Parents parents, SavedRandomFunc randFunc)
        {
            var baseMon = GetBasePokemon_forForm(parents);

            // Result ignored
            GetSeedMonsNo(baseMon.GetMonsNo(), baseMon.GetFormNo());
        }

        private static void DecideEggParam_Form_MINOMUTTI(EggParam egg, Parents parents)
        {
            var baseMon = GetBasePokemon_forForm(parents);
            var baseMonsno = baseMon.GetMonsNo();
            var baseFormno = baseMon.GetFormNo();
            var eggMonsno = GetSeedMonsNo(baseMon.GetMonsNo(), baseMon.GetFormNo());

            if (baseMonsno == MonsNo.GAAMEIRU && eggMonsno == MonsNo.MINOMUTTI)
                egg.spec.formno = 0;
        }

        private static void DecideEggParam_Sex(EggParam egg, MonsNo monsno, ushort formno, SavedRandomFunc randFunc)
        {
            var sexVector = (SexVector)PersonalSystem.GetPersonalData(monsno, formno).GetParam(ParamID.SEX);
            switch (sexVector)
            {
                case SexVector.ONLY_MALE:
                    egg.spec.sex = (ushort)Sex.MALE;
                    break;

                case SexVector.ONLY_FEMALE:
                    egg.spec.sex = (ushort)Sex.FEMALE;
                    break;

                case SexVector.UNKNOWN:
                    egg.spec.sex = (ushort)Sex.UNKNOWN;
                    break;

                default:
                    egg.spec.sex = (ushort)(((randFunc.Invoke(((uint)SexVector.RANDOM_MAX) - 1) + 1) < (uint)sexVector) ? Sex.FEMALE : Sex.MALE);
                    break;
            }
        }

        private static void DecideEggParam_Seikaku_BASIC(EggParam egg, Parents parents, SavedRandomFunc randFunc)
        {
            egg.spec.seikaku = (ushort)randFunc.Invoke((uint)Seikaku.NUM);
        }

        private static void DecideEggParam_Seikaku_KAWARAZUNOISI(EggParam egg, Parents parents, SavedRandomFunc randFunc)
        {
            var motherItem = parents.mother.GetItem();
            var motherSeikaku = parents.mother.GetSeikaku();
            var fatherItem = parents.father.GetItem();
            var fatherSeikaku = parents.father.GetSeikaku();

            if (fatherItem == (ushort)ItemNo.KAWARAZUNOISI && motherItem == (ushort)ItemNo.KAWARAZUNOISI)
                egg.spec.seikaku = (ushort)(randFunc.Invoke(2) == 0 ? fatherSeikaku : motherSeikaku);
            else if (fatherItem == (ushort)ItemNo.KAWARAZUNOISI)
                egg.spec.seikaku = (ushort)fatherSeikaku;
            else if (motherItem == (ushort)ItemNo.KAWARAZUNOISI)
                egg.spec.seikaku = (ushort)motherSeikaku;
        }

        private static void DecideEggParam_TokuseiIndex(EggParam egg, Parents parents, SavedRandomFunc randFunc)
        {
            var percent = randFunc.Invoke(100);
            switch (GetBasePokemon_forMonsNo(parents).GetTokuseiIndexStrict())
            {
                case 0:
                    if (percent < 80)
                        egg.spec.tokuseiIndex = 0;
                    else
                        egg.spec.tokuseiIndex = 1;
                    break;

                case 1:
                    if (percent < 20)
                        egg.spec.tokuseiIndex = 0;
                    else
                        egg.spec.tokuseiIndex = 1;
                    break;

                case 2:
                    if (percent < 20)
                        egg.spec.tokuseiIndex = 0;
                    else if (percent < 40)
                        egg.spec.tokuseiIndex = 1;
                    else
                        egg.spec.tokuseiIndex = 2;
                    break;
            }
        }

        private static void DecideEggParam_BirthCount(EggParam egg)
        {
            egg.spec.friendship = PersonalSystem.GetPersonalData(egg.spec.monsno, egg.spec.formno).GetParam(ParamID.EGG_BIRTH);
        }

        private static void DecideDerivedTalentPower_AKAIITO(EggParam egg, Parents parents)
        {
            egg.totalDeriveTalentCount = (parents.father.GetItem() != (ushort)ItemNo.AKAIITO && parents.mother.GetItem() != (ushort)ItemNo.AKAIITO) ? 3u : 5u;
        }

        private static void DecideDerivedTalentPower_ITEM(EggParam egg, Parents parents, SavedRandomFunc randFunc)
        {
            var fatherItem = parents.father.GetItem();

            bool fatherDerivedTalent = false;
            uint fatherPowerItem = 0;
            if (POWER_ITEMS[0] == fatherItem)
            {
                fatherPowerItem = 0;
                fatherDerivedTalent = true;
            }
            else if (POWER_ITEMS[1] == fatherItem)
            {
                fatherPowerItem = 1;
                fatherDerivedTalent = true;
            }
            else if (POWER_ITEMS[2] == fatherItem)
            {
                fatherPowerItem = 2;
                fatherDerivedTalent = true;
            }
            else if (POWER_ITEMS[3] == fatherItem)
            {
                fatherPowerItem = 3;
                fatherDerivedTalent = true;
            }
            else if (POWER_ITEMS[4] == fatherItem)
            {
                fatherPowerItem = 4;
                fatherDerivedTalent = true;
            }
            else if (POWER_ITEMS[5] == fatherItem)
            {
                fatherPowerItem = 5;
                fatherDerivedTalent = true;
            }

            bool motherDerivedTalent = false;
            uint motherPowerItem = 0;
            if (POWER_ITEMS[0] == fatherItem)
            {
                motherPowerItem = 0;
                motherDerivedTalent = true;
            }
            else if (POWER_ITEMS[1] == fatherItem)
            {
                motherPowerItem = 1;
                motherDerivedTalent = true;
            }
            else if (POWER_ITEMS[2] == fatherItem)
            {
                motherPowerItem = 2;
                motherDerivedTalent = true;
            }
            else if (POWER_ITEMS[3] == fatherItem)
            {
                motherPowerItem = 3;
                motherDerivedTalent = true;
            }
            else if (POWER_ITEMS[4] == fatherItem)
            {
                motherPowerItem = 4;
                motherDerivedTalent = true;
            }
            else if (POWER_ITEMS[5] == fatherItem)
            {
                motherPowerItem = 5;
                motherDerivedTalent = true;
            }

            if (fatherDerivedTalent && motherDerivedTalent)
            {
                if (randFunc.Invoke(2) != 0)
                    egg.isTalentDerivedFromMother[motherPowerItem] = true;
                else
                    egg.isTalentDerivedFromFather[fatherPowerItem] = true;

                egg.derivedTalentCount++;
            }
            else if (fatherDerivedTalent)
            {
                egg.isTalentDerivedFromFather[fatherPowerItem] = true;
                egg.derivedTalentCount++;
            }
            else if (motherDerivedTalent)
            {
                egg.isTalentDerivedFromMother[motherPowerItem] = true;
                egg.derivedTalentCount++;
            }
        }

        private static void DecideDerivedTalentPower_RANDOM(EggParam egg, Parents parents, SavedRandomFunc randFunc)
        {
            while (egg.derivedTalentCount < egg.totalDeriveTalentCount)
            {
                var talent = randFunc.Invoke(6);
                if (!egg.isTalentDerivedFromFather[talent] && !egg.isTalentDerivedFromMother[talent])
                {
                    var parent = randFunc.Invoke(2);
                    if (parent == 0)
                        egg.isTalentDerivedFromFather[parent] = true;
                    else
                        egg.isTalentDerivedFromMother[parent] = true;

                    egg.derivedTalentCount++;
                }
            }
        }

        private static void DecideEggParam_TalentPower_RANDOM(EggParam egg, Parents parents, SavedRandomFunc randFunc)
        {
            egg.spec.talentPower[0] = (ushort)randFunc.Invoke(PmlConstants.MAX_TALENT_POWER+1);
            egg.spec.talentPower[1] = (ushort)randFunc.Invoke(PmlConstants.MAX_TALENT_POWER+1);
            egg.spec.talentPower[2] = (ushort)randFunc.Invoke(PmlConstants.MAX_TALENT_POWER+1);
            egg.spec.talentPower[3] = (ushort)randFunc.Invoke(PmlConstants.MAX_TALENT_POWER+1);
            egg.spec.talentPower[4] = (ushort)randFunc.Invoke(PmlConstants.MAX_TALENT_POWER+1);
            egg.spec.talentPower[5] = (ushort)randFunc.Invoke(PmlConstants.MAX_TALENT_POWER+1);
        }

        private static void DecideEggParam_TalentPower_DERIVE(EggParam egg, Parents parents)
        {
            if (egg.isTalentDerivedFromFather[0])
                egg.spec.talentPower[0] = (ushort)parents.father?.GetNativeTalentPower(PowerID.HP);
            else if (egg.isTalentDerivedFromMother[0])
                egg.spec.talentPower[0] = (ushort)parents.mother?.GetNativeTalentPower(PowerID.HP);
            else if (egg.isTalentDerivedFromFather[1])
                egg.spec.talentPower[1] = (ushort)parents.father?.GetNativeTalentPower(PowerID.ATK);
            else if (egg.isTalentDerivedFromMother[1])
                egg.spec.talentPower[1] = (ushort)parents.mother?.GetNativeTalentPower(PowerID.ATK);
            else if (egg.isTalentDerivedFromFather[2])
                egg.spec.talentPower[2] = (ushort)parents.father?.GetNativeTalentPower(PowerID.DEF);
            else if (egg.isTalentDerivedFromMother[2])
                egg.spec.talentPower[2] = (ushort)parents.mother?.GetNativeTalentPower(PowerID.DEF);
            else if (egg.isTalentDerivedFromFather[3])
                egg.spec.talentPower[3] = (ushort)parents.father?.GetNativeTalentPower(PowerID.SPATK);
            else if (egg.isTalentDerivedFromMother[3])
                egg.spec.talentPower[3] = (ushort)parents.mother?.GetNativeTalentPower(PowerID.SPATK);
            else if (egg.isTalentDerivedFromFather[4])
                egg.spec.talentPower[4] = (ushort)parents.father?.GetNativeTalentPower(PowerID.SPDEF);
            else if (egg.isTalentDerivedFromMother[4])
                egg.spec.talentPower[4] = (ushort)parents.mother?.GetNativeTalentPower(PowerID.SPDEF);
            else if (egg.isTalentDerivedFromFather[5])
                egg.spec.talentPower[5] = (ushort)parents.father?.GetNativeTalentPower(PowerID.AGI);
            else if (egg.isTalentDerivedFromMother[5])
                egg.spec.talentPower[5] = (ushort)parents.mother?.GetNativeTalentPower(PowerID.AGI);
        }

        private static void DecideEggParam_PersonalRnd(EggParam egg, Parents parents, SavedRandomFunc randFunc)
        {
            egg.spec.personalRnd = randFunc.Invoke(0xFFFFFFFF);
        }

        private static void DecideEggParam_RareRnd(EggParam egg, Parents parents, bool have_HIKARUOMAMORI, SavedRandomFunc randFunc)
        {
            var rolls = 0;

            if (parents.father.GetLangId() != parents.mother.GetLangId())
                rolls += 6;

            if (have_HIKARUOMAMORI)
                rolls += 2;

            for (int i=0; i<rolls; i++)
            {
                egg.spec.rareRnd = randFunc.Invoke(0xFFFFFFFF);

                if (CalcTool.IsRareColor((uint)egg.spec.id, (uint)egg.spec.rareRnd))
                    break;
            }
        }

        private static void DecideEggParam_Waza_DEFAULT(EggParam egg)
        {
            PersonalSystem.LoadWazaOboeData(egg.spec.monsno, egg.spec.formno);
            for (ushort i=0; i<PersonalSystem.GetWazaOboeNum(); i++)
            {
                var wazalevel = PersonalSystem.GetWazaOboeLevel(i);
                var wazano = PersonalSystem.GetWazaOboeWazaNo(i);

                if (wazalevel > egg.spec.level)
                    break;

                PushWaza_to_EggParam(egg, (WazaNo)wazano);
            }
        }

        private static void PushWaza_to_EggParam(EggParam egg, WazaNo wazano)
        {
            if (wazano == WazaNo.NULL)
                return;
            
            for (int i=0; i<egg.wazaCount; i++)
            {
                if (egg.wazano[i] == wazano)
                    return;
            }

            if (egg.wazaCount >= PmlConstants.MAX_WAZA_NUM)
            {
                egg.wazano[0] = egg.wazano[1];
                egg.wazano[1] = egg.wazano[2];
                egg.wazano[2] = egg.wazano[3];
                egg.wazano[3] = wazano;
            }
            else
            {
                egg.wazano[egg.wazaCount] = wazano;
                egg.wazaCount++;
            }
        }

        private static void PushEggWaza_to_EggParam(EggParam egg, CoreParam parent, EggWazaData eggWazaData)
        {
            if (parent.GetMonsNo() == MonsNo.METAMON)
                return;

            if (eggWazaData.GetEggWazaNum() == 0)
            {
                _ = parent.GetWazaNo(0);
                _ = parent.GetWazaNo(1);
                _ = parent.GetWazaNo(2);
                _ = parent.GetWazaNo(3);
            }
            else
            {
                var waza = parent.GetWazaNo(0);
                if (eggWazaData.IsContain(waza))
                    PushWaza_to_EggParam(egg, waza);

                waza = parent.GetWazaNo(1);
                if (eggWazaData.IsContain(waza))
                    PushWaza_to_EggParam(egg, waza);

                waza = parent.GetWazaNo(2);
                if (eggWazaData.IsContain(waza))
                    PushWaza_to_EggParam(egg, waza);

                waza = parent.GetWazaNo(3);
                if (eggWazaData.IsContain(waza))
                    PushWaza_to_EggParam(egg, waza);
            }
        }

        private static void DecideEggParam_Waza_EGG(EggParam egg, Parents parents)
        {
            var wazadata = new EggWazaData();
            wazadata.Load(egg.spec.monsno, egg.spec.formno);

            PushEggWaza_to_EggParam(egg, parents.father, wazadata);
            PushEggWaza_to_EggParam(egg, parents.mother, wazadata);
        }

        private static void DecideEggParam_Waza_PARENTS(EggParam egg, Parents parents)
        {
            PersonalSystem.LoadWazaOboeData(egg.spec.monsno, egg.spec.formno);
            for (ushort i=0; i<PersonalSystem.GetWazaOboeNum(); i++)
            {
                var wazano = PersonalSystem.GetWazaOboeWazaNo(i);

                bool fatherHasWaza = false;
                if ((ushort)parents.father.GetWazaNo(0) == wazano)
                    fatherHasWaza = true;
                else if ((ushort)parents.father.GetWazaNo(1) == wazano)
                    fatherHasWaza = true;
                else if ((ushort)parents.father.GetWazaNo(2) == wazano)
                    fatherHasWaza = true;
                else if ((ushort)parents.father.GetWazaNo(3) == wazano)
                    fatherHasWaza = true;

                bool motherHasWaza = false;
                if ((ushort)parents.mother.GetWazaNo(0) == wazano)
                    motherHasWaza = true;
                else if ((ushort)parents.mother.GetWazaNo(1) == wazano)
                    motherHasWaza = true;
                else if ((ushort)parents.mother.GetWazaNo(2) == wazano)
                    motherHasWaza = true;
                else if ((ushort)parents.mother.GetWazaNo(3) == wazano)
                    motherHasWaza = true;

                if (fatherHasWaza && motherHasWaza)
                    PushWaza_to_EggParam(egg, (WazaNo)wazano);
            }
        }

        private static void DecideEggParam_Waza_PITYUU(EggParam egg, Parents parents)
        {
            if (egg.spec.monsno != MonsNo.PITYUU)
                return;

            if (parents.father.GetItem() == (ushort)ItemNo.DENKIDAMA || parents.mother.GetItem() == (ushort)ItemNo.DENKIDAMA)
                PushWaza_to_EggParam(egg, WazaNo.BORUTEKKAA);
        }

        private static void DecideEggParam_Waza_MACHINE(EggParam egg, Parents parents)
        {
            var fatherWazano = parents.father.GetWazaNo(0);
            for (ushort i=(ushort)ItemNo.WAZAMASIN01; i<(ushort)ItemNo.DATA_MAX; i++)
            {
                if (fatherWazano == ItemData.GetWazaNo(i) && IsWazaMachineAbleToUse(egg.spec.monsno, egg.spec.formno, i))
                    PushWaza_to_EggParam(egg, fatherWazano);
            }

            fatherWazano = parents.father.GetWazaNo(1);
            for (ushort i=(ushort)ItemNo.WAZAMASIN01; i<(ushort)ItemNo.DATA_MAX; i++)
            {
                if (fatherWazano == ItemData.GetWazaNo(i) && IsWazaMachineAbleToUse(egg.spec.monsno, egg.spec.formno, i))
                    PushWaza_to_EggParam(egg, fatherWazano);
            }

            fatherWazano = parents.father.GetWazaNo(2);
            for (ushort i=(ushort)ItemNo.WAZAMASIN01; i<(ushort)ItemNo.DATA_MAX; i++)
            {
                if (fatherWazano == ItemData.GetWazaNo(i) && IsWazaMachineAbleToUse(egg.spec.monsno, egg.spec.formno, i))
                    PushWaza_to_EggParam(egg, fatherWazano);
            }

            fatherWazano = parents.father.GetWazaNo(3);
            for (ushort i=(ushort)ItemNo.WAZAMASIN01; i<(ushort)ItemNo.DATA_MAX; i++)
            {
                if (fatherWazano == ItemData.GetWazaNo(i) && IsWazaMachineAbleToUse(egg.spec.monsno, egg.spec.formno, i))
                    PushWaza_to_EggParam(egg, fatherWazano);
            }
        }

        private static void DecideEggParam_BallID(EggParam egg, Parents parents, SavedRandomFunc randFunc)
        {
            var motherMonsno = parents.mother.GetMonsNo();
            var fatherMonsno = parents.father.GetMonsNo();
            var motherGetBall = parents.mother.GetGetBall();
            var fatherGetBall = parents.father.GetGetBall();

            if (motherMonsno == MonsNo.METAMON)
                egg.ballID = fatherGetBall;
            else if (motherMonsno == fatherMonsno)
                egg.ballID = (randFunc.Invoke(100) + 1 > 50) ? fatherGetBall : motherGetBall;
            else
                egg.ballID = motherGetBall;

            if (egg.ballID == (uint)BallId.MASUTAABOORU || egg.ballID == (uint)BallId.PURESYASUBOORU || ItemManager.IsStrangeBall((BallId)egg.ballID))
                egg.ballID = (uint)BallId.MONSUTAABOORU;
        }

        private static bool IsWazaMachineAbleToUse(MonsNo monsno, ushort formno, ushort itemno)
        {
            if (monsno <= MonsNo.END)
            {
                if (ItemData.IsWazaMachine(itemno))
                {
                    PersonalSystem.LoadPersonalData(monsno, formno);

                    uint bitfield;
                    uint tmno = ItemData.GetWazaMashineNo(itemno);
                    if (tmno < 32)
                    {
                        bitfield = PersonalSystem.GetPersonalParam(ParamID.MACHINE1);
                    }
                    else if (tmno < 64)
                    {
                        bitfield = PersonalSystem.GetPersonalParam(ParamID.MACHINE2);
                        tmno -= 32;
                    }
                    else if (tmno < 96)
                    {
                        bitfield = PersonalSystem.GetPersonalParam(ParamID.MACHINE3);
                        tmno -= 64;
                    }
                    else
                    {
                        bitfield = PersonalSystem.GetPersonalParam(ParamID.MACHINE4);
                        tmno -= 96;
                    }

                    var bit = 1 << (int)(tmno & 0x1F);
                    return (bitfield & bit) != 0;
                }
            }
            else
            {
                GFL.ASSERT(false);
            }

            return false;
        }

        private static void SetupEggParam(CoreParam egg, EggParam egg_param, Parents parents, Setting setting)
        {
            bool validFlag = egg.StartFastMode();

            egg.SetParentName(setting.parentName);
            egg.SetNickName(PersonalSystem.GetMonsName(MonsNo.TAMAGO, (MessageEnumData.MsgLangId)PmlUse.Instance.LangId));

            for (byte i=0; i<egg_param.wazaCount; i++)
            {
                egg.SetWaza(i, egg_param.wazano[i]);
                egg.SetTamagoWazaNo(i, egg_param.wazano[i]);
            }

            egg.SetGetBall(egg_param.ballID);
            egg.SetEggFlag();

            egg.EndFastMode(validFlag);
        }

        private static bool isFormInheritEnableByKawarazuNoIshi(ref ushort pFormNo, CoreParam pParent)
        {
            if (pParent.GetItem() != (ushort)ItemNo.KAWARAZUNOISI)
                return false;

            PersonalSystem.LoadPersonalData(pParent.GetMonsNo(), pParent.GetFormNo());
            pFormNo = (ushort)PersonalSystem.GetPersonalParam(ParamID.EGG_FORM_NO_KAWARAZUNOISHI);
            return PersonalSystem.GetPersonalParam(ParamID.EGG_FORM_INHERIT_KAWARAZUNOISHI) != 0;
        }

        private static MonsNo GetSeedMonsNo(MonsNo monsno, ushort formno)
        {
            return (MonsNo)PersonalSystem.GetPersonalData(monsno, formno).GetParam(ParamID.EGG_MONS_NO);
        }

        public delegate uint SavedRandomFunc(uint maxValue);

        public class Setting
        {
	        public uint IDNo;
            public string parentName;
            public bool haveItem_HIKARUOMAMORI;
            public SavedRandomFunc randFunc;
            public byte realRegionFormNo;
        }
    }
}