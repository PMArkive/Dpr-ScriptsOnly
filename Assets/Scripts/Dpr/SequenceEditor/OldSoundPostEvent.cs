namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.OldSoundPostEvent, "blue", "one_frame", "")]
	public class OldSoundPostEvent : Macro
	{
		public string @event;
		
		public OldSoundPostEvent(Macro macro) : base(macro)
        {
            @event = ParseString(macro.GetValue("event"));
        }
    }
}