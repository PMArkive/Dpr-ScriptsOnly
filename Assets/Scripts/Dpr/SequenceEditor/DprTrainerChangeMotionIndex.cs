namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprTrainerChangeMotionIndex, "lightyellow", "one_frame", "")]
	public class DprTrainerChangeMotionIndex : Macro
	{
		public SEQ_DEF_TRAINER_ADD trg;
		public SEQ_DEF_TRAINER_MOTION index;
		public float duration;
		public float startTime;
		public bool isLoop;
		
		public DprTrainerChangeMotionIndex(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_TRAINER_ADD(macro.GetValue("trg"));
            index = (SEQ_DEF_TRAINER_MOTION)ParseInt(macro.GetValue("index"));
            duration = ParseFloat(macro.GetValue("duration"));
            startTime = ParseFloat(macro.GetValue("startTime"));
            isLoop = ParseBool(macro.GetValue("isLoop"), 0);
        }
    }
}