namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonHappyMotion, "red", "one_frame", "")]
	public class PokemonHappyMotion : Macro
	{
		public SEQ_DEF_POS trg;
		
		public PokemonHappyMotion(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
        }
    }
}