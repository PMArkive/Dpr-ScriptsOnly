using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SubCameraAnimationScale, "yellow", "one_frame", "")]
	public class SubCameraAnimationScale : Macro
	{
		public Vector3 pos;
		
		public SubCameraAnimationScale(Macro macro) : base(macro)
        {
            pos = ParseVector3(macro.GetValue("pos"), 1.0f, 1.0f, 1.0f);
        }
    }
}