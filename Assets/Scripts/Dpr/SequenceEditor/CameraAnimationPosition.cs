using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.CameraAnimationPosition, "yellow", "one_frame", "PreloadCameraAnimation")]
    public class CameraAnimationPosition : Macro
	{
		public string camFile;
		public string anmFile;
		public Vector3 pos;
		public bool isFlip;
		
		public CameraAnimationPosition(Macro macro) : base(macro)
        {
            camFile = ParseString(macro.GetValue("camFile"));
            anmFile = ParseString(macro.GetValue("anmFile"));
            pos = ParseVector3(macro.GetValue("pos"));
            isFlip = ParseBool(macro.GetValue("isFlip"));
        }
	}
}