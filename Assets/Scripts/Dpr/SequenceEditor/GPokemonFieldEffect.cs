namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.GPokemonFieldEffect, "red", "one_frame", "")]
	public class GPokemonFieldEffect : Macro
	{
		public SEQ_DEF_POS trg;
		public bool enable;
		
		public GPokemonFieldEffect(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            enable = ParseBool(macro.GetValue("enable"), 0);
        }
    }
}