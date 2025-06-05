namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonVisibleOther, "red", "one_frame", "")]
	public class PokemonVisibleOther : Macro
	{
		public bool visible;
		
		public PokemonVisibleOther(Macro macro) : base(macro)
        {
            visible = ParseBool(macro.GetValue("visible"), 0);
        }
    }
}