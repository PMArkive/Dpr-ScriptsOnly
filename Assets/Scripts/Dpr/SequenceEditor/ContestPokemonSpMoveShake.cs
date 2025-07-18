namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ContestPokemonSpMoveShake, "orange", "", "")]
	public class ContestPokemonSpMoveShake : Macro
	{
		public SEQ_DEF_POS trg;
		public float srate;
		public float erate;
		public float sdec;
		public float edec;
		public SEQ_DEF_AXIS axis;
		public bool isFlip;
		
		public ContestPokemonSpMoveShake(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            srate = ParseFloat(macro.GetValue("srate"));
            erate = ParseFloat(macro.GetValue("erate"));
            sdec = ParseFloat(macro.GetValue("sdec"));
            edec = ParseFloat(macro.GetValue("edec"));
            axis = Parse_SEQ_DEF_AXIS(macro.GetValue("axis"));
            isFlip = ParseBool(macro.GetValue("isFlip"));
        }
    }
}