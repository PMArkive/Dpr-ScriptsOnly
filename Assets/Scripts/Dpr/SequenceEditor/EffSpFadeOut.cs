using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffSpFadeOut, "lightgreen", "", "")]
	public class EffSpFadeOut : Macro
	{
		public Vector3 col;
		public float alpha;
		public bool isCapthre;
		public FADE_TYPE type;
		public bool isCpuBoost;
		
		public EffSpFadeOut(Macro macro) : base(macro)
        {
            col = ParseVector3(macro.GetValue("col"));
            alpha = ParseFloat(macro.GetValue("alpha"), 255.0f);
            isCapthre = ParseBool(macro.GetValue("isCapthre"), 0);
            type = Parse_FADE_TYPE(macro.GetValue("type"));
            isCpuBoost = ParseBool(macro.GetValue("isCpuBoost"), 0);
        }
    }
}