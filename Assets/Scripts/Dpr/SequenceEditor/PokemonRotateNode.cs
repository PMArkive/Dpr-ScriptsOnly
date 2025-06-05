using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonRotateNode, "red", "", "")]
	public class PokemonRotateNode : Macro
	{
		public SEQ_DEF_POS trg;
		public SEQ_DEF_NODE node;
		public Vector3 scale;
		public bool relative;
		public bool isFlip;
		public SEQ_DEF_MOVETYPE move;
		
		public PokemonRotateNode(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            node = Parse_SEQ_DEF_NODE(macro.GetValue("node"));
            scale = ParseVector3(macro.GetValue("scale"));
            relative = ParseBool(macro.GetValue("relative"), 0);
            isFlip = ParseBool(macro.GetValue("isFlip"), 0);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}