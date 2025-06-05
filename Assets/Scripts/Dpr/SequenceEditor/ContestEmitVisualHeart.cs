namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ContestEmitVisualHeart, "orange", "", "")]
	public class ContestEmitVisualHeart : Macro
	{
		public SEQ_DEF_TRAINER trg;
		
		public ContestEmitVisualHeart(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_TRAINER(macro.GetValue("trg"));
        }
    }
}