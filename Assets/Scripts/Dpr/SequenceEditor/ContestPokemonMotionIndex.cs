namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ContestPokemonMotionIndex, "orange", "one_frame", "")]
	public class ContestPokemonMotionIndex : Macro
	{
		public SEQ_DEF_POS trg;
		public SEQ_DEF_POKE_MOTION index;
		public float duration;
		public float startTime;
		public bool isLoop;
		
		public ContestPokemonMotionIndex(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            index = (SEQ_DEF_POKE_MOTION)ParseInt(macro.GetValue("index"));
            duration = ParseFloat(macro.GetValue("duration"));
            startTime = ParseFloat(macro.GetValue("startTime"));
            isLoop = ParseBool(macro.GetValue("isLoop"), 0);
        }
    }
}