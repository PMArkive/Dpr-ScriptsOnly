namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprPokemonVisibleOther, "red", "one_frame", "")]
	public class DprPokemonVisibleOther : Macro
	{
		public int trg;
		public bool visible;
		
		public DprPokemonVisibleOther(Macro macro) : base(macro)
        {
            trg = ParseInt(macro.GetValue("trg"), 0);
            visible = ParseBool(macro.GetValue("visible"));
        }
    }
}