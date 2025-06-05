using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SubCameraAnimationTrainer, "yellow", "one_frame", "PreloadCameraAnimationTrainer")]
	public class SubCameraAnimationTrainer : CameraAnimationTrainer
	{
		public SEQ_DEF_TR_CAM camType;
		public string camFile;
		public string anmFile;
		public SEQ_DEF_TRAINER trg;
		public string node;
		public Vector3 pos;
		public bool isFlip;
		public bool isRot;
		public bool forceUpdate;
		public bool isLoseCam;
		
		public SubCameraAnimationTrainer(Macro macro) : base(macro)
		{
            camType = Parse_SEQ_DEF_TR_CAM(macro.GetValue("camType"));
            camFile = ParseString(macro.GetValue("camFile"));
            anmFile = ParseString(macro.GetValue("anmFile"));
            trg = Parse_SEQ_DEF_TRAINER(macro.GetValue("trg"));
            node = ParseString(macro.GetValue("node"));
            pos = ParseVector3(macro.GetValue("pos"));
            isFlip = ParseBool(macro.GetValue("isFlip"), 0);
            isRot = ParseBool(macro.GetValue("isRot"), 0);
            forceUpdate = ParseBool(macro.GetValue("forceUpdate"), 0);
            isLoseCam = ParseBool(macro.GetValue("isLoseCam"), 0);
        }
	}
}