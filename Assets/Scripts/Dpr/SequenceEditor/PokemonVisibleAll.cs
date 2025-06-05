namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonVisibleAll, "red", "one_frame", "")]
	public class PokemonVisibleAll : Macro
	{
		public bool visible;
		
		public PokemonVisibleAll(Macro macro) : base(macro)
        {
            visible = ParseBool(macro.GetValue("visible"), 0);
        }
    }
}