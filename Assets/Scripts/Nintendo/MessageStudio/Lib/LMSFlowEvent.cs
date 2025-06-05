namespace Nintendo.MessageStudio.Lib
{
    public struct LMSFlowEvent
    {
        public ushort NextNodeIndex;
        public ushort EventID;
        public ushort[] Reserved;
    }
}