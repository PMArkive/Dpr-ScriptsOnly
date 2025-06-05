namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffGlareControl, "lightgreen", "", "")]
	public class EffGlareControl : Macro
	{
		public bool reset;
		public float luminance;
		public float threshold;
		public SEQ_DEF_MOVETYPE move;
		public bool subCamera;
		
		public EffGlareControl(Macro macro) : base(macro)
        {
            reset = ParseBool(macro.GetValue("reset"), 0);
            luminance = ParseFloat(macro.GetValue("luminance"));
            threshold = ParseFloat(macro.GetValue("threshold"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            subCamera = ParseBool(macro.GetValue("subCamera"), 0);
        }
    }
}