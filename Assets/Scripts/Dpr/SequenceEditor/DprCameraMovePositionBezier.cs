using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprCameraMovePositionBezier, "yellow", "", "")]
	public class DprCameraMovePositionBezier : Macro
	{
		public bool relative;
		public Vector3 p0;
		public Vector3 p1;
		public Vector3 p2;
		public Vector3 p3;
		public SEQ_DEF_MOVETYPE move;
		public bool[] enableElem;
		
		public DprCameraMovePositionBezier(Macro macro) : base(macro)
        {
            relative = ParseBool(macro.GetValue("relative"));
            p0 = ParseVector3(macro.GetValue("p0"));
            p1 = ParseVector3(macro.GetValue("p1"));
            p2 = ParseVector3(macro.GetValue("p2"));
            p3 = ParseVector3(macro.GetValue("p3"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            enableElem = ParseBoolArray(macro.GetValue("enableElem"), 1, 1, 1);
        }
    }
}