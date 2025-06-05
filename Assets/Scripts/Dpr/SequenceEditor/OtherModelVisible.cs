namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.OtherModelVisible, "violet", "one_frame", "")]
	public class OtherModelVisible : Macro
	{
		public SEQ_DEF_POS trg;
		public bool visible;
		
		public OtherModelVisible(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            visible = ParseBool(macro.GetValue("visible"), 0);
        }
    }
}