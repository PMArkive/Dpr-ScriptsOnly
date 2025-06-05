namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffFeedbackEffectSet, "lightgreen", "", "")]
	public class EffFeedbackEffectSet : Macro
	{
		public float weight;
		public float Rotation;
		public float Scale;
		public float Hue;
		public float Saturation;
		public float Brightness;
		public float Contrast;
		public SEQ_DEF_MOVETYPE move;
		public bool subCamera;
		
		public EffFeedbackEffectSet(Macro macro) : base(macro)
        {
            weight = ParseFloat(macro.GetValue("weight"));
            Rotation = ParseFloat(macro.GetValue("Rotation"));
            Scale = ParseFloat(macro.GetValue("Scale"));
            Hue = ParseFloat(macro.GetValue("Hue"));
            Saturation = ParseFloat(macro.GetValue("Saturation"));
            Brightness = ParseFloat(macro.GetValue("Brightness"));
            Contrast = ParseFloat(macro.GetValue("Contrast"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            subCamera = ParseBool(macro.GetValue("subCamera"), 0);
        }
    }
}