namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PostEffectRadialBlurFlg, "lightgreen", "", "")]
	public class PostEffectRadialBlurFlg : Macro
	{
		public bool isEnable;
		
		public PostEffectRadialBlurFlg(Macro macro) : base(macro)
        {
            isEnable = ParseBool(macro.GetValue("isEnable"), 1);
        }
    }
}