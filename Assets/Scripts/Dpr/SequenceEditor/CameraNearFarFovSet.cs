namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.CameraNearFarFovSet, "yellow", "", "")]
    public class CameraNearFarFovSet : Macro
	{
		public float near;
		public float far;
		public float fov;
		public bool[] enableElem;
		public bool relative;
		
		public CameraNearFarFovSet(Macro macro) : base(macro)
		{
            near = ParseFloat(macro.GetValue("near"));
            far = ParseFloat(macro.GetValue("far"));
            fov = ParseFloat(macro.GetValue("fov"));
            enableElem = ParseBoolArray(macro.GetValue("enableElem"), 1, 1, 1);
            relative = ParseBool(macro.GetValue("relative"), 0);
        }
	}
}