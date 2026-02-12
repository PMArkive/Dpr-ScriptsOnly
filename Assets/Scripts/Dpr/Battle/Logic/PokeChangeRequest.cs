namespace Dpr.Battle.Logic
{
    public sealed class PokeChangeRequest
    {
        private readonly MainModule m_pMainModule;
        private BtlPokePos[] m_requestPos = new BtlPokePos[5];
        private byte m_requestCount;

        public PokeChangeRequest(MainModule pMainModule)
        {
            m_pMainModule = pMainModule;
            m_requestCount = 0;
        }

        public void Clear()
        {
        	this[0] = 0;
        }

        // TODO
        public void Request(BtlPokePos pos) { }

        // TODO
        public void RequestEmptyPos(in PosPoke posPoke) { }

        // TODO
        private void addRequest(BtlPokePos pos) { }

        // TODO
        public bool IsExist() { return false; }

        // TODO
        public bool IsExist(BTL_CLIENT_ID clientID) { return false; }

        // TODO
        public byte GetCount() { return 0; }

        // TODO
        public byte GetCount(BTL_CLIENT_ID clientID) { return 0; }

        public BtlPokePos GetRequestPos(byte index)
        {
        	if (this[0] <= index) {
        	  return (BtlPokePos)5;
        	}
        	if ((uint)index < this.Length.Length) {
        	  return this.Length + (ulong)index[0];
        	}
        }
    }
}