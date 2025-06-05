namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprTrainerMoveResetAll, "lightyellow", "one_frame", "")]
	public class DprTrainerMoveResetAll : Macro
	{
		public SEQ_DEF_DEFAULT_PLACEMENT place;
		
		public DprTrainerMoveResetAll(Macro macro) : base(macro)
        {
            place = Parse_SEQ_DEF_DEFAULT_PLACEMENT(macro.GetValue("place"));
        }
    }
}