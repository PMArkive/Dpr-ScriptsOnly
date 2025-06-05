namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.TrainerChangeMotionBool, "lightyellow", "one_frame", "")]
	public class TrainerChangeMotionBool : Macro
	{
		public SEQ_DEF_TRAINER_ADD trg;
		public string state;
		public bool flg;
		
		public TrainerChangeMotionBool(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_TRAINER_ADD(macro.GetValue("trg"));
            state = ParseString(macro.GetValue("state"));
            flg = ParseBool(macro.GetValue("flg"));
        }
    }
}