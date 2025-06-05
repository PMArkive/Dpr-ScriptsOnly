using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SoundBelugaMoveRelativePoke, "blue", "", "")]
	public class SoundBelugaMoveRelativePoke : Macro
	{
		public SEQ_DEF_POS trg;
		public SEQ_DEF_NODE node;
		public Vector3 pos;
		public int rate;
		public SEQ_DEF_MOVETYPE move;
		
		public SoundBelugaMoveRelativePoke(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            node = Parse_SEQ_DEF_NODE(macro.GetValue("node"));
            pos = ParseVector3(macro.GetValue("pos"));
            rate = ParseInt(macro.GetValue("rate"), 100);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}