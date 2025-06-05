namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DispUIBallBar, "lightblue", "one_frame", "")]
	public class DispUIBallBar : Macro
	{
		public SEQ_DEF_POS trg;
		public bool isDisp;
		
		public DispUIBallBar(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            isDisp = ParseBool(macro.GetValue("isDisp"), 0);
        }
    }
}