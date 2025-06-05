namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SpecialMigawariVisible, "purple", "one_frame", "")]
	public class SpecialMigawariVisible : Macro
	{
		public SEQ_DEF_POS trg;
		public bool visible;
		
		public SpecialMigawariVisible(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            visible = ParseBool(macro.GetValue("visible"));
        }
    }
}