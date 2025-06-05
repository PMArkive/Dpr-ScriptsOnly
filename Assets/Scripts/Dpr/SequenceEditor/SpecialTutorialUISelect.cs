namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SpecialTutorialUISelect, "purple", "one_frame", "")]
	public class SpecialTutorialUISelect : Macro
	{
		public bool visible;
		
		public SpecialTutorialUISelect(Macro macro) : base(macro)
        {
            visible = ParseBool(macro.GetValue("visible"), 0);
        }
    }
}