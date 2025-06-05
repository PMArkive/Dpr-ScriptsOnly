using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonMoveRelativePoke, "red", "", "")]
	public class PokemonMoveRelativePoke : Macro
	{
		public SEQ_DEF_POS moveTrg;
		public SEQ_DEF_POS posTrg;
		public SEQ_DEF_NODE node;
		public Vector3 ofs;
		public int rate;
		public bool isFlip;
		public bool isRot;
		public bool isRotPos;
		public bool forceUpdate;
		public SEQ_DEF_MOVETYPE move;
		public bool[] enableElem;
		
		public PokemonMoveRelativePoke(Macro macro) : base(macro)
        {
            moveTrg = Parse_SEQ_DEF_POS(macro.GetValue("moveTrg"));
            posTrg = Parse_SEQ_DEF_POS(macro.GetValue("posTrg"));
            node = Parse_SEQ_DEF_NODE(macro.GetValue("node"));
            ofs = ParseVector3(macro.GetValue("ofs"));
            rate = ParseInt(macro.GetValue("rate"), 100);
            isFlip = ParseBool(macro.GetValue("isFlip"), 1);
            isRot = ParseBool(macro.GetValue("isRot"), 1);
            isRotPos = ParseBool(macro.GetValue("isRotPos"), 1);
            forceUpdate = ParseBool(macro.GetValue("forceUpdate"), 0);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            enableElem = ParseBoolArray(macro.GetValue("enableElem"), 1, 1, 1);
        }
    }
}