using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffLightShaftSet, "lightgreen", "", "")]
	public class EffLightShaftSet : Macro
	{
		public float intensity;
		public Vector3 lsColor;
		public Vector3 srcPos;
		public float length;
		public float glareRatio;
		public float attenuation;
		public float noiseMask;
		public float noiseMaskFrequency;
		public float ringIntensity;
		public Vector3 ringOutClr;
		public float ringRadius;
		public float ringAttenua;
		public SEQ_DEF_MOVETYPE move;
		public bool subCamera;
		
		public EffLightShaftSet(Macro macro) : base(macro)
        {
            intensity = ParseFloat(macro.GetValue("intensity"), 1.0f);
            lsColor = ParseVector3(macro.GetValue("lsColor"), 1.0f, 1.0f, 1.0f);
            srcPos = ParseVector3(macro.GetValue("srcPos"));
            length = ParseFloat(macro.GetValue("length"), 1.0f);
            glareRatio = ParseFloat(macro.GetValue("glareRatio"), 0.25f);
            attenuation = ParseFloat(macro.GetValue("attenuation"), 1.0f);
            noiseMask = ParseFloat(macro.GetValue("noiseMask"), 1.0f);
            noiseMaskFrequency = ParseFloat(macro.GetValue("noiseMaskFrequency"), 1.0f);
            ringIntensity = ParseFloat(macro.GetValue("ringIntensity"), 0.5f);
            ringOutClr = ParseVector3(macro.GetValue("ringOutClr"), 1.0f, 1.0f, 1.0f);
            ringRadius = ParseFloat(macro.GetValue("ringRadius"), 15.0f);
            ringAttenua = ParseFloat(macro.GetValue("ringAttenua"), 0.5f);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            subCamera = ParseBool(macro.GetValue("subCamera"), 0);
        }
    }
}