using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonScaleNode, "red", "", "")]
	public class PokemonScaleNode : Macro
	{
		public SEQ_DEF_POS trg;
		public SEQ_DEF_NODE node;
		public bool reset;
		public Vector3 scale;
		public bool relative;
		public SEQ_DEF_MOVETYPE move;
		public bool origin;
		
		public PokemonScaleNode(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            node = Parse_SEQ_DEF_NODE(macro.GetValue("node"));
            reset = ParseBool(macro.GetValue("reset"), 0);
            scale = ParseVector3(macro.GetValue("scale"), 1.0f, 1.0f, 1.0f);
            relative = ParseBool(macro.GetValue("relative"), 0);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            origin = ParseBool(macro.GetValue("origin"), 0);
        }
    }
}