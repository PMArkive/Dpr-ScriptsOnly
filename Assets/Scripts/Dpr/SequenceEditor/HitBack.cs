namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.HitBack, "lightblue", "one_frame", "")]
	public class HitBack : Macro
	{
		public SEQ_DEF_POS trg;
		public bool isDefault;
		
		public HitBack(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            isDefault = ParseBool(macro.GetValue("isDefault"), 0);
        }
    }
}