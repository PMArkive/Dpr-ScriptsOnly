namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.GPokemonIntroMotion, "red", "one_frame", "PreloadGPokemonIntro")]
	public class GPokemonIntroMotion : Macro
	{
		public SEQ_DEF_POS trg;
		public int landSpeed;
		public int roraEffCnt;
		
		public GPokemonIntroMotion(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            landSpeed = ParseInt(macro.GetValue("landSpeed"), 5);
            roraEffCnt = ParseInt(macro.GetValue("roraEffCnt"), 36);
        }
    }
}