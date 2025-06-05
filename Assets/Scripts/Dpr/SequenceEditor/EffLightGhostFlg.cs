namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffLightGhostFlg, "lightgreen", "", "")]
	public class EffLightGhostFlg : Macro
	{
		public bool visible;
		public bool subCamera;
		
		public EffLightGhostFlg(Macro macro) : base(macro)
        {
            visible = ParseBool(macro.GetValue("visible"), 1);
            subCamera = ParseBool(macro.GetValue("subCamera"), 0);
        }
    }
}