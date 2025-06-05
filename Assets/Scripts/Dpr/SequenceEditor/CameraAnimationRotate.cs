namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.CameraAnimationRotate, "yellow", "one_frame", "")]
    public class CameraAnimationRotate : Macro
	{
		public float pos;
		
		public CameraAnimationRotate(Macro macro) : base(macro)
        {
            pos = ParseFloat(macro.GetValue("pos"));
        }
	}
}