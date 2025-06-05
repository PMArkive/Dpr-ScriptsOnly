using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SubCameraMoveRelativeCameraSp, "yellow", "", "")]
	public class SubCameraMoveRelativeCameraSp : Macro
	{
		public SEQ_DEF_SPPOS posTrg;
		public Vector3 pos;
		public Vector3 trg;
		public float fov;
		public SEQ_DEF_MOVETYPE move;
		public bool isFlip;
		public bool isRot;
		public bool relative;
		public bool[] enableElemPos;
		public bool[] enableElemTrg;
		
		public SubCameraMoveRelativeCameraSp(Macro macro) : base(macro)
        {
            posTrg = Parse_SEQ_DEF_SPPOS(macro.GetValue("posTrg"));
            pos = ParseVector3(macro.GetValue("pos"));
            trg = ParseVector3(macro.GetValue("trg"));
            fov = ParseFloat(macro.GetValue("fov"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            isFlip = ParseBool(macro.GetValue("isFlip"), 1);
            isRot = ParseBool(macro.GetValue("isRot"), 1);
            relative = ParseBool(macro.GetValue("relative"));
            enableElemPos = ParseBoolArray(macro.GetValue("enableElemPos"), 1, 1, 1);
            enableElemTrg = ParseBoolArray(macro.GetValue("enableElemTrg"), 1, 1, 1);
        }
    }
}