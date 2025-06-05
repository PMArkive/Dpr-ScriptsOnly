namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.TrainerRevertAnimationConfige, "red", "one_frame", "")]
	public class TrainerRevertAnimationConfige : Macro
	{
		public SEQ_DEF_TRAINER_ADD trg;
		
		public TrainerRevertAnimationConfige(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_TRAINER_ADD(macro.GetValue("trg"));
        }
    }
}