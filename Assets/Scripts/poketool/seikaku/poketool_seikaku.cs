using Pml.PokePara;

namespace poketool.seikaku
{
    public static class poketool_seikaku
    {
        // TODO: cctor

        private static readonly PowerID[] s_power_priority;
        private static readonly uint[][] s_priority_array;

        // TODO
        public static Seikaku2nd GetSeikaku2nd(CoreParam poke) { return Seikaku2nd.TABERU; }

        // TODO
        private static Seikaku2nd GetSeikaku2nd(uint personalRand, uint talent_hp, uint talent_atk, uint talent_def, uint talent_spatk, uint talent_spdef, uint talent_agi) { return Seikaku2nd.TABERU; }

        // TODO
        public static PowerID GetPowerBySeikaku2nd(Seikaku2nd seikaku2nd) { return PowerID.HP; }

        public enum Seikaku2nd : int
        {
            TABERU = 0,
            HIRUNE = 1,
            INEMURI = 2,
            TIRAKASU = 3,
            NONBIRI = 4,
            TIKARAZIMAN = 5,
            ABARERU = 6,
            OKORIPPOI = 7,
            KENKA = 8,
            TINOKE = 9,
            ZYOUBU = 10,
            UTAREDUYOI = 11,
            NEBARIDUYOI = 12,
            SINBOUDUYOI = 13,
            GAMANDUYOI = 14,
            KAKEKKO = 15,
            MONOOTO = 16,
            OTTYOKOTYOI = 17,
            OTYOUSIMONO = 18,
            NIGERU = 19,
            KOUKISIN = 20,
            ITAZURA = 21,
            NUKEMEGANAI = 22,
            KANGAEGOTO = 23,
            KITYOUMEN = 24,
            KIGATUYOI = 25,
            MIEPPARI = 26,
            MAKENKI = 27,
            MAKEZUGIRAI = 28,
            GOUZYOU = 29,
            NUM = 30,
        }
    }
}
