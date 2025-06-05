namespace Dpr.Battle.Logic
{
    public static class ActPri
    {
        internal const uint MASK_DOMINANT = 234881024;
        internal const uint MASK_OPERATION = 29360128;
        internal const uint MASK_WAZA = 4128768;
        internal const uint MASK_SP = 57344;
        internal const uint MASK_AGILITY = 8191;

        // TODO
        private static uint GetShiftWidthByMask(uint mask) { return 0; }

        // TODO
        private static uint MakeBitFlag(uint value, uint mask) { return 0; }

        // TODO
        private static uint GetMaskedValue(uint value, uint mask) { return 0; }

        // TODO
        private static uint SetMaskedValue(uint oldValue, uint mask, uint setValue) { return 0; }

        // TODO
        public static uint Make(DominantPriority dominantPri, OperationPriority operationPri, byte wazaPri, byte spPri, ushort agility) { return 0; }

        // TODO
        public static uint ChangeAgility(uint priority, ushort agility) { return 0; }

        // TODO
        public static uint ChangeWazaPriority(uint priority, byte wazaPri) { return 0; }

        // TODO
        public static byte GetWazaPri(uint priority) { return 0; }

        // TODO
        public static byte GetSpPri(uint priority) { return 0; }

        // TODO
        public static OperationPriority GetOperationPri(uint priority) { return OperationPriority.RAIDBOSS_EXTRA_ACTION; }

        // TODO
        public static DominantPriority GetDominantPri(uint priority) { return DominantPriority.RAIDBOSS_ANGRY_WAZA_ON_TURNEND; }

        // TODO
        public static uint SetDominantPri(uint priority, DominantPriority dominantPri) { return 0; }

        // TODO
        public static uint SetSpPri(uint priority, byte spPri) { return 0; }

        // TODO
        public static uint ToHandlerPri(uint priority) { return 0; }

        // TODO
        public static int ToWazaOrgPri(uint priority) { return 0; }
    }
}