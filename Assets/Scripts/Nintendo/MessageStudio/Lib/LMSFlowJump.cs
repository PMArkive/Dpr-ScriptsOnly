namespace Nintendo.MessageStudio.Lib
{
    public struct LMSFlowJump
    {
        public ushort NextNodeIndex;
        public ushort FileIndex;
        public ushort[] Reserved;
    }
}