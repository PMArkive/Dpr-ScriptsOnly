namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.OldSoundLoadBank, "blue", "one_frame", "PreloadSoundBank")]
	public class OldSoundLoadBank : SoundLoadBank
	{
		public string @event;
		
		public OldSoundLoadBank(Macro macro) : base(macro)
        {
            @event = ParseString(macro.GetValue("event"));
        }
    }
}