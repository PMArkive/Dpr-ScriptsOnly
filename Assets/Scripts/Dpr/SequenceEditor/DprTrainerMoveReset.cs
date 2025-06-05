namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprTrainerMoveReset, "lightyellow", "one_frame", "")]
	public class DprTrainerMoveReset : Macro
	{
		public SEQ_DEF_TRAINER_ADD trg;
		public SEQ_DEF_DEFAULT_PLACEMENT place;
		
		public DprTrainerMoveReset(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_TRAINER_ADD(macro.GetValue("trg"));
            place = Parse_SEQ_DEF_DEFAULT_PLACEMENT(macro.GetValue("place"));
        }
    }
}