namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffDispBg, "lightgreen", "one_frame", "")]
	public class EffDispBg : Macro
	{
		public bool isDisp;
		public bool maskLink;
		
		public EffDispBg(Macro macro) : base(macro)
        {
            isDisp = ParseBool(macro.GetValue("isDisp"));
            maskLink = ParseBool(macro.GetValue("maskLink"), 1);
        }
    }
}