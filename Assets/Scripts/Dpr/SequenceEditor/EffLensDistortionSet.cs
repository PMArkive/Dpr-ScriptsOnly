namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffLensDistortionSet, "lightgreen", "", "")]
	public class EffLensDistortionSet : Macro
	{
		public SEQ_DEF_MODETYPE mode;
		public float power;
		public float Ufov;
		public float Afov;
		public float ScaleW;
		public float ScaleH;
		public float OffsetX;
		public float OffsetY;
		public SEQ_DEF_MOVETYPE move;
		public bool subCamera;
		
		public EffLensDistortionSet(Macro macro) : base(macro)
        {
            mode = Parse_SEQ_DEF_MODETYPE(macro.GetValue("mode"));
            power = ParseFloat(macro.GetValue("power"), 1.0f);
            Ufov = ParseFloat(macro.GetValue("Ufov"), 30.0f);
            Afov = ParseFloat(macro.GetValue("Afov"), 20.0f);
            ScaleW = ParseFloat(macro.GetValue("ScaleW"), 1.0f);
            ScaleH = ParseFloat(macro.GetValue("ScaleH"), 1.0f);
            OffsetX = ParseFloat(macro.GetValue("OffsetX"));
            OffsetY = ParseFloat(macro.GetValue("OffsetY"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            subCamera = ParseBool(macro.GetValue("subCamera"), 0);
        }
    }
}