namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SubCameraAnimationRotate, "yellow", "one_frame", "")]
	public class SubCameraAnimationRotate : Macro
	{
		public float pos;
		
		public SubCameraAnimationRotate(Macro macro) : base(macro)
        {
            pos = ParseFloat(macro.GetValue("pos"));
        }
    }
}