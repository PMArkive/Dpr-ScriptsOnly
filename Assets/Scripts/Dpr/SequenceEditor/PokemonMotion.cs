namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonMotion, "red", "one_frame", "")]
	public class PokemonMotion : Macro
	{
		public SEQ_DEF_POS trg;
		public SEQ_DEF_MOTION motion;
		
		public PokemonMotion(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            motion = Parse_SEQ_DEF_MOTION(macro.GetValue("motion"));
        }
    }
}