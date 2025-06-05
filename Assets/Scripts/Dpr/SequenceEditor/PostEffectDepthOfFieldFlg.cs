namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PostEffectDepthOfFieldFlg, "lightgreen", "one_frame", "")]
	public class PostEffectDepthOfFieldFlg : Macro
	{
		public bool isEnable;
		
		public PostEffectDepthOfFieldFlg(Macro macro) : base(macro)
        {
            isEnable = ParseBool(macro.GetValue("isEnable"), 1);
        }
    }
}