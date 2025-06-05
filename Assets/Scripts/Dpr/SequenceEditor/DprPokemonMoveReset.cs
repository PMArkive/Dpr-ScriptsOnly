namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprPokemonMoveReset, "red", "one_frame", "")]
	public class DprPokemonMoveReset : Macro
	{
		public SEQ_DEF_POS trg;
		public SEQ_DEF_DEFAULT_PLACEMENT place;
		
		public DprPokemonMoveReset(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            place = Parse_SEQ_DEF_DEFAULT_PLACEMENT(macro.GetValue("place"));
        }
    }
}