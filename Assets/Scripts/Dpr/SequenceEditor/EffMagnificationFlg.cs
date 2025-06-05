namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffMagnificationFlg, "lightgreen", "", "")]
	public class EffMagnificationFlg : Macro
	{
		public bool visible;
		public bool subCamera;
		
		public EffMagnificationFlg(Macro macro) : base(macro)
        {
            visible = ParseBool(macro.GetValue("visible"), 1);
            subCamera = ParseBool(macro.GetValue("subCamera"), 0);
        }
    }
}