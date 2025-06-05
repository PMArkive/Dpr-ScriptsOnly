namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SpecialTameVisible, "purple", "one_frame", "")]
	public class SpecialTameVisible : Macro
	{
		public SEQ_DEF_POS trg;
		public bool visible;
		
		public SpecialTameVisible(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            visible = ParseBool(macro.GetValue("visible"));
        }
    }
}