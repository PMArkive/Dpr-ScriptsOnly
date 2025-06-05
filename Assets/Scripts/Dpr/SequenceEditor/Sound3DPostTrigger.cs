namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.Sound3DPostTrigger, "blue", "one_frame", "")]
	public class Sound3DPostTrigger : Macro
	{
		public string trigger;
		
		public Sound3DPostTrigger(Macro macro) : base(macro)
        {
            trigger = ParseString(macro.GetValue("trigger"));
        }
    }
}