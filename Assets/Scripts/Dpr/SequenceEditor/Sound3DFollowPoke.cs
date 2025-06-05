using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.Sound3DFollowPoke, "blue", "one_frame", "")]
	public class Sound3DFollowPoke : Macro
	{
		public bool isEnable;
		public SEQ_DEF_POS pos;
		public SEQ_DEF_NODE node;
		public Vector3 posOfs;
		public bool isRot;
		public bool isScl;
		
		public Sound3DFollowPoke(Macro macro) : base(macro)
        {
            isEnable = ParseBool(macro.GetValue("isEnable"), 1);
            pos = Parse_SEQ_DEF_POS(macro.GetValue("pos"));
            node = Parse_SEQ_DEF_NODE(macro.GetValue("node"));
            posOfs = ParseVector3(macro.GetValue("posOfs"));
            isRot = ParseBool(macro.GetValue("isRot"), 0);
            isScl = ParseBool(macro.GetValue("isScl"), 0);
        }
    }
}