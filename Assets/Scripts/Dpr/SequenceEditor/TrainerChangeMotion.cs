namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.TrainerChangeMotion, "lightyellow", "one_frame", "")]
	public class TrainerChangeMotion : Macro
	{
		public SEQ_DEF_TRAINER_ADD trg;
		public string state;
		
		public TrainerChangeMotion(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_TRAINER_ADD(macro.GetValue("trg"));
            state = ParseString(macro.GetValue("state"));
        }
    }
}