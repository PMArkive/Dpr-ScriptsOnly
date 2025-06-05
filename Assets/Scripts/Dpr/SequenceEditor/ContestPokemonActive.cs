namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ContestPokemonActive, "orange", "one_frame", "")]
	public class ContestPokemonActive : Macro
	{
		public SEQ_DEF_POS trg;
		public bool active;
		
		public ContestPokemonActive(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            active = ParseBool(macro.GetValue("active"), 1);
        }
    }
}