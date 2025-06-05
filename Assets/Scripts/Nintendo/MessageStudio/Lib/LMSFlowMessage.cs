namespace Nintendo.MessageStudio.Lib
{
    public struct LMSFlowMessage
    {
        public ushort NextNodeIndex;
        public ushort FileIndex;
        public ushort TextIndex;
        public ushort Reserved;
    }
}