namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.TrainerChangeMotionResource, "lightyellow", "one_frame", "")]
	public class TrainerChangeMotionResource : Macro
	{
		public SEQ_DEF_TRAINER trg;
		public string file;
		public bool loop;
		
		public TrainerChangeMotionResource(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_TRAINER(macro.GetValue("trg"));
            file = ParseString(macro.GetValue("file"));
            loop = ParseBool(macro.GetValue("loop"));
        }
    }
}