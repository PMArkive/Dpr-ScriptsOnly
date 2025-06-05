namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonSetAnimationConfig, "red", "one_frame", "PreloadPokemonAnimationConfig")]
	public class PokemonSetAnimationConfig : Macro
	{
		public SEQ_DEF_POS trg;
		public string cfgfile;
		public string pakfile;
		
		public PokemonSetAnimationConfig(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            cfgfile = ParseString(macro.GetValue("cfgfile"));
            pakfile = ParseString(macro.GetValue("pakfile"));
        }
    }
}