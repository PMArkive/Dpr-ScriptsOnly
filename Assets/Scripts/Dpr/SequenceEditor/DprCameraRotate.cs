using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprCameraRotate, "yellow", "", "")]
	public class DprCameraRotate : Macro
	{
		public Vector3 rot;
		public SEQ_DEF_MOVETYPE move;
		public bool relative;
		public bool[] enableElemRot;
		
		public DprCameraRotate(Macro macro) : base(macro)
        {
            rot = ParseVector3(macro.GetValue("rot"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            relative = ParseBool(macro.GetValue("relative"));
            enableElemRot = ParseBoolArray(macro.GetValue("enableElemRot"), 1, 1, 1);
        }
    }
}