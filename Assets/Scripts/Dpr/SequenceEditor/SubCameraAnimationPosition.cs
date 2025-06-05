using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SubCameraAnimationPosition, "yellow", "one_frame", "PreloadCameraAnimation")]
	public class SubCameraAnimationPosition : Macro
	{
		public string camFile;
		public string anmFile;
		public Vector3 pos;
		public bool isFlip;
		
		public SubCameraAnimationPosition(Macro macro) : base(macro)
        {
            camFile = ParseString(macro.GetValue("camFile"));
            anmFile = ParseString(macro.GetValue("anmFile"));
            pos = ParseVector3(macro.GetValue("pos"));
            isFlip = ParseBool(macro.GetValue("isFlip"));
        }
    }
}