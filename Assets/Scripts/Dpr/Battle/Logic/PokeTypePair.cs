namespace Dpr.Battle.Logic
{
    public struct PokeTypePair
    {
        public ushort value;

        public PokeTypePair(ushort value)
        {
            this.value = value;
        }

        // TODO
        public static PokeTypePair Make(byte type1, byte type2, byte type_ex) { return default; }

        // TODO
        public static PokeTypePair MakePure(byte type) { return default; }

        // TODO
        public static byte GetType1(PokeTypePair pair) { return 0; }

        // TODO
        public static byte GetType2(PokeTypePair pair) { return 0; }

        // TODO
        public static byte GetTypeEx(PokeTypePair pair) { return 0; }

        // TODO
        public static void Split(PokeTypePair pair, out byte type1, out byte type2, out byte typeEx)
        {
            type1 = 0;
            type2 = 0;
            typeEx = 0;
        }

        // TODO
        public static bool IsMatch(PokeTypePair pair, byte type) { return false; }

        // TODO
        public static bool IsPure(PokeTypePair pair, bool includeExType = true) { return false; }

        // TODO
        public static PokeTypePair Replace(PokeTypePair pair, byte targetType, byte newType) { return default; }

        // TODO
        public static bool IsAnyTypeExist(PokeTypePair pair) { return false; }

        public static implicit operator ushort(PokeTypePair pair)
        {
            return pair.value;
        }

        public static explicit operator PokeTypePair(ushort value)
        {
            return new PokeTypePair(value);
        }
    }
}