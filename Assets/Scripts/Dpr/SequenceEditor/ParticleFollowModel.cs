using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ParticleFollowModel, "green", "one_frame", "")]
	public class ParticleFollowModel : Macro
	{
		public int grpNo;
		public string node;
		public bool isPos;
		public bool isRot;
		public bool isScl;
		public Vector3 pos;
		public Vector3 rot;
		public bool isAnimScl;
		
		public ParticleFollowModel(Macro macro) : base(macro)
        {
            grpNo = ParseInt(macro.GetValue("grpNo"));
            node = ParseString(macro.GetValue("node"));
            isPos = ParseBool(macro.GetValue("isPos"), 1);
            isRot = ParseBool(macro.GetValue("isRot"), 1);
            isScl = ParseBool(macro.GetValue("isScl"), 1);
            pos = ParseVector3(macro.GetValue("pos"));
            rot = ParseVector3(macro.GetValue("rot"));
            isAnimScl = ParseBool(macro.GetValue("isAnimScl"), 0);
        }
    }
}