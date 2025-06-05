namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffRadialBlurFlg, "lightgreen", "", "")]
	public class EffRadialBlurFlg : Macro
	{
		public bool enable;
		public bool subCamera;
		
		public EffRadialBlurFlg(Macro macro) : base(macro)
        {
            enable = ParseBool(macro.GetValue("enable"), 1);
            subCamera = ParseBool(macro.GetValue("subCamera"), 0);
        }
    }
}