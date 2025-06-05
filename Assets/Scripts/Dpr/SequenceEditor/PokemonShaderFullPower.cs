namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonShaderFullPower, "red", "", "")]
	public class PokemonShaderFullPower : Macro
	{
		public SEQ_DEF_POS trg;
		public bool isEnable;
		
		public PokemonShaderFullPower(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            isEnable = ParseBool(macro.GetValue("isEnable"), 1);
        }
    }
}