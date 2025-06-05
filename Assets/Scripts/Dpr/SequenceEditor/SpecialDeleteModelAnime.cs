namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SpecialDeleteModelAnime, "purple", "one_frame", "")]
	public class SpecialDeleteModelAnime : Macro
	{
		public string file;
		
		public SpecialDeleteModelAnime(Macro macro) : base(macro)
        {
            file = ParseString(macro.GetValue("file"));
        }
    }
}