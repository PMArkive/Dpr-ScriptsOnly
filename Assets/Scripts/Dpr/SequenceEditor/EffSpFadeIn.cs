using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffSpFadeIn, "lightgreen", "", "")]
	public class EffSpFadeIn : Macro
	{
		public Vector3 col;
		public float alpha;
		public FADE_TYPE type;
		
		public EffSpFadeIn(Macro macro) : base(macro)
        {
            col = ParseVector3(macro.GetValue("col"));
            alpha = ParseFloat(macro.GetValue("alpha"), 255.0f);
            type = Parse_FADE_TYPE(macro.GetValue("type"));
        }
    }
}