using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ModelFollowPokeNodeName, "pink", "one_frame", "")]
	public class ModelFollowPokeNodeName : Macro
	{
		public bool isEnable;
		public SEQ_DEF_POS pos;
		public string node;
		public Vector3 posOfs;
		public bool isRot;
		public bool isScl;
		
		public ModelFollowPokeNodeName(Macro macro) : base(macro)
        {
            isEnable = ParseBool(macro.GetValue("isEnable"), 1);
            pos = Parse_SEQ_DEF_POS(macro.GetValue("pos"));
            node = ParseString(macro.GetValue("node"));
            posOfs = ParseVector3(macro.GetValue("posOfs"));
            isRot = ParseBool(macro.GetValue("isRot"), 0);
            isScl = ParseBool(macro.GetValue("isScl"), 0);
        }
    }
}