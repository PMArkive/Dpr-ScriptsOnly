namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonSetOriginScale, "red", "", "")]
	public class PokemonSetOriginScale : Macro
	{
		public SEQ_DEF_POS trg;
		
		public PokemonSetOriginScale(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
        }
    }
}