namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SpecialDeleteModel, "purple", "one_frame", "")]
	public class SpecialDeleteModel : Macro
	{
		public string file;
		
		public SpecialDeleteModel(Macro macro) : base(macro)
        {
            file = ParseString(macro.GetValue("file"));
        }
    }
}