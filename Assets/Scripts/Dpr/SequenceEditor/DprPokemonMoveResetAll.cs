namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprPokemonMoveResetAll, "red", "one_frame", "")]
	public class DprPokemonMoveResetAll : Macro
	{
		public SEQ_DEF_DEFAULT_PLACEMENT place;
		
		public DprPokemonMoveResetAll(Macro macro) : base(macro)
        {
            place = Parse_SEQ_DEF_DEFAULT_PLACEMENT(macro.GetValue("place"));
        }
    }
}