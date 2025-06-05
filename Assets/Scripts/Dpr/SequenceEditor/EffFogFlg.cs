namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffFogFlg, "lightgreen", "", "")]
	public class EffFogFlg : Macro
	{
		public bool visible;
		public bool subCamera;
		public bool isReset;
		
		public EffFogFlg(Macro macro) : base(macro)
        {
            visible = ParseBool(macro.GetValue("visible"), 1);
            subCamera = ParseBool(macro.GetValue("subCamera"), 0);
            isReset = ParseBool(macro.GetValue("isReset"), 0);
        }
    }
}