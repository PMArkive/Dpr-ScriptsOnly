namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprParticleMoveRelativeModel, "green", "", "")]
	public class DprParticleMoveRelativeModel : Macro
	{
		public int grpNo;
		public int nodeIndex;
		public SEQ_DEF_MOVETYPE move;
		
		public DprParticleMoveRelativeModel(Macro macro) : base(macro)
        {
            grpNo = ParseInt(macro.GetValue("grpNo"));
            nodeIndex = ParseInt(macro.GetValue("nodeIndex"), 0);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}