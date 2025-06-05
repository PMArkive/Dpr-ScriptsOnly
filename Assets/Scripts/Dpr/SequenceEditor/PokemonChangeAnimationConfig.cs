namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonChangeAnimationConfig, "red", "one_frame", "")]
	public class PokemonChangeAnimationConfig : Macro
	{
		public SEQ_DEF_POS trg;
		public SEQ_DEF_ANIMCONF type;
		
		public PokemonChangeAnimationConfig(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            type = Parse_SEQ_DEF_ANIMCONF(macro.GetValue("type"));
        }
    }
}