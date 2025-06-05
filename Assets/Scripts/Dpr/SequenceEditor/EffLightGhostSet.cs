using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffLightGhostSet, "lightgreen", "", "")]
	public class EffLightGhostSet : Macro
	{
		public SEQ_DEF_LG_LUM lumFactor;
		public SEQ_DEF_LG_SHAPE lightGhostShape;
		public Vector3 srcPos;
		public Vector3 lgColor;
		public float intensity;
		public float sizeScale;
		public float distScale;
		public float vignette;
		public float distortion;
		public SEQ_DEF_MOVETYPE move;
		public bool subCamera;
		
		public EffLightGhostSet(Macro macro) : base(macro)
        {
            lumFactor = Parse_SEQ_DEF_LG_LUM(macro.GetValue("lumFactor"));
            lightGhostShape = Parse_SEQ_DEF_LG_SHAPE(macro.GetValue("lightGhostShape"));
            srcPos = ParseVector3(macro.GetValue("srcPos"));
            lgColor = ParseVector3(macro.GetValue("lgColor"), 1.0f, 1.0f, 1.0f);
            intensity = ParseFloat(macro.GetValue("intensity"), 1.0f);
            sizeScale = ParseFloat(macro.GetValue("sizeScale"), 1.0f);
            distScale = ParseFloat(macro.GetValue("distScale"), 1.0f);
            vignette = ParseFloat(macro.GetValue("vignette"), 1.0f);
            distortion = ParseFloat(macro.GetValue("distortion"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            subCamera = ParseBool(macro.GetValue("subCamera"), 0);
        }
    }
}