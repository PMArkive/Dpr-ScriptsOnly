namespace Dpr.Battle.Logic
{
    public sealed class WazaRobParam
    {
        public byte robberCount;
        public byte[] robberPokeID = new byte[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
        public BtlPokePos[] targetPos = new BtlPokePos[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
        public byte[] targetPokeID = new byte[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];

        // TODO
        public void Add(byte robberPokeID, byte targetPokeID, BtlPokePos targetPos) { }

        // TODO
        public void CopyFrom(in WazaRobParam src) { }

        // TODO
        public void Clear() { }
    }
}