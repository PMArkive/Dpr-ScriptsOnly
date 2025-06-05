using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprModelFollowModel, "pink", "one_frame", "")]
	public class DprModelFollowModel : Macro
	{
		public int grpNo;
		public int nodeIndex;
		public bool isPos;
		public bool isRot;
		public bool isScl;
		public Vector3 pos;
		public Vector3 rot;
		
		public DprModelFollowModel(Macro macro) : base(macro)
        {
            grpNo = ParseInt(macro.GetValue("grpNo"));
            nodeIndex = ParseInt(macro.GetValue("nodeIndex"), 0);
            isPos = ParseBool(macro.GetValue("isPos"), 1);
            isRot = ParseBool(macro.GetValue("isRot"), 1);
            isScl = ParseBool(macro.GetValue("isScl"), 1);
            pos = ParseVector3(macro.GetValue("pos"));
            rot = ParseVector3(macro.GetValue("rot"));
        }
    }
}