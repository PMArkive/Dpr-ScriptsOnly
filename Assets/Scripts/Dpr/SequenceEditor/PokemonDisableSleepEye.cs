namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonDisableSleepEye, "red", "", "")]
	public class PokemonDisableSleepEye : Macro
	{
		public SEQ_DEF_POS trg;
		public bool disable;
		
		public PokemonDisableSleepEye(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            disable = ParseBool(macro.GetValue("disable"), 1);
        }
    }
}