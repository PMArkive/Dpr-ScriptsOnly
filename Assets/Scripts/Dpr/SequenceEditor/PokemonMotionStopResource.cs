namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonMotionStopResource, "red", "one_frame", "")]
	public class PokemonMotionStopResource : Macro
	{
		public SEQ_DEF_POS trg;
		public int slot;
		
		public PokemonMotionStopResource(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            slot = ParseInt(macro.GetValue("slot"), 0);
        }
    }
}