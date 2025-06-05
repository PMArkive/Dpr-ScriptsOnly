using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.Sound3DFollowModel, "blue", "one_frame", "")]
	public class Sound3DFollowModel : Macro
	{
		public SEQ_DEF_FOLLOW type;
		public int grpNo;
		public string node;
		public bool isPos;
		public bool isRot;
		public bool isScl;
		public Vector3 pos;
		public Vector3 rot;
		
		public Sound3DFollowModel(Macro macro) : base(macro)
        {
            type = Parse_SEQ_DEF_FOLLOW(macro.GetValue("type"));
            grpNo = ParseInt(macro.GetValue("grpNo"));
            node = ParseString(macro.GetValue("node"));
            isPos = ParseBool(macro.GetValue("isPos"), 1);
            isRot = ParseBool(macro.GetValue("isRot"), 1);
            isScl = ParseBool(macro.GetValue("isScl"), 1);
            pos = ParseVector3(macro.GetValue("pos"));
            rot = ParseVector3(macro.GetValue("rot"));
        }
    }
}