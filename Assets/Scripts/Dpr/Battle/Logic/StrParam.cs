namespace Dpr.Battle.Logic
{
    public sealed class StrParam
    {
        private Param m_param;

        // TODO
        public StrParam() { }

        // TODO
        public StrParam(in StrParam src) { }

        // TODO
        public void CopyFrom(in StrParam src) { }

        // TODO
        public void Clear() { }

        // TODO
        public bool IsEnable() { return false; }

        // TODO
        public void Setup(BtlStrType type, ushort strID) { }

        // TODO
        public ushort GetStrID() { return 0; }

        // TODO
        public BtlStrType GetStrType() { return BtlStrType.BTL_STRTYPE_NULL; }

        // TODO
        public void AddArg(int arg) { }

        // TODO
        public void ChangeArg(byte index, int value) { }

        // TODO
        public ushort GetArgsCount() { return 0; }

        // TODO
        public int[] GetArgs() { return null; }

        // TODO
        public void AddSE(uint SENo) { }

        // TODO
        public bool IsSEAdded() { return false; }

        // TODO
        public int GetSE() { return 0; }

        // TODO
        public void SetFailMsgFlag() { }

        // TODO
        public bool IsFailMsg() { return false; }

        private class Param
        {
            public ushort ID;
            public ushort type;
            public ushort argCnt;
            public bool fSEAdd;
            public bool fFailMsg;
            public int[] args;

            // TODO
            public void CopyFrom(Param src) { }

            // TODO
            public void Clear() { }

            // TODO
            public Param() { }
        }
    }
}