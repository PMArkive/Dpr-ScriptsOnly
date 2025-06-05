namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffLensDistortionFlg, "lightgreen", "", "")]
	public class EffLensDistortionFlg : Macro
	{
		public bool enable;
		public bool subCamera;
		
		public EffLensDistortionFlg(Macro macro) : base(macro)
        {
            enable = ParseBool(macro.GetValue("enable"), 1);
            subCamera = ParseBool(macro.GetValue("subCamera"), 0);
        }
    }
}