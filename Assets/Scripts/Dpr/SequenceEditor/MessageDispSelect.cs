namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.MessageDispSelect, "purple", "one_frame", "")]
	public class MessageDispSelect : Macro
	{
		public string MsgId1;
		public string MsgId2;
		public string MsgId3;
		
		public MessageDispSelect(Macro macro) : base(macro)
        {
            MsgId1 = ParseString(macro.GetValue("MsgId1"));
            MsgId2 = ParseString(macro.GetValue("MsgId2"));
            MsgId3 = ParseString(macro.GetValue("MsgId3"));
        }
    }
}