namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.Old3DSoundPostEvent, "blue", "one_frame", "")]
	public class Old3DSoundPostEvent : Macro
	{
		public string @event;
		
		public Old3DSoundPostEvent(Macro macro) : base(macro)
        {
            @event = ParseString(macro.GetValue("event"));
        }
    }
}