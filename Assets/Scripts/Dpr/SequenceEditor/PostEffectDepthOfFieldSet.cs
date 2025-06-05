namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PostEffectDepthOfFieldSet, "lightgreen", "", "")]
	public class PostEffectDepthOfFieldSet : Macro
	{
		public float farDepth;
		public float focalLength;
		public float distance;
		public float blurry;
		public SEQ_DEF_MOVETYPE move;
		public bool isReset;
		
		public PostEffectDepthOfFieldSet(Macro macro) : base(macro)
        {
            farDepth = ParseFloat(macro.GetValue("farDepth"), 30.0f);
            focalLength = ParseFloat(macro.GetValue("focalLength"), 5.0f);
            distance = ParseFloat(macro.GetValue("distance"));
            blurry = ParseFloat(macro.GetValue("blurry"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            isReset = ParseBool(macro.GetValue("isReset"), 0);
        }
    }
}