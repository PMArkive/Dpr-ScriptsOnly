namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonIntroMotion, "red", "one_frame", "PreloadPokemonIntro")]
	public class PokemonIntroMotion : Macro
	{
		public SEQ_DEF_POS trg;
		public float height;
		public SEQ_DEF_DEFAULT_PLACEMENT place;
		
		public PokemonIntroMotion(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            height = ParseFloat(macro.GetValue("height"), 100.0f);
            place = Parse_SEQ_DEF_DEFAULT_PLACEMENT(macro.GetValue("place"));
        }
    }
}