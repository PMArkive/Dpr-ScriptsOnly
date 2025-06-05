using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprCameraRotationFreeze, "yellow", "", "")]
	public class DprCameraRotationFreeze : Macro
	{
		public bool isEnable;
		public bool isUpdateRot;
		public Vector3 rot;
		public bool relative;
		
		public DprCameraRotationFreeze(Macro macro) : base(macro)
        {
            isEnable = ParseBool(macro.GetValue("isEnable"), 0);
            isUpdateRot = ParseBool(macro.GetValue("isUpdateRot"), 0);
            rot = ParseVector3(macro.GetValue("rot"));
            relative = ParseBool(macro.GetValue("relative"), 0);
        }
    }
}