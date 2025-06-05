namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SoundLoadBank, "blue", "one_frame", "PreloadSoundBank")]
	public class SoundLoadBank : Macro
	{
		public string @event;
		
		public SoundLoadBank(Macro macro) : base(macro)
        {
            @event = ParseString(macro.GetValue("event"));
        }
    }
}