namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SubCameraAnimationEnd, "yellow", "one_frame", "")]
	public class SubCameraAnimationEnd : Macro
	{
		public bool isHoldPos;
		
		public SubCameraAnimationEnd(Macro macro) : base(macro)
        {
            isHoldPos = ParseBool(macro.GetValue("isHoldPos"), 1);
        }
    }
}