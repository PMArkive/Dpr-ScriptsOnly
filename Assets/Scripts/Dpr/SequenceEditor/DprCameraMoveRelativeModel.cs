using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprCameraMoveRelativeModel, "yellow", "", "")]
	public class DprCameraMoveRelativeModel : Macro
	{
		public int grpNo;
		public int nodeIndex;
		public Vector3 pos;
		public Vector3 trg;
		public float fov;
		public int rate;
		public SEQ_DEF_POS dirPoke;
		public bool isFlip;
		public bool isRot;
		public bool forceUpdate;
		public SEQ_DEF_MOVETYPE move;
		public bool[] enableElemPos;
		public bool[] enableElemTrg;
		
		public DprCameraMoveRelativeModel(Macro macro) : base(macro)
        {
            grpNo = ParseInt(macro.GetValue("grpNo"));
            nodeIndex = ParseInt(macro.GetValue("nodeIndex"), 0);
            pos = ParseVector3(macro.GetValue("pos"));
            trg = ParseVector3(macro.GetValue("trg"));
            fov = ParseFloat(macro.GetValue("fov"));
            rate = ParseInt(macro.GetValue("rate"), 100);
            dirPoke = Parse_SEQ_DEF_POS(macro.GetValue("dirPoke"));
            isFlip = ParseBool(macro.GetValue("isFlip"), 1);
            isRot = ParseBool(macro.GetValue("isRot"), 1);
            forceUpdate = ParseBool(macro.GetValue("forceUpdate"), 0);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            enableElemPos = ParseBoolArray(macro.GetValue("enableElemPos"), 1, 1, 1);
            enableElemTrg = ParseBoolArray(macro.GetValue("enableElemTrg"), 1, 1, 1);
        }
    }
}