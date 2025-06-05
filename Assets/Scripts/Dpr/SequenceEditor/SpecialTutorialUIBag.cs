namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SpecialTutorialUIBag, "purple", "one_frame", "")]
	public class SpecialTutorialUIBag : Macro
	{
		public bool visible;
		
		public SpecialTutorialUIBag(Macro macro) : base(macro)
        {
            visible = ParseBool(macro.GetValue("visible"), 0);
        }
    }
}