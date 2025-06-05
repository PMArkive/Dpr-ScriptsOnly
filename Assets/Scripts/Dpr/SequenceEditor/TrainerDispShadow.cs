namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.TrainerDispShadow, "lightyellow", "one_frame", "")]
	public class TrainerDispShadow : Macro
	{
		public SEQ_DEF_TRAINER trg;
		public bool isDisp;
		
		public TrainerDispShadow(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_TRAINER(macro.GetValue("trg"));
            isDisp = ParseBool(macro.GetValue("isDisp"));
        }
    }
}