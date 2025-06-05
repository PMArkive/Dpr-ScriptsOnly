namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffColorCorrectionFlg, "lightgreen", "", "")]
	public class EffColorCorrectionFlg : Macro
	{
		public bool visible;
		public bool subCamera;
		
		public EffColorCorrectionFlg(Macro macro) : base(macro)
        {
            visible = ParseBool(macro.GetValue("visible"), 1);
            subCamera = ParseBool(macro.GetValue("subCamera"), 0);
        }
    }
}