using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffColorVignetteSet, "lightgreen", "", "")]
	public class EffColorVignetteSet : Macro
	{
		public SEQ_DEF_VIGNETTE_TYPE viType;
		public float viOffset;
		public float viFovDepe;
		public float viScale;
		public Vector3 viColor;
		public float imageCircle;
		public float imageCircleFov;
		public float widthScale;
		public float penumbraFov;
		public SEQ_DEF_MOVETYPE move;
		public bool subCamera;
		
		public EffColorVignetteSet(Macro macro) : base(macro)
        {
            viType = Parse_SEQ_DEF_VIGNETTE_TYPE(macro.GetValue("viType"));
            viOffset = ParseFloat(macro.GetValue("viOffset"));
            viFovDepe = ParseFloat(macro.GetValue("viFovDepe"), 0.05f);
            viScale = ParseFloat(macro.GetValue("viScale"), 1.0f);
            viColor = ParseVector3(macro.GetValue("viColor"), 1.0f, 1.0f, 1.0f);
            imageCircle = ParseFloat(macro.GetValue("imageCircle"));
            imageCircleFov = ParseFloat(macro.GetValue("imageCircleFov"), 0.05f);
            widthScale = ParseFloat(macro.GetValue("widthScale"), 1.0f);
            penumbraFov = ParseFloat(macro.GetValue("penumbraFov"), 0.05f);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            subCamera = ParseBool(macro.GetValue("subCamera"), 0);
        }
    }
}