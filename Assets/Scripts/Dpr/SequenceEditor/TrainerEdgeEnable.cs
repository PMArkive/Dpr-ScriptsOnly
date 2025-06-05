namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.TrainerEdgeEnable, "lightyellow", "one_frame", "")]
	public class TrainerEdgeEnable : Macro
	{
		public SEQ_DEF_TRAINER trg;
		public bool visible;
		
		public TrainerEdgeEnable(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_TRAINER(macro.GetValue("trg"));
            visible = ParseBool(macro.GetValue("visible"));
        }
    }
}