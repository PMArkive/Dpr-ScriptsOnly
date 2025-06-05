namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.CameraAnimationChangeSpeed, "yellow", "one_frame", "")]
    public class CameraAnimationChangeSpeed : Macro
	{
		public float speed;
		
		public CameraAnimationChangeSpeed(Macro macro) : base(macro)
        {
            speed = ParseFloat(macro.GetValue("speed"));
        }
	}
}