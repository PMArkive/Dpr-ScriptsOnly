namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SplitScreenEnable, "lightgreen", "", "PreloadMaskTexture")]
	public class SplitScreenEnable : Macro
	{
		public bool isEnable;
		public SEQ_DEF_MASK_TEX_PATTERN maskPatt;
		
		public SplitScreenEnable(Macro macro) : base(macro)
        {
            isEnable = ParseBool(macro.GetValue("isEnable"), 0);
            maskPatt = Parse_SEQ_DEF_MASK_TEX_PATTERN(macro.GetValue("maskPatt"));
        }
    }
}