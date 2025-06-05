namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonMoveReset, "red", "", "")]
	public class PokemonMoveReset : Macro
	{
		public SEQ_DEF_POS trg;
		public SEQ_DEF_MOVETYPE move;
		
		public PokemonMoveReset(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}