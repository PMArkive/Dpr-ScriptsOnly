namespace Nintendo.MessageStudio.Lib
{
    public struct LMSFlowNodeData
    {
        public LMSFlowNodeType NodeType;
        public LMSFlowParamType ParamType;
        public ushort Reserved;
        public uint ParamValue;
        public ushort Rawdata0;
        public ushort Rawdata1;
        public ushort Rawdata2;
        public ushort Rawdata3;
        public LMSFlowEntry Entry;
        public LMSFlowMessage Message;
        public LMSFlowBranch Branch;
        public LMSFlowEvent Event;
        public LMSFlowJump Jump;
    }
}