namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.MessageDispTalk, "purple", "one_frame", "")]
	public class MessageDispTalk : Macro
	{
		public string MsgId;
		public bool isKeyWait;
		public SEQ_DEF_WINDOW_TYPE type;
		
		public MessageDispTalk(Macro macro) : base(macro)
        {
            MsgId = ParseString(macro.GetValue("MsgId"));
            isKeyWait = ParseBool(macro.GetValue("isKeyWait"), 0);
            type = Parse_SEQ_DEF_WINDOW_TYPE(macro.GetValue("type"));
        }
    }
}