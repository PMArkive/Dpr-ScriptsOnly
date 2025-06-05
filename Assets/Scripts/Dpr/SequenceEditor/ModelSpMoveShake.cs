namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ModelSpMoveShake, "pink", "", "")]
	public class ModelSpMoveShake : Macro
	{
		public float srate;
		public float erate;
		public float sdec;
		public float edec;
		public SEQ_DEF_AXIS axis;
		
		public ModelSpMoveShake(Macro macro) : base(macro)
        {
            srate = ParseFloat(macro.GetValue("srate"));
            erate = ParseFloat(macro.GetValue("erate"));
            sdec = ParseFloat(macro.GetValue("sdec"));
            edec = ParseFloat(macro.GetValue("edec"));
            axis = Parse_SEQ_DEF_AXIS(macro.GetValue("axis"));
        }
    }
}