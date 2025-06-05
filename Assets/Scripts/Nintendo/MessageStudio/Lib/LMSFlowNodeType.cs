namespace Nintendo.MessageStudio.Lib
{
    public enum LMSFlowNodeType : byte
    {
        Invalid = 0,
        Message = 1,
        Branch = 2,
        Event = 3,
        Entry = 4,
        Jump = 5,
    }
}