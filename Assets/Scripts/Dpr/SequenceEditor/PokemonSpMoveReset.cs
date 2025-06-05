namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonSpMoveReset, "red", "", "")]
	public class PokemonSpMoveReset : Macro
	{
		public SEQ_DEF_POS trg;
		
		public PokemonSpMoveReset(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
        }
    }
}