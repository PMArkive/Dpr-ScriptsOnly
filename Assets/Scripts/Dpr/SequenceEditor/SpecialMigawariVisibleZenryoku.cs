namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SpecialMigawariVisibleZenryoku, "purple", "one_frame", "")]
	public class SpecialMigawariVisibleZenryoku : Macro
	{
		public SEQ_DEF_POS trg;
		public bool visible;
		
		public SpecialMigawariVisibleZenryoku(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            visible = ParseBool(macro.GetValue("visible"));
        }
    }
}