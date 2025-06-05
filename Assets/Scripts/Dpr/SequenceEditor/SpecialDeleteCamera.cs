namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SpecialDeleteCamera, "purple", "one_frame", "")]
	public class SpecialDeleteCamera : Macro
	{
		public string envfile;
		public string motfile;
		
		public SpecialDeleteCamera(Macro macro) : base(macro)
        {
            envfile = ParseString(macro.GetValue("envfile"));
            motfile = ParseString(macro.GetValue("motfile"));
        }
    }
}