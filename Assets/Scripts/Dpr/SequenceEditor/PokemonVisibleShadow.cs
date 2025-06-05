namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonVisibleShadow, "red", "one_frame", "")]
	public class PokemonVisibleShadow : Macro
	{
		public SEQ_DEF_POS trg;
		public bool visible;
		
		public PokemonVisibleShadow(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            visible = ParseBool(macro.GetValue("visible"), 0);
        }
    }
}