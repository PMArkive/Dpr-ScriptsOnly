namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.Old3DSoundPostTrigger, "blue", "one_frame", "")]
	public class Old3DSoundPostTrigger : Macro
	{
		public string trigger;
		
		public Old3DSoundPostTrigger(Macro macro) : base(macro)
        {
            trigger = ParseString(macro.GetValue("trigger"));
        }
    }
}