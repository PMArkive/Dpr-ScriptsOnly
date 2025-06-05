namespace Dpr.Battle.Logic
{
    public sealed class PokeDesc
    {
        public DefaultPowerUpDesc defaultPowerUpDesc = new DefaultPowerUpDesc();
        public bool isGEnableByNPC;

        // TODO
        public static void Clear(PokeDesc desc) { }

        // TODO
        public static void Copy(PokeDesc dest, in PokeDesc src) { }
    }
}