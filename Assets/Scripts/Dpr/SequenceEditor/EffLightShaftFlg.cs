namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffLightShaftFlg, "lightgreen", "", "")]
	public class EffLightShaftFlg : Macro
	{
		public bool visible;
		public bool subCamera;
		
		public EffLightShaftFlg(Macro macro) : base(macro)
        {
            visible = ParseBool(macro.GetValue("visible"), 1);
            subCamera = ParseBool(macro.GetValue("subCamera"), 0);
        }
    }
}