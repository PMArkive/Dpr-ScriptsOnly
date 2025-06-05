namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonEdgeEnable, "red", "one_frame", "")]
	public class PokemonEdgeEnable : Macro
	{
		public SEQ_DEF_POS trg;
		public bool visible;
		
		public PokemonEdgeEnable(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            visible = ParseBool(macro.GetValue("visible"), 0);
        }
    }
}