using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SubCameraAnimationSpecialPos, "yellow", "", "PreloadCameraAnimation")]
	public class SubCameraAnimationSpecialPos : Macro
	{
		public string camFile;
		public string anmFile;
		public SEQ_DEF_SPPOS posTrg;
		public Vector3 posOfs;
		public bool isFlip;
		public bool isRot;
		
		public SubCameraAnimationSpecialPos(Macro macro) : base(macro)
        {
            camFile = ParseString(macro.GetValue("camFile"));
            anmFile = ParseString(macro.GetValue("anmFile"));
            posTrg = Parse_SEQ_DEF_SPPOS(macro.GetValue("posTrg"));
            posOfs = ParseVector3(macro.GetValue("posOfs"));
            isFlip = ParseBool(macro.GetValue("isFlip"), 1);
            isRot = ParseBool(macro.GetValue("isRot"), 1);
        }
    }
}