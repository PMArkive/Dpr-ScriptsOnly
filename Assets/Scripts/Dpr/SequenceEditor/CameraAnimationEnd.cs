namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.CameraAnimationEnd, "yellow", "one_frame", "")]
    public class CameraAnimationEnd : Macro
	{
		public bool isHoldPos;
		
		public CameraAnimationEnd(Macro macro) : base(macro)
        {
            isHoldPos = ParseBool(macro.GetValue("isHoldPos"), 1);
        }
	}
}