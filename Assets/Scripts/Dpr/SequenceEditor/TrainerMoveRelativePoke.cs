using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.TrainerMoveRelativePoke, "lightyellow", "", "")]
	public class TrainerMoveRelativePoke : Macro
	{
		public SEQ_DEF_TRAINER_ADD moveTrg;
		public SEQ_DEF_POS posTrg;
		public SEQ_DEF_NODE node;
		public Vector3 pos;
		public int rate;
		public bool isFlip;
		public bool isScale;
		public bool isRot;
		public bool isRotPos;
		public bool forceUpdate;
		public SEQ_DEF_MOVETYPE move;
		public bool[] enableElem;
		
		public TrainerMoveRelativePoke(Macro macro) : base(macro)
        {
            moveTrg = Parse_SEQ_DEF_TRAINER_ADD(macro.GetValue("moveTrg"));
            posTrg = Parse_SEQ_DEF_POS(macro.GetValue("posTrg"));
            node = Parse_SEQ_DEF_NODE(macro.GetValue("node"));
            pos = ParseVector3(macro.GetValue("pos"));
            rate = ParseInt(macro.GetValue("rate"), 100);
            isFlip = ParseBool(macro.GetValue("isFlip"), 1);
            isScale = ParseBool(macro.GetValue("isScale"), 1);
            isRot = ParseBool(macro.GetValue("isRot"), 1);
            isRotPos = ParseBool(macro.GetValue("isRotPos"), 1);
            forceUpdate = ParseBool(macro.GetValue("forceUpdate"), 0);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            enableElem = ParseBoolArray(macro.GetValue("enableElem"), 1, 1, 1);
        }
    }
}