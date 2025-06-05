namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.TrainerDisp, "lightyellow", "one_frame", "")]
	public class TrainerDisp : Macro
	{
		public SEQ_DEF_TRAINER_ADD trg;
		public bool isDisp;
		
		public TrainerDisp(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_TRAINER_ADD(macro.GetValue("trg"));
            isDisp = ParseBool(macro.GetValue("isDisp"));
        }
    }
}