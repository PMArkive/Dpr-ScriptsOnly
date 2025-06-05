namespace Dpr.Battle.Logic
{
    public class WazaEffectReservedPos
    {
        public ushort prevEffectCmd;
        public ushort mainEffectCmd;
        private const ushort INVALID_VALUE = 65535;

        public void CopyFrom(WazaEffectReservedPos src)
        {
            prevEffectCmd = src.prevEffectCmd;
            mainEffectCmd = src.mainEffectCmd;
        }

        public WazaEffectReservedPos()
        {
            prevEffectCmd = INVALID_VALUE;
            mainEffectCmd = INVALID_VALUE;
        }

        public bool IsValid()
        {
            return mainEffectCmd != INVALID_VALUE;
        }

        // TODO
        public void Reserve(ServerCommandQueue queue) { }
    }
}