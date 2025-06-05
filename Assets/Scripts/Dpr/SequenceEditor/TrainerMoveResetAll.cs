namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.TrainerMoveResetAll, "lightyellow", "one_frame", "")]
	public class TrainerMoveResetAll : Macro
	{
		public bool origin;
		
		public TrainerMoveResetAll(Macro macro) : base(macro)
        {
            origin = ParseBool(macro.GetValue("origin"));
        }
    }
}