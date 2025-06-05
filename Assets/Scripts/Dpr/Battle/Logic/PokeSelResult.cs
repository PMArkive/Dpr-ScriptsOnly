namespace Dpr.Battle.Logic
{
    public sealed class PokeSelResult
    {
        private BTL_CLIENT_ID m_myClientID;
        private BTL_CLIENT_ID[] m_selClientID = new BTL_CLIENT_ID[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
        public byte[] m_selIdx = new byte[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
        public byte[] m_outPokeIdx = new byte[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
        private ushort[] m_useItem = new ushort[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
        private byte[] m_wazaIdx = new byte[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
        public byte m_cnt;
        private byte m_max;
        private bool m_fCancel;

        // TODO
        public byte GetSelectMax() { return 0; }

        // TODO
        public void Init(PokeSelParam param) { }

        // TODO
        public void Push(byte outPokeIdx, byte selPokeIdx) { }

        // TODO
        public void Pop() { }

        // TODO
        public void SetCancel(bool flg) { }

        // TODO
        public bool IsCancel() { return false; }

        // TODO
        public bool IsDone() { return false; }

        // TODO
        public byte GetCount() { return 0; }

        // TODO
        public byte GetLast() { return 0; }

        // TODO
        public byte Get(byte idx) { return 0; }

        // TODO
        public void SetItemUse(BTL_CLIENT_ID clientID, byte pokeIdx, ushort itemNo, byte wazaIdx = 0) { }

        // TODO
        public bool IsItemUse(out BTL_CLIENT_ID clientID, out byte pokeIdx, out ushort itemNo, out byte wazaIdx)
        {
            clientID = BTL_CLIENT_ID.BTL_CLIENT_PLAYER;
            pokeIdx = 0;
            itemNo = 0;
            wazaIdx = 0;
            return false;
        }
    }
}