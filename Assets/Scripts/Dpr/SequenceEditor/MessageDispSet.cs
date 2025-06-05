namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.MessageDispSet, "purple", "one_frame", "")]
	public class MessageDispSet : Macro
	{
		public int MsgId;
		public int option;
		
		public MessageDispSet(Macro macro) : base(macro)
        {
            MsgId = ParseInt(macro.GetValue("MsgId"));
            option = ParseInt(macro.GetValue("option"));
        }
    }
}