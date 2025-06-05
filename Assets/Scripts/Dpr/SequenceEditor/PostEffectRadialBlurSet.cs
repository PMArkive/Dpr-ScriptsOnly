using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PostEffectRadialBlurSet, "lightgreen", "", "")]
	public class PostEffectRadialBlurSet : Macro
	{
		public Vector3 center;
		public float intensity;
		public int numSamples;
		public SEQ_DEF_MOVETYPE move;
		
		public PostEffectRadialBlurSet(Macro macro) : base(macro)
        {
            center = ParseVector3(macro.GetValue("center"), 0.5f, 0.5f, 0.0f);
            intensity = ParseFloat(macro.GetValue("intensity"));
            numSamples = ParseInt(macro.GetValue("numSamples"), 3);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}