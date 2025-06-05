namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SubCameraAnimationChangeSpeed, "yellow", "one_frame", "")]
	public class SubCameraAnimationChangeSpeed : Macro
	{
		public float speed;
		
		public SubCameraAnimationChangeSpeed(Macro macro) : base(macro)
        {
            speed = ParseFloat(macro.GetValue("speed"));
        }
    }
}