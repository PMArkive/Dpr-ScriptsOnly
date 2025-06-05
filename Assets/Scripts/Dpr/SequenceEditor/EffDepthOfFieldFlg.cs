namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffDepthOfFieldFlg, "lightgreen", "", "")]
	public class EffDepthOfFieldFlg : Macro
	{
		public bool enable;
		public bool subCamera;
		
		public EffDepthOfFieldFlg(Macro macro) : base(macro)
        {
            enable = ParseBool(macro.GetValue("enable"), 1);
            subCamera = ParseBool(macro.GetValue("subCamera"), 0);
        }
    }
}