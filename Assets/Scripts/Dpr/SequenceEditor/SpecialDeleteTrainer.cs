namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SpecialDeleteTrainer, "purple", "", "")]
	public class SpecialDeleteTrainer : Macro
	{
		public SEQ_DEF_TRAINER trg;
		
		public SpecialDeleteTrainer(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_TRAINER(macro.GetValue("trg"));
        }
    }
}