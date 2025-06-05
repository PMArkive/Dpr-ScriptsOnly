namespace Dpr.SequenceEditor
{
	[Macro(CommandNo.BelugaSoundAddEvent, "blue", "one_frame", "")]
	public class BelugaSoundAddEvent : Macro
	{
		public string @event;
		
		public BelugaSoundAddEvent(Macro macro) : base(macro)
        {
			@event = ParseString(macro.GetValue("event"));
		}
	}
}