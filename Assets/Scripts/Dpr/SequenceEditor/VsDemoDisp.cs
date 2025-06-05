namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.VsDemoDisp, "lightblue", "one_frame", "")]
	public class VsDemoDisp : Macro
	{
		public SEQ_DEF_POS trg;
		public bool visible;
		
		public VsDemoDisp(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            visible = ParseBool(macro.GetValue("visible"), 1);
        }
    }
}