using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ClusterMoveRelativePoke, "orange", "", "")]
    public class ClusterMoveRelativePoke : Macro
	{
		public SEQ_DEF_POS trg;
		public SEQ_DEF_NODE node;
		public Vector3 pos;
		public int rate;
		public bool isFlip;
		public bool isScale;
		public bool isRot;
		public bool isRotPos;
		public bool forceUpdate;
		
		public ClusterMoveRelativePoke(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            node = Parse_SEQ_DEF_NODE(macro.GetValue("node"));
            pos = ParseVector3(macro.GetValue("pos"));
            rate = ParseInt(macro.GetValue("rate"), 100);
            isFlip = ParseBool(macro.GetValue("isFlip"), 1);
            isScale = ParseBool(macro.GetValue("isScale"), 1);
            isRot = ParseBool(macro.GetValue("isRot"), 1);
            isRotPos = ParseBool(macro.GetValue("isRotPos"), 1);
            forceUpdate = ParseBool(macro.GetValue("forceUpdate"), 0);
        }
    }
}