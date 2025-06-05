namespace Pml.PokePara
{
    public class EggParam
    {
        public InitialSpec spec;
        public uint wazaCount;
        public WazaNo[] wazano = new WazaNo[PmlConstants.MAX_WAZA_NUM];
        public uint ballID;
        public bool[] isTalentDerivedFromFather = new bool[(int)PowerID.NUM];
        public bool[] isTalentDerivedFromMother = new bool[(int)PowerID.NUM];
        public uint derivedTalentCount;
        public uint totalDeriveTalentCount;

        public EggParam()
        {
            spec = new InitialSpec();
            wazaCount = 0;
            ballID = (uint)BallId.NULL;
            derivedTalentCount = 0;
            totalDeriveTalentCount = 0;

            for (int i=0; i<wazano.Length; i++)
                wazano[i] = WazaNo.NULL;

            for (int i=0; i<isTalentDerivedFromFather.Length; i++)
                isTalentDerivedFromFather[i] = false;

            for (int i=0; i<isTalentDerivedFromMother.Length; i++)
                isTalentDerivedFromMother[i] = false;
        }
    }
}