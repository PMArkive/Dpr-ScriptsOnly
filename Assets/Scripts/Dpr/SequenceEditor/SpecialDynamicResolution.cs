namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SpecialDynamicResolution, "purple", "", "")]
	public class SpecialDynamicResolution : Macro
	{
		public bool enable;
		
		public SpecialDynamicResolution(Macro macro) : base(macro)
        {
            enable = ParseBool(macro.GetValue("enable"), 1);
        }
    }
}