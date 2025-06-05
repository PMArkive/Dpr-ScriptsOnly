namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.TrainerChangeMotionInt, "lightyellow", "one_frame", "")]
	public class TrainerChangeMotionInt : Macro
	{
		public SEQ_DEF_TRAINER_ADD trg;
		public string state;
		public int number;
		
		public TrainerChangeMotionInt(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_TRAINER_ADD(macro.GetValue("trg"));
            state = ParseString(macro.GetValue("state"));
            number = ParseInt(macro.GetValue("number"), 0);
        }
    }
}