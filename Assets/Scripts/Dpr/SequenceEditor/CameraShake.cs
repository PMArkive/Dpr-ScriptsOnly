namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.CameraShake, "yellow", "", "")]
    public class CameraShake : Macro
	{
		public float srate;
		public float erate;
		public float dec;
		public SEQ_DEF_AXIS axis;
		public bool pos;
		public bool trg;
		
		public CameraShake(Macro macro) : base(macro)
        {
            srate = ParseFloat(macro.GetValue("srate"));
            erate = ParseFloat(macro.GetValue("erate"));
            dec = ParseFloat(macro.GetValue("dec"));
            axis = Parse_SEQ_DEF_AXIS(macro.GetValue("axis"));
            pos = ParseBool(macro.GetValue("pos"), 1);
            trg = ParseBool(macro.GetValue("trg"), 1);
        }
    }
}