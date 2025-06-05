namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonSetEye, "red", "", "")]
	public class PokemonSetEye : Macro
	{
		public SEQ_DEF_POS trg;
		public SEQ_DEF_GPOKE_EFFECT type;
		public bool pokeGroup;
		
		public PokemonSetEye(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            type = Parse_SEQ_DEF_GPOKE_EFFECT(macro.GetValue("type"));
            pokeGroup = ParseBool(macro.GetValue("pokeGroup"), 0);
        }
    }
}