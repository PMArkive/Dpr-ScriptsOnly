namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ModelRotatePoke, "pink", "", "")]
	public class ModelRotatePoke : Macro
	{
		public SEQ_DEF_POS dirPoke;
		public SEQ_DEF_NODE node;
		public float ofs;
		public bool vertical;
		public SEQ_DEF_MOVETYPE move;
		
		public ModelRotatePoke(Macro macro) : base(macro)
        {
            dirPoke = Parse_SEQ_DEF_POS(macro.GetValue("dirPoke"));
            node = Parse_SEQ_DEF_NODE(macro.GetValue("node"));
            ofs = ParseFloat(macro.GetValue("ofs"));
            vertical = ParseBool(macro.GetValue("vertical"), 0);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}