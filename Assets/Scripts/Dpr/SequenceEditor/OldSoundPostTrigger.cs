namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.OldSoundPostTrigger, "blue", "one_frame", "")]
	public class OldSoundPostTrigger : Macro
	{
		public string trigger;
		
		public OldSoundPostTrigger(Macro macro) : base(macro)
        {
            trigger = ParseString(macro.GetValue("trigger"));
        }
    }
}