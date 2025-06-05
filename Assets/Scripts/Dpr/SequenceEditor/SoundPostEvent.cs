namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SoundPostEvent, "blue", "one_frame", "")]
	public class SoundPostEvent : Macro
	{
		public string @event;
		public bool isAttrEffect;
		
		public SoundPostEvent(Macro macro) : base(macro)
        {
            @event = ParseString(macro.GetValue("event"));
            isAttrEffect = ParseBool(macro.GetValue("isAttrEffect"));
        }
    }
}