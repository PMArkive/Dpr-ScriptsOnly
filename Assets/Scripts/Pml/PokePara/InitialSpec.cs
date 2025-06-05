using System;

namespace Pml.PokePara
{
    public class InitialSpec
    {
        public const ulong INIT_SPEC_ID_RANDOM = 0xFFFFFFFFFFFFFFFF;
        public const ulong INIT_SPEC_PERSONALRND_RANDOM = 0xFFFFFFFFFFFFFFFF;
        public const ulong INIT_SPEC_RARE_FALSE = 0x1FFFFFFFF;
        public const ulong INIT_SPEC_RARE_TRUE = 0x2FFFFFFFF;
        public const ulong INIT_SPEC_RARE_RANDOM = 0x3FFFFFFFF;
        public ulong randomSeed;
        public bool isRandomSeedEnable;
        public ulong personalRnd;
        public ulong rareRnd;
        public ulong id;
        public MonsNo monsno;
        public ushort formno;
        public ushort level;
        public ushort sex;
        public ushort seikaku;
        public byte tokuseiIndex;
        public byte rareTryCount;
        public ushort[] talentPower;
        public uint friendship;
        public byte talentVNum;
        public ushort weight;
        public ushort height;

        public InitialSpec()
        {
            id = INIT_SPEC_ID_RANDOM;
            personalRnd = INIT_SPEC_PERSONALRND_RANDOM;
            rareRnd = INIT_SPEC_RARE_RANDOM;
            monsno = MonsNo.TAMAGO;
            formno = 0;
            level = 1;
            sex = (ushort)InitSpec.SEX_BOTH;
            seikaku = (ushort)InitSpec.SEIKAKU_RANDOM;
            tokuseiIndex = (byte)InitSpec.TOKUSEI_1_OR_2;
            rareTryCount = (byte)InitSpec.RARE_TRY_COUNT_DEFAULT;
            randomSeed = 0;
            isRandomSeedEnable = false;
            weight = (ushort)InitSpec.SIZE_RANDOM;
            height = (ushort)InitSpec.SIZE_RANDOM;
            friendship = (uint)InitSpec.FRIENDSHIP_DEFAULT;
            talentVNum = (byte)InitSpec.TALENT_V_NUM_NONE;
            talentPower = new ushort[6];
            for (int i=0; i<6; i++)
                talentPower[i] = (ushort)InitSpec.TALENT_RANDOM;
        }

        public void CopyFrom(InitialSpec src)
        {
            randomSeed = src.randomSeed;
            isRandomSeedEnable = src.isRandomSeedEnable;
            personalRnd = src.personalRnd;
            personalRnd = src.personalRnd; // Duplicated in the code
            rareRnd = src.rareRnd;
            id = src.id;
            monsno = src.monsno;
            formno = src.formno;
            level = src.level;
            sex = src.sex;
            seikaku = src.seikaku;
            tokuseiIndex = src.tokuseiIndex;
            rareTryCount = src.rareTryCount;

            Array.Copy(src.talentPower, talentPower, src.talentPower.Length);

            friendship = src.friendship;
            talentVNum = src.talentVNum;
            weight = src.weight;
            height = src.height;
        }
    }
}