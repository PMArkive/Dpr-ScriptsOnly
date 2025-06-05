namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonSetEnableFloat, "red", "one_frame", "")]
	public class PokemonSetEnableFloat : Macro
	{
		public SEQ_DEF_POS trg;
		public bool enable;
		public bool visible;
		
		public PokemonSetEnableFloat(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            enable = ParseBool(macro.GetValue("enable"), 1);
            visible = ParseBool(macro.GetValue("visible"), 0);
        }
    }
}