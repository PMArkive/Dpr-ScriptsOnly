using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprCameraMovePosition, "yellow", "", "")]
	public class DprCameraMovePosition : Macro
	{
		public Vector3 pos;
		public SEQ_DEF_MOVETYPE move;
		public bool relative;
		public bool[] enableElemPos;
		
		public DprCameraMovePosition(Macro macro) : base(macro)
        {
            pos = ParseVector3(macro.GetValue("pos"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            relative = ParseBool(macro.GetValue("relative"));
            enableElemPos = ParseBoolArray(macro.GetValue("enableElemPos"), 1, 1, 1);
        }
    }
}