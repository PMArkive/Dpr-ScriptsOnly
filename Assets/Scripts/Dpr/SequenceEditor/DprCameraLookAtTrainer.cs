namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprCameraLookAtTrainer, "yellow", "", "")]
	public class DprCameraLookAtTrainer : Macro
	{
		public SEQ_DEF_TRAINER trg;
		public SEQ_DEF_NODE_MODEL node;
		public SEQ_DEF_MOVETYPE move;
		
		public DprCameraLookAtTrainer(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_TRAINER(macro.GetValue("trg"));
            node = (SEQ_DEF_NODE_MODEL)ParseInt(macro.GetValue("node"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}