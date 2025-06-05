namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprTrainerChangeMotionThrowBall, "lightyellow", "one_frame", "")]
	public class DprTrainerChangeMotionThrowBall : Macro
	{
		public SEQ_DEF_TRAINER_ADD trg;
		public float duration;
		public SEQ_DEF_TRAINER_MOTION_THROW_BALL ballThrowType;
		
		public DprTrainerChangeMotionThrowBall(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_TRAINER_ADD(macro.GetValue("trg"));
            duration = ParseFloat(macro.GetValue("duration"));
            ballThrowType = (SEQ_DEF_TRAINER_MOTION_THROW_BALL)ParseInt(macro.GetValue("ballThrowType"));
        }
    }
}