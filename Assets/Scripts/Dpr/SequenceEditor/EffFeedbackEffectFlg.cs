namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffFeedbackEffectFlg, "lightgreen", "", "")]
	public class EffFeedbackEffectFlg : Macro
	{
		public bool enable;
		public bool subCamera;
		
		public EffFeedbackEffectFlg(Macro macro) : base(macro)
        {
            enable = ParseBool(macro.GetValue("enable"), 1);
            subCamera = ParseBool(macro.GetValue("subCamera"), 0);
        }
    }
}