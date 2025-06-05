namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonVisible, "red", "one_frame", "")]
	public class PokemonVisible : Macro
	{
		public SEQ_DEF_POS trg;
		public bool visible;
		
		public PokemonVisible(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            visible = ParseBool(macro.GetValue("visible"), 0);
        }
    }
}