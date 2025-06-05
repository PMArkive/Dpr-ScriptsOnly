namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ModelVisible, "pink", "one_frame", "")]
	public class ModelVisible : Macro
	{
		public bool visible;
		
		public ModelVisible(Macro macro) : base(macro)
        {
            visible = ParseBool(macro.GetValue("visible"), 0);
        }
    }
}