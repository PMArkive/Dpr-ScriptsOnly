namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.MessageDispSFes, "purple", "one_frame", "")]
	public class MessageDispSFes : Macro
	{
		public int option;
		
		public MessageDispSFes(Macro macro) : base(macro)
        {
            option = ParseInt(macro.GetValue("option"));
        }
    }
}