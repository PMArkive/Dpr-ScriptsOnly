namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffRadialBlurSet, "lightgreen", "", "")]
	public class EffRadialBlurSet : Macro
	{
		public float posx;
		public float posy;
		public float Scale;
		public float Intensity;
		public int NumSamples;
		public SEQ_DEF_MOVETYPE move;
		public bool subCamera;
		
		public EffRadialBlurSet(Macro macro) : base(macro)
        {
            posx = ParseFloat(macro.GetValue("posx"));
            posy = ParseFloat(macro.GetValue("posy"));
            Scale = ParseFloat(macro.GetValue("Scale"));
            Intensity = ParseFloat(macro.GetValue("Intensity"));
            NumSamples = ParseInt(macro.GetValue("NumSamples"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            subCamera = ParseBool(macro.GetValue("subCamera"), 0);
        }
    }
}