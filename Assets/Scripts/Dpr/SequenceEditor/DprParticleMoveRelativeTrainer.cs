using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprParticleMoveRelativeTrainer, "green", "", "")]
	public class DprParticleMoveRelativeTrainer : Macro
	{
		public SEQ_DEF_TRAINER trg;
		public int nodeIndex;
		public Vector3 pos;
		public bool isRot;
		public bool forceUpdate;
		public SEQ_DEF_MOVETYPE move;
		
		public DprParticleMoveRelativeTrainer(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_TRAINER(macro.GetValue("trg"));
            nodeIndex = ParseInt(macro.GetValue("nodeIndex"), 0);
            pos = ParseVector3(macro.GetValue("pos"));
            isRot = ParseBool(macro.GetValue("isRot"), 0);
            forceUpdate = ParseBool(macro.GetValue("forceUpdate"), 0);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}