using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprParticleFollowTrainer, "green", "one_frame", "")]
	public class DprParticleFollowTrainer : Macro
	{
		public bool isEnable;
		public SEQ_DEF_TRAINER trg;
		public int nodeIndex;
		public bool isPos;
		public bool isRot;
		public bool isScl;
		public Vector3 pos;
		public Vector3 rot;
		public bool isAnimScl;
		public bool isLocalScl;
		
		public DprParticleFollowTrainer(Macro macro) : base(macro)
        {
            isEnable = ParseBool(macro.GetValue("isEnable"), 1);
            trg = Parse_SEQ_DEF_TRAINER(macro.GetValue("trg"));
            nodeIndex = ParseInt(macro.GetValue("nodeIndex"), 0);
            isPos = ParseBool(macro.GetValue("isPos"), 1);
            isRot = ParseBool(macro.GetValue("isRot"), 1);
            isScl = ParseBool(macro.GetValue("isScl"), 1);
            pos = ParseVector3(macro.GetValue("pos"));
            rot = ParseVector3(macro.GetValue("rot"));
            isAnimScl = ParseBool(macro.GetValue("isAnimScl"), 0);
            isLocalScl = ParseBool(macro.GetValue("isLocalScl"), 0);
        }
    }
}