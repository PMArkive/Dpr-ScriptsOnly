namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ParticleLengthScale, "green", "", "")]
	public class ParticleLengthScale : Macro
	{
		public SEQ_DEF_POS trg;
		public SEQ_DEF_NODE node;
		public float baseLen;
		public bool[] scale;
		public SEQ_DEF_MOVETYPE move;
		
		public ParticleLengthScale(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            node = Parse_SEQ_DEF_NODE(macro.GetValue("node"));
            baseLen = ParseFloat(macro.GetValue("baseLen"));
            scale = ParseBoolArray(macro.GetValue("scale"), true);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}