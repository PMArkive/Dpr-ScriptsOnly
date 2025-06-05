namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ContestPokemonMoveReset, "orange", "", "")]
	public class ContestPokemonMoveReset : Macro
	{
		public SEQ_DEF_POS trg;
		public SEQ_DEF_MOVETYPE move;
		
		// TODO
		public ContestPokemonMoveReset(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}