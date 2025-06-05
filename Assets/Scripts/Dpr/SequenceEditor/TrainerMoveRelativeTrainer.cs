using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.TrainerMoveRelativeTrainer, "red", "", "")]
	public class TrainerMoveRelativeTrainer : Macro
	{
		public SEQ_DEF_TRAINER moveTrg;
		public string moveNode;
		public SEQ_DEF_TRAINER posTrg;
		public string posNode;
		public Vector3 pos;
		public bool isRot;
		public bool forceUpdate;
		public SEQ_DEF_MOVETYPE move;
		
		public TrainerMoveRelativeTrainer(Macro macro) : base(macro)
        {
            moveTrg = Parse_SEQ_DEF_TRAINER(macro.GetValue("moveTrg"));
            moveNode = ParseString(macro.GetValue("moveNode"));
            posTrg = Parse_SEQ_DEF_TRAINER(macro.GetValue("posTrg"));
            posNode = ParseString(macro.GetValue("posNode"));
            pos = ParseVector3(macro.GetValue("pos"));
            isRot = ParseBool(macro.GetValue("isRot"), 0);
            forceUpdate = ParseBool(macro.GetValue("forceUpdate"), 0);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}