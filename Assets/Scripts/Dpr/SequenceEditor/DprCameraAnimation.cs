namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprCameraAnimation, "yellow", "one_frame", "PreloadCameraAnimation")]
	public class DprCameraAnimation : Macro
	{
		public string camFile;
		
		public DprCameraAnimation(Macro macro) : base(macro)
        {
            camFile = ParseString(macro.GetValue("camFile"));
        }
    }
}