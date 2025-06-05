namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ClusterRotatePoke, "orange", "", "")]
	public class ClusterRotatePoke : Macro
	{
		public SEQ_DEF_POS dirPoke;
		public SEQ_DEF_NODE node;
		public float ofs;
		public bool vertical;
		
		public ClusterRotatePoke(Macro macro) : base(macro)
        {
            dirPoke = Parse_SEQ_DEF_POS(macro.GetValue("dirPoke"));
            node = Parse_SEQ_DEF_NODE(macro.GetValue("node"));
            ofs = ParseFloat(macro.GetValue("ofs"));
            vertical = ParseBool(macro.GetValue("vertical"));
        }
	}
}