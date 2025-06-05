using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprSetCameraTargetPos, "yellow", "", "")]
	public class DprSetCameraTargetPos : Macro
	{
		public Vector3 pos;
		
		public DprSetCameraTargetPos(Macro macro) : base(macro)
        {
            pos = ParseVector3(macro.GetValue("pos"));
        }
    }
}