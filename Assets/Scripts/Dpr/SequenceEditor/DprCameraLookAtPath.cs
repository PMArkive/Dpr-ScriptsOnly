using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprCameraLookAtPath, "yellow", "", "")]
	public class DprCameraLookAtPath : Macro
	{
		public bool relative;
		public SEQ_DEF_PATHTYPE pathType;
		public Vector3 p0;
		public Vector3 p1;
		public Vector3 p2;
		public Vector3 p3;
		public SEQ_DEF_MOVETYPE move;
		public bool[] enableElem;
		
		public DprCameraLookAtPath(Macro macro) : base(macro)
        {
            relative = ParseBool(macro.GetValue("relative"), 0);
            pathType = (SEQ_DEF_PATHTYPE)ParseInt(macro.GetValue("pathType"));
            p0 = ParseVector3(macro.GetValue("p0"));
            p1 = ParseVector3(macro.GetValue("p1"));
            p2 = ParseVector3(macro.GetValue("p2"));
            p3 = ParseVector3(macro.GetValue("p3"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            enableElem = ParseBoolArray(macro.GetValue("enableElem"), 1, 1, 1);
        }
    }
}