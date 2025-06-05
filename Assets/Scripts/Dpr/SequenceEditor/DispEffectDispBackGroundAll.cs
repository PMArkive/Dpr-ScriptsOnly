namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DispEffectDispBackGroundAll, "lightgreen", "one_frame", "")]
	public class DispEffectDispBackGroundAll : Macro
	{
		public bool isDisp;
		public SEQ_DEF_BACKGROUND_TRG trg;
		
		public DispEffectDispBackGroundAll(Macro macro) : base(macro)
        {
            isDisp = ParseBool(macro.GetValue("isDisp"));
            trg = (SEQ_DEF_BACKGROUND_TRG)ParseInt(macro.GetValue("trg"));
        }
    }
}