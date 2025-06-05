namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PostEffectColorGradingFlg, "lightgreen", "", "")]
	public class PostEffectColorGradingFlg : Macro
	{
		public bool isEnable;
		
		public PostEffectColorGradingFlg(Macro macro) : base(macro)
        {
            isEnable = ParseBool(macro.GetValue("isEnable"), 1);
        }
    }
}