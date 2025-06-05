namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonMoveResetAll, "red", "", "")]
	public class PokemonMoveResetAll : Macro
	{
		public SEQ_DEF_MOVETYPE move;
		
		public PokemonMoveResetAll(Macro macro) : base(macro)
        {
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}