namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.Sound3DPostEvent, "blue", "one_frame", "")]
	public class Sound3DPostEvent : Macro
	{
		public string @event;
		
		public Sound3DPostEvent(Macro macro) : base(macro)
        {
            @event = ParseString(macro.GetValue("event"));
        }
    }
}