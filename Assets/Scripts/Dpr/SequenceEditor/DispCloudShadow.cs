namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DispCloudShadow, "lightgreen", "one_frame", "")]
	public class DispCloudShadow : Macro
	{
		public bool isDisp;
		
		public DispCloudShadow(Macro macro) : base(macro)
        {
            isDisp = ParseBool(macro.GetValue("isDisp"), 0);
        }
    }
}