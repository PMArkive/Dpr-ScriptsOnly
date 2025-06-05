namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SpecialLoadTrainer, "purple", "", "")]
	public class SpecialLoadTrainer : Macro
	{
		public SEQ_DEF_TRAINER trg;
		public string traName;
		
		public SpecialLoadTrainer(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_TRAINER(macro.GetValue("trg"));
            traName = ParseString(macro.GetValue("traName"));
        }
    }
}