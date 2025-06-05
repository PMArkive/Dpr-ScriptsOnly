namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ContestPokemonSpMoveReset, "orange", "", "")]
	public class ContestPokemonSpMoveReset : Macro
	{
		public SEQ_DEF_POS trg;
		
		public ContestPokemonSpMoveReset(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
        }
    }
}