using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.OtherModelFollowMode, "violet", "one_frame", "")]
	public class OtherModelFollowMode : Macro
	{
		public SEQ_DEF_POS trg;
		public int grpNo;
		public string node;
		public bool isPos;
		public bool isRot;
		public bool isScl;
		public Vector3 pos;
		public Vector3 rot;
		
		public OtherModelFollowMode(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
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