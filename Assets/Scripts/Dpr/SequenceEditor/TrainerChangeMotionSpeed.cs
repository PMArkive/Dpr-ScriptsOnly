namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.TrainerChangeMotionSpeed, "lightyellow", "one_frame", "")]
	public class TrainerChangeMotionSpeed : Macro
	{
		public SEQ_DEF_TRAINER trg;
		public float speed;
		
		public TrainerChangeMotionSpeed(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_TRAINER(macro.GetValue("trg"));
            speed = ParseFloat(macro.GetValue("speed"));
        }
    }
}