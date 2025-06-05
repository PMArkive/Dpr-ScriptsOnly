using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffColorCorrectionSet, "lightgreen", "", "")]
	public class EffColorCorrectionSet : Macro
	{
		public Vector3 colorScale;
		public Vector3 colorBias;
		public float brightness;
		public float saturation;
		public float contrast;
		public float temperature;
		public float sepiaTone;
		public bool inversion;
		public SEQ_DEF_MOVETYPE move;
		public bool subCamera;
		public bool isReset;
		
		public EffColorCorrectionSet(Macro macro) : base(macro)
        {
            colorScale = ParseVector3(macro.GetValue("colorScale"), 1.0f, 1.0f, 1.0f);
            colorBias = ParseVector3(macro.GetValue("colorBias"), 0.0f, 0.0f, 0.0f);
            brightness = ParseFloat(macro.GetValue("brightness"), 1.0f);
            saturation = ParseFloat(macro.GetValue("saturation"), 1.0f);
            contrast = ParseFloat(macro.GetValue("contrast"), 1.0f);
            temperature = ParseFloat(macro.GetValue("temperature"), 6500.0f);
            sepiaTone = ParseFloat(macro.GetValue("sepiaTone"));
            inversion = ParseBool(macro.GetValue("inversion"), 0);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            subCamera = ParseBool(macro.GetValue("subCamera"), 0);
            isReset = ParseBool(macro.GetValue("isReset"), 0);
        }
    }
}