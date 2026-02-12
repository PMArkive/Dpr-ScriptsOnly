namespace Dpr.Battle.Logic
{
    public sealed class PokeDesc
    {
        public DefaultPowerUpDesc defaultPowerUpDesc = new DefaultPowerUpDesc();
        public bool isGEnableByNPC;

        public static void Clear(PokeDesc desc)
        {
        	DEFAULT_POWERUP_DESC.Clear(this.defaultPowerUpDesc);
        	this.Length = 0;
        }

        // TODO
        public static void Copy(PokeDesc dest, in PokeDesc src) { }
    }
}