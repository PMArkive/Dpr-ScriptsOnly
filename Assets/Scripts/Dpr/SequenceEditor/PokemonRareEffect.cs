namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonRareEffect, "red", "one_frame", "")]
	public class PokemonRareEffect : Macro
	{
		public SEQ_DEF_POS trg;
		
		public PokemonRareEffect(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
        }
    }
}