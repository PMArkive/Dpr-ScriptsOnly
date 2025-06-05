using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.CameraAnimationScale, "yellow", "one_frame", "PreloadCameraAnimation")]
    public class CameraAnimationScale : Macro
    {
        public Vector3 pos;

        public CameraAnimationScale(Macro macro) : base(macro)
        {
            pos = ParseVector3(macro.GetValue("pos"), 1.0f, 1.0f, 1.0f);
        }
    }
}