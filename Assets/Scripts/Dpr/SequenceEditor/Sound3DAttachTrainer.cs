namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.Sound3DAttachTrainer, "blue", "one_frame", "")]
	public class Sound3DAttachTrainer : Macro
	{
		public bool isEnable;
		public SEQ_DEF_TRAINER trg;
		public string node;
		public bool isAnimScl;
		public bool isLocalScl;
		
		public Sound3DAttachTrainer(Macro macro) : base(macro)
        {
            isEnable = ParseBool(macro.GetValue("isEnable"), 1);
            trg = Parse_SEQ_DEF_TRAINER(macro.GetValue("trg"));
            node = ParseString(macro.GetValue("node"));
            isAnimScl = ParseBool(macro.GetValue("isAnimScl"), 0);
            isLocalScl = ParseBool(macro.GetValue("isLocalScl"), 0);
        }
    }
}