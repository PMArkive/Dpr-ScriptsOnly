namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SoundPostTrigger, "blue", "one_frame", "")]
	public class SoundPostTrigger : Macro
	{
		public string trigger;
		
		public SoundPostTrigger(Macro macro) : base(macro)
        {
            trigger = ParseString(macro.GetValue("trigger"));
        }
    }
}