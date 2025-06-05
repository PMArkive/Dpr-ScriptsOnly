namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonReplaceAnimationConfig, "red", "one_frame", "PreloadPokemonAnimationConfigReplace")]
	public class PokemonReplaceAnimationConfig : Macro
	{
		public SEQ_DEF_POS trg;
		public string cfgfile;
		public string pakfile;
		
		public PokemonReplaceAnimationConfig(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            cfgfile = ParseString(macro.GetValue("cfgfile"));
            pakfile = ParseString(macro.GetValue("pakfile"));
        }
    }
}