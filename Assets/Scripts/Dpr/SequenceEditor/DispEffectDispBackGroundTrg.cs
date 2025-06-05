namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DispEffectDispBackGroundTrg, "lightgreen", "one_frame", "")]
	public class DispEffectDispBackGroundTrg : Macro
	{
		public bool isDisp;
		public SEQ_DEF_BACKGROUND_TRG trg;
		public int index;
		
		public DispEffectDispBackGroundTrg(Macro macro) : base(macro)
        {
            isDisp = ParseBool(macro.GetValue("isDisp"));
            trg = (SEQ_DEF_BACKGROUND_TRG)ParseInt(macro.GetValue("trg"));
            index = ParseInt(macro.GetValue("trg"), 0);
        }
    }
}