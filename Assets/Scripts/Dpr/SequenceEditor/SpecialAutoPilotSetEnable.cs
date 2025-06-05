namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SpecialAutoPilotSetEnable, "purple", "", "")]
	public class SpecialAutoPilotSetEnable : Macro
	{
		public bool visible;
		
		public SpecialAutoPilotSetEnable(Macro macro) : base(macro)
        {
            visible = ParseBool(macro.GetValue("visible"), 0);
        }
    }
}