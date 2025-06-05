namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.TrainerSetMotionFrame, "lightyellow", "one_frame", "")]
	public class TrainerSetMotionFrame : Macro
	{
		public SEQ_DEF_TRAINER trg;
		public float frame;
		
		public TrainerSetMotionFrame(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_TRAINER(macro.GetValue("trg"));
            frame = ParseFloat(macro.GetValue("frame"));
        }
    }
}