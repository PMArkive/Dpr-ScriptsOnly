namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ParticleMoveRelativeModel, "green", "", "")]
	public class ParticleMoveRelativeModel : Macro
	{
		public int grpNo;
		public string node;
		public SEQ_DEF_MOVETYPE move;
		
		public ParticleMoveRelativeModel(Macro macro) : base(macro)
        {
            grpNo = ParseInt(macro.GetValue("grpNo"));
            node = ParseString(macro.GetValue("node"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}