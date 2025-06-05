namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.TrainerMoveReset, "lightyellow", "one_frame", "")]
	public class TrainerMoveReset : Macro
	{
		public SEQ_DEF_TRAINER_ADD trg;
		public bool origin;
		
		public TrainerMoveReset(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_TRAINER_ADD(macro.GetValue("trg"));
            origin = ParseBool(macro.GetValue("origin"));
        }
    }
}