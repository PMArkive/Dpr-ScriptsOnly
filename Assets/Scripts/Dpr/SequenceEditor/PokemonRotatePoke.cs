namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonRotatePoke, "red", "", "")]
	public class PokemonRotatePoke : Macro
	{
		public SEQ_DEF_POS trgPoke;
		public SEQ_DEF_POS dirPoke;
		public SEQ_DEF_NODE node;
		public float ofs;
		public SEQ_DEF_MOVETYPE move;
		
		public PokemonRotatePoke(Macro macro) : base(macro)
        {
            trgPoke = Parse_SEQ_DEF_POS(macro.GetValue("trgPoke"));
            dirPoke = Parse_SEQ_DEF_POS(macro.GetValue("dirPoke"));
            node = Parse_SEQ_DEF_NODE(macro.GetValue("node"));
            ofs = ParseFloat(macro.GetValue("ofs"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}