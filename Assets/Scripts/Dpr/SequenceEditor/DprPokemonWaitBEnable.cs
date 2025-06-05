namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprPokemonWaitBEnable, "red", "one_frame", "")]
	public class DprPokemonWaitBEnable : Macro
	{
		public SEQ_DEF_POS trg;
		public bool enable;
		
		public DprPokemonWaitBEnable(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            enable = ParseBool(macro.GetValue("enable"));
        }
    }
}