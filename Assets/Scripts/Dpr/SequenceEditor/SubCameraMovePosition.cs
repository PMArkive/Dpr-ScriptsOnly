using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SubCameraMovePosition, "yellow", "", "")]
	public class SubCameraMovePosition : Macro
	{
		public Vector3 pos;
		public Vector3 trg;
		public float fov;
		public SEQ_DEF_MOVETYPE move;
		public bool relative;
		public bool[] enableElemPos;
		public bool[] enableElemTrg;
		
		public SubCameraMovePosition(Macro macro) : base(macro)
        {
            pos = ParseVector3(macro.GetValue("pos"));
            trg = ParseVector3(macro.GetValue("trg"));
            fov = ParseFloat(macro.GetValue("fov"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            relative = ParseBool(macro.GetValue("relative"));
            enableElemPos = ParseBoolArray(macro.GetValue("enableElemPos"), 1, 1, 1);
            enableElemTrg = ParseBoolArray(macro.GetValue("enableElemTrg"), 1, 1, 1);
        }
    }
}