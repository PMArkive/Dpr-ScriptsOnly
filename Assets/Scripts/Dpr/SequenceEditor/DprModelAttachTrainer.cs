namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprModelAttachTrainer, "pink", "one_frame", "")]
	public class DprModelAttachTrainer : Macro
	{
		public bool isEnable;
		public SEQ_DEF_TRAINER trg;
		public SEQ_DEF_NODE_MODEL node;
		public bool ignoreDominantHand;
		public bool enableDominantHoldBallHand;
		public bool changeLight;
		public bool isAnimScl;
		public bool isLocalScl;
		
		public DprModelAttachTrainer(Macro macro) : base(macro)
        {
            isEnable = ParseBool(macro.GetValue("isEnable"), 1);
            trg = Parse_SEQ_DEF_TRAINER(macro.GetValue("trg"));
            node = (SEQ_DEF_NODE_MODEL)ParseInt(macro.GetValue("node"));
            ignoreDominantHand = ParseBool(macro.GetValue("ignoreDominantHand"), 0);
            enableDominantHoldBallHand = ParseBool(macro.GetValue("enableDominantHoldBallHand"), 0);
            changeLight = ParseBool(macro.GetValue("changeLight"));
            isAnimScl = ParseBool(macro.GetValue("isAnimScl"), 0);
            isLocalScl = ParseBool(macro.GetValue("isLocalScl"), 0);
        }
    }
}