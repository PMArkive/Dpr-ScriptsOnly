namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.MessageDispStd, "purple", "one_frame", "")]
	public class MessageDispStd : Macro
	{
		public int MsgId;
		public int option;
		public bool autoHide;
		
		// TODO
		public MessageDispStd(Macro macro) : base(macro)
        {
            MsgId = ParseInt(macro.GetValue("MsgId"));
            option = ParseInt(macro.GetValue("option"));
            autoHide = ParseBool(macro.GetValue("autoHide"), 0);
        }
    }
}