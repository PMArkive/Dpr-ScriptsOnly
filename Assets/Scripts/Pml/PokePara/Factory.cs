using Pml.Local;
using Pml.Personal;
using System;

namespace Pml.PokePara
{
    public static class Factory
    {
        public static byte[] CreateCoreData()
        {
            var coreData = AllocCoreData();
            ClearCoreData(coreData);

            return coreData;
        }

        public static byte[] CreateCoreData(MonsNo monsno, ushort level, ulong id)
        {
            return CreateCoreData(new InitialSpec
            {
                monsno = monsno,
                level = level,
                id = id
            });
        }

        public static byte[] CreateCoreData(InitialSpec spec)
        {
            var coreData = AllocCoreData();
            SetupCoreData(coreData, spec);

            return coreData;
        }

        public static void SetupCoreData(byte[] coreData, InitialSpec spec)
        {
            ClearCoreData(coreData);

            var newSpec = new InitialSpec();
            FixInitSpec(newSpec, spec);
            InitCoreData(coreData, newSpec);
        }

        public static byte[] CreateCalcData(uint personalRnd)
        {
            uint size = PokemonParam.DATASIZE - CoreParam.DATASIZE;
            var data = new byte[size];
            
            unsafe
            {
                fixed (byte* ptr = data)
                {
                    Encoder.Encode(ptr, size, personalRnd);
                }
            }

            return data;
        }

        public static PokemonParam CreateNukenin(PokemonParam tutinin)
        {
            var monsno = tutinin.GetMonsNo();
            GFL.ASSERT(monsno == MonsNo.TUTININ || monsno == MonsNo.TEKKANIN);

            var nukenin = new PokemonParam(tutinin);
            nukenin.ChangeMonsNo(MonsNo.NUKENIN, 0);
            nukenin.SetSick(Sick.NONE);
            nukenin.SetItem((ushort)ItemNo.DUMMY_DATA);
            nukenin.SetGetBall((uint)BallId.MONSUTAABOORU);
            nukenin.RemoveAllBoxMark();
            nukenin.RemoveAllRibbon();
            nukenin.SetDefaultNickName();
            nukenin.ClearBankUniqueID();

            return nukenin;
        }

        private static void FixInitSpec(InitialSpec pFixSpec, InitialSpec spec)
        {
            pFixSpec.CopyFrom(spec);

            RandomGenerator random = null;
            if (spec.isRandomSeedEnable)
            {
                random = new RandomGenerator();
                random.Initialize(spec.randomSeed);
            }

            if (pFixSpec.personalRnd == InitialSpec.INIT_SPEC_PERSONALRND_RANDOM)
                pFixSpec.personalRnd = GetRandom(random);

            if (pFixSpec.id == InitialSpec.INIT_SPEC_ID_RANDOM)
                pFixSpec.id = GetRandom(random);

            switch (pFixSpec.rareRnd)
            {
                case InitialSpec.INIT_SPEC_RARE_FALSE:
                    pFixSpec.rareRnd = CalcTool.CorrectColorRndForNormal((uint)pFixSpec.id, GetRandom(random));
                    break;

                case InitialSpec.INIT_SPEC_RARE_TRUE:
                    pFixSpec.rareRnd = CalcTool.CorrectColorRndForRare((uint)pFixSpec.id, GetRandom(random));
                    break;

                case InitialSpec.INIT_SPEC_RARE_RANDOM:
                    for (byte i=0; i<pFixSpec.rareTryCount; i++)
                    {
                        pFixSpec.rareRnd = GetRandom(random);
                        if (CalcTool.IsRareColor((uint)pFixSpec.id, (uint)pFixSpec.rareRnd))
                            break;
                    }
                    break;
            }

            if (pFixSpec.level > PmlConstants.MAX_POKE_LEVEL)
                pFixSpec.level = PmlConstants.MAX_POKE_LEVEL;

            if (pFixSpec.talentVNum != (byte)InitSpec.TALENT_V_NUM_NONE)
            {
                if (pFixSpec.talentVNum > 5)
                {
                    GFL.ASSERT(false);
                    pFixSpec.talentVNum = (byte)InitSpec.TALENT_V_NUM_NONE;
                }

                pFixSpec.talentPower[(int)PowerID.HP] = (ushort)InitSpec.TALENT_RANDOM;
                pFixSpec.talentPower[(int)PowerID.ATK] = (ushort)InitSpec.TALENT_RANDOM;
                pFixSpec.talentPower[(int)PowerID.DEF] = (ushort)InitSpec.TALENT_RANDOM;
                pFixSpec.talentPower[(int)PowerID.SPATK] = (ushort)InitSpec.TALENT_RANDOM;
                pFixSpec.talentPower[(int)PowerID.SPDEF] = (ushort)InitSpec.TALENT_RANDOM;
                pFixSpec.talentPower[(int)PowerID.AGI] = (ushort)InitSpec.TALENT_RANDOM;

                for (byte i=0; i<pFixSpec.talentVNum; i++)
                {
                    uint power;
                    do
                    {
                        power = GetRandom(random, (int)PowerID.NUM);
                    }
                    while (pFixSpec.talentPower[power] != (ushort)InitSpec.TALENT_RANDOM);

                    pFixSpec.talentPower[power] = PmlConstants.MAX_TALENT_POWER;
                }
            }

            if (pFixSpec.talentPower[(int)PowerID.HP] == (ushort)InitSpec.TALENT_RANDOM)
                pFixSpec.talentPower[(int)PowerID.HP] = (ushort)GetRandom(random, PmlConstants.MAX_TALENT_POWER + 1);
            if (pFixSpec.talentPower[(int)PowerID.ATK] == (ushort)InitSpec.TALENT_RANDOM)
                pFixSpec.talentPower[(int)PowerID.ATK] = (ushort)GetRandom(random, PmlConstants.MAX_TALENT_POWER + 1);
            if (pFixSpec.talentPower[(int)PowerID.DEF] == (ushort)InitSpec.TALENT_RANDOM)
                pFixSpec.talentPower[(int)PowerID.DEF] = (ushort)GetRandom(random, PmlConstants.MAX_TALENT_POWER + 1);
            if (pFixSpec.talentPower[(int)PowerID.SPATK] == (ushort)InitSpec.TALENT_RANDOM)
                pFixSpec.talentPower[(int)PowerID.SPATK] = (ushort)GetRandom(random, PmlConstants.MAX_TALENT_POWER + 1);
            if (pFixSpec.talentPower[(int)PowerID.SPDEF] == (ushort)InitSpec.TALENT_RANDOM)
                pFixSpec.talentPower[(int)PowerID.SPDEF] = (ushort)GetRandom(random, PmlConstants.MAX_TALENT_POWER + 1);
            if (pFixSpec.talentPower[(int)PowerID.AGI] == (ushort)InitSpec.TALENT_RANDOM)
                pFixSpec.talentPower[(int)PowerID.AGI] = (ushort)GetRandom(random, PmlConstants.MAX_TALENT_POWER + 1);

            switch (pFixSpec.tokuseiIndex)
            {
                case (byte)InitSpec.TOKUSEI_1_OR_2_OR_3:
                    pFixSpec.tokuseiIndex = (byte)GetRandom(random, 3);
                    break;

                case (byte)InitSpec.TOKUSEI_1_OR_2:
                    pFixSpec.tokuseiIndex = (byte)GetRandom(random, 2);
                    break;
            }

            if (pFixSpec.formno == (ushort)InitSpec.FORM_RANDOM)
                pFixSpec.formno = (ushort)GetRandom(random, PersonalSystem.GetPersonalData(pFixSpec.monsno, 0).GetParam(ParamID.FORM_MAX) & 0xFF);

            if (pFixSpec.sex == (ushort)InitSpec.SEX_BOTH)
                pFixSpec.sex = (ushort)GetSexAtRandomInPersonalDistribution(pFixSpec.monsno, pFixSpec.formno, random);

            pFixSpec.sex = (ushort)CalcTool.GetCorrectSexInPersonalData(pFixSpec.monsno, pFixSpec.formno, (Sex)pFixSpec.sex);

            if (pFixSpec.seikaku == (ushort)InitSpec.SEIKAKU_RANDOM)
                pFixSpec.seikaku = (ushort)GetRandom(random, (uint)Seikaku.NUM);

            if (pFixSpec.friendship == (ushort)InitSpec.FRIENDSHIP_DEFAULT)
                pFixSpec.friendship = PersonalSystem.GetPersonalData(pFixSpec.monsno, 0).GetParam(ParamID.INITIAL_FRIENDSHIP);

            pFixSpec.height = (ushort)GetSizePersonalValue((short)pFixSpec.height, random);
            pFixSpec.weight = (ushort)GetSizePersonalValue((short)pFixSpec.weight, random);
        }

        private static Seikaku getSeikakuAtRandom(RandomGenerator pRandom, MonsNo monsno, ushort formno)
        {
            return (Seikaku)GetRandom(pRandom, (uint)Seikaku.NUM);
        }

        private static Seikaku getHighSeikakuAtRandom(RandomGenerator pRandom)
        {
            var seikakus = CalcTool.GetSeikakuHigh(out byte count);
            return seikakus[GetRandom(pRandom, count)];
        }

        private static Seikaku getLowSeikakuAtRandom(RandomGenerator pRandom)
        {
            var seikakus = CalcTool.GetSeikakuLow(out byte count);
            return seikakus[GetRandom(pRandom, count)];
        }

        private static Sex GetSexAtRandomInPersonalDistribution(MonsNo monsno, ushort formno, RandomGenerator pRandom)
        {
            var sex = PersonalSystem.GetPersonalData(monsno, formno).GetParam(ParamID.SEX);
            switch (sex)
            {
                case (uint)SexVector.ONLY_MALE:
                    return Sex.MALE;

                case (uint)SexVector.ONLY_FEMALE:
                    return Sex.FEMALE;

                case (uint)SexVector.UNKNOWN:
                    return Sex.UNKNOWN;

                default:
                    return GetRandom(pRandom, (uint)SexVector.RANDOM_MAX) + 1 < sex ? Sex.FEMALE : Sex.MALE;
            }
        }

        private static short GetSizePersonalValue(short value, RandomGenerator pRandom)
        {
            if (value < (short)InitSpec.SIZE_RANDOM)
                return value;

            switch (value)
            {
                case (short)InitSpec.SIZE_RANDOM:
                    return (short)(GetRandom(pRandom, 128) + GetRandom(pRandom, 129));

                case (short)InitSpec.SIZE_XS:
                    return (short)(GetRandom(pRandom, 16) + PokemonParamSizeLocal.SIZE_BORDER_XS);

                case (short)InitSpec.SIZE_S:
                    return (short)(GetRandom(pRandom, 32) + PokemonParamSizeLocal.SIZE_BORDER_S);

                case (short)InitSpec.SIZE_M:
                    return (short)(GetRandom(pRandom, 160) + PokemonParamSizeLocal.SIZE_BORDER_M);

                case (short)InitSpec.SIZE_L:
                    return (short)(GetRandom(pRandom, 32) + PokemonParamSizeLocal.SIZE_BORDER_L);

                case (short)InitSpec.SIZE_XL:
                    return (short)(GetRandom(pRandom, 16) + PokemonParamSizeLocal.SIZE_BORDER_XL);

                default:
                    GFL.ASSERT(false);
                    return 128;
            }
        }

        private static byte[] AllocCoreData()
        {
            return new byte[CoreParam.DATASIZE];
        }

        private static void ClearCoreData(byte[] coreData)
        {
            Array.Clear(coreData, 0, coreData.Length);
        }

        private static void InitCoreData(byte[] coreData, InitialSpec spec)
        {
            var accessor = new Accessor();
            accessor.AttachDecodedData(coreData, null);

            if (spec.monsno == MonsNo.NULL)
                return;

            accessor.SetPersonalRnd((uint)spec.personalRnd);
            accessor.SetID((uint)spec.id);
            accessor.SetColorRnd((uint)spec.rareRnd);
            accessor.SetMonsNo((uint)spec.monsno);
            accessor.SetFormNo(spec.formno);
            accessor.SetLevel((byte)spec.level);
            accessor.SetSeikaku(spec.seikaku);
            accessor.SetSeikakuHosei(spec.seikaku);
            accessor.SetSex((Sex)spec.sex);
            accessor.SetGetLevel((byte)spec.level);
            accessor.SetCassetteVersion(0);
            accessor.SetFriendship((byte)spec.friendship);
            accessor.SetLangId((byte)PmlUse.Instance.LangId);
            accessor.SetEquipRibbonNo(PmlConstants.EQUIP_RIBBON_NULL);

            accessor.SetTalentHp((byte)spec.talentPower[(int)PowerID.HP]);
            accessor.SetTalentAtk((byte)spec.talentPower[(int)PowerID.ATK]);
            accessor.SetTalentDef((byte)spec.talentPower[(int)PowerID.DEF]);
            accessor.SetTalentSpAtk((byte)spec.talentPower[(int)PowerID.SPATK]);
            accessor.SetTalentSpDef((byte)spec.talentPower[(int)PowerID.SPDEF]);
            accessor.SetTalentAgi((byte)spec.talentPower[(int)PowerID.AGI]);

            accessor.SetTokuseiNo(CalcTool.GetTokuseiNo(spec.monsno, spec.formno, spec.tokuseiIndex));
            accessor.SetTokusei1Flag(spec.tokuseiIndex == 0);
            accessor.SetTokusei2Flag(spec.tokuseiIndex == 1);
            accessor.SetTokusei3Flag(spec.tokuseiIndex == 2);
            accessor.SetFavoriteFlag(false);
            accessor.SetExp(PersonalSystem.GetGrowTable(spec.monsno, spec.formno).GetMinExp((byte)spec.level));
            accessor.SetTalentHeight((byte)spec.height);
            accessor.SetTalentWeight((byte)spec.weight);
        }

        private static uint GetRandom(RandomGenerator pRandGenerator)
        {
            return pRandGenerator?.GetRand() ?? Local.Random.GetValue();
        }

        private static uint GetRandom(RandomGenerator pRandGenerator, uint max_range)
        {
            return pRandGenerator?.GetRand(max_range) ?? Local.Random.GetValue(max_range);
        }

        public static byte[] AllocFullData()
        {
            return new byte[PokemonParam.DATASIZE];
        }

        public static byte[] CreateFullData()
        {
            var fullData = AllocFullData();
            Accessor.updateChecksumAndEncode_Core(fullData);
            return fullData;
        }
    }
}