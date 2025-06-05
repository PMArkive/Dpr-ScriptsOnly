namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffColorVignetteFlg, "lightgreen", "", "")]
	public class EffColorVignetteFlg : Macro
	{
		public bool visible;
		public bool subCamera;
		
		public EffColorVignetteFlg(Macro macro) : base(macro)
        {
            visible = ParseBool(macro.GetValue("visible"), 1);
            subCamera = ParseBool(macro.GetValue("subCamera"), 0);
        }
    }
}