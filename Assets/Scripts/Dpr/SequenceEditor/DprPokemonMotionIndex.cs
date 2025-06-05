namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprPokemonMotionIndex, "red", "one_frame", "")]
	public class DprPokemonMotionIndex : Macro
	{
		public SEQ_DEF_POS trg;
		public SEQ_DEF_POKE_MOTION index;
		public float duration;
		public float startTime;
		
		public DprPokemonMotionIndex(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            index = (SEQ_DEF_POKE_MOTION)ParseInt(macro.GetValue("index"));
            duration = ParseFloat(macro.GetValue("duration"));
            startTime = ParseFloat(macro.GetValue("startTime"));
        }
    }
}