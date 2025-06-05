namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SpecialPokemonRenderVisible, "purple", "", "")]
	public class SpecialPokemonRenderVisible : Macro
	{
		public SEQ_DEF_RENDERER_TYPE trgRender;
		public SEQ_DEF_POS trgPoke;
		public bool model;
		public bool shadow;
		
		public SpecialPokemonRenderVisible(Macro macro) : base(macro)
        {
            trgRender = Parse_SEQ_DEF_RENDERER_TYPE(macro.GetValue("trgRender"));
            trgPoke = Parse_SEQ_DEF_POS(macro.GetValue("trgPoke"));
            model = ParseBool(macro.GetValue("model"), 0);
            shadow = ParseBool(macro.GetValue("shadow"), 0);
        }
    }
}