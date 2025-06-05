namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SpecialDeleteKisekaeAnime, "purple", "one_frame", "")]
	public class SpecialDeleteKisekaeAnime : Macro
	{
		public string file;
		
		public SpecialDeleteKisekaeAnime(Macro macro) : base(macro)
        {
            file = ParseString(macro.GetValue("file"));
        }
    }
}