namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.GaugeDisp, "lightblue", "one_frame", "")]
	public class GaugeDisp : Macro
	{
		public SEQ_DEF_POS trg;
		public bool visible;
		public bool isUpdate;
		
		public GaugeDisp(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            visible = ParseBool(macro.GetValue("visible"), 1);
            isUpdate = ParseBool(macro.GetValue("isUpdate"), 0);
        }
    }
}