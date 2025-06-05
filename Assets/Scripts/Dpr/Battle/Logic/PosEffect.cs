namespace Dpr.Battle.Logic
{
    public sealed class PosEffect
    {
        // TODO: cctor

        public const int POSEFF_PARAM_MAX = 4;
        private static readonly EffectParamType[] ParamTypeTable;

        // TODO
        public static EffectParamType GetEffectParamType(BtlPosEffect posEffect) { return EffectParamType.PARAM_TYPE_NONE; }

        // TODO
        public PosEffect() { }

        public enum EffectParamType : int
        {
            PARAM_TYPE_NONE = 0,
            PARAM_TYPE_DELAY_ATTACK = 1,
            PARAM_TYPE_DELAY_RECOVER = 2,
        }

        public struct EffectParam
        {
            private const int sz0 = 16;
            private const int loc0 = 0;
            private const int mask0 = 65535;
            private const int sz1 = 4;
            private const int loc1 = 16;
            private const int mask1 = 983040;
            private const int sz2 = 4;
            private const int loc2 = 20;
            private const int mask2 = 15728640;
            private const int sz3 = 8;
            private const int loc3 = 24;
            private const int mask3 = -16777216;
            private int raw;

            // TODO
            public uint Raw_param1 { get; set; }
            public ushort DelayAttack_wazaNo { get; set; }
            public byte DelayAttack_execTurnMax { get; set; }
            public byte DelayAttack_execTurnCount { get; set; }
        }
    }
}