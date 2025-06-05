namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SpecialAutoPilotTrigger, "purple", "one_frame", "")]
	public class SpecialAutoPilotTrigger : Macro
	{
		public SEQ_DEF_INPUT button;
		
		public SpecialAutoPilotTrigger(Macro macro) : base(macro)
        {
            button = Parse_SEQ_DEF_INPUT(macro.GetValue("button"));
        }
    }
}